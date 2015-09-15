using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSerialize
{
    [Serializable]
   public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }
}
