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
            String excelFilepath = Application.StartupPath + @"\" + excelFilename;
            label1.Text = Application.StartupPath + @"\" + excelFilename;

        }
    }
}
