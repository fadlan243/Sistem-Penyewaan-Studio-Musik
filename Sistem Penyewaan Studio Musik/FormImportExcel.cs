using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormImportExcel : Form
    {
        string connString = ("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");
        private DataTable dtPreview = new DataTable();
        private string selectedFilePath = "";

        public FormImportExcel()
        {
            InitializeComponent();
        }

        // ==================== LOAD FORM ====================
        private void FormImportExcel_Load(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnImport.BackColor = System.Drawing.Color.Gray;
        }

    }
}