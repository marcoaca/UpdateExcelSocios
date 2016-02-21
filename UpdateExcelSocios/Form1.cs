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
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Smo;
using System.Data.Sql;

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
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.Workbooks.Open(excelFilepath);
        }

        private void sociosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sociosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
            
            dataGridView2.DataSource = dataTable;

            Server srv = new Server(@".\SQLEXPRESS");
            if (srv == null)
            {
                Console.WriteLine(srv.Information.Version);
                Database db = srv.Databases["AssociGestorDb"];
                Backup bk = new Backup();
                bk.Action = BackupActionType.Database;
                bk.BackupSetDescription = "Full backup of AssociGestorDb";
                bk.BackupSetName = "AssociGestorDb Backup";
                bk.Database = "AssociGestorDb";
                BackupDeviceItem bdi = new BackupDeviceItem(@"c:\temp\AssociGestorDb" + DateTime.Now.ToString("_yyyyMMdd"), DeviceType.File);
                bk.Devices.Add(bdi);
                bk.Incremental = false;
                bk.LogTruncation = BackupTruncateLogType.Truncate;
                bk.SqlBackup(srv);
            }
            else
            {
                MessageBox.Show("No server found.");
            }


        }
    }
}
