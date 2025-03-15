using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PsipSwitch {
    public enum AccessControlListAction {
        Permit,
        Deny,
    }

    public enum AccessControlListProtocol {
        Any,
        ICMP,
        TCP,
        UDP,
    }

    public enum AccessControlListDirection {
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

    public struct AccessControlListRule {
        public AccessControlListAction Action { get; set; }
        public AccessControlListProtocol Protocol { get; set; }
        public PhysicalAddress SourceMacAddress { get; set; }
        public PhysicalAddress DestinationMacAddress { get; set; }
        public IPAddress SourceIpV4Address { get; set; }
        public IPAddress DestinationIpV4Address { get; set; }
        public ushort SourcePort { get; set; }
        public ushort DestinationPort { get; set; }
        public AccessControlListDirection Direction { get; set; }
        public byte Interface { get; set; }
        public ICMPType ICMPType { get; set; }

        public static bool AnalyzePacket(
            PacketCapture capture,
            byte interfaceIndex,
            List<AccessControlListRule> aclTable
        ) {
            var rawPacket = capture.GetPacket();
            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            foreach (var rule in aclTable) {
                // TODO
            }

            return true;
        }
    }

    public struct GuiAclRule {
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

        public static GuiAclRule FromAccessControlListRule(AccessControlListRule rule) {
            return new GuiAclRule {
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
