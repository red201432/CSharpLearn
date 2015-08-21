using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeTranslation
{
    /// <summary>
    /// 对于属性和字段的区别
    ///  
    /// </summary>
    class Program
    {
        public class Rectangle
        {
            public int Width{ get; set; }
            public int Height{ get; set; }
            public Rectangle(int w, int h)//:this()  //this( ) 表示从当前类中调用变量的值来作为构造函数重载方法
            {
                Width = w;
                Height = h;
            }

            public void Draw()
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    { Console.Write("*"); }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            public override string ToString()
            {
                return string.Format("[Width= {0};Height= {1} ]", Width, Height);
            }

        }

        public struct Square
        {
            public int Length;// { get; set; }
            public Square(int l)//:this()
            {
                Length = l;
            }
            public void Draw()
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < Length; j++)
                        Console.Write("*");
                    Console.WriteLine();
                }
                
            }

            public override string ToString()
            {
                return string.Format("[Length: {0} ]", Length);
            }

            public static explicit operator Square(Rectangle r)
            {
                Square s = new Square();
                s.Length = r.Height;
                return s;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(FiboCalculator.Equals(10, 0.0));
            Console.WriteLine("***Fun With Conversions ***");
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.DisplayDefiningAssembly();

           Console.WriteLine( myInt.ReverseDigits());
           Console.WriteLine("扩展接口测试");
           string[] data = { "Wow", "this", "is ", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun" };
           data.PrintDataAndBeep();
                Rectangle r=new Rectangle(5,4);
            Console.WriteLine(r.ToString());
            r.Draw();
            Square s = (Square)r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.WriteLine(GC.GetTotalMemory(false)+"---"+GC.MaxGeneration);
          //  Console.ReadLine();
            BuildAnonType("BWM", "red", 1234);
        }

         static void BuildAnonType(string make, string color, int currSp)
        {
            var car = new { Make = make, Color = color, CurrSP = currSp };
           // Console.WriteLine(&car);
            Console.WriteLine(car.ToString());
        }
    }
}
