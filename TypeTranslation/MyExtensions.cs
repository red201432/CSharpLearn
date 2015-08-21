using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace TypeTranslation
{
   static class MyExtensions
    {
        //本方法允许任何对象显示它所处的程序集
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here : {1} ", 
                obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        public static int ReverseDigits(this int i)
        {
            //将int 转换为string并或得所有字符
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            //放回string
            string newDigits = new string(digits);
            //最后以int返回修改后的字符串
            return int.Parse(newDigits);
        }
    }
}
