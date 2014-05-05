using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpProgram
{
    class Program
    {

        private const int LISTEN_PORT = 2010;
        private const int SEND_PORT = 2011;

        static int Main(string[] args)
        {
            ListenForUdpData();

            return 0;
        }

        public static void ListenForUdpData()
        {
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, LISTEN_PORT);
            UdpClient listenSocket = new UdpClient(LISTEN_PORT);
            UdpClient sendSocket = new UdpClient(SEND_PORT);
            
            try
            {
                while (true)
                {
                    byte[] udpData = listenSocket.Receive(ref clientEndPoint);
                    String clientAddress = clientEndPoint.Address.ToString();
                    String dataDecoded = Encoding.ASCII.GetString(udpData, 0, udpData.Length);
                    ProcessData(dataDecoded);
                }
            }
            catch (Exception e)
            {
                e.ToString();
                listenSocket.Close();
                sendSocket.Close();
            }
        }

        private static void ProcessData(String data)
        {
            // structure:
            // <udp_message type=3> </udp_message>
        }


    }
}
