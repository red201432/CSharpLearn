using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace testforwpf
{
    /// <summary>
    /// ClickForm.xaml 的交互逻辑
    /// </summary>
    public partial class ClickForm : Window
    {
        public ClickForm()
        {
            InitializeComponent();
            
        }
        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mouseLocation = e.GetPosition(this.drawCanvas);
            Square mySquars = new Square(100);

            if (mySquars is IDraw)
            {
                IDraw drawSquare = mySquars;
                drawSquare.setLocation((int)mouseLocation.X, (int)mouseLocation.Y);
                drawSquare.draw(drawCanvas);
            }

            if (mySquars is IColor)
            {
                IColor colorSquare = mySquars;
                colorSquare.setColor(Colors.Blue);
            }
        }
        /// <summary>
        /// 重写OnClosing事件 解决窗口关闭不能再开的bug。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.drawCanvas.Children.Clear();
            this.Hide();
            e.Cancel = true;
            //System.Environment.Exit(0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.drawCanvas.Children.Clear();
        }
    }
}
