using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

using PacketDotNet;
using SharpPcap;

namespace PsipSwitch {
    public enum SyslogSeverity {
        Emergency = 0,
        Alert = 1,
        Critical = 2,
        Error = 3,
        Warning = 4,
        Notice = 5,
        Informational = 6,
        Debug = 7,
    }

    public enum SyslogFacility {
        Kernel = 0,
        User = 1,
        Mail = 2,
        Daemon = 3,
        Auth = 4,
        Syslogd = 5,
        Printer = 6,
        News = 7,
        Uucp = 8,
        Cron = 9,
        Auth2 = 10,
        Ftp = 11,
        Ntp = 12,
        Audit = 13,
        Alert = 14,
        Clock = 15,
        Local0 = 16,
        Local1 = 17,
        Local2 = 18,
        Local3 = 19,
        Local4 = 20,
        Local5 = 21,
        Local6 = 22,
        Local7 = 23,
    }

    public static class Syslog {
        public static readonly string NilValue = "-";
        public static readonly byte Version = 1;
        public static readonly string AppName = "PsipSwitch";
        public static readonly char ByteOrderMark = '\uFEFF';
        public static readonly ushort SrcPort = 49152; // ephemeral port
        public static readonly ushort DstPort = 514;
        public static IPAddress ServerAddress = null;
        public static IPAddress ClientAddress = null;

        // RFC 3339
        public static string GetTimestamp() => DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        // RFC 5424
        public static string FormatMessage(
            string message,
            SyslogSeverity severity,
            SyslogFacility facility = SyslogFacility.Local0
        ) {
            var prival = ((int) facility << 3) | (int) severity;
            var timestamp = GetTimestamp();
            var hostname = ClientAddress;
            var procId = NilValue;
            var msgId = NilValue;
            var structuredData = NilValue;

            return $"<{prival}>{Version} {timestamp} {hostname} {AppName} {procId} {msgId} {structuredData} {ByteOrderMark}{message}";
        }

        public static void Log(
            string message,
            SyslogSeverity severity,
            ILiveDevice device1,
            ILiveDevice device2
        ) {
            if (device1 == null || device2 == null || ServerAddress == null || ClientAddress == null) {
                return;
            }

            try {
                var formattedMessage = FormatMessage(message, severity);
                var data = Encoding.UTF8.GetBytes(formattedMessage);

                var udpPacket = new UdpPacket(SrcPort, DstPort) {
                    PayloadData = data,
                };

                var ipPacket = new IPv4Packet(ClientAddress, ServerAddress) {
                    Protocol = ProtocolType.Udp,
                    PayloadPacket = udpPacket,
                };

                var ethernetPacket = new EthernetPacket(
                    device1.MacAddress,
                    PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"),
                    EthernetType.IPv4
                ) {
                    PayloadPacket = ipPacket,
                };

                device2.SendPacket(ethernetPacket);
            } catch (Exception) {
            }
        }
    }
}
