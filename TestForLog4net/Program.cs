using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestForLog4net
{
    class Program
    {
        static void Main(string[] args)
        {
             //第一种记录用法
            //（1）FormMain是类名称
           //（2）第二个参数是字符串信息
           LogHelper.WriteLog(typeof(String),"测试Log4Net日志是否写入");


           //第二种记录用法
            //（1）FormMain是类名称
           //（2）第二个参数是需要捕捉的异常块
            //try { 
            
           //}catch(Exception ex){

            //    LogHelper.WriteLog(typeof(FormMain), ex);
             //}           
           Console.WriteLine("测试log4net");
        }
    }
}
