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

        // ==================== TOMBOL TAMPILKAN ====================
        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            LoadChart();
        }

        // ==================== CHART ====================
        private void LoadChart()
        {
            try
            {
                string jenis = cmbJenisLaporan.SelectedItem.ToString();
                DataTable dt = GetData(jenis);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk periode ini!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chart1.Series.Clear();
                    return;
                }

                // Bersihkan chart
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Buat Chart Area
                ChartArea area = new ChartArea("MainArea");
                area.AxisX.Title = "Kategori";
                area.AxisY.Title = "Jumlah";
                chart1.ChartAreas.Add(area);

                // Buat Series
                Series series = new Series();
                series.ChartType = cmbTipeChart.SelectedIndex == 0 ?
                    SeriesChartType.Column : SeriesChartType.Pie;
                series.Name = jenis;

                // Isi data
                foreach (DataRow row in dt.Rows)
                {
                    string label = row[0].ToString();
                    double value = Convert.ToDouble(row[1]);

                    DataPoint point = series.Points.Add(value);
                    point.AxisLabel = label;
                    point.Label = value.ToString("N0");
                    point.LabelForeColor = Color.White;

                    // Untuk Pie Chart, tampilkan label lebih detail
                    if (cmbTipeChart.SelectedIndex == 1)
                    {
                        point.Label = $"{label}\n{value:N0}";
                    }
                }

                chart1.Series.Add(series);

                // Set judul
                chart1.Titles.Clear();
                Title title = new Title();
                title.Text = $"{jenis} - {dtpMulai.Value:dd/MM/yyyy} s/d {dtpSelesai.Value:dd/MM/yyyy}";
                title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                title.ForeColor = Color.FromArgb(230, 57, 70);
                chart1.Titles.Add(title);

                chart1.Invalidate();
                chart1.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadChart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}