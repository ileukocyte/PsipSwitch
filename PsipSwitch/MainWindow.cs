using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;
using System.Security.Cryptography;
using System.Collections.Concurrent;

using PacketDotNet;
using SharpPcap;

namespace PsipSwitch {
    public partial class MainWindow : Form {
        private const short DeviceTimeoutSeconds = 15;

        private static readonly PhysicalAddress BroadcastMac = PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF");

        private readonly object _lock = new();

        private readonly ConcurrentDictionary<Protocol, long> in1 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> in2 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> out1 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> out2 = NetworkStats.Create();

        private readonly ConcurrentDictionary<PhysicalAddress, MacAddressTableEntry> macAddressTable = new();

        private readonly BindingSource bindingSourceIn1 = [];
        private readonly BindingSource bindingSourceIn2 = [];
        private readonly BindingSource bindingSourceOut1 = [];
        private readonly BindingSource bindingSourceOut2 = [];

        private readonly BindingSource bindingSourceMac = [];

        private readonly CaptureDeviceList devices = CaptureDeviceList.Instance;

        private ILiveDevice Device1 { get; set; }
        private ILiveDevice Device2 { get; set; }

        private readonly ConcurrentDictionary<ILiveDevice, System.Threading.Timer> deviceTimers = [];

        private bool IsRunning { get; set; }
        private bool SyslogEnabled { get; set; }

        public MainWindow() {
            InitializeComponent();
        }

        private async void MainWindow_Load(object sender, EventArgs e) {
            foreach (var dev in devices) {
                comboBoxDevice1.Items.Add(dev.Description);
                comboBoxDevice2.Items.Add(dev.Description);
            }

            dataGridViewIn1.AutoGenerateColumns = true;
            dataGridViewIn1.DataSource = bindingSourceIn1;
            await Task.Run(() => RefreshProtocolGrid(in1, bindingSourceIn1));

            dataGridViewOut1.AutoGenerateColumns = true;
            dataGridViewOut1.DataSource = bindingSourceOut1;
            await Task.Run(() => RefreshProtocolGrid(out1, bindingSourceOut1));

            dataGridViewIn2.AutoGenerateColumns = true;
            dataGridViewIn2.DataSource = bindingSourceIn2;
            await Task.Run(() => RefreshProtocolGrid(in2, bindingSourceIn2));

            dataGridViewOut2.AutoGenerateColumns = true;
            dataGridViewOut2.DataSource = bindingSourceOut2;
            await Task.Run(() => RefreshProtocolGrid(out2, bindingSourceOut2));

            dataGridViewMac.AutoGenerateColumns = true;
            dataGridViewMac.DataSource = bindingSourceMac;
            await Task.Run(() => RefreshMacGrid(macAddressTable, bindingSourceMac));
        }

        private void RefreshProtocolGrid(ConcurrentDictionary<Protocol, long> stats, BindingSource bindingSource) {
            if (InvokeRequired) {
                Invoke(new Action<ConcurrentDictionary<Protocol, long>, BindingSource>(RefreshProtocolGrid), stats, bindingSource);
            } else {
                var list = stats.Select(kv => new GuiProtocolStat {
                    Protocol = kv.Key.GetName(),
                    Count = kv.Value
                }).ToList();

                bindingSource.DataSource = new BindingList<GuiProtocolStat>(list);
            }
        }

        private void RefreshMacGrid(
            ConcurrentDictionary<PhysicalAddress, MacAddressTableEntry> macTable,
            BindingSource bindingSource
        ) {
            if (InvokeRequired) {
                Invoke(
                    new Action<ConcurrentDictionary<PhysicalAddress, MacAddressTableEntry>, BindingSource>(RefreshMacGrid),
                    macTable,
                    bindingSource
                );
            } else {
                var list = macTable.Select(kv => new GuiMacAddressTableRecord {
                    MacAddress = FormatMacAddress(kv.Key),
                    Port = (byte) (kv.Value.Port.MacAddress == Device1.MacAddress ? 1 : 2),
                    LifetimeSeconds = kv.Value.LifetimeSeconds,
                }).ToList();

                bindingSource.DataSource = new BindingList<GuiMacAddressTableRecord>(list);
            }
        }

        private void switchDevice_OnPacketArrival(object sender, PacketCapture e) {
            var device = (ILiveDevice) sender;

            deviceTimers[device].Change(TimeSpan.FromSeconds(DeviceTimeoutSeconds), Timeout.InfiniteTimeSpan);

            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            if (device.MacAddress == Device1.MacAddress) {
                NetworkStats.UpdateStats(in1, rawPacket);
                RefreshProtocolGrid(in1, bindingSourceIn1);
            } else {
                NetworkStats.UpdateStats(in2, rawPacket);
                RefreshProtocolGrid(in2, bindingSourceIn2);
            }

            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data).Extract<EthernetPacket>();
            var sourceMac = packet.SourceHardwareAddress;
            var destMac = packet.DestinationHardwareAddress;

            var timeout = (double) numericUpDownTimeout.Value;
            System.Threading.Timer timer = null;

            if (macAddressTable.ContainsKey(sourceMac)) {
                var entry = macAddressTable[sourceMac];

                // cable swap
                lock (_lock) {
                    var guiData = (BindingList<GuiMacAddressTableRecord>) bindingSourceMac.DataSource;
                    var record = guiData.First(r => r.MacAddress == FormatMacAddress(sourceMac));
                    var port = (byte) (device.MacAddress == Device1.MacAddress ? 1 : 2);

                    if (port != record.Port) {
                        (Device2, Device1) = (Device1, Device2);
                    }
                }

                timeout = entry.LifetimeSeconds;
                timer = entry.Timer;
                timer.Change(TimeSpan.FromSeconds(timeout), Timeout.InfiniteTimeSpan);
            } else {
                timer = new System.Threading.Timer(new TimerCallback((state) => {
                    var mac = (PhysicalAddress) state;
                    macAddressTable.TryRemove(mac, out _);
                    RefreshMacGrid(macAddressTable, bindingSourceMac);
                }), sourceMac, TimeSpan.FromSeconds(timeout), Timeout.InfiniteTimeSpan);
            }

            macAddressTable.AddOrUpdate(
                sourceMac,
                new MacAddressTableEntry {
                    Port = device,
                    LifetimeSeconds = timeout,
                    Timer = timer
                },
                (_, _) => new MacAddressTableEntry {
                    Port = device,
                    LifetimeSeconds = timeout,
                    Timer = timer
                }
            );

            RefreshMacGrid(macAddressTable, bindingSourceMac);

            var srcRecord = macAddressTable[sourceMac];

            if (destMac.Equals(BroadcastMac) || !macAddressTable.ContainsKey(destMac)) {
                if (srcRecord.Port.MacAddress == Device1.MacAddress) {
                    try {
                        Device2.SendPacket(rawPacket.Data);
                        NetworkStats.UpdateStats(out1, rawPacket);
                        RefreshProtocolGrid(out1, bindingSourceOut1);
                    } catch (Exception) {
                    }
                } else {
                    try {
                        Device1.SendPacket(rawPacket.Data);
                        NetworkStats.UpdateStats(out2, rawPacket);
                        RefreshProtocolGrid(out2, bindingSourceOut2);
                    } catch (Exception) {
                    }
                }

                return;
            }

            var destRecord = macAddressTable[destMac];

            if (destRecord.Port.MacAddress == srcRecord.Port.MacAddress) {
                return;
            }

            if (destRecord.Port.MacAddress == Device1.MacAddress) {
                try {
                    Device1.SendPacket(rawPacket.Data);
                    NetworkStats.UpdateStats(out2, rawPacket);
                    RefreshProtocolGrid(out2, bindingSourceOut2);
                } catch (Exception) {
                }
            } else {
                try {
                    Device2.SendPacket(rawPacket.Data);
                    NetworkStats.UpdateStats(out1, rawPacket);
                    RefreshProtocolGrid(out1, bindingSourceOut1);
                } catch (Exception) {
                }
            }
        }

        private void toggleButton_Click(object sender, EventArgs e) {
            lock (_lock) {
                if (IsRunning) {
                    toggleButton.Text = "Start";
                    refreshButton.Enabled = true;
                    comboBoxDevice1.Enabled = comboBoxDevice2.Enabled = true;

                    IsRunning = false;

                    CloseDevices();

                    return;
                }

                toggleButton.Text = "Stop";
                refreshButton.Enabled = false;
                comboBoxDevice1.Enabled = comboBoxDevice2.Enabled = false;

                ResetStats();
                RefreshMacGrid(macAddressTable, bindingSourceMac);

                IsRunning = true;
            }

            Device1 = devices[comboBoxDevice1.SelectedIndex];
            Device2 = devices[comboBoxDevice2.SelectedIndex];

            Device1.OnPacketArrival += new PacketArrivalEventHandler(switchDevice_OnPacketArrival);
            Device2.OnPacketArrival += new PacketArrivalEventHandler(switchDevice_OnPacketArrival);

            Device1.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal | DeviceModes.MaxResponsiveness, 1000);
            Device2.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal | DeviceModes.MaxResponsiveness, 1000);

            Device1.StartCapture();
            Device2.StartCapture();

            var callback = new TimerCallback((state) => {
                lock (_lock) {
                    if (IsRunning) {
                        toggleButton_Click(sender, e);
                    }
                }
            });

            deviceTimers[Device1] = new System.Threading.Timer(
                callback,
                Device1,
                TimeSpan.FromSeconds(DeviceTimeoutSeconds),
                Timeout.InfiniteTimeSpan
            );

            deviceTimers[Device2] = new System.Threading.Timer(
                callback,
                Device2,
                TimeSpan.FromSeconds(DeviceTimeoutSeconds),
                Timeout.InfiniteTimeSpan
            );
        }

        private void CloseDevices() {
            Parallel.ForEach(macAddressTable, kv => kv.Value.Timer.Dispose());
            Parallel.ForEach(deviceTimers, kv => kv.Value.Dispose());

            if (Device1 != null && Device1.Started) {
                Device1.StopCapture();
                Device1.Close();
            }

            if (Device2 != null && Device2.Started) {
                Device2.StopCapture();
                Device2.Close();
            }

            Device1 = null;
            Device2 = null;

            macAddressTable.Clear();
            deviceTimers.Clear();
        }

        private void ResetStats(bool resetDevice1 = true, bool resetDevice2 = true) {
            if (resetDevice1) {
                NetworkStats.Reset(in1);
                RefreshProtocolGrid(in1, bindingSourceIn1);

                NetworkStats.Reset(out1);
                RefreshProtocolGrid(out1, bindingSourceOut1);
            }

            if (resetDevice2) {
                NetworkStats.Reset(in2);
                RefreshProtocolGrid(in2, bindingSourceIn2);

                NetworkStats.Reset(out2);
                RefreshProtocolGrid(out2, bindingSourceOut2);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            CloseDevices();
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            if (comboBoxDevice1.SelectedItem != null && comboBoxDevice2.SelectedItem != null) {
                toggleButton.Enabled = true;

                lock (_lock) {
                    if (IsRunning &&
                        (Device1 != devices[comboBoxDevice1.SelectedIndex] || Device2 != devices[comboBoxDevice2.SelectedIndex])
                    ) {
                        IsRunning = false;
                        CloseDevices();
                        ResetStats();
                        toggleButton_Click(sender, e);
                    }
                }

                return;
            }

            toggleButton.Enabled = false;
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            devices.Refresh();

            comboBoxDevice1.Items.Clear();
            comboBoxDevice2.Items.Clear();

            comboBoxDevice1.ResetText();
            comboBoxDevice2.ResetText();

            foreach (var dev in devices) {
                comboBoxDevice1.Items.Add(dev.Description);
                comboBoxDevice2.Items.Add(dev.Description);
            }

            ResetStats();
            RefreshMacGrid(macAddressTable, bindingSourceMac);

            toggleButton.Enabled = false;
        }

        public static string FormatMacAddress(PhysicalAddress mac) {
            return string.Join("-", mac.GetAddressBytes().Select(b => b.ToString("X2")));
        }

        private void clearMacTableButton_Click(object sender, EventArgs e) {
            Parallel.ForEach(macAddressTable, kv => kv.Value.Timer.Dispose());
            macAddressTable.Clear();
            RefreshMacGrid(macAddressTable, bindingSourceMac);
        }

        private void numericUpDownTimeout_ValueChanged(object sender, EventArgs e) {
            if (!IsRunning) {
                return;
            }

            var value = (double) numericUpDownTimeout.Value;
            Parallel.ForEach(macAddressTable, kv => {
                var entry = kv.Value;

                entry.LifetimeSeconds = value;
                entry.Timer.Change(TimeSpan.FromSeconds(value), Timeout.InfiniteTimeSpan);

                macAddressTable[kv.Key] = entry;
            });
        }

        private void ifStatsResetButton_Click(object sender, EventArgs e) {
            if (sender == ifStatsResetButton1) {
                ResetStats(resetDevice2: false);

                return;
            }

            ResetStats(resetDevice1: false);
        }

        private void syslogToggleButton_Click(object sender, EventArgs e) {
            srcAddrTextBox.Enabled = !srcAddrTextBox.Enabled;
            dstAddrTextBox.Enabled = !dstAddrTextBox.Enabled;
            SyslogEnabled = !SyslogEnabled;

            if (SyslogEnabled) {
                syslogToggleButton.Text = "Stop";
            } else {
                syslogToggleButton.Text = "Start";
            }
        }
    }
}
