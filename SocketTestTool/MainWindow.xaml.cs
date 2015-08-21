using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SocketTestTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static byte[] data = new byte[1024];
        private string hostName;
        private int hostPort,clientNumber=1000, timeInterval=1000;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        protected override void  OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 创建客户端并连接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateClientsClick(object sender, RoutedEventArgs e)
        {
            hostName = SocketHostName.Text.ToString();
            hostPort = Convert.ToInt32(SocketHostPort.Text);
            //hostName = SocketHostName.ToString();
            //hostPort = Convert.ToInt32(SocketHostPort.ToString());
            if (ClientNumber.Text.ToString().Equals(null))
            {

            }
            else
            {
                clientNumber = Convert.ToInt32(ClientNumber.Text.ToString());
            }

            for (int i = 0; i < clientNumber; i++)
            {
                // ThreadPool.QueueUserWorkItem(new WaitCallback(startClient), i);
                //Thread th = new Thread(startClient);
                //th.Start();
                Task t = Task.Factory.StartNew(startClient);
                StatusText.Dispatcher.Invoke(new Action(() => { StatusText.Text = " 连接成功"+i; }));
            }
        }

        private void startClient()        
        {
            
            Socket newclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(hostName), hostPort);//服务器的IP和端口

            try
            {
                newclient.Connect(ie);
                //Console.WriteLine("连接成功");
              //  StatusText.Dispatcher.Invoke(new Action(() => { StatusText.Text = " 连接成功"; }));
            }
            catch (SocketException ex)
            {
                StatusText.Dispatcher.Invoke(new Action(() => { StatusText.Text = ex.Message.ToString(); }));
                throw ex;
            }
            DateTime dt = DateTime.Now;
            string time = dt.ToLongTimeString();
            //Console.WriteLine(time.Replace(":", ""));
           // string input = "SLC678833010109143|W80|V4.0{<U1#1><U3#" + time.Replace(":", "") + ".000,A,3616.22620,N,12016.42950,E,0.000,27.30,180815,,|10|100|100|090>}\r";
         // string input = "SLC678833010109143|W80|V4.0{<U1#1><U3#120455.000,A,3616.22620,N,12016.42950,E,0.000,27.30,180815,,|10|100|100|090>}\r";
            string input = "";
            //Console.WriteLine(newclient.LocalEndPoint.ToString());
            if (newclient.Connected)
            {
                //if (input == "exit")
                //    break;
                //Console.WriteLine(Encoding.Unicode.GetBytes(input).ToString());

                newclient.Send(Encoding.ASCII.GetBytes(input));//处理中文
                ConnStatus.Dispatcher.Invoke(new Action(() => { ConnStatus.Text += newclient.LocalEndPoint.ToString() + "---->连接成功\n"; }));
                data = new byte[1024];
                int recv = newclient.Receive(data);
                
                string stringdata = Encoding.ASCII.GetString(data, 0, recv);
                //Console.WriteLine(stringdata);

              
                Thread.Sleep(30000);
            }
            
        }
    }
}
