using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonSnappableTypes;
using System.Reflection;
namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void snapInMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //允许用户选择一个程序集加载
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                {
                    //LoadExternalModule(dlg.FileName);
                    MessageBox.Show("CommonSnappableTypes has no snap-ins");
                }
                else if (!LoadExternalModule(dlg.FileName))
                    MessageBox.Show("Nothing implements IAppFunctionality");
            }
        }
        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly snapAsm = null;
            try
            {
                snapAsm = Assembly.LoadFrom(path);//将动态程序集加入到内存
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }
            var theClassTypes = from t in snapAsm.GetTypes()
                                where t.IsClass && (t.GetInterface("IAppFunctionality") != null)
                                select t;//判断IAppFunctionality是否在程序集内
            //创建对象调用DoIt
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;
                //使用晚期绑定建立类型
                IAppFunctionality itfApp = (IAppFunctionality)snapAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();//调用的方法必须在接口内进行定义
                
                lstLoadedSnapIns.Items.Add(t.FullName);
            }
            return foundSnapIn;
        }
    }
}
