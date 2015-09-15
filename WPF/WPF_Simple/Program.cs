using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Simple
{
    class Program:System.Windows.Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            Program app = new Program();
            app.Startup += AppStartUp;
            app.Exit += AppExit;
            app.Run();
        }
        static void AppExit(object sender, ExitEventArgs e)
        {
            MessageBox.Show("App has exited");
        }
        static void AppStartUp(object sender, StartupEventArgs e)
        {
            Window mainWin = new Window();
            mainWin.Title = "My fitst WPF APP!";
            mainWin.Height = 200;
            mainWin.Width = 300;
            mainWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWin.Show();
        }
    }
}
