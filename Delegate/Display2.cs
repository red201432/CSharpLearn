using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    class Display2
    {
        public static void ShowMsg(object sender, heater2.BoiledEventArgs e)
        {
            heater2 heater22 = (heater2)sender;
            Console.WriteLine("Display:{0}--{1}", heater22.type, heater22.area);
            Console.WriteLine("Display: 温度已经到达{0}度,就要开了", e.temperature);
            Console.WriteLine();
        }
    }
}
