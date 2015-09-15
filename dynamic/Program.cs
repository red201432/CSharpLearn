using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic b = "avbdadffa";
            Console.WriteLine(b.ToUpper());
            ImplictlyTypedVariable();
           // AddWithReflection();
            AddWithDynamic();
        }
        static void ImplictlyTypedVariable()
        {
            var a = new List<int>();
            a.Add(90);
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }

        static private void AddWithReflection()
        {
            Assembly asm = Assembly.Load("dynamic.MathLibrary");
            try
            {
                //获取MathLibrary类型的元数据
                Type math = asm.GetType("dynamic.MathLibrary.SimpleMath");
                object obj = Activator.CreateInstance(math);
                MethodInfo mi = math.GetMethod("Add");
                object[] args = { 10, 70 };
                Console.WriteLine(mi.Invoke(obj, args));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //使用动态类型可以简化代码
        static private void AddWithDynamic()
        {
            Assembly asm = Assembly.Load("dynamic.MathLibrary");
            try
            {
                Type t = asm.GetType("dynamic.MathLibrary.SimpleMath");
                dynamic obj = Activator.CreateInstance(t);
               Console.WriteLine(obj.Add(10, 70));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
