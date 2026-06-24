using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormLaporan : Form
    {
        private readonly string connString = "Data Source=192.168.1.5,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;";

        private int id_admin;
        private string nama_admin;

        // Simpan nilai statistik untuk dipakai SimpanLaporan
        private int _totalBooking = 0;
        private decimal _totalPendapatan = 0;

        public FormLaporan(int id_admin = 1, string nama_admin = "Admin")
        {
            InitializeComponent();
            this.id_admin = id_admin;
            this.nama_admin = nama_admin;

            dtpTglMulai.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTglSelesai.Value = DateTime.Now;

            GenerateNamaFile();
        }

        private void GenerateNamaFile()
        {
            string tglMulai = dtpTglMulai.Value.ToString("yyyyMMdd");
            string tglSelesai = dtpTglSelesai.Value.ToString("yyyyMMdd");
            txtNamaFile.Text = $"laporan_{tglMulai}_{tglSelesai}";
        }

        // ==================== HITUNG STATISTIK ====================
        private void HitungStatistik(DateTime tglMulai, DateTime tglSelesai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Total Booking
                    SqlCommand cmdTotalBooking = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE CAST(created_at AS DATE) BETWEEN @mulai AND @selesai", conn);
                    cmdTotalBooking.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdTotalBooking.Parameters.AddWithValue("@selesai", tglSelesai);
                    _totalBooking = (int)cmdTotalBooking.ExecuteScalar();

                    // Booking Disetujui
                    SqlCommand cmdDisetujui = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE status = 'disetujui' AND CAST(created_at AS DATE) BETWEEN @mulai AND @selesai", conn);
                    cmdDisetujui.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdDisetujui.Parameters.AddWithValue("@selesai", tglSelesai);
                    int disetujui = (int)cmdDisetujui.ExecuteScalar();

                    // Booking Selesai
                    SqlCommand cmdSelesai = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE status = 'selesai' AND CAST(created_at AS DATE) BETWEEN @mulai AND @selesai", conn);
                    cmdSelesai.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdSelesai.Parameters.AddWithValue("@selesai", tglSelesai);
                    int selesai = (int)cmdSelesai.ExecuteScalar();

                    // Booking Ditolak
                    SqlCommand cmdDitolak = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE status = 'ditolak' AND CAST(created_at AS DATE) BETWEEN @mulai AND @selesai", conn);
                    cmdDitolak.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdDitolak.Parameters.AddWithValue("@selesai", tglSelesai);
                    int ditolak = (int)cmdDitolak.ExecuteScalar();

                    // Total Pendapatan
                    SqlCommand cmdPendapatan = new SqlCommand(
                        "SELECT ISNULL(SUM(total_harga), 0) FROM tbl_booking WHERE (status = 'disetujui' OR status = 'selesai') AND CAST(created_at AS DATE) BETWEEN @mulai AND @selesai", conn);
                    cmdPendapatan.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdPendapatan.Parameters.AddWithValue("@selesai", tglSelesai);
                    _totalPendapatan = (decimal)cmdPendapatan.ExecuteScalar();

                    // Rata-rata per Booking
                    int totalBookingForAvg = disetujui + selesai;
                    decimal rataRata = totalBookingForAvg > 0 ? _totalPendapatan / totalBookingForAvg : 0;

                    // Studio Terpopuler
                    SqlCommand cmdStudio = new SqlCommand(
                        @"SELECT TOP 1 s.nama_studio FROM tbl_booking b
                          JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                          JOIN tbl_studio s ON j.id_studio = s.id_studio
                          WHERE CAST(b.created_at AS DATE) BETWEEN @mulai AND @selesai
                          GROUP BY s.nama_studio ORDER BY COUNT(b.id_booking) DESC", conn);
                    cmdStudio.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdStudio.Parameters.AddWithValue("@selesai", tglSelesai);
                    object studioResult = cmdStudio.ExecuteScalar();
                    string studioTerpopuler = studioResult != null ? studioResult.ToString() : "-";

                    // Pelanggan Teraktif
                    SqlCommand cmdPelanggan = new SqlCommand(
                        @"SELECT TOP 1 p.Nama FROM tbl_booking b
                          JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                          WHERE CAST(b.created_at AS DATE) BETWEEN @mulai AND @selesai
                          GROUP BY p.Nama ORDER BY COUNT(b.id_booking) DESC", conn);
                    cmdPelanggan.Parameters.AddWithValue("@mulai", tglMulai);
                    cmdPelanggan.Parameters.AddWithValue("@selesai", tglSelesai);
                    object pelangganResult = cmdPelanggan.ExecuteScalar();
                    string pelangganTeraktif = pelangganResult != null ? pelangganResult.ToString() : "-";

                    
                    // ✅ ISI TEXTBOX OTOMATIS DARI VALUE DI ATAS
                    txtTotalBooking.Text = _totalBooking.ToString();
                    txtDisetujui.Text = disetujui.ToString();
                    txtSelesai.Text = selesai.ToString();
                    txtDitolak.Text = ditolak.ToString();
                    txtPendapatan.Text = "Rp " + _totalPendapatan.ToString("N0");
                    txtRataRata.Text = "Rp " + rataRata.ToString("N0");
                    txtTerpopuler.Text = studioTerpopuler;
                    txtTeraktif.Text = pelangganTeraktif;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error HitungStatistik: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== HITUNG DETAIL PERIODE ====================
        private void HitungDetailPeriode(DateTime tglMulai, DateTime tglSelesai)
        {
            int lamaHari = (tglSelesai - tglMulai).Days + 1;
            int jumlahMinggu = lamaHari / 7;
            int sisaHari = lamaHari % 7;

            string detailMinggu = jumlahMinggu > 0
                ? $"{jumlahMinggu} minggu" + (sisaHari > 0 ? $" {sisaHari} hari" : "")
                : $"{lamaHari} hari";

            string detailText = $"{tglMulai:dd/MM/yyyy} - {tglSelesai:dd/MM/yyyy}  |  Lama: {lamaHari} hari  |  {detailMinggu}";

            lblDetailPeriode.Text = detailText;

            // ✅ ISI TEXTBOX 9 UNTUK DETAIL PERIODE
            txtPeriode.Text = detailText;
        }

        // ==================== LOAD PREVIEW DATA ====================
        private void LoadPreviewData(DateTime tglMulai, DateTime tglSelesai)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT ROW_NUMBER() OVER (ORDER BY b.created_at) as No,
                                            b.tanggal_booking as Tanggal,
                                            p.Nama as Pelanggan,
                                            s.nama_studio as Studio,
                                            b.durasi_jam as Durasi,
                                            b.total_harga as TotalHarga,
                                            b.status as Status
                                     FROM tbl_booking b
                                     JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE CAST(b.created_at AS DATE) BETWEEN @mulai AND @selesai
                                     ORDER BY b.tanggal_booking DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@mulai", tglMulai);
                    da.SelectCommand.Parameters.AddWithValue("@selesai", tglSelesai);
                    DataTable dtPreview = new DataTable();
                    da.Fill(dtPreview);

                    dgvPreview.DataSource = dtPreview;
                }

                if (dgvPreview.Columns.Count > 0)
                {
                    if (dgvPreview.Columns.Contains("No")) { dgvPreview.Columns["No"].HeaderText = "No"; dgvPreview.Columns["No"].Width = 50; }
                    if (dgvPreview.Columns.Contains("Tanggal")) { dgvPreview.Columns["Tanggal"].HeaderText = "Tanggal"; dgvPreview.Columns["Tanggal"].Width = 100; dgvPreview.Columns["Tanggal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; }
                    if (dgvPreview.Columns.Contains("Pelanggan")) { dgvPreview.Columns["Pelanggan"].HeaderText = "Pelanggan"; dgvPreview.Columns["Pelanggan"].Width = 180; }
                    if (dgvPreview.Columns.Contains("Studio")) { dgvPreview.Columns["Studio"].HeaderText = "Studio"; dgvPreview.Columns["Studio"].Width = 150; }
                    if (dgvPreview.Columns.Contains("Durasi")) { dgvPreview.Columns["Durasi"].HeaderText = "Durasi (Jam)"; dgvPreview.Columns["Durasi"].Width = 80; }
                    if (dgvPreview.Columns.Contains("TotalHarga")) { dgvPreview.Columns["TotalHarga"].HeaderText = "Total Harga"; dgvPreview.Columns["TotalHarga"].Width = 120; dgvPreview.Columns["TotalHarga"].DefaultCellStyle.Format = "N0"; }
                    if (dgvPreview.Columns.Contains("Status")) { dgvPreview.Columns["Status"].HeaderText = "Status"; dgvPreview.Columns["Status"].Width = 100; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadPreview: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== SIMPAN LAPORAN ====================
        private void SimpanLaporan()
        {
            try
            {
                DateTime tglMulai = dtpTglMulai.Value.Date;
                DateTime tglSelesai = dtpTglSelesai.Value.Date;
                string namaFile = txtNamaFile.Text;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"INSERT INTO tbl_laporan (dibuat_oleh, periode_mulai, periode_selesai, 
                                       total_booking, total_pendapatan, file_laporan, tgl_buat) 
                                     VALUES (@dibuat_oleh, @mulai, @selesai, @total_booking, @total_pendapatan, @file, @tgl_buat)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dibuat_oleh", id_admin);
                    cmd.Parameters.AddWithValue("@mulai", tglMulai);
                    cmd.Parameters.AddWithValue("@selesai", tglSelesai);
                    cmd.Parameters.AddWithValue("@total_booking", _totalBooking);
                    cmd.Parameters.AddWithValue("@total_pendapatan", _totalPendapatan);
                    cmd.Parameters.AddWithValue("@file", namaFile);
                    cmd.Parameters.AddWithValue("@tgl_buat", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Laporan berhasil disimpan ke database!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SimpanLaporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== REFRESH FORM ====================
        private void RefreshForm()
        {
            dtpTglMulai.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTglSelesai.Value = DateTime.Now;

            // ✅ Reset textbox juga
            txtDisetujui.Clear();
            txtDitolak.Clear();
            txtPendapatan.Clear();
            txtTeraktif.Clear();
            txtTotalBooking.Clear();
            txtTerpopuler.Clear();
            txtRataRata.Clear();
            txtSelesai.Clear();
            txtPeriode.Clear();

            dgvPreview.DataSource = null;
            _totalBooking = 0;
            _totalPendapatan = 0;

            GenerateNamaFile();
        }

        // ==================== EVENT HANDLERS ====================
        private void FormLaporan_Load(object sender, EventArgs e) { }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tglMulai = dtpTglMulai.Value.Date;
                DateTime tglSelesai = dtpTglSelesai.Value.Date;

                if (tglMulai > tglSelesai)
                {
                    MessageBox.Show("Tanggal Mulai tidak boleh lebih besar dari Tanggal Selesai!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HitungStatistik(tglMulai, tglSelesai);
                HitungDetailPeriode(tglMulai, tglSelesai);
                LoadPreviewData(tglMulai, tglSelesai);
                GenerateNamaFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpanLaporan_Click(object sender, EventArgs e)
        {
            if (lblTotalBooking.Text == "-")
            {
                MessageBox.Show("Harap klik 'Hitung' terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SimpanLaporan();
        }

        private void btnRefresh_Click(object sender, EventArgs e) { RefreshForm(); }
        private void btnTutup_Click(object sender, EventArgs e) { this.Close(); }
        private void dtpTglMulai_ValueChanged(object sender, EventArgs e) { GenerateNamaFile(); }
        private void dtpTglSelesai_ValueChanged(object sender, EventArgs e) { GenerateNamaFile(); }
        private void txtNamaFile_TextChanged(object sender, EventArgs e) { }
        private void dgvPreview_CellClick(object sender, DataGridViewCellEventArgs e) { }

        // Label click handlers kosong
        private void lblPeriode_Click(object sender, EventArgs e) { }
        private void lblTglMulai_Click(object sender, EventArgs e) { }
        private void lblTglSelesai_Click(object sender, EventArgs e) { }
        private void lblRingkasan_Click(object sender, EventArgs e) { }
        private void lblStatistik_Click(object sender, EventArgs e) { }
        private void lblTotalBooking_Click(object sender, EventArgs e) { }
        private void lblTotalDiSetujui_Click(object sender, EventArgs e) { }
        private void lblTotalSelesai_Click(object sender, EventArgs e) { }
        private void lblTotalDibatalkan_Click(object sender, EventArgs e) { }
        private void lblPelangganTeraktif_Click(object sender, EventArgs e) { }
        private void lblStudioTerpopuler_Click(object sender, EventArgs e) { }
        private void lblTotalPendapatan_Click(object sender, EventArgs e) { }
        private void lblRataRata_Click(object sender, EventArgs e) { }
        private void lblPendapatan_Click(object sender, EventArgs e) { }
        private void lblPreview_Click(object sender, EventArgs e) { }
        private void lblNamaFile_Click(object sender, EventArgs e) { }
        private void lblDetailPeriode_Click(object sender, EventArgs e) { }

        // TextBox change handlers kosong
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void textBox9_TextChanged(object sender, EventArgs e) { }
    }
}