using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    public delegate void GreetingDelegate(string name);

    public class GreetingManager 
    {
        public GreetingDelegate gd1;
        public void GreetPeople(string name,GreetingDelegate MakeGreeting) 
        {
            MakeGreeting(name);
        }
    }

    class Program
    {
        /// <summary>
        /// 使用委托可以将多个方法绑定到委托变量,当调用此变量时,可以一次调用所有绑定的方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            heater2 heater22 = new heater2();
            Alarm2 alarm2 = new Alarm2();
            heater22.Boiled += alarm2.MakeAlert;
            heater22.Boiled += (new Alarm2()).MakeAlert;
            heater22.Boiled += new heater2.BoiledEventHandler(alarm2.MakeAlert);
            heater22.Boiled += Display2.ShowMsg;

            heater22.BoilWater();

            //
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert;                //绑定事件
            heater.BoilEvent += (new Alarm()).MakeAlert;        //绑定事件
            heater.BoilEvent += Display.ShowMsg;
            heater.BoilWater();

           // heater.BoilWater();


            GreetingManager2 gm2 = new GreetingManager2();
            //gm2.MakeGreet = ChineseGeting;
            gm2.MakeGreet += EnglishGeting;
            gm2.GreetPeople("hello world");
            GreetingManager gm = new GreetingManager();
            gm.GreetPeople("Jim", EnglishGeting);
            gm.GreetPeople("章子怡", ChineseGeting);
            //GreetingDelegate gd1, gd2;
            gm.gd1 = EnglishGeting;
            gm.gd1 += ChineseGeting;
            gm.GreetPeople("John", gm.gd1);



           // GreetingDelegate gd1,gd2;
           // gd1 = EnglishGeting;//如果第一次就使用“+=”，将出现“使用了未赋值的局部变量”的编译错误。
           // gd1 += ChineseGeting;
           // GreetPeople("Jim",EnglishGeting);
           // GreetPeople("Jim2", gd1);
           // Console.WriteLine("***下面测试绑定的顺序和执行的顺序***");
           // gd2 = ChineseGeting;
           // gd2 += EnglishGeting;
           // gd2 += ChineseGeting;
           // gd2("章子怡");
           // Console.WriteLine("***测试结束***");
           // gd1-=EnglishGeting;
           //// gd1 -= ChineseGeting;将方法全部解除之后会产生错误
           // GreetPeople("章子怡", ChineseGeting);
           // gd1("zhang");
           // GreetPeople("Andy",sayHello);

            Console.WriteLine("\u0001");
            Console.WriteLine("\u0002");
            Console.WriteLine("\u0003");
            Console.WriteLine("\u0004");
            Console.WriteLine('Q');
        }
        //private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        //{
        //    MakeGreeting(name);
        //}
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
