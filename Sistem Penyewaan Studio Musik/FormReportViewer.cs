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

        // ==================== AMBIL DATA DARI DATABASE ====================
        private DataTable GetData(string jenis)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                if (jenis.Contains("Booking"))
                {
                    string query = @"SELECT 
                                        s.nama_studio AS 'Studio',
                                        COUNT(b.id_booking) AS 'Total'
                                    FROM tbl_booking b
                                    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                    JOIN tbl_studio s ON j.id_studio = s.id_studio
                                    WHERE CAST(b.tanggal_booking AS DATE) BETWEEN @mulai AND @selesai
                                    GROUP BY s.nama_studio
                                    ORDER BY COUNT(b.id_booking) DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.Date);
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else if (jenis.Contains("Pendapatan"))
                {
                    string query = @"SELECT 
                                        s.nama_studio AS 'Studio',
                                        SUM(b.total_harga) AS 'Total'
                                    FROM tbl_booking b
                                    JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                    JOIN tbl_studio s ON j.id_studio = s.id_studio
                                    WHERE b.status IN ('selesai', 'disetujui')
                                    AND CAST(b.tanggal_booking AS DATE) BETWEEN @mulai AND @selesai
                                    GROUP BY s.nama_studio
                                    ORDER BY SUM(b.total_harga) DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.Date);
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else if (jenis.Contains("Pelanggan"))
                {
                    string query = @"SELECT TOP 10
                                        p.Nama AS 'Pelanggan',
                                        COUNT(b.id_booking) AS 'Total'
                                    FROM tbl_booking b
                                    JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                                    WHERE b.status IN ('selesai', 'disetujui')
                                    AND CAST(b.tanggal_booking AS DATE) BETWEEN @mulai AND @selesai
                                    GROUP BY p.Nama
                                    ORDER BY COUNT(b.id_booking) DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mulai", dtpMulai.Value.Date);
                    cmd.Parameters.AddWithValue("@selesai", dtpSelesai.Value.Date);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // ==================== EXPORT CHART KE PNG ====================
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Series.Count == 0)
                {
                    MessageBox.Show("Tidak ada chart untuk diexport!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Image|*.png";
                sfd.FileName = $"Laporan_Chart_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    chart1.SaveImage(sfd.FileName, ChartImageFormat.Png);
                    MessageBox.Show($"✅ Chart berhasil diexport!\n📁 {sfd.FileName}", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Export Chart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LIHAT REPORT (Crystal Report) ====================
        private void btnLihatReport_Click(object sender, EventArgs e)
        {
            if (cmbJenisLaporan.SelectedItem == null)
            {
                MessageBox.Show("Pilih jenis laporan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string jenis = cmbJenisLaporan.SelectedItem.ToString();
            string reportName = "";
            string tableName = "";
            string judul = "";

            if (jenis.Contains("Booking"))
            {
                reportName = "LaporanBooking.rpt";
                tableName = "dtBooking";
                judul = "Laporan Booking";
            }
            else if (jenis.Contains("Pendapatan"))
            {
                reportName = "LaporanPendapatan.rpt";
                tableName = "dtPendapatan";
                judul = "Laporan Pendapatan";
            }
            else if (jenis.Contains("Pelanggan"))
            {
                reportName = "LaporanPelanggan.rpt";
                tableName = "dtPelanggan";
                judul = "Laporan Pelanggan";
            }

            // Gabungkan folder aplikasi dengan nama file secara bersih
            string fullReportPath = System.IO.Path.Combine(Application.StartupPath, reportName);

            // Cek langsung ke lokasi apakah filenya beneran ada
            if (!System.IO.File.Exists(fullReportPath))
            {
                MessageBox.Show("File report tidak ditemukan!\n" + fullReportPath,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = GetData(jenis);

            // KODE BARU (Sesuaikan dengan nama variabel DataTable hasil query database kamu)
            FORMCRYSTALREPORTVIEWER form = new FORMCRYSTALREPORTVIEWER(fullReportPath, tableName, judul, dt);
            form.ShowDialog();
        }

    }
}