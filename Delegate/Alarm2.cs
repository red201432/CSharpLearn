using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// 观察者模式的类
    /// </summary>
    class Alarm2
    {
        public void MakeAlert(object sender, heater2.BoiledEventArgs e)
        {
            heater2 heater22 = (heater2)sender;
            Console.WriteLine("Alarm:{0}--{1}", heater22.type, heater22.area);
            Console.WriteLine("Alarm: 温度已经到达{0}度,就要开了", e.temperature);
            Console.WriteLine();
        }
    }
}
