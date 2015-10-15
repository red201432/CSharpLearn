using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace ConsoleSocket
{
    /// <summary>
    /// Tcp客户端
    /// </summary>
    class TcpClient
    {
        private Position position = new Position();
        
        private static string HOST_NAME = "219.146.70.115";
        private static int HOST_PORT = 8870;
        private object threadLock = new object();

        private List<Position> positions = new List<Position>();
        public List<Position> Positions { get; set; }

        /// <summary>
        /// 启动连接
        /// </summary>
        public void start()
        {
            lock (threadLock)
            {
                socketSend(HOST_NAME, HOST_PORT, "sendStr");
            }
        }
        /// <summary>
        /// 返回一个Socket连接
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public Socket connectSocket(string server,int port)
        {
            IPAddress address = IPAddress.Parse(server);
            IPEndPoint ipe = new IPEndPoint(address, port);
            Socket tempSocket = new Socket(ipe.AddressFamily,SocketType.Stream,ProtocolType.Tcp);
            try
            {
                tempSocket.Connect(ipe);
            }
            catch { 
                
            }
            return tempSocket;
        }
        /// <summary>
        /// 发送与接收数据
        /// </summary>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="str"></param>
        public void socketSend(string server,int port,string str) {
            Socket s = connectSocket(server, port);
            try
            {
                Byte[] bytesSend = Encoding.ASCII.GetBytes(str);
                s.Send(bytesSend);
                Byte[] recevBytes = new Byte[1024];
                String recevStr = Encoding.ASCII.GetString(recevBytes, 0, s.Receive(recevBytes, 1024, 0));
            }
            catch { }
            finally {
            s.Shutdown(SocketShutdown.Both);
            s.Dispose();
            s.Close();
            }

        }



    }
}
