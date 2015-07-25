using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// 一开始时的闹钟类
    /// </summary>
    class Alarm
    {
        public void MakeAlert(int t)
        {
            Console.WriteLine("Alarm: 温度已经到达{0}度,就要开了", t);
        }
    }
}
