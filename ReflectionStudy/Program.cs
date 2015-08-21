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
        }

        static void DisplayTypesInAssembly(Assembly asm)
        {
            Console.WriteLine("***Types in Assembly ***");
            Console.WriteLine("-->" + asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine(t.ToString());
        }
    }
}
