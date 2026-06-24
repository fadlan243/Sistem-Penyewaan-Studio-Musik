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
        string connString = "Data Source=192.168.1.5,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;";
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

        // ==================== IMPORT DATA KE DATABASE ====================
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dtPreview.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diimport!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Yakin ingin mengimport {dtPreview.Rows.Count} data studio?\n\n" +
                "Data yang sudah ada dengan nama yang sama akan dilewati (tidak diduplikasi).",
                "Konfirmasi Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(selectedFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    int successCount = 0;
                    int skipCount = 0;
                    int errorCount = 0;
                    string errors = "";

                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                string nama_studio = worksheet.Cells[row, 1].Value?.ToString()?.Trim();
                                if (string.IsNullOrEmpty(nama_studio))
                                {
                                    skipCount++;
                                    continue;
                                }

                                int.TryParse(worksheet.Cells[row, 2].Value?.ToString(), out int kapasitas);

                                decimal harga = 0;
                                string hargaText = worksheet.Cells[row, 3].Value?.ToString()?.Trim()
                                    .Replace("Rp", "").Replace(".", "").Replace(",", "");
                                if (!string.IsNullOrEmpty(hargaText))
                                    decimal.TryParse(hargaText, out harga);

                                string deskripsi = worksheet.Cells[row, 4].Value?.ToString()?.Trim() ?? "";
                                string status = worksheet.Cells[row, 5].Value?.ToString()?.Trim().ToLower() ?? "aktif";
                                if (status != "aktif" && status != "nonaktif")
                                    status = "aktif";

                                // Cek duplikat
                                string checkQuery = "SELECT COUNT(*) FROM tbl_studio WHERE nama_studio = @nama";
                                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                                checkCmd.Parameters.AddWithValue("@nama", nama_studio);
                                int exists = (int)checkCmd.ExecuteScalar();

                                if (exists > 0)
                                {
                                    skipCount++;
                                    continue;
                                }

                                // Insert data
                                string insertQuery = @"INSERT INTO tbl_studio (nama_studio, kapasitas, harga_per_jam, deskripsi, status, created_at) 
                                                       VALUES (@nama, @kapasitas, @harga, @deskripsi, @status, GETDATE())";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                                insertCmd.Parameters.AddWithValue("@nama", nama_studio);
                                insertCmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                                insertCmd.Parameters.AddWithValue("@harga", harga);
                                insertCmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                                insertCmd.Parameters.AddWithValue("@status", status);
                                insertCmd.ExecuteNonQuery();

                                successCount++;
                            }
                            catch (Exception ex)
                            {
                                errorCount++;
                                errors += $"Baris {row}: {ex.Message}\n";
                            }
                        }
                    }

                    string message = $"✅ IMPORT SELESAI!\n\n" +
                                     $"✅ Berhasil: {successCount} data\n" +
                                     $"⏭️ Dilewati (duplikat): {skipCount} data\n" +
                                     $"❌ Error: {errorCount} data";

                    if (errorCount > 0)
                        message += $"\n\nDetail Error:\n{errors}";

                    MessageBox.Show(message, "Hasil Import", MessageBoxButtons.OK,
                        errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);

                    // Refresh preview
                    PreviewExcel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Import: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== TOMBOL TUTUP ====================
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==================== EVENT LAINNYA (TIDAK DIGUNAKAN) ====================
        private void label1_Click(object sender, EventArgs e) { }
        private void txtFilePath_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblRowCount_Click(object sender, EventArgs e) { }
    }
}