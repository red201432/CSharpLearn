using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    /// <summary>
    /// 类名称+2 代表是按照.net framework 规范编写的代码
    /// </summary>
    class heater2
    {
        private int temperature;
        public string type = "Haier H001";
        public string area = "China";

        //声明委托
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs e);
        public event BoiledEventHandler Boiled;                                     

        //定义 BoiledEventArgs 类,传递给Observer所感兴趣的信息
        public class BoiledEventArgs : EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        // 可以继承自Heater类的重写,以便继承类拒绝其他类的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if (Boiled != null)//如果有对象注册
            {
                Boiled(this, e);//调用所有注册对象的方法
            }
        }
        /// <summary>
        /// 加热
        /// </summary>
        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature >= 95)
                {
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
    }
}
