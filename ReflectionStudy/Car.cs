using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionStudy
{
    class Car
    {
        private string band { get; set; }
        private int miles { get; set; }
        public Car()
        {
            band = "BMW";
            miles = 0;
        }
        public void newCar(string band, int mile)
        {
            this.band = band;
            this.miles += mile;
            Console.WriteLine(this.band + "===" + this.miles);
        }
        public void SayHello()
        {
            Console.WriteLine("Hello world");
        }
    }
}
