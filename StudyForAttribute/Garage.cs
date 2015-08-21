using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace StudyForAttribute
{
    class Garage:IEnumerable
    {
        private Car[] carArray = new Car[4];
        public Garage() {
            carArray[0] = new Car("BMW", 40);
            carArray[1] = new Car("Zippy", 32);
            carArray[2] = new Car("AUDI", 21);
            carArray[3] = new Car("Fred", 34);
        }
        
        public IEnumerator GetEnumerator()
        {
           
            return carArray.GetEnumerator();
        }
    }
}
