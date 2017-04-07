using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDP
{
    class ReceiverClientUdp
    {
        private UdpClient receivingUdpClient = new UdpClient();
        private IPEndPoint remoteIpEndPoint = null;

        public void receivemessage()
        {
            byte[] receiveBytes = receivingUdpClient.Receive(
                  ref remoteIpEndPoint);

            string returnData = Encoding.UTF8.GetString(receiveBytes);
        }
    }
}
