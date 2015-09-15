using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonSnappableTypes;
using System.Windows.Forms;
namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName="MyCompany",CompanyUrl="www.MyCompany.com")]
   public class CSharpModule:IAppFunctionality
    {
        void IAppFunctionality.DoIt()
        {
            MessageBox.Show("You have just used the C# snap in!");
        }
        void sayHello()
        {
            MessageBox.Show("Hello world,By C#");
        }
    }
}
