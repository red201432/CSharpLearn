using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace myProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsCarcs sport = new SportsCarcs();
            Console.WriteLine();

            SportsCarTS sports = new SportsCarTS();
            Console.WriteLine();


            Console.ReadLine();
            AppDomain ad = AppDomain.CurrentDomain;
            ListAllAssemblyInAppDomain();
            MakeNewAppDomain();

            DisplayDADStatus();
            // StartAndKillProcess();
            ListAllProcesses();
            while (true)
            {
                Console.WriteLine();
                string pid = Console.ReadLine();
                if (pid == "Q")
                    break;
                EnmuThreadsForProcess(int.Parse(pid));
            }
        }

        static void ListAllProcesses()
        {
            var runningProcessed = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            foreach (var p in runningProcessed)
            {
                

                string info = string.Format("-->PID: {0} \ttName: {1}",p.Id,p.ProcessName);

                Console.WriteLine(info);
              
            }
            Console.WriteLine("******************");
        }
        static void EnmuThreadsForProcess(int pid) {
            Process p = null;
            try
            {
                p = Process.GetProcessById(pid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.WriteLine("Here are the Threads used by :{0}",p.ProcessName);
            //显示进程中的线程
            ProcessThreadCollection thethreads = p.Threads;
            foreach (ProcessThread pt in thethreads)
            {
                string ptinfo = string.Format("-->Thread ID :{0} \t StartTime: {1} \t Priority: {2}", pt.Id, pt.StartTime, pt.PriorityLevel);
                Console.WriteLine(ptinfo);
            }

            //显示进程中的模块信息
            ProcessModuleCollection pms = p.Modules;
            foreach (ProcessModule pm in pms)
            {
                string pminfo = string.Format("-->Mod Name :{0} \t Mod Size:{1}", pm.ModuleName,pm.ModuleMemorySize);
                Console.WriteLine(pminfo);
            }
        }
        //启动和结束进程
        static void StartAndKillProcess()
        {
            Process ieProc = null;
            try
            {
                ieProc = Process.Start("IExplore.exe", "www.baidu.com");

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Hit enter to kill {0}", ieProc.ProcessName);
            Console.ReadLine();
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //显示AppDomain信息
        private static void DisplayDADStatus() {
            AppDomain defaultApp = AppDomain.CurrentDomain;
            Console.WriteLine("Name of this AppDomain"+defaultApp.FriendlyName+" \nAppDomain ID:"+defaultApp.Id+" \nIS default Domain :"+defaultApp.IsDefaultAppDomain()+" \nDirectory of this Domain:"+defaultApp.BaseDirectory);
        }
        //显示加载的程序集
        private static void ListAllAssemblyInAppDomain()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            //获取默认应用程序中的所有程序集
            var loadedAssembly = from a in ad.GetAssemblies() orderby a.GetName().Name select a;
            //Assembly[] loadedAssembly = ad.GetAssemblies();
            foreach (Assembly a in loadedAssembly)
            {
                Console.WriteLine("--->Name is :" + a.GetName().Name + "\n--->Version :" + a.GetName().Version);
            }
        }


        private static void MakeNewAppDomain()
        {
            AppDomain newad = AppDomain.CreateDomain("NewDomain") ;
            //卸载程序集时的事件处理
            newad.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The Second AppDomain has been unloaded!!!");
            };
            try
            {
                newad.Load("GraphDemo");//加载外部程序集
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ListAllAssemblyInAppDomain(newad);
            AppDomain.Unload(newad);
            ListAllAssemblyInAppDomain();
        }
        private static void ListAllAssemblyInAppDomain( AppDomain ad)
        {
            Console.WriteLine("Here are new AppDomain************************************");
            //AppDomain ad = AppDomain.CurrentDomain;
            //获取默认应用程序中的所有程序集
            var loadedAssembly = from a in ad.GetAssemblies() orderby a.GetName().Name select a;
            
            //Assembly[] loadedAssembly = ad.GetAssemblies();
            foreach (Assembly a in loadedAssembly)
            {
                Console.WriteLine("--->Name is :" + a.GetName().Name + "\n--->Version :" + a.GetName().Version);
            }
        }
    }
}
