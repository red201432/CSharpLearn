using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace testforwpf
{
    class Square:DrawingShapes, IDraw,IColor
    {
        private int sideLength;
        public Square(int sideLength):base(sideLength)
        {
            this.sideLength = sideLength;
        }



        //public void setLocation(int x, int y)
        //{
        //    this.locX = x;
        //    this.locY = y;
        //}

        public override void draw(Canvas canvas)
        {
            if (this.shape != null)
                canvas.Children.Remove(this.shape);
            else
                this.shape = new Rectangle();
            base.draw(canvas);
            //this.rect.Height = this.sideLength;
            //this.rect.Width = this.sideLength;
            //Canvas.SetTop(this.rect, this.locY);
            //Canvas.SetLeft(this.rect, this.locX);
            //canvas.Children.Add(rect);
        }

        //public void setColor(Color color)
        //{
        //    if (rect != null)
        //    {
        //        SolidColorBrush brush = new SolidColorBrush(color);
        //        rect.Fill = brush;
        //    }
        //}
    }
}
