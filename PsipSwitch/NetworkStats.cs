using System;
using System.Collections.Concurrent;

using PacketDotNet;
using SharpPcap;

namespace PsipSwitch {
    public enum Protocol {
        EthernetII,
        ARP,
        IPv4,
        IPv6,
        TCP,
        UDP,
        ICMPv4,
        HTTP,
        HTTPS,
    }

    public struct GuiProtocolStatsEntry {
        public string Protocol { get; set; }
        public long Count { get; set; }
    }

    public static class NetworkStats {
        public static string GetName(this Protocol protocol) => protocol switch {
            Protocol.EthernetII => "Ethernet II",
            Protocol.ARP => "ARP",
            Protocol.IPv4 => "IPv4",
            Protocol.IPv6 => "IPv6",
            Protocol.TCP => "TCP",
            Protocol.UDP => "UDP",
            Protocol.ICMPv4 => "ICMPv4",
            Protocol.HTTP => "HTTP",
            Protocol.HTTPS => "HTTPS",
            _ => throw new NotImplementedException(),
        };

        public static void UpdateStats(ConcurrentDictionary<Protocol, long> dict, RawCapture raw) {
            var packet = Packet.ParsePacket(raw.LinkLayerType, raw.Data);

            dict.AddOrUpdate(Protocol.EthernetII, 1, (_, v) => v + 1);

            var arp = packet.Extract<ArpPacket>();

            if (arp != null) {
                dict.AddOrUpdate(Protocol.ARP, 1, (_, v) => v + 1);
            }

            var ip = packet.Extract<IPPacket>();

            if (ip != null) {
                if (ip.Version == IPVersion.IPv4) {
                    dict.AddOrUpdate(Protocol.IPv4, 1, (_, v) => v + 1);
                } else {
                    dict.AddOrUpdate(Protocol.IPv6, 1, (_, v) => v + 1);
                }

                var tcp = packet.Extract<TcpPacket>();

                if (tcp != null) {
                    dict.AddOrUpdate(Protocol.TCP, 1, (_, v) => v + 1);

                    if (tcp.DestinationPort == 80 || tcp.SourcePort == 80) {
                        dict.AddOrUpdate(Protocol.HTTP, 1, (_, v) => v + 1);
                    } else if (tcp.DestinationPort == 443 || tcp.SourcePort == 443) {
                        dict.AddOrUpdate(Protocol.HTTPS, 1, (_, v) => v + 1);
                    }
                }

                var udp = packet.Extract<UdpPacket>();

                if (udp != null) {
                    dict.AddOrUpdate(Protocol.UDP, 1, (_, v) => v + 1);

                    // HTTP/3
                    if (udp.DestinationPort == 80 || udp.SourcePort == 80) {
                        dict.AddOrUpdate(Protocol.HTTP, 1, (_, v) => v + 1);
                    } else if (udp.DestinationPort == 443 || udp.SourcePort == 443) {
                        dict.AddOrUpdate(Protocol.HTTPS, 1, (_, v) => v + 1);
                    }
                }

                var icmp = packet.Extract<IcmpV4Packet>();

                if (icmp != null) {
                    dict.AddOrUpdate(Protocol.ICMPv4, 1, (_, v) => v + 1);
                }
            }
        }

        public static void Reset(ConcurrentDictionary<Protocol, long> dict) {
            dict[Protocol.EthernetII] = 0;
            dict[Protocol.ARP] = 0;
            dict[Protocol.IPv4] = 0;
            dict[Protocol.IPv6] = 0;
            dict[Protocol.TCP] = 0;
            dict[Protocol.UDP] = 0;
            dict[Protocol.ICMPv4] = 0;
            dict[Protocol.HTTP] = 0;
            dict[Protocol.HTTPS] = 0;
        }

        public static ConcurrentDictionary<Protocol, long> Create() {
            return new ConcurrentDictionary<Protocol, long> {
                [Protocol.EthernetII] = 0,
                [Protocol.ARP] = 0,
                [Protocol.IPv4] = 0,
                [Protocol.IPv6] = 0,
                [Protocol.TCP] = 0,
                [Protocol.UDP] = 0,
                [Protocol.ICMPv4] = 0,
                [Protocol.HTTP] = 0,
                [Protocol.HTTPS] = 0,
            };
        }
    }
}
