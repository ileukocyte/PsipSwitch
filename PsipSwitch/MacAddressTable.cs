using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SharpPcap;

namespace PsipSwitch {
    public struct MacAddressTableEntry {
        public ILiveDevice Port { get; set; }
        public double LifetimeSeconds { get; set; }
        public Timer Timer { get; set; }
    }

    public struct GuiMacAddressTableRecord {
        [DisplayName("MAC Address")]
        public string MacAddress { get; set; }

        public byte Port { get; set; }

        [DisplayName("Lifetime (s)")]
        public double LifetimeSeconds { get; set; }
    }
}
 