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

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormRiwayatBookingPelanggan : Form
    {
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";

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

        // ==================== LOAD RIWAYAT BOOKING ====================
        private void LoadRiwayatBooking(string searchStudio = "", string statusFilter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT b.id_booking, 
                                            b.tanggal_booking, 
                                            s.nama_studio, 
                                            j.tanggal, 
                                            j.jam_mulai, 
                                            j.jam_selesai, 
                                            b.durasi_jam, 
                                            b.total_harga, 
                                            b.status, 
                                            b.catatan
                                     FROM tbl_booking b
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE b.id_pelanggan = @id_pelanggan";

                    if (!string.IsNullOrWhiteSpace(searchStudio))
                        query += " AND s.nama_studio LIKE @search";

                    if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "Semua")
                        query += " AND b.status = @status";

                    query += " ORDER BY b.tanggal_booking DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);

                    if (!string.IsNullOrWhiteSpace(searchStudio))
                        cmd.Parameters.AddWithValue("@search", "%" + searchStudio + "%");

                    if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "Semua")
                        cmd.Parameters.AddWithValue("@status", statusFilter);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRiwayatBooking.DataSource = dt;
                }

                if (dgvRiwayatBooking.Columns.Count > 0)
                {
                    if (dgvRiwayatBooking.Columns.Contains("id_booking"))
                        dgvRiwayatBooking.Columns["id_booking"].HeaderText = "ID";
                    if (dgvRiwayatBooking.Columns.Contains("tanggal_booking"))
                    {
                        dgvRiwayatBooking.Columns["tanggal_booking"].HeaderText = "Tgl Booking";
                        dgvRiwayatBooking.Columns["tanggal_booking"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvRiwayatBooking.Columns.Contains("nama_studio"))
                        dgvRiwayatBooking.Columns["nama_studio"].HeaderText = "Studio";
                    if (dgvRiwayatBooking.Columns.Contains("tanggal"))
                    {
                        dgvRiwayatBooking.Columns["tanggal"].HeaderText = "Tgl Sewa";
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
                    if (dgvRiwayatBooking.Columns.Contains("catatan"))
                        dgvRiwayatBooking.Columns["catatan"].HeaderText = "Catatan";
                }

                dgvRiwayatBooking.CellFormatting -= DgvRiwayatBooking_CellFormatting;
                dgvRiwayatBooking.CellFormatting += DgvRiwayatBooking_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadRiwayatBooking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                                            p.status as status_bayar, p.jumlah_bayar, 
                                            p.metode_bayar, p.tgl_pembayaran, p.catatan_admin
                                     FROM tbl_booking b
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     LEFT JOIN tbl_pembayaran p ON b.id_booking = p.id_booking
                                     WHERE b.id_booking = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_booking);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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

                            // ✅ Status bayar
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDetailBooking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ==================== SHOW INPUT DIALOG ====================
        private string ShowInputDialog(string prompt, string title, string defaultValue = "")
        {
            Form inputForm = new Form();
            inputForm.Text = title;
            inputForm.Width = 400;
            inputForm.Height = 160;
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;

            Label lbl = new Label() { Text = prompt, Left = 10, Top = 10, Width = 360, Height = 40 };
            TextBox txt = new TextBox() { Left = 10, Top = 55, Width = 360, Text = defaultValue };
            Button btnOk = new Button() { Text = "OK", Left = 210, Top = 85, Width = 75, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Batal", Left = 295, Top = 85, Width = 75, DialogResult = DialogResult.Cancel };

            inputForm.Controls.AddRange(new Control[] { lbl, txt, btnOk, btnCancel });
            inputForm.AcceptButton = btnOk;
            inputForm.CancelButton = btnCancel;

            return inputForm.ShowDialog() == DialogResult.OK ? txt.Text : "";
        }

        // ==================== TOMBOL BAYAR ====================
        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (selectedIdBooking == 0)
            {
                MessageBox.Show("Pilih booking terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusBayar = txtStatusBayar.Text;

            if (statusBayar == "Lunas" || statusBayar == "dikonfirmasi")
            {
                MessageBox.Show("Tagihan ini sudah lunas!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (statusBayar == "menunggu")
            {
                MessageBox.Show("Pembayaran sudah dikirim, menunggu konfirmasi admin!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cek status booking harus disetujui dulu oleh admin
            string statusBooking = txtStatusBooking.Text;
            if (statusBooking == "menunggu")
            {
                MessageBox.Show("Booking masih menunggu persetujuan admin, belum bisa bayar!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (statusBooking == "ditolak")
            {
                MessageBox.Show("Booking ini sudah ditolak, tidak bisa dibayar!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ambil total harga
            string totalText = txtTotalHarga.Text
                .Replace("Rp ", "")
                .Replace(".", "")
                .Replace(",", "")
                .Trim();

            if (!decimal.TryParse(totalText, out decimal totalHarga) || totalHarga == 0)
            {
                MessageBox.Show("Pilih booking terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Input jumlah bayar
            string inputJumlah = ShowInputDialog(
                $"Total Harga: Rp {totalHarga:N0}\nMasukkan jumlah bayar:",
                "Input Pembayaran",
                totalHarga.ToString());

            if (string.IsNullOrWhiteSpace(inputJumlah)) return;

            if (!decimal.TryParse(inputJumlah, out decimal jumlahBayar))
            {
                MessageBox.Show("Jumlah bayar tidak valid! Masukkan angka saja.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (jumlahBayar < totalHarga)
            {
                MessageBox.Show(
                    $"Jumlah bayar kurang!\n" +
                    $"Total Harga  : Rp {totalHarga:N0}\n" +
                    $"Jumlah Bayar : Rp {jumlahBayar:N0}\n" +
                    $"Kurang       : Rp {(totalHarga - jumlahBayar):N0}",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Input metode bayar
            string metodeBayar = ShowInputDialog(
                "Masukkan metode pembayaran:\n(Tunai / Transfer / QRIS)",
                "Metode Pembayaran",
                "Tunai");

            if (string.IsNullOrWhiteSpace(metodeBayar)) metodeBayar = "Tunai";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Cek apakah sudah ada pembayaran
                    string cekQuery = "SELECT COUNT(*) FROM tbl_pembayaran WHERE id_booking = @id";
                    SqlCommand cmdCek = new SqlCommand(cekQuery, conn);
                    cmdCek.Parameters.AddWithValue("@id", selectedIdBooking);
                    int sudahAda = (int)cmdCek.ExecuteScalar();

                    if (sudahAda > 0)
                    {
                        MessageBox.Show("Pembayaran untuk booking ini sudah ada!", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ✅ Insert ke tbl_pembayaran
                    string query = @"INSERT INTO tbl_pembayaran 
                                    (id_booking, jumlah_bayar, jumlah_kembalian, metode_bayar, status, tgl_pembayaran)
                                    VALUES (@id_booking, @jumlah_bayar, @kembalian, @metode, 'menunggu', GETDATE())";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_booking", selectedIdBooking);
                    cmd.Parameters.AddWithValue("@jumlah_bayar", jumlahBayar);
                    cmd.Parameters.AddWithValue("@kembalian", jumlahBayar - totalHarga);
                    cmd.Parameters.AddWithValue("@metode", metodeBayar);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    $"Pembayaran berhasil dikirim!\n\n" +
                    $"Total Harga  : Rp {totalHarga:N0}\n" +
                    $"Jumlah Bayar : Rp {jumlahBayar:N0}\n" +
                    $"Kembalian    : Rp {(jumlahBayar - totalHarga):N0}\n" +
                    $"Metode       : {metodeBayar}\n\n" +
                    "Menunggu konfirmasi admin.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Refresh tampilan
                LoadRiwayatBooking();
                UpdateStatistik();
                LoadDetailBooking(selectedIdBooking);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BayarTagihan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENT HANDLERS ====================
        private void FormRiwayatBookingPelanggan_Load(object sender, EventArgs e) { }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayatBooking();
            UpdateStatistik();
            ClearDetail();
            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRiwayatBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value != null)
            {
                selectedIdBooking = Convert.ToInt32(dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value);
                LoadDetailBooking(selectedIdBooking);
            }
        }

        // Event handlers kosong
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
    }
}