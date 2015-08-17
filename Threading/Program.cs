using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class Program
    {
        public static int newTask(int ms) 
        {
            Console.WriteLine("Task is begin");
            Thread.Sleep(ms);
            Random random = new Random();
            int n = random.Next(1000);
            Console.WriteLine("Task is end");
            return n;
        }

        public delegate int NewTaskDelegate(int ms);
        private delegate int MyMethod();
        private int method() {
            Thread.Sleep(10000);
            return 100;
        }

        private void MethodCompleted(IAsyncResult asyncResult)
        {
            if (asyncResult == null)
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            #region 委托绑定方法不带参数
            Console.WriteLine("Main threadId is :" + Thread.CurrentThread.ManagedThreadId);
            Message message = new Message();
            Thread thread=new Thread(new ThreadStart(message.ShowMessage));
            thread.IsBackground=true;
            thread.Start();
             Console.WriteLine("Do something ..........!");
            Console.WriteLine("Main thread working is complete!");

            #endregion
            #region 委托绑定方法带参数
            Person person = new Person();
            person.Name = "john";
            person.Age = 32;
            Thread thread1 = new Thread(new ParameterizedThreadStart(message.ShowPerson));
            thread1.IsBackground = true;
            thread1.Start();
            #endregion
            #region 线程池
            //ThreadPool.SetMaxThreads(10000, 10000);//设置线程池的最大值
            //ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncCallback));
            //Console.ReadKey();

            #endregion 
            NewTaskDelegate task = newTask;
            IAsyncResult asyncResult = task.BeginInvoke(2000, null, null);
            while (!asyncResult.IsCompleted)
            {
                Console.Write("*");
                Thread.Sleep(100);
            }
            
            // EndInvoke方法将被阻塞2秒
            int result = task.EndInvoke(asyncResult);
            Console.WriteLine(result);
        }

        static void AsynCallback(object state)
        {
            Thread.Sleep(200);
            //ThreadMessage("AsynCallback");
            Console.WriteLine("Async thread do work");

        }
    }
}
