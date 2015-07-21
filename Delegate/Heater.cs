using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// 显然能完成我们之前描述的工作，但是却并不够好。现在假设热水器由三部分组成：热水器、警报器、显示器，它们来自于不同厂商并进行了组装。那么，应该是热水器仅仅负责烧水，它不能发出警报也不能显示水温；在水烧开时由警报器发出警报、显示器显示提示和水温。
    /// 采用 观察者模式
    /// 1 . 警报器和显示器告诉热水器，它对它的温度比较感兴趣(注册)。
    /// 2 . 热水器知道后保留对警报器和显示器的引用。
    /// 3 . 热水器进行烧水这一动作，当水温超过95度时，通过对警报器和显示器的引用，自动调用警报器的MakeAlert()方法、显示器的ShowMsg()方法。
    /// </summary>
    class Heater
    {
        private int temperature;//水温
        public delegate void BoilHandler(int param);    //声明委托
        public event BoilHandler BoilEvent;             //声明事件


        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature >= 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature);
                    }
                    //MakeAlert(temperature);
                    //ShowMsg(temperature);
                }
            }
        }

        ////发出警报
        //public void MakeAlert(int t)
        //{
        //    Console.WriteLine("Alarm: 温度已经到达{0}度,就要开了", t);
        //}

        ////显示水温
        //public void ShowMsg(int t)
        //{
        //    Console.WriteLine("Display:水快开了,当前温度{0}度.", t);
        //}
    }
}
