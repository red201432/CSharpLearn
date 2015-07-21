using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    public delegate void GreetingDelegate(string name);

    class Program
    {
        static void Main(string[] args)
        {
            GreetingDelegate gd1;
            gd1 = EnglishGeting;
            gd1 += ChineseGeting;
            GreetPeople("Jim",EnglishGeting);
            GreetPeople("Jim2", gd1);
            gd1-=EnglishGeting;
           // gd1 -= ChineseGeting;将方法全部解除之后会产生错误
            GreetPeople("章子怡", ChineseGeting);
            gd1("zhang");
            GreetPeople("Andy",sayHello);
            Console.WriteLine("\u0001");
            Console.WriteLine("\u0002");
            Console.WriteLine("\u0003");
            Console.WriteLine("\u0004");
            Console.WriteLine('Q');
        }
        private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }
        public static void sayHello(string s)
        {
            Console.WriteLine("say hello to " + s);
        }
        public static void GreetPeople(string name)
        {
            EnglishGeting(name);
        }
        public static void EnglishGeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        public static void ChineseGeting(string name) 
        {
            Console.WriteLine("早上好," + name);
        }

    }
}
