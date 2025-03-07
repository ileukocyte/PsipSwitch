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
        private readonly object _lock = new();

        private readonly ConcurrentDictionary<Protocol, long> in1 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> in2 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> out1 = NetworkStats.Create();
        private readonly ConcurrentDictionary<Protocol, long> out2 = NetworkStats.Create();

        private readonly BindingSource bindingSourceIn1 = [];
        private readonly BindingSource bindingSourceIn2 = [];
        private readonly BindingSource bindingSourceOut1 = [];
        private readonly BindingSource bindingSourceOut2 = [];

        private CaptureDeviceList devices = CaptureDeviceList.Instance;

        private ILiveDevice Device1 { get; set; }
        private ILiveDevice Device2 { get; set; }

        private Boolean IsRunning { get; set; }

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
        }

        private void RefreshProtocolGrid(ConcurrentDictionary<Protocol, long> stats, BindingSource bindingSource) {
            if (InvokeRequired) {
                Invoke(new Action<ConcurrentDictionary<Protocol, long>, BindingSource>(RefreshProtocolGrid), stats, bindingSource);
            } else {
                var list = stats.Select(kv => new ProtocolStat { Protocol = kv.Key.GetName(), Count = kv.Value }).ToList();
                bindingSource.DataSource = new BindingList<ProtocolStat>(list);
            }
        }

        private void device1_OnPacketArrival(object sender, PacketCapture e) {
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            NetworkStats.UpdateStats(in1, rawPacket);
            RefreshProtocolGrid(in1, bindingSourceIn1);

            Device2.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out1, rawPacket);
            RefreshProtocolGrid(out1, bindingSourceOut1);
        }

        private void device2_OnPacketArrival(object sender, PacketCapture e) {
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            NetworkStats.UpdateStats(in2, rawPacket);
            RefreshProtocolGrid(in2, bindingSourceIn2);

            Device1.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out2, rawPacket);
            RefreshProtocolGrid(out2, bindingSourceOut2);
        }

        private void toggleButton_Click(object sender, EventArgs e) {
            lock (_lock) {
                if (IsRunning) {
                    toggleButton.Text = "Start";
                    refreshButton.Enabled = true;

                    IsRunning = false;

                    CloseDevices();

                    return;
                }

                toggleButton.Text = "Stop";
                refreshButton.Enabled = false;

                ResetStats();

                IsRunning = true;
            }

            Device1 = devices[comboBoxDevice1.SelectedIndex];
            Device2 = devices[comboBoxDevice2.SelectedIndex];

            Device1.OnPacketArrival += new PacketArrivalEventHandler(device1_OnPacketArrival);
            Device2.OnPacketArrival += new PacketArrivalEventHandler(device2_OnPacketArrival);

            Device1.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal | DeviceModes.MaxResponsiveness, 1000);
            Device2.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal | DeviceModes.MaxResponsiveness, 1000);

            Device1.StartCapture();
            Device2.StartCapture();
        }

        private void CloseDevices() {
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
        }

        private void ResetStats() {
            NetworkStats.Reset(in1);
            RefreshProtocolGrid(in1, bindingSourceIn1);

            NetworkStats.Reset(in2);
            RefreshProtocolGrid(in2, bindingSourceIn2);

            NetworkStats.Reset(out1);
            RefreshProtocolGrid(out1, bindingSourceOut1);

            NetworkStats.Reset(out2);
            RefreshProtocolGrid(out2, bindingSourceOut2);
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

            toggleButton.Enabled = false;
        }
    }
}
