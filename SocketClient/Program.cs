using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketClient
{
    /// <summary>
    /// 信息发生时的编码方式和解析时的要对应起来
    /// </summary>
    class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
         public static byte[] data = new byte[1024];
            
          public static  string ipadd ="127.0.0.1";
          public static  int port = Convert.ToInt32("8870");
            
        static void Main(string[] args)
        {
           
           // ThreadPool.SetMaxThreads(10, 10);//设置线程池的最大值
            for (int i = 0; i < 1000; i++)
            {
               // ThreadPool.QueueUserWorkItem(new WaitCallback(startClient), i);
                Thread th = new Thread(startClient);
                th.Start();
            }
        }
        public static void startClient(object i)
        {
           // Console.WriteLine("第" + i + "个客户端");
            Socket newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd), port);//服务器的IP和端口
            try
            {
                //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的IP和端口。不需要监听。
                newclient.Connect(ie);
                Console.WriteLine("连接成功");
            }
            catch (SocketException e)
            {
                Console.WriteLine("unable to connect to server");
                Console.WriteLine(e.ToString());
                return;
            }
            //int recv = newclient.Receive(data);
            ////string stringdata = Encoding.ASCII.GetString(data, 0, recv);
            //string stringdata = Encoding.Unicode.GetString(data, 0, recv);
            ////Console.WriteLine(stringdata);
            DateTime dt = DateTime.Now;
            string time = dt.ToLongTimeString();
            Console.WriteLine(time.Replace(":", ""));
            string input = "SLC678833010109143|W80|V4.0{<U1#1><U3#" + time.Replace(":", "") + ".000,A,3616.22620,N,12016.42950,E,0.000,27.30,140815,,|10|100|100|090>}\r";
            Console.WriteLine(input);
            Console.WriteLine(newclient.LocalEndPoint.ToString());
            if (newclient.Connected)
            {
                //if (input == "exit")
                //    break;
                //Console.WriteLine(Encoding.Unicode.GetBytes(input).ToString());
                
                newclient.Send(Encoding.ASCII.GetBytes(input));//处理中文
               
                data = new byte[1024];
                int recv = newclient.Receive(data);
                string stringdata = Encoding.ASCII.GetString(data, 0, recv);
                //Console.WriteLine(stringdata);
                
                Thread.Sleep(30000);
            }
            
            input = Console.ReadLine();
            if (input == "exit")
            {
                Console.WriteLine("disconnect from sercer");
                newclient.Shutdown(SocketShutdown.Both);
                newclient.Close();
            }         
        }

    }
}
