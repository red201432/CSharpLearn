using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncDelegate
{
    class Printer
    {
        private object threadLock = new object();
        public void PrintNumber()
        {
            //lock (threadLock)
            Monitor.Enter(threadLock);
            try
            {
                //显示Thread信息
                Console.WriteLine("-->{0} is executing PrintNumber()", Thread.CurrentThread.Name);
                //输出数字
                Console.WriteLine("Your Number is :");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(i + ", ");
                    Thread.Sleep(2000);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
