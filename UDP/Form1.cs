using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace UDP
{
    public partial class Form1 : Form
    {    
        IPAddress ipaddress;
        int remotePort;
        int localPort;
        ClientUdp clientudpsender;
        public Form1()
        {
            InitializeComponent();
            
            textBox1.Text = "127.0.0.1";
            ipaddress = IPAddress.Parse(textBox1.Text);
            textBox2.Text = "9877";
            remotePort = Int16.Parse(textBox2.Text);
            textBox3.Text = "9877";
            localPort = Int16.Parse(textBox3.Text);
            Thread thread = new Thread(new ThreadStart(receivemessage));
            thread.IsBackground = true;
            
            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientudpsender = new ClientUdp(ipaddress, remotePort);
        }
   
        private void printMessage(string message)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new Action<string>((s) => listBox1.Items.Add(s)), "<--" + "\n" + message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientudpsender.sendmessage(textBox4.Text);
            listBox1.Items.Add("--> " + DateTime.Now + ": " + textBox4.Text + "\n");
            textBox4.Clear(); 
        }

        public void receivemessage()
        {          
            UdpClient receivingUdpClient = new UdpClient(localPort);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);        
                printMessage(returnData.ToString());
            }
           
        }

    }
}
