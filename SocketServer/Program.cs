using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace SocketServer
{
    class Program
    {
        /// <summary>
        /// 程序主入口
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            NewTaskDelegate task = newTask;
            IAsyncResult asyncResult = task.BeginInvoke(2000, null, null);
            int result = task.EndInvoke(asyncResult);
            Console.WriteLine(result);
            Thread.Sleep(10000);
            Console.WriteLine("2343");
            Console.WriteLine(int.Parse("2343"));
            Console.WriteLine("this is server");
            int recv;//接收的信息长度
            byte[] data = new byte[1024];//接收的数据
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newSocket.Bind(ipep);
            newSocket.Listen(10);
            Console.WriteLine("waiting for a client..");
            string welcomeString = "welcome here!";
            Socket client = newSocket.Accept();
            IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("connect with client:" + clientip.Address + " at port:" + clientip.Port);
            //data = Encoding.ASCII.GetBytes(welcomeString);
            data = Encoding.Unicode.GetBytes(welcomeString);
            client.Send(data, data.Length, SocketFlags.None);
            while (true)
            {
                data = new byte[1024];
                recv = client.Receive(data);
                Console.WriteLine("recv " + recv);
                if (recv == 0)
                {
                    break;
                }

                Console.WriteLine(Encoding.Unicode.GetString(data, 0, recv));
                string s = Encoding.Unicode.GetString(data, 0, recv)+"----来自于服务器";
                data = Encoding.Unicode.GetBytes(s);
                client.Send(data, recv, SocketFlags.None);

            }

            Console.WriteLine("Disconnected from " + clientip.Address);
            client.Close();
            newSocket.Close();
        }
        private static int newTask(int ms)
        {
            Console.WriteLine("task begin");
            Thread.Sleep(ms);
            Random random = new Random();
            int n = random.Next(1000);
            Console.WriteLine("task end");
            return n;
        }

        private delegate int NewTaskDelegate(int ms);
        

    }
}
