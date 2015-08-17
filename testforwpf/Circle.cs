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
    class Circle : DrawingShapes, IDraw, IColor
    {
        private int radius;
       
        public Circle(int radius):base(radius)
        {
            this.radius = radius;
        }


        //public void setLocation(int x, int y)
        //{
        //    this.locX = x;
        //    this.locY = y;
        //}

        public override void draw(Canvas canvas)
        {
            if (this.shape!= null)
                canvas.Children.Remove(this.shape);
            else
                this.shape = new Ellipse();
            base.draw(canvas);

            //this.circle.Height = this.radius;
            //this.circle.Width = this.radius;
            //Canvas.SetTop(this.circle, this.locY);
            //Canvas.SetLeft(this.circle, this.locX);
            //canvas.Children.Add(circle);
        }

        //public void setColor(Color color)
        //{
        //    if (circle != null)
        //    {
        //        SolidColorBrush brush = new SolidColorBrush(color);
        //        circle.Fill = brush;
        //    }
        //}
    }
}
