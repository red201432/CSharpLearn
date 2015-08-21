using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeTranslation
{
    /// <summary>
    /// 对接口进行扩展
    /// </summary>
   static class InterfaceExtensions
    {
       public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
       {
           foreach (var item in iterator)
           {
               Console.WriteLine(item);
               Console.Beep();
           }
       }
    }
}
