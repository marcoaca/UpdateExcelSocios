using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace UpdateExcelSocios
{
    public partial class Form1 : Form
    {
        
        string excelFilename = Properties.Settings.Default.fileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.Anos' table. You can move, or remove it, as needed.
            this.anosTableAdapter.Fill(this.dataSet.Anos);
            // TODO: This line of code loads data into the 'dataSet.Socios' table. You can move, or remove it, as needed.
            this.sociosTableAdapter.Fill(this.dataSet.Socios);
            // TODO: This line of code loads data into the 'dataSet.Socios' table. You can move, or remove it, as needed.
            this.sociosTableAdapter.Fill(this.dataSet.Socios);
            // TODO: This line of code loads data into the 'dataSet.Socios' table. You can move, or remove it, as needed.
            this.sociosTableAdapter.Fill(this.dataSet.Socios);
            String excelFilepath = Application.StartupPath + @"\" + excelFilename;
            

        }

        private void sociosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sociosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);

        }
    }
}
