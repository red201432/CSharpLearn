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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testforwpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Counter oCounter = new Counter();

        public MainWindow()
        {
            oCounter.NumberReached += new NumberReachedEventHandler(oCounter_NumberReached);

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            txtReachable.Text = DateTime.Now.ToString();
            textBlock1.Text = ((int)'Ā').ToString();
            if (txtCountTo.Text == "" || txtReachable.Text == "")

                return;

            oCounter.CountTo(Convert.ToInt32(txtCountTo.Text), Convert.ToInt32(txtReachable.Text)); 

        }
        private void oCounter_NumberReached(object sender, NumberReachedEventArgs e)
        {

            MessageBox.Show("Reached: " + e.ReachedNumber.ToString());

        } 

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
