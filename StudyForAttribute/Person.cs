using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyForAttribute
{
   public  class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public Person() { }
        public Person(int age, string name)
        {
            Age = age;
            FirstName = name;
        }

        public override string ToString()
        {
            return string.Format("Name :"+FirstName+","+"Age : "+Age);
        }
    }
}
