using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyForAttribute
{
    class Car
    {
      public  string Name {get;set;}
      public int Account { get; set; }
        public Car(string name, int account)
        {
            this.Name = name;
            this.Account = account;
        }
    }
}
