using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsipSwitch {
    public struct ProtocolStat {
        public string Protocol { get; set; }
        public long Count { get; set; }
    }

    public class NetworkStats {
        public static void UpdateStats(Dictionary<string, long> dict, RawCapture raw) {
            var packet = Packet.ParsePacket(raw.LinkLayerType, raw.Data);

            if (dict.ContainsKey("Ethernet II")) {
                dict["Ethernet II"]++;
            } else {
                dict["Ethernet II"] = 1;
            }

            var arp = packet.Extract<ArpPacket>();

            if (arp != null) {
                if (dict.ContainsKey("ARP")) {
                    dict["ARP"]++;
                } else {
                    dict["ARP"] = 1;
                }
            }

            var ip = packet.Extract<IPv4Packet>();

            if (ip != null) {
                if (dict.ContainsKey("IPv4")) {
                    dict["IPv4"]++;
                } else {
                    dict["IPv4"] = 1;
                }

                var tcp = packet.Extract<TcpPacket>();

                if (tcp != null) {
                    if (dict.ContainsKey("TCP")) {
                        dict["TCP"]++;
                    } else {
                        dict["TCP"] = 1;
                    }

                    if (tcp.DestinationPort == 80) {
                        if (dict.ContainsKey("HTTP")) {
                            dict["HTTP"]++;
                        } else {
                            dict["HTTP"] = 1;
                        }
                    } else if (tcp.DestinationPort == 443) {
                        if (dict.ContainsKey("HTTPS")) {
                            dict["HTTPS"]++;
                        } else {
                            dict["HTTPS"] = 1;
                        }
                    }
                }

                var udp = packet.Extract<UdpPacket>();

                if (udp != null) {
                    if (dict.ContainsKey("UDP")) {
                        dict["UDP"]++;
                    } else {
                        dict["UDP"] = 1;
                    }

                    if (udp.DestinationPort == 80) {
                        if (dict.ContainsKey("HTTP")) {
                            dict["HTTP"]++;
                        } else {
                            dict["HTTP"] = 1;
                        }
                    } else if (udp.DestinationPort == 443) {
                        if (dict.ContainsKey("HTTPS")) {
                            dict["HTTPS"]++;
                        } else {
                            dict["HTTPS"] = 1;
                        }
                    }
                }

                var icmp = packet.Extract<IcmpV4Packet>();

                if (icmp != null) {
                    if (dict.ContainsKey("ICMP")) {
                        dict["ICMP"]++;
                    } else {
                        dict["ICMP"] = 1;
                    }
                }
            }
        }

        public static void Reset(Dictionary<string, long> dict) {
            dict["Ethernet II"] = 0;
            dict["ARP"] = 0;
            dict["IPv4"] = 0;
            dict["TCP"] = 0;
            dict["UDP"] = 0;
            dict["ICMP"] = 0;
            dict["HTTP"] = 0;
            dict["HTTPS"] = 0;
        }

        public static Dictionary<string, long> AsDictionary() {
            return new Dictionary<string, long> {
                { "Ethernet II", 0 },
                { "ARP", 0 },
                { "IPv4", 0 },
                { "TCP", 0 },
                { "UDP", 0 },
                { "ICMP", 0 },
                { "HTTP", 0 },
                { "HTTPS", 0 },
            };
        }
    }
}
