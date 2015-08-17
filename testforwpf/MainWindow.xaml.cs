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
using System.Threading;
namespace testforwpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    
    public partial class MainWindow : Window
    {
        private delegate int MyMethod();

        Counter oCounter = new Counter();
        public static ClickForm cf;
        #region 时钟
        //private LocalClock localClock = null;
        //private LondonClock londonClock = null;
        //private NewYorkClock NYClock = null;
        System.Windows.Threading.DispatcherTimer timer;
        public void Time_Start(object sender, RoutedEventArgs e)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender,EventArgs e)
        {
            tbLocalTime.Text = DateTime.Now.ToLongTimeString();
            
        }
        #endregion
        public MainWindow()
        {
            oCounter.NumberReached += new NumberReachedEventHandler(oCounter_NumberReached);

            InitializeComponent();
            //localClock = new LocalClock(localTimeDisplay);
            //londonClock = new LondonClock(londonTimeDisplay);
            //NYClock = new NewYorkClock(NYTimeDisplay);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MyMethod my = method;
            IAsyncResult asyncResult = my.BeginInvoke(MethodCompleted, my);
           // MainWindow.cf.ShowDialog();
            txtReachable.Text = DateTime.Now.ToString();
            textBlock1.Text = ((int)'Ā').ToString();
            if (MainWindow.cf == null)
            {
                MainWindow.cf = new ClickForm();
            }
            
            MainWindow.cf.Show();
          

            if (txtCountTo.Text == "" || txtReachable.Text == "")

                return;

            oCounter.CountTo(Convert.ToInt32(txtCountTo.Text), Convert.ToInt32(txtReachable.Text));
            
        }
        private void oCounter_NumberReached(object sender, NumberReachedEventArgs e)
        {
            MessageBox.Show("Reached: " + e.ReachedNumber.ToString());
        } 

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {            
            System.Environment.Exit(0);//关闭窗口同时结束相关的进程
        }

        private int method()
        {
            Thread.Sleep(1000);
            return 100;
        }

        private void MethodCompleted(IAsyncResult asyncResult)
        {
            if (asyncResult == null) return;
            //txtReachable.Text += (asyncResult.AsyncState as MyMethod).EndInvoke(asyncResult).ToString();//此时这个对象已被线程占用，异步线程无法访问
           // txtCountTo.Text += (asyncResult.AsyncState as MyMethod).EndInvoke(asyncResult).ToString();
        }
    }
}
