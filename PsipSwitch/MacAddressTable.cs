using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PsipSwitch {
    public struct MacAdressTableRecord {
        //public string MacAdress { get; set; }
        //public string Port { get; set; }
        public PhysicalAddress MacAdress { get; set; }
        public ILiveDevice Port { get; set; }
        public int LifetimeSeconds { get; set; }
    }
}
