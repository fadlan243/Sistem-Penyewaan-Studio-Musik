using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormReportViewer : Form
    {
        private readonly string connString = ("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");

        public FormReportViewer()
        {
            InitializeComponent();
        }

        private void FormReportViewer_Load(object sender, EventArgs e)
        {
            // Default tanggal
            dtpMulai.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpSelesai.Value = DateTime.Now;

            // Isi ComboBox Laporan
            cmbJenisLaporan.Items.Clear();
            cmbJenisLaporan.Items.Add("📊 Laporan Booking");
            cmbJenisLaporan.Items.Add("💰 Laporan Pendapatan");
            cmbJenisLaporan.Items.Add("👤 Laporan Pelanggan");
            cmbJenisLaporan.SelectedIndex = 0;

            // Isi ComboBox Tipe Chart
            cmbTipeChart.Items.Clear();
            cmbTipeChart.Items.Add("📊 Bar Chart");
            cmbTipeChart.Items.Add("🥧 Pie Chart");
            cmbTipeChart.SelectedIndex = 0;

            LoadChart();
        }

        
    }
}