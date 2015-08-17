using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace testforwpf
{
    /// <summary>
    /// define the virtual class for drawing shapes
    /// </summary>
    class DrawingShapes
    {
        private int size;
        private int locX = 0, locY = 0;
        protected Shape shape = null;

        public DrawingShapes(int size)
        {
            this.size = size;
        }

        public void setLocation(int X, int Y)
        {
            this.locX = X;
            this.locY = Y;
        }

        public void setColor(Color color)
        {
            if (shape != null)
            {
                SolidColorBrush brush = new SolidColorBrush(color);
                shape.Fill = brush;
            }
        }

        public virtual void draw(Canvas canvas)
        {
            if (this.shape == null)
            {
                throw new ApplicationException("shape is null");
            }

            this.shape.Height = this.size;
            this.shape.Width = this.size;
            Canvas.SetTop(this.shape, this.locX);
            Canvas.SetLeft(this.shape, this.locY);
            canvas.Children.Add(shape);
        }

    }
}
