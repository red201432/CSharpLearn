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
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
namespace GraphDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static long availableMemorySize = 0;
        private int pixelWidth = 0;
        private int pixelHeight = 0;
        private double dpiX= 96.0;
        private double dpiY = 96.0;
        private static CancellationTokenSource tokenSource =new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;
        private WriteableBitmap graphBitmap = null;

        public MainWindow()
        {
            InitializeComponent();
            PerformanceCounter memCounter = new PerformanceCounter("Memory", "Available Bytes");
            availableMemorySize=Convert.ToInt64(memCounter.NextValue());

            this.pixelWidth = (int)availableMemorySize / 10000;

            if (this.pixelWidth < 0 || this.pixelWidth > 15000)
                this.pixelWidth = 15000;
            this.pixelHeight = (int)availableMemorySize / 20000;
            if (this.pixelHeight < 0 || this.pixelHeight > 7500)
                this.pixelHeight = 7500;
        }

        private void plotButton_click(object sender, RoutedEventArgs e)
        {
            if (graphBitmap == null)
            {
                graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Gray8, null);
            }
            Action doPlotButtonWorkAction = new Action(doPlotButtonWork);
            doPlotButtonWorkAction.BeginInvoke(null, null);

            //int byetePerPixel = (graphBitmap.Format.BitsPerPixel + 7) / 8;
            //int stride = byetePerPixel * graphBitmap.PixelWidth;
            //int dataSize = stride * graphBitmap.PixelHeight;
            //byte[] data = new byte[dataSize];

            //Stopwatch watch = new Stopwatch();

            ////generateGraphData(data);
            ////新建线程
            //Task first = Task.Factory.StartNew(()=>generateGraphData(data,0,pixelWidth/8));
            //Task second = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 8, pixelWidth / 4));
            //Task first1 = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 4, pixelWidth / 2));
            //Task second1 = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 2, pixelWidth));
            //Task.WaitAll(first, second,first1,second1);
            //duration.Content = string.Format("Duration (ms):{0}", watch.ElapsedMilliseconds);
            //graphBitmap.WritePixels(new Int32Rect(0, 0, graphBitmap.PixelWidth, graphBitmap.PixelHeight), data, stride, 0);
            //graphImage.Source = graphBitmap;
        }
        private void doPlotButtonWork()
        {

            //int byetePerPixel = (graphBitmap.Format.BitsPerPixel + 7) / 8;
            int byetePerPixel = 0;
            int stride = 0, dataSize = 0;
            plotButton.Dispatcher.Invoke(new Action(()=>{
                byetePerPixel=(graphBitmap.Format.BitsPerPixel+7)/8;
                stride = byetePerPixel * graphBitmap.PixelWidth;
                dataSize = stride * graphBitmap.PixelHeight;
            }),DispatcherPriority.ApplicationIdle);
            //int stride = byetePerPixel * graphBitmap.PixelWidth;
            //int dataSize = stride * graphBitmap.PixelHeight;
            byte[] data = new byte[dataSize];

            Stopwatch watch = new Stopwatch();

            //generateGraphData(data);
            //新建线程
            Task first = Task.Factory.StartNew(() => generateGraphData(data, 0, pixelWidth / 8,token));
            Task second = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 8, pixelWidth / 4,token));
            Task first1 = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 4, pixelWidth / 2,token));
            Task second1 = Task.Factory.StartNew(() => generateGraphData(data, pixelWidth / 2, pixelWidth,token));
            Task.WaitAll(first, second, first1, second1);
            String message = String.Format("status of tasks is {0} ,{1} ,{2} ,{3} \n", first.Status, second.Status, first1.Status,second1.Status);
            textBox1.Dispatcher.Invoke(new Action(() => { textBox1.Text += message; }));
            
            plotButton.Dispatcher.Invoke(new Action(() =>
            {
                duration.Content = string.Format("Duration (ms):{0}", watch.ElapsedMilliseconds);
                graphBitmap.WritePixels(new Int32Rect(0, 0, graphBitmap.PixelWidth, graphBitmap.PixelHeight), data, stride, 0);
                graphImage.Source = graphBitmap;
            }), DispatcherPriority.ApplicationIdle);
        }

        #region 单线程
        /*
        private void generateGraphData(byte[] data)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;
            for (int x = 0; x < a; x++)
            {
                int s = x * x;
                double p = Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 3)
                {
                    double r = Math.Sqrt(s + i * i) / a;
                    double q = (r - 1) * Math.Sin(24 * r);
                    double y = i / 3 + (q * c);
                    plotXY(data,(int)(-x+(pixelWidth/2)),(int)(y+(pixelHeight/2)));
                    plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                }
            }
        }
         * */
        #endregion


        #region 多线程
        private void generateGraphData(byte[] data,int partitionstart,int partitionEnd,CancellationToken token)
        {
            int a = pixelWidth / 2;
            int b = a * a;
            int c = pixelHeight / 2;
           // for (int x = 0; x < a; x++)
            for(int x=partitionstart;x<partitionEnd;x++)
            {
                int s = x * x;
                double p = Math.Sqrt(b - s);
                for (double i = -p; i < p; i += 3)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    double r = Math.Sqrt(s + i * i) / a;
                    double q = (r - 1) * Math.Sin(24 * r);
                    double y = i / 3 + (q * c);
                    plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                    plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
                }
            }
        }

        #endregion
        private void plotXY(byte[] data, int x, int y)
        {
            data[x + y * pixelWidth] = 0xFF;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (tokenSource != null)
            {
                tokenSource.Cancel();
            }
        }
        private byte[] getDataForGraph(int dataSize)
        {
            byte[] data = new byte[dataSize];
            return data;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }
            
    }
}
