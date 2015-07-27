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
            
            NewTaskDelegate task = newTask;
            IAsyncResult asyncResult = task.BeginInvoke(2000, null, null);

            // EndInvoke方法将被阻塞2秒
            int result = task.EndInvoke(asyncResult);
            Console.WriteLine(result);
        }
    }
}
