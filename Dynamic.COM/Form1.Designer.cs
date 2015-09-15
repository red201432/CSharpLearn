namespace Dynamic.COM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CarView = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.ExportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CarView)).BeginInit();
            this.SuspendLayout();
            // 
            // CarView
            // 
            this.CarView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarView.Location = new System.Drawing.Point(13, 13);
            this.CarView.Name = "CarView";
            this.CarView.RowTemplate.Height = 23;
            this.CarView.Size = new System.Drawing.Size(674, 150);
            this.CarView.TabIndex = 0;
            this.CarView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CarView_CellContentClick);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(76, 196);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(256, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add new Data";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ExportToExcel
            // 
            this.ExportToExcel.Location = new System.Drawing.Point(380, 196);
            this.ExportToExcel.Name = "ExportToExcel";
            this.ExportToExcel.Size = new System.Drawing.Size(256, 23);
            this.ExportToExcel.TabIndex = 2;
            this.ExportToExcel.Text = "Export data to Excel";
            this.ExportToExcel.UseVisualStyleBackColor = true;
            this.ExportToExcel.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 262);
            this.Controls.Add(this.ExportToExcel);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.CarView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.CarView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CarView;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button ExportToExcel;
    }
}

