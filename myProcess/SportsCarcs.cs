using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace myProcess
{
    class SportsCarcs
    {
        public SportsCarcs(){
        Context context = Thread.CurrentContext;
        Console.WriteLine(this.ToString() + " object in context " + context.ContextID);
        foreach (IContextProperty icp in context.ContextProperties)
        {
            Console.WriteLine("---> context Prop :" + icp.Name);
        }
        }
    }
}
