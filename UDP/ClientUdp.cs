using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDP
{
    class ClientUdp
    {
        private UdpClient udpclient; 
        private IPEndPoint endpoint;
        public ClientUdp(IPAddress remoteIPAdress, int port)
        {
            this.udpclient = new UdpClient();
            this.endpoint = new IPEndPoint(remoteIPAdress, port);
        }


        public ClientUdp(int port)
        {
            this.udpclient = new UdpClient(port);
            this.endpoint = null;
        }


        public void sendmessage(String datagram)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(datagram);
            udpclient.Send(bytes, bytes.Length, endpoint);
            Console.WriteLine("Send from "+ endpoint.Address.ToString() + " " + datagram);
        }


    }
}
