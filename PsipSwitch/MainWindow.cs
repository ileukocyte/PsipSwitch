using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
using System.Net.NetworkInformation;
using System.Threading;
using System.Security.Cryptography;

namespace PsipSwitch {
    public partial class MainWindow : Form {
        private readonly Dictionary<string, long> in1 = NetworkStats.AsDictionary();
        private readonly Dictionary<string, long> in2 = NetworkStats.AsDictionary();
        private readonly Dictionary<string, long> out1 = NetworkStats.AsDictionary();
        private readonly Dictionary<string, long> out2 = NetworkStats.AsDictionary();

        private readonly BindingSource bindingSourceIn1 = [];
        private readonly BindingSource bindingSourceIn2 = [];
        private readonly BindingSource bindingSourceOut1 = [];
        private readonly BindingSource bindingSourceOut2 = [];

        private Boolean IsRunning { get; set; }

        private readonly CaptureDeviceList devices = CaptureDeviceList.Instance;

        private ILiveDevice Device1 { get; set; }
        private ILiveDevice Device2 { get; set; }

        private readonly object _balanceLock = new();

        public MainWindow() {
            InitializeComponent();
        }

        private async void MainWindow_Load(object sender, EventArgs e) {
            foreach (var dev in devices) {
                comboBox1.Items.Add(dev.Description);
                comboBox2.Items.Add(dev.Description);
            }

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSourceIn1;
            await Task.Run(() => RefreshGrid(in1, bindingSourceIn1));

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSourceOut1;
            await Task.Run(() => RefreshGrid(out1, bindingSourceOut1));

            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.DataSource = bindingSourceIn2;
            await Task.Run(() => RefreshGrid(in2, bindingSourceIn2));

            dataGridView4.AutoGenerateColumns = true;
            dataGridView4.DataSource = bindingSourceOut2;
            await Task.Run(() => RefreshGrid(out2, bindingSourceOut2));
        }

        private void RefreshGrid(Dictionary<string, long> stats, BindingSource bindingSource) {
            if (InvokeRequired) {
                Invoke(new Action<Dictionary<string, long>, BindingSource>(RefreshGrid), stats, bindingSource);
            } else {
                var list = stats.Select(kv => new ProtocolStat { Protocol = kv.Key, Count = kv.Value }).ToList();
                bindingSource.DataSource = new BindingList<ProtocolStat>(list);
            }
        }

        private void device1_OnPacketArrival(object sender, PacketCapture e) {
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            NetworkStats.UpdateStats(in1, rawPacket);
            RefreshGrid(in1, bindingSourceIn1);

            Device2.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out1, rawPacket);
            RefreshGrid(out1, bindingSourceOut1);
        }

        private void device2_OnPacketArrival(object sender, PacketCapture e) {
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            NetworkStats.UpdateStats(in2, rawPacket);
            RefreshGrid(in2, bindingSourceIn2);

            Device1.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out2, rawPacket);
            RefreshGrid(out2, bindingSourceOut2);
        }

        private void button1_Click(object sender, EventArgs e) {
            lock (_balanceLock) {
                if (IsRunning) {
                    button1.Text = "Start";
                    IsRunning = false;
                    CloseDevices();

                    return;
                }

                button1.Text = "Stop";

                NetworkStats.Reset(in1);
                RefreshGrid(in1, bindingSourceIn1);

                NetworkStats.Reset(in2);
                RefreshGrid(in2, bindingSourceIn2);

                NetworkStats.Reset(out1);
                RefreshGrid(out1, bindingSourceOut1);

                NetworkStats.Reset(out2);
                RefreshGrid(out2, bindingSourceOut2);

                IsRunning = true;
            }

            Device1 = devices[comboBox1.SelectedIndex];
            Device2 = devices[comboBox2.SelectedIndex];

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
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            CloseDevices();
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null) {
                button1.Enabled = true;

                return;
            }

            button1.Enabled = false;
        }
    }
}
