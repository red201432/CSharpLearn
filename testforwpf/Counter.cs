using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testforwpf
{
    public delegate void NumberReachedEventHandler(object sender,NumberReachedEventArgs e); 

    class Counter
    {
        public event NumberReachedEventHandler NumberReached;

        public Counter()
        {
            // 
            // TODO: Add constructor logic here 
            // 
            
        }

        public void CountTo(int countTo, int reachableNum)
        {

            if (countTo < reachableNum)

                throw new ArgumentException("reachableNum should be less than countTo");

            for (int ctr = 0; ctr <= countTo; ctr++)
            {

                if (ctr == reachableNum)
                {

                    NumberReachedEventArgs e = new NumberReachedEventArgs(reachableNum);
                    OnNumberReached(e);
                    return;//don't count any more 
                }
            }
        }

        protected virtual void OnNumberReached(NumberReachedEventArgs e)
        {
            if (NumberReached != null)
            {
                NumberReached(this, e);//Raise the event 
            }
        } 
    }
}
