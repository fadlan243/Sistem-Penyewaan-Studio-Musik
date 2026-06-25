using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormRiwayatBookingPelanggan : Form
    {
        private readonly string connString = ("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");

        private int id_pelanggan;
        private string nama_pelanggan;
        private int selectedIdBooking = 0;

        public FormRiwayatBookingPelanggan(int id_pelanggan, string nama_pelanggan)
        {
            InitializeComponent();
            this.id_pelanggan = id_pelanggan;
            this.nama_pelanggan = nama_pelanggan;

            LoadRiwayatBooking();
            UpdateStatistik();
            ClearDetail();
        }

        // ==================== LOAD RIWAYAT BOOKING PAKAI SP ====================
        private void LoadRiwayatBooking()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("sp_SearchRiwayatBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                    cmd.Parameters.AddWithValue("@status", "semua");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();

                    dgvRiwayatBooking.DataSource = dt;
                }

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadRiwayatBooking: " + ex.Message);
            }
        }

        // ==================== FORMAT DATAGRIDVIEW ====================
        private void FormatDataGridView()
        {
            if (dgvRiwayatBooking.Columns.Count == 0) return;

            if (dgvRiwayatBooking.Columns.Contains("id_pelanggan"))
                dgvRiwayatBooking.Columns["id_pelanggan"].Visible = false;

            if (dgvRiwayatBooking.Columns.Contains("id_booking"))
                dgvRiwayatBooking.Columns["id_booking"].HeaderText = "ID";
            if (dgvRiwayatBooking.Columns.Contains("nama_studio"))
                dgvRiwayatBooking.Columns["nama_studio"].HeaderText = "Studio";
            if (dgvRiwayatBooking.Columns.Contains("tanggal"))
            {
                dgvRiwayatBooking.Columns["tanggal"].HeaderText = "Tanggal Sewa";
                dgvRiwayatBooking.Columns["tanggal"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvRiwayatBooking.Columns.Contains("jam_mulai"))
                dgvRiwayatBooking.Columns["jam_mulai"].HeaderText = "Jam Mulai";
            if (dgvRiwayatBooking.Columns.Contains("jam_selesai"))
                dgvRiwayatBooking.Columns["jam_selesai"].HeaderText = "Jam Selesai";
            if (dgvRiwayatBooking.Columns.Contains("durasi_jam"))
                dgvRiwayatBooking.Columns["durasi_jam"].HeaderText = "Durasi (Jam)";
            if (dgvRiwayatBooking.Columns.Contains("total_harga"))
            {
                dgvRiwayatBooking.Columns["total_harga"].HeaderText = "Total Harga";
                dgvRiwayatBooking.Columns["total_harga"].DefaultCellStyle.Format = "N0";
            }
            if (dgvRiwayatBooking.Columns.Contains("status"))
                dgvRiwayatBooking.Columns["status"].HeaderText = "Status";

            dgvRiwayatBooking.CellFormatting -= DgvRiwayatBooking_CellFormatting;
            dgvRiwayatBooking.CellFormatting += DgvRiwayatBooking_CellFormatting;
        }

        private void DgvRiwayatBooking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRiwayatBooking.Columns.Contains("status") &&
                e.ColumnIndex == dgvRiwayatBooking.Columns["status"].Index && e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "menunggu": e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7); break;
                    case "disetujui": e.CellStyle.ForeColor = Color.FromArgb(76, 175, 80); break;
                    case "ditolak": e.CellStyle.ForeColor = Color.FromArgb(244, 67, 54); break;
                    case "selesai": e.CellStyle.ForeColor = Color.FromArgb(33, 150, 243); break;
                }
            }
        }

        // ==================== LOAD DETAIL BOOKING ====================
        private void LoadDetailBooking(int id_booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT b.id_booking, s.nama_studio, j.tanggal, 
                                            j.jam_mulai, j.jam_selesai, b.durasi_jam, 
                                            b.total_harga, b.status, b.catatan,
                                            py.status as status_bayar, py.jumlah_bayar, 
                                            py.metode_bayar, py.tgl_pembayaran, py.catatan_admin
                                     FROM tbl_booking b
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     LEFT JOIN tbl_pembayaran py ON b.id_booking = py.id_booking
                                     WHERE b.id_booking = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_booking);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtIDBooking.Text = reader["id_booking"].ToString();
                        txtStudio.Text = reader["nama_studio"].ToString();
                        txtTglSewa.Text = Convert.ToDateTime(reader["tanggal"]).ToString("dd/MM/yyyy");
                        txtJamMulai.Text = reader["jam_mulai"].ToString();
                        txtSelesai.Text = reader["jam_selesai"].ToString();
                        txtDurasi.Text = reader["durasi_jam"].ToString() + " Jam";
                        txtTotalHarga.Text = "Rp " + Convert.ToDecimal(reader["total_harga"]).ToString("N0");
                        txtCatatan.Text = reader["catatan"]?.ToString() ?? "-";
                        txtStatusBooking.Text = reader["status"].ToString();

                        string statusBayar = reader["status_bayar"]?.ToString() ?? "";
                        txtStatusBayar.Text = string.IsNullOrEmpty(statusBayar) ? "Belum Dibayar"
                            : statusBayar == "dikonfirmasi" ? "Lunas" : statusBayar;

                        txtJumlahBayar.Text = reader["jumlah_bayar"] != DBNull.Value
                            ? "Rp " + Convert.ToDecimal(reader["jumlah_bayar"]).ToString("N0") : "-";
                        txtMetodeBayar.Text = reader["metode_bayar"]?.ToString() ?? "-";
                        txtTglBayar.Text = reader["tgl_pembayaran"] != DBNull.Value
                            ? Convert.ToDateTime(reader["tgl_pembayaran"]).ToString("dd/MM/yyyy HH:mm") : "-";
                        txtCatatanAdmin.Text = reader["catatan_admin"]?.ToString() ?? "-";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDetailBooking: " + ex.Message);
            }
        }

        // ==================== UPDATE STATISTIK ====================
        private void UpdateStatistik()
        {
            try
            {
                int total = 0, menunggu = 0, disetujui = 0, selesai = 0, ditolak = 0;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmdTotal = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE id_pelanggan = @id", conn);
                    cmdTotal.Parameters.AddWithValue("@id", id_pelanggan);
                    total = (int)cmdTotal.ExecuteScalar();

                    SqlCommand cmdMenunggu = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE id_pelanggan = @id AND status = 'menunggu'", conn);
                    cmdMenunggu.Parameters.AddWithValue("@id", id_pelanggan);
                    menunggu = (int)cmdMenunggu.ExecuteScalar();

                    SqlCommand cmdDisetujui = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE id_pelanggan = @id AND status = 'disetujui'", conn);
                    cmdDisetujui.Parameters.AddWithValue("@id", id_pelanggan);
                    disetujui = (int)cmdDisetujui.ExecuteScalar();

                    SqlCommand cmdSelesai = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE id_pelanggan = @id AND status = 'selesai'", conn);
                    cmdSelesai.Parameters.AddWithValue("@id", id_pelanggan);
                    selesai = (int)cmdSelesai.ExecuteScalar();

                    SqlCommand cmdDitolak = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_booking WHERE id_pelanggan = @id AND status = 'ditolak'", conn);
                    cmdDitolak.Parameters.AddWithValue("@id", id_pelanggan);
                    ditolak = (int)cmdDitolak.ExecuteScalar();
                }

                lblStatistik.Text = $"📊 STATISTIK: Total: {total} | Menunggu: {menunggu} | Disetujui: {disetujui} | Selesai: {selesai} | Ditolak: {ditolak}";
            }
            catch
            {
                lblStatistik.Text = "📊 STATISTIK: Error loading data";
            }
        }

        // ==================== CLEAR DETAIL ====================
        private void ClearDetail()
        {
            txtIDBooking.Clear();
            txtStudio.Clear();
            txtTglSewa.Clear();
            txtJamMulai.Clear();
            txtSelesai.Clear();
            txtDurasi.Clear();
            txtTotalHarga.Clear();
            txtCatatan.Clear();
            txtStatusBooking.Clear();
            txtStatusBayar.Clear();
            txtJumlahBayar.Clear();
            txtMetodeBayar.Clear();
            txtTglBayar.Clear();
            txtCatatanAdmin.Clear();
        }

        // ==================== TOMBOL REFRESH ====================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayatBooking();
            UpdateStatistik();
            ClearDetail();
            MessageBox.Show("Data berhasil direfresh!", "Info");
        }

        // ==================== TOMBOL TUTUP ====================
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==================== DGV CELL CLICK ====================
        private void dgvRiwayatBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value != null)
            {
                selectedIdBooking = Convert.ToInt32(dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value);
                LoadDetailBooking(selectedIdBooking);
            }
        }

        // ==================== EVENT KOSONG ====================
        private void FormRiwayatBookingPelanggan_Load(object sender, EventArgs e) { }
        private void lblDetailBooking_Click(object sender, EventArgs e) { }
        private void lblJudul_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblInfoBooking_Click(object sender, EventArgs e) { }
        private void lblIdBooking_Click(object sender, EventArgs e) { }
        private void lblStudio_Click(object sender, EventArgs e) { }
        private void lblTanggalSewa_Click(object sender, EventArgs e) { }
        private void lblJamMulai_Click(object sender, EventArgs e) { }
        private void lblJamSelesai_Click(object sender, EventArgs e) { }
        private void lblDurasi_Click(object sender, EventArgs e) { }
        private void lblTotalHarga_Click(object sender, EventArgs e) { }
        private void lblCatatan_Click(object sender, EventArgs e) { }
        private void lblStatusBooking_Click(object sender, EventArgs e) { }
        private void lblStatusBayar_Click(object sender, EventArgs e) { }
        private void lblInformasiPembayaran_Click(object sender, EventArgs e) { }
        private void lblJumlahBayar_Click(object sender, EventArgs e) { }
        private void lblMetodeBayar_Click(object sender, EventArgs e) { }
        private void lblTglBayar_Click(object sender, EventArgs e) { }
        private void lblCatatanAdmin_Click(object sender, EventArgs e) { }
        private void lblDaftarBooking_Click(object sender, EventArgs e) { }
        private void lblStatistik_Click(object sender, EventArgs e) { }
        private void btnBayar_Click(object sender, EventArgs e) { } // Kosong jika tidak perlu
    }
}