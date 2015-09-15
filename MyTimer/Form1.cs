using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            timeonload();
            InitializeComponent();
        }
        private void timeonload()
        {
            mytime.Text = DateTime.Now.ToString();
        }
    }
}
