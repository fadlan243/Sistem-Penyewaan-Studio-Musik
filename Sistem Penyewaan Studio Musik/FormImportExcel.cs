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

        // ==================== BROWSE FILE EXCEL ====================
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls";
                ofd.Title = "Pilih File Excel Studio";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    txtFilePath.Text = selectedFilePath;
                    PreviewExcel();
                }
            }
        }

        // ==================== PREVIEW DATA DARI EXCEL ====================
        private void PreviewExcel()
        {
            try
            {
                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBox.Show("Pilih file Excel terlebih dahulu!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var package = new ExcelPackage(new FileInfo(selectedFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    if (worksheet == null)
                    {
                        MessageBox.Show("Sheet tidak ditemukan!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dtPreview = new DataTable();

                    // Header (baris pertama)
                    int colCount = worksheet.Dimension.Columns;
                    for (int col = 1; col <= colCount; col++)
                    {
                        string header = worksheet.Cells[1, col].Value?.ToString();
                        if (string.IsNullOrEmpty(header))
                            header = "Kolom " + col;
                        dtPreview.Columns.Add(header);
                    }

                    // Data (baris 2 - seterusnya)
                    int rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= Math.Min(rowCount, 100); row++)
                    {
                        DataRow dataRow = dtPreview.NewRow();
                        for (int col = 1; col <= colCount; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Value?.ToString() ?? "";
                        }
                        dtPreview.Rows.Add(dataRow);
                    }

                    dataGridView1.DataSource = dtPreview;

                    lblRowCount.Text = $"📊 Total data: {rowCount - 1} baris | Preview: {dtPreview.Rows.Count} baris";

                    // Aktifkan tombol import jika ada data
                    if (dtPreview.Rows.Count > 0)
                    {
                        btnImport.Enabled = true;
                        btnImport.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
                    }
                    else
                    {
                        btnImport.Enabled = false;
                        btnImport.BackColor = System.Drawing.Color.Gray;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error PreviewExcel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}