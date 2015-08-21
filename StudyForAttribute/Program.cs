using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyForAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Dates and Times");
            DateTime dt =DateTime.Now.ToLocalTime();

            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            
            dt = dt.AddMonths(2);
            Console.WriteLine("DayLight saving :{0}", dt.IsDaylightSavingTime());

            TimeSpan ts = new TimeSpan(4, 40, 0);
            Console.WriteLine(ts);
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));


            var info = typeof(MyClass);
            var classAttribute=(VersionAttribute)Attribute.GetCustomAttribute(info,typeof(VersionAttribute));
            Console.WriteLine(classAttribute.Name);
            Console.WriteLine(classAttribute.Date);
            Console.WriteLine(classAttribute.Describtion);

            Console.WriteLine();
            Console.WriteLine(@"C:\myqpp");
            double[] d = new double[] { 1.2, 46.5, 45.78, 14.453, 45.1 };
           Console.WriteLine(CalculateAverage(d));

           Console.WriteLine();
           Garage garate = new Garage();
           
           foreach (Car car in garate)
           {
               Console.WriteLine(car.Name +"--->"+car.Account);
           }

           UsePsersonCollection();
        }
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("you sent me {0} doubles.", values.Length);

            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length - 1; i++)
            {
                sum += values[i];
            }
            return sum/values.Length;
        }

        static void UsePsersonCollection() {
            Console.WriteLine("***Customer Person Collection***");
            PersonCollection pc = new PersonCollection();
            pc.AddPerson(new Person(12,"Herry"));
            pc.AddPerson(new Person(32,"John"));
            pc.AddPerson(new Person(34,"Lisa"));
            foreach(Person p in pc)
                Console.WriteLine(p);
        }
    }
}
