using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ReflectionStudy
{
    class Program
    {
       
        static void Main(string[] args)
        {
            #region 晚期绑定
            Console.WriteLine("Fun with Late Binding...");
            Assembly a = null;
            try
            {
                a = Assembly.Load("ReflectionStudy");
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine(fex.Message);
                throw;
            }
            if (a != null)
            {
                CreateUsingLateBinding(a);
            }
            #endregion
            #region
            ////car c = new car();
            ////type t = c.gettype();
            //Console.WriteLine(t.GetMethods().ToString());
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter an assembly to evalute");
                asmName = Console.ReadLine();
                if (asmName.ToUpper() == "Q")
                    break;
                try
                {
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAssembly(asm);
                } 
                catch{
                    Console.WriteLine("There is no class find");
                }
            } while (true);
            #endregion
        }

        static void DisplayTypesInAssembly(Assembly asm)
        {
            Console.WriteLine("***Types in Assembly ***");
            Console.WriteLine("-->" + asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.ToString());
            }
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type t = asm.GetType("ReflectionStudy.Car");
                //采用动态类型 ,更符合一般的调用方法
                dynamic obj = Activator.CreateInstance(t);
                obj.SayHello();
                obj.newCar("ada",12);
                #region
                //object obj = Activator.CreateInstance(t);
                //Console.WriteLine("Created a {0} using late bingding",obj);
                //MethodInfo mi = t.GetMethod("SayHello");//调用对象的方法
                //MethodInfo m2 = t.GetMethod("newCar");
                //mi.Invoke(obj, null);
                //m2.Invoke(obj,new object[]{"aodeo",12});
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
