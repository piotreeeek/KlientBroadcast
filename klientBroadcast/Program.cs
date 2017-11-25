using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace klientBroadcast
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();

            udpClient.ExclusiveAddressUse = false;
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 2222);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.ExclusiveAddressUse = false;

            udpClient.Client.Bind(localEp);

            IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
            string reciveMessage;
            do
            {
                byte[] reciveByte = udpClient.Receive(ref remoteEp);
                reciveMessage = Encoding.UTF8.GetString(reciveByte);
                Console.WriteLine("Odebrano: " + reciveMessage);
            } while (reciveMessage != String.Empty);
            udpClient.Close();
        }
    }
}
