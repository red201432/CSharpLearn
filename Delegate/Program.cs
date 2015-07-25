using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// 关于委托是对方法类型的定义，使得方法可以作为另一个方法的参数进行传递。
    /// 委托是对方法类型的定义，包括方法的返回值类型和参数类型。
    /// 可以将多个方法绑定到一个委托，委托会按照绑定的顺序进行执行。
    /// 
    /// 声明委托的目的是将类暴露在客户端的方法进行注册，不能声明为private，否则对客户端不可用
    /// 用属性对字段进行封装
    /// 
    /// 事件的由来
    /// 事件封装了委托类型的变量。在类的内部总是private的，在类的外部注册“+=”和注销“-=”的访问限定符与你在声明事件时使用的访问符相同
    /// 声明事件类似于声明一个进行了封装的委托类型的变量而已。
    /// 
    /// 观察者模式是为了定义对象间的一对多的依赖关系，以便于当一个对象的状态改变时，其他依赖于它的对象会被自动告知并更新。
    /// 观察者设计模式一种松耦合的设计模式。
    /// </summary>
    /// <param name="name"></param>
    public delegate void GreetingDelegate(string name);

   

    public class GreetingManager 
    {
        public GreetingDelegate gd1;
        public void GreetPeople(string name,GreetingDelegate MakeGreeting) 
        {
            MakeGreeting(name);
        }
    }
    delegate double DoubleOp(double x);
    class Program
    {
        /// <summary>
        /// 使用委托可以将多个方法绑定到委托变量,当调用此变量时,可以一次调用所有绑定的方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Employee[] employees = { 
                                    new Employee("Jim",20000),
                                    new Employee("John",10000),
                                    new Employee("Marry",5000),
                                    new Employee("Wille",30000),
                                    new Employee("RoadRunner",59232)
                                   };
            BubbleSort.Sort(employees, Employee.CompareSalary);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);//类似于Javade 隐藏遍历
            }

            DoubleOp[] operations = { 
                                    MathOperations.MultiplyByTwo,MathOperations.Square
                                    };
            for (int i = 0; i < operations.Length; i++) {
                Console.WriteLine("USing operation{0}", i);
                Console.WriteLine(operations[i](2.0));
                Console.WriteLine(operations[i](6.74));

            }
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
