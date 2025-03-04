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
    public partial class Form1 : Form {
        private Dictionary<string, long> in1 = NetworkStats.AsDictionary();
        private Dictionary<string, long> in2 = NetworkStats.AsDictionary();
        private Dictionary<string, long> out1 = NetworkStats.AsDictionary();
        private Dictionary<string, long> out2 = NetworkStats.AsDictionary();

        private BindingSource bindingSourceIn1 = new();
        private BindingSource bindingSourceIn2 = new();
        private BindingSource bindingSourceOut1 = new();
        private BindingSource bindingSourceOut2 = new();

        private Boolean running = false;

        private readonly CaptureDeviceList devices = CaptureDeviceList.Instance;
        private readonly Dictionary<PhysicalAddress, (uint, ILiveDevice)> macAddresses = [];

        private ILiveDevice Device1 { get; set; }
        private ILiveDevice Device2 { get; set; }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            foreach (var dev in devices) {
                comboBox1.Items.Add(dev.Description);
                comboBox2.Items.Add(dev.Description);
            }

            dataGridView1.AutoGenerateColumns = true;
            bindingSourceIn1.DataSource = new BindingList<ProtocolStat>();
            dataGridView1.DataSource = bindingSourceIn1;

            dataGridView2.AutoGenerateColumns = true;
            bindingSourceOut1.DataSource = new BindingList<ProtocolStat>();
            dataGridView2.DataSource = bindingSourceOut1;

            dataGridView3.AutoGenerateColumns = true;
            bindingSourceIn2.DataSource = new BindingList<ProtocolStat>();
            dataGridView3.DataSource = bindingSourceIn2;

            dataGridView4.AutoGenerateColumns = true;
            bindingSourceOut2.DataSource = new BindingList<ProtocolStat>();
            dataGridView4.DataSource = bindingSourceOut2;

            /*comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;*/

            /*
             
            var devices = CaptureDeviceList.Instance;

            int i = 0;

            foreach (var dev in devices) {
                Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
                i++;
            }

            using var device = devices[4];

            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

            int readTimeoutMilliseconds = 1000;
            device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

            Console.WriteLine();
            Console.WriteLine("-- Listening on {0} {1}, hit 'Enter' to stop...", device.Name, device.Description);

            // Start the capturing process
            device.StartCapture();

            // Wait for 'Enter' from the user.
            Console.ReadLine();

            // Stop the capturing process
            device.StopCapture();

            Console.WriteLine("-- Capture stopped.");

            // Print out the device statistics
            Console.WriteLine(device.Statistics.ToString());
            */
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
            //var time = e.Header.Timeval.Date;
            //var len = e.Data.Length;
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            //var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            //var eth = packet.Extract<EthernetPacket>();

            //var dest = eth.DestinationHardwareAddress;
            //var src = eth.SourceHardwareAddress;

            /*if (macAddresses.ContainsKey(dest) && macAddresses[dest].Item1 == 1) {
                NetworkStats.UpdateStats(in1, rawPacket);

                RefreshGrid(in1, bindingSourceIn1);
            } else if (macAddresses.ContainsKey(src) && macAddresses[src].Item1 == 1) {
                NetworkStats.UpdateStats(out1, rawPacket);

                RefreshGrid(out1, bindingSourceOut1);
            }*/

            /*if (dest.Equals(PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"))) {
                foreach (var mac in macAddresses.Keys) {
                    macAddresses[mac].Item2.SendPacket(rawPacket.Data);
                }
            }*/

            /*if (dest.Equals(PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"))) {
                foreach (var mac in macAddresses.Keys) {
                    macAddresses[mac].Item2.SendPacket(rawPacket.Data);
                }
            } else if (macAddresses.ContainsKey(dest) && macAddresses[dest].Item1 == 2) {
                macAddresses[dest].Item2.SendPacket(rawPacket.Data);
            }*/

            NetworkStats.UpdateStats(in1, rawPacket);
            RefreshGrid(in1, bindingSourceIn1);

            Device2.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out1, rawPacket);
            RefreshGrid(out1, bindingSourceOut1);

            /*foreach (var (dev, mac) in macAddresses.Values) {
                if (dev == 2) {
                    mac.SendPacket(rawPacket.Data);
                    NetworkStats.UpdateStats(out1, rawPacket);
                    RefreshGrid(out1, bindingSourceOut1);
                }
            }*/

            /*Console.WriteLine("{0}:{1}:{2},{3} If=1, Len={4}",
            time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Console.WriteLine(rawPacket.ToString());*/
        }

        private void device2_OnPacketArrival(object sender, PacketCapture e) {
            //var time = e.Header.Timeval.Date;
            //var len = e.Data.Length;
            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType != LinkLayers.Ethernet) {
                return;
            }

            //var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            //var eth = packet.Extract<EthernetPacket>();

            //var dest = eth.DestinationHardwareAddress;
            //var src = eth.SourceHardwareAddress;

            NetworkStats.UpdateStats(in2, rawPacket);
            RefreshGrid(in2, bindingSourceIn2);

            Device1.SendPacket(rawPacket.Data);
            NetworkStats.UpdateStats(out2, rawPacket);
            RefreshGrid(out2, bindingSourceOut2);

            /*foreach (var (dev, mac) in macAddresses.Values) {
                if (dev == 1) {
                    mac.SendPacket(rawPacket.Data);
                    NetworkStats.UpdateStats(out2, rawPacket);
                    RefreshGrid(out2, bindingSourceOut2);
                }
            }*/

            /*if (macAddresses.ContainsKey(dest) && macAddresses[dest].Item1 == 2) {
                NetworkStats.UpdateStats(in2, rawPacket);

                RefreshGrid(in2, bindingSourceIn2);
            } else if (macAddresses.ContainsKey(src) && macAddresses[src].Item1 == 2) {
                NetworkStats.UpdateStats(out2, rawPacket);

                RefreshGrid(out2, bindingSourceOut2);
            }

            if (dest.Equals(PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"))) {
                foreach (var mac in macAddresses.Keys) {
                    macAddresses[mac].Item2.SendPacket(rawPacket.Data);
                }
            }*/

            /*foreach (var (dev, mac) in macAddresses.Values) {
                if (dev == 1) {
                    mac.SendPacket(rawPacket.Data);
                }
            }*/
            /*if (dest.Equals(PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"))) {
                foreach (var mac in macAddresses.Keys) {
                    macAddresses[mac].Item2.SendPacket(rawPacket.Data);
                }
            } else if (macAddresses.ContainsKey(dest) && macAddresses[dest].Item1 == 1) {
                macAddresses[dest].Item2.SendPacket(rawPacket.Data);
            }*/

            /*Console.WriteLine("{0}:{1}:{2},{3} If=2, Len={4}",
            time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Console.WriteLine(rawPacket.ToString());*/
        }

        private void button1_Click(object sender, EventArgs e) {
            lock (this) {
                if (running) {
                    running = false;

                    foreach (var (_, device) in macAddresses.Values) {
                        if (device.Started) {
                            device.StopCapture();
                            device.Close();
                        }
                    }

                    return;
                }

                running = true;
            }

            Device1 = devices[comboBox1.SelectedIndex];
            Device2 = devices[comboBox2.SelectedIndex];

            macAddresses[Device1.MacAddress] = (1, Device1);
            macAddresses[Device2.MacAddress] = (2, Device2);

            Device1.OnPacketArrival += new PacketArrivalEventHandler(device1_OnPacketArrival);
            Device2.OnPacketArrival += new PacketArrivalEventHandler(device2_OnPacketArrival);

            Device1.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal, 5000);
            Device2.Open(DeviceModes.Promiscuous | DeviceModes.NoCaptureLocal, 5000);

            Device1.StartCapture();
            Device2.StartCapture();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (var (_, device) in macAddresses.Values) {
                if (device.Started) {
                    device.StopCapture();
                    device.Close();
                }
            }
        }
    }
}
