using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace SocketClient
{
    class SocketClient
    {
        string addr;
        int port;
        byte[] data = new byte[1024];
       
        public SocketClient(string addr,int port) {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建客户端
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(addr), port);//服务器的IP和端口
            try
            {
                client.Connect(ie);//连接服务器
            }
            catch (SocketException e)
            {
                Console.WriteLine("unable to connect to server");
                Console.WriteLine(e.ToString());
                return;
            }
        }




    }
}
