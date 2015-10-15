using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleSocket
{
    class MyThread
    {
        public static int MAX_THREAD = Environment.ProcessorCount*2;//最大的线程数=逻辑核心数*2
        public static int number_of_thread = 0;
        static Thread[] threads = new Thread[number_of_thread];
        static string path;
        List<Position> positions = MyFile.getPositions(path);
        static int index=0;
        public void createThread()
        {            
            TcpClient tc = new TcpClient();
            tc.Position = positions[index];
            for (int i = 0; i < number_of_thread; i++)
            {
                threads[i] = new Thread(new ThreadStart(tc.start));
            }

        }
    }
}
