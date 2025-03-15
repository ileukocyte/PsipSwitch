using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

using PacketDotNet;
using SharpPcap;

namespace PsipSwitch {
    public enum AccessControlEntryAction {
        Permit,
        Deny,
    }

    public enum AccessControlEntryProtocol {
        Any,
        ICMP,
        TCP,
        UDP,
    }

    public enum AccessControlEntryDirection {
        Inbound,
        Outbound,
    }

    // source: https://www.iana.org/assignments/icmp-parameters/icmp-parameters.xhtml
    public enum ICMPType : byte {
        Any = byte.MaxValue,
        EchoReply = 0,
        DestinationUnreachable = 3,
        SourceQuench = 4,
        Redirect = 5,
        EchoRequest = 8,
        RouterAdvertisement = 9,
        RouterSolicitation = 10,
        TimeExceeded = 11,
        ParameterProblem = 12,
        Timestamp = 13,
        TimestampReply = 14,
        ExtendedEchoRequest = 42,
        ExtendedEchoReply = 43,
    }

    public struct AccessControlEntry {
        public AccessControlEntryAction Action { get; set; }
        public AccessControlEntryProtocol Protocol { get; set; }
        public PhysicalAddress SourceMacAddress { get; set; }
        public PhysicalAddress DestinationMacAddress { get; set; }
        public IPAddress SourceIpV4Address { get; set; }
        public IPAddress DestinationIpV4Address { get; set; }
        public ushort SourcePort { get; set; }
        public ushort DestinationPort { get; set; }
        public AccessControlEntryDirection Direction { get; set; }
        public byte Interface { get; set; }
        public ICMPType ICMPType { get; set; }

        public static (bool, AccessControlEntryDirection) AnalyzePacket(
            RawCapture rawPacket,
            byte interfaceIndex,
            List<AccessControlEntry> aclTable
        ) {
            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            foreach (var rule in aclTable) {
                var ethPacket = packet.Extract<EthernetPacket>();
                var ipPacket = packet.Extract<IPv4Packet>();
                var tcpPacket = packet.Extract<TcpPacket>();
                var udpPacket = packet.Extract<UdpPacket>();
                var icmpPacket = packet.Extract<IcmpV4Packet>();

                var interfaceMatch = rule.Interface == interfaceIndex;
                var protocolMatch = rule.Protocol switch {
                    AccessControlEntryProtocol.TCP => tcpPacket != null,
                    AccessControlEntryProtocol.UDP => udpPacket != null,
                    AccessControlEntryProtocol.ICMP => icmpPacket != null,
                    _ => true,
                };
                var srcMacMatch = rule.SourceMacAddress == null
                    || rule.SourceMacAddress.Equals(ethPacket.SourceHardwareAddress);
                var dstMacMatch = rule.DestinationMacAddress == null
                    || rule.DestinationMacAddress.Equals(ethPacket.DestinationHardwareAddress);
                var srcIpMatch = rule.SourceIpV4Address == null
                    || (ipPacket != null && ipPacket.SourceAddress.Equals(rule.SourceIpV4Address));
                var dstIpMatch = rule.DestinationIpV4Address == null
                    || (ipPacket != null && ipPacket.DestinationAddress.Equals(rule.DestinationIpV4Address));
                var srcPortMatch = rule.SourcePort == 0
                    || (tcpPacket != null && tcpPacket.SourcePort == rule.SourcePort)
                    || (udpPacket != null && udpPacket.SourcePort == rule.SourcePort);
                var dstPortMatch = rule.DestinationPort == 0
                    || (tcpPacket != null && tcpPacket.DestinationPort == rule.DestinationPort)
                    || (udpPacket != null && udpPacket.DestinationPort == rule.DestinationPort);
                var icmpMatch = icmpPacket != null
                    && (rule.ICMPType == ICMPType.Any || (byte) rule.ICMPType == icmpPacket.HeaderData[0]);

                var match = interfaceMatch && protocolMatch
                    && srcMacMatch && dstMacMatch
                    && srcIpMatch && dstIpMatch
                    && (
                        rule.Protocol == AccessControlEntryProtocol.Any
                        || ((rule.Protocol == AccessControlEntryProtocol.TCP || rule.Protocol == AccessControlEntryProtocol.UDP) && srcPortMatch && dstPortMatch)
                        || (rule.Protocol == AccessControlEntryProtocol.ICMP && icmpMatch)
                    );

                if (match) {
                    return (rule.Action == AccessControlEntryAction.Permit, rule.Direction);
                }
            }

            return (true, AccessControlEntryDirection.Outbound);
        }
    }

    public struct GuiAccessControlEntry {
        public string Action { get; set; }
        public string Direction { get; set; }
        public byte Interface { get; set; }
        public string Protocol { get; set; }
        [DisplayName("Source MAC")]
        public string SourceMacAddress { get; set; }
        [DisplayName("Destination MAC")]
        public string DestinationMacAddress { get; set; }
        [DisplayName("Source IPv4")]
        public string SourceIpV4Address { get; set; }
        [DisplayName("Destination IPv4")]
        public string DestinationIpV4Address { get; set; }
        [DisplayName("Source Port")]
        public string SourcePort { get; set; }
        [DisplayName("Destination Port")]
        public string DestinationPort { get; set; }
        [DisplayName("ICMP Type")]
        public string ICMPType { get; set; }

        public static GuiAccessControlEntry FromAccessControlEntry(AccessControlEntry rule) {
            return new GuiAccessControlEntry {
                Action = rule.Action.ToString(),
                Protocol = rule.Protocol.ToString(),
                SourceMacAddress = rule.SourceMacAddress == null ? "Any" : MainWindow.FormatMacAddress(rule.SourceMacAddress),
                DestinationMacAddress = rule.DestinationMacAddress == null ? "Any" : MainWindow.FormatMacAddress(rule.DestinationMacAddress),
                SourceIpV4Address = rule.SourceIpV4Address?.ToString() ?? "Any",
                DestinationIpV4Address = rule.DestinationIpV4Address?.ToString() ?? "Any",
                SourcePort = rule.SourcePort == 0 ? "Any" : rule.SourcePort.ToString(),
                DestinationPort = rule.DestinationPort == 0 ? "Any" : rule.DestinationPort.ToString(),
                Direction = rule.Direction.ToString(),
                Interface = rule.Interface,
                ICMPType = Regex.Replace(rule.ICMPType.ToString(), "([a-z])([A-Z])", "$1 $2"),
            };
        }
    }
}
