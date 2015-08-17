using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace testforwpf
{
    interface IDraw
    {
        void setLocation(int x, int y);
        void draw(Canvas canvas);
    }
}
