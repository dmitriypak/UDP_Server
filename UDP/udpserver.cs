using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDP
{
    class Udpserver
    {
        private IPAddress remoteIPAddress;
        private int remotePort;
        private int localPort;
        public Udpserver(IPAddress ipaddress,int remotePort, int localPort)
        {
            this.remoteIPAddress = ipaddress;
            this.remotePort = remotePort;
            this.localPort = localPort;
        }

        
    }
}
