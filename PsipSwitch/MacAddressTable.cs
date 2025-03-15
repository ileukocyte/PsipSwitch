using System.ComponentModel;
using System.Threading;

using SharpPcap;

namespace PsipSwitch {
    public struct MacAddressTableEntry {
        public ILiveDevice Interface { get; set; }
        public double LifetimeSeconds { get; set; }
        public Timer Timer { get; set; }
    }

    public struct GuiMacAddressTableEntry {
        [DisplayName("MAC Address")]
        public string MacAddress { get; set; }

        public byte Interface { get; set; }

        [DisplayName("Lifetime (s)")]
        public double LifetimeSeconds { get; set; }
    }
}
 