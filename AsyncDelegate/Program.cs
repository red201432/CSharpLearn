using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;
namespace AsyncDelegate
{
    /// <summary>
    /// 异步调用委托
    /// </summary>
    class Program
    {
        public delegate int BinaryDelagate(int x,int y);
        public static event BinaryDelagate AddHandle;
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);//使用AutoResetEvent

        private static bool IsDone = false;
        static void Main(string[] args)
        {

            #region 线程池
            Printer p1 = new Printer();
            WaitCallback workItem = new WaitCallback(PrintNumbers);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p1);
            }
            Console.ReadLine();
            #endregion

            #region Timer
            TimerCallback timeTC = new TimerCallback(printTime);
            Timer timer = new Timer(
                timeTC, //  TimerCallback委托对象
                "Hello Timer",   //  想传入的参数
                0,      //  在开始之前，等待多久
                1000    //  每次调用的间隔时间
                );
            #endregion

            #region 传入参数给次线程
            AddParams ap = new AddParams(23, 430);
            Thread t = new Thread(new ParameterizedThreadStart(AddNum));//参数为 定义的方法
            t.Start(ap);
            //Thread.Sleep(5);
            waitHandle.WaitOne();
            Console.WriteLine("Other Thread is done");
            #endregion
            #region 创建次线程 无参数
            string threadCount = Console.ReadLine();
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            Console.WriteLine("-->{0} is executing Main()", Thread.CurrentThread.Name);

            Printer p = new Printer();
            switch (threadCount)
            {
                case "2":
                    //设置线程
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumber));
                    backgroundThread.Name = "Background";
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumber();
                    break;
                default:
                    Console.WriteLine(" ....Goto case 1");
                    goto case "1";

            }

            #endregion

            BinaryDelagate bdAdd = new BinaryDelagate(Add);



            Console.WriteLine("Main( ) invoked on thread " + Thread.CurrentThread.ManagedThreadId);
            //IAsyncResult iar = bdAdd.BeginInvoke(10, 10, null, null);
            //完成时发出通知
            IAsyncResult iar = bdAdd.BeginInvoke(10, 10, new AsyncCallback(AddComplete), "Thanks you for adding these numbers");
            while (!IsDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working ....");
            }
           // AddHandle += Add;
            
            //while (!iar.IsCompleted)
            //{
            //    Console.WriteLine("Doing more work in main");
                
            //}
            //在AddComplete中输出结果
            //int answer = bdAdd.EndInvoke(iar);
            //Console.WriteLine(answer);
        }
        static void printTime(object state)
        {
            Console.WriteLine("time is :" + DateTime.Now.ToLongTimeString()+"------"+state.ToString());
        }
        static void PrintNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumber();
        }
        public static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on thread " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
        static void AddNum(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in add() is :{0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine(ap.a + ap.b);
                waitHandle.Set();//发出通知告诉该线程已结束
            }
        }
        public static void AddComplete(IAsyncResult iar)
        {
          
            Console.WriteLine("AddComplete() Invoke on thread {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is done");
            //获取消息对象，并转换为string
            string msg = (string)iar.AsyncState;
            AsyncResult ar = (AsyncResult)iar; //AsyncResult 定义在 using System.Runtime.Remoting.Messaging中
            BinaryDelagate b = (BinaryDelagate)ar.AsyncDelegate;
            Console.WriteLine("10 +10 is " + b.EndInvoke(iar));
            Console.WriteLine(msg);
            IsDone = true;
        }
    }
}
