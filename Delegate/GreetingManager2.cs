using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// we will declear an Event in this class
    /// </summary>
    class GreetingManager2
    {
        public event GreetingDelegate MakeGreet;//声明一个事件不过类似于声明一个进行了封装的委托类型的变量而已
        public void GreetPeople(string name)
        {
            MakeGreet(name);
        }
    }
}
