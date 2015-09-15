using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//为Excel对象模型创建一个别名
using Excel = Microsoft.Office.Interop.Excel;

namespace Dynamic.COM
{
    public partial class Form1 : Form
    {
        List<Car> carsInStock = null;
       
        public Form1()
        {
            
            InitializeComponent();
            Form1_Load();
        }
        private void Form1_Load()
        {
            carsInStock = new List<Car>
            {
                new Car {Color="Green",Make="VW",PetName="Mary"},
                new Car {Color="Blue",Make="BMW",PetName="BB"},
                new Car {Color="Blue2",Make="BMW2",PetName="BB2"},
                new Car {Color="Blue3",Make="BMW3",PetName="BB3"}
            };
            UpdateGrid();
        }
        protected void UpdateGrid() {
            CarView.DataSource = null;
            CarView.DataSource = carsInStock;
        }
        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelFile(carsInStock);

        }

        private void CarView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ExportToExcelFile(List<Car> carsInStock){
            //创建一个新的工作薄
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            //添加一个工作表
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "PetName";

            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            //美化数据表
            workSheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            workSheet.Range["A2"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic3);
            workSheet.SaveAs(string.Format(@"{0}\ceshi.xlsx",Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("Export complete!!");
        }
    }
}
