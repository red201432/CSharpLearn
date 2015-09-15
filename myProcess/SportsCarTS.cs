using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace myProcess
{
    [Synchronization]
    class SportsCarTS:ContextBoundObject
    {
        public SportsCarTS() {
            Context context = Thread.CurrentContext;
            Console.WriteLine(this.ToString() + " object in context is :" + context.ContextID);
            foreach (IContextProperty icp in context.ContextProperties)
            {
                Console.WriteLine("---> context Prop :" + icp.Name);
            }
        }
    }
}
