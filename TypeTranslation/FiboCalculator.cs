using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeTranslation
{
    public  class FiboCalculator
    {
        delegate void Callback(int count, ICollection<decimal> series);
        private Callback callback = new Callback(GetFibo);
        public IAsyncResult BeginGetFibo(int count, ICollection<decimal> series, AsyncCallback callback, object state)
        {
            return this.callback.BeginInvoke(count, series, callback, state);
        }
        public void EndGetFibo(IAsyncResult asyncResult)
        {
            this.callback.EndInvoke(asyncResult);
        }

        public static void GetFibo(int count, ICollection<decimal> series)
        {
            for (int i = 0; i < count; i++)
            {
                decimal d = GetFiboCore(i);
                lock(series){
                    series.Add(d);
                }
            }
        }
        static decimal GetFiboCore(int i)
        {
            if (i < 0) throw new ArgumentException(" i must be > 0");
            if (i == 0 || i == 1) return 1;
            return GetFiboCore(i - 1) + GetFiboCore(i - 2);
        }
    }
}
