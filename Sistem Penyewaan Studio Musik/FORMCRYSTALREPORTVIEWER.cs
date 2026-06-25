using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FORMCRYSTALREPORTVIEWER : Form
    {
        private ReportDocument _report;

        // SEKARANG CONSTRUCTOR MENERIMA DATATABLE LANGSUNG AGAR TIDAK ERROR LOAD
        public FORMCRYSTALREPORTVIEWER(string reportPath, string tableName, string judul, DataTable dt)
        {
            InitializeComponent();
            this.Text = judul;

            try
            {
                _report = new ReportDocument();

                // KARENA reportPath SUDAH JALUR LENGKAP, JANGAN DITAMBAH Application.StartupPath LAGI!
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show($"File report tidak ditemukan!\n{reportPath}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 1. Load file rpt
                _report.Load(reportPath);

                // 2. Pasang data source sebelum menampilkannya ke viewer
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Menghubungkan DataTable sesuai skema table di dsReport
                    _report.Database.Tables[tableName].SetDataSource(dt);
                }
                else
                {
                    MessageBox.Show("Data query kosong, laporan mungkin tidak menampilkan data.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 3. Tampilkan ke viewer
                crystalReportViewer1.ReportSource = _report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tombol Tutup
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FORMCRYSTALREPORTVIEWER_Load(object sender, EventArgs e)
        {
            // Biarkan kosong
        }

        
    }
}