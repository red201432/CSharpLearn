using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic.COM
{
    class Car
    {
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
        public Car() { }
        public Car(string c, string m, string pn)
        {
            Color = c;
            Make = m;
            PetName = pn;
        }
    }
}
