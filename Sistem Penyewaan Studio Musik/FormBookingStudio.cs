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
    public partial class FormBookingStudio : Form
    {
        // ✅ Hanya simpan string koneksi, BUKAN objek koneksi global
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";

        private int id_pelanggan;
        private string nama_pelanggan;
        private int selectedIdJadwal = 0;
        private int selectedIdBooking = 0;
        private bool isUpdating = false;

        public FormBookingStudio(int id_pelanggan, string nama_pelanggan)
        {
            InitializeComponent();
            this.id_pelanggan = id_pelanggan;
            this.nama_pelanggan = nama_pelanggan;

            txtNama.Text = nama_pelanggan;

            LoadStudioCombo();
            LoadDataPelanggan();
            LoadJadwalTersedia();
            LoadRiwayatBooking();

            dtpTanggal.Value = DateTime.Now;
            dtpJamMulai.Value = DateTime.Now.Date.AddHours(10);
            dtpJamSelesai.Value = DateTime.Now.Date.AddHours(12);
        }

        // ==================== LOAD DATA PELANGGAN ====================
        private void LoadDataPelanggan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT Nama, Email, NoTelp FROM pelanggan WHERE id_pelanggan = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_pelanggan);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNama.Text = reader["Nama"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtNoTelp.Text = reader["NoTelp"]?.ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDataPelanggan: " + ex.Message);
            }
        }

        // ==================== LOAD STUDIO COMBO ====================
        private void LoadStudioCombo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id_studio, nama_studio FROM tbl_studio WHERE status = 'aktif' ORDER BY nama_studio";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dtStudio = new DataTable();
                    da.Fill(dtStudio);

                    cbStudio.DataSource = dtStudio;
                    cbStudio.DisplayMember = "nama_studio";
                    cbStudio.ValueMember = "id_studio";
                    cbStudio.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadStudioCombo: " + ex.Message);
            }
        }

        // ==================== LOAD JADWAL TERSEDIA ====================
        private void LoadJadwalTersedia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT j.id_jadwal, s.nama_studio, j.tanggal, 
                                            j.jam_mulai, j.jam_selesai, s.harga_per_jam,
                                            DATEDIFF(HOUR, j.jam_mulai, j.jam_selesai) as durasi
                                     FROM tbl_jadwal j
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE j.status = 'tersedia'
                                     AND j.tanggal >= CAST(GETDATE() AS DATE)
                                     ORDER BY j.tanggal, j.jam_mulai";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvJadwalTersedia.DataSource = dt;
                }

                // Atur header kolom
                if (dgvJadwalTersedia.Columns.Count > 0)
                {
                    if (dgvJadwalTersedia.Columns.Contains("id_jadwal"))
                        dgvJadwalTersedia.Columns["id_jadwal"].HeaderText = "ID";
                    if (dgvJadwalTersedia.Columns.Contains("nama_studio"))
                        dgvJadwalTersedia.Columns["nama_studio"].HeaderText = "Studio";
                    if (dgvJadwalTersedia.Columns.Contains("tanggal"))
                    {
                        dgvJadwalTersedia.Columns["tanggal"].HeaderText = "Tanggal";
                        dgvJadwalTersedia.Columns["tanggal"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvJadwalTersedia.Columns.Contains("jam_mulai"))
                        dgvJadwalTersedia.Columns["jam_mulai"].HeaderText = "Jam Mulai";
                    if (dgvJadwalTersedia.Columns.Contains("jam_selesai"))
                        dgvJadwalTersedia.Columns["jam_selesai"].HeaderText = "Jam Selesai";
                    if (dgvJadwalTersedia.Columns.Contains("harga_per_jam"))
                        dgvJadwalTersedia.Columns["harga_per_jam"].HeaderText = "Harga/Jam";
                    if (dgvJadwalTersedia.Columns.Contains("durasi"))
                        dgvJadwalTersedia.Columns["durasi"].HeaderText = "Durasi (Jam)";
                }

                if (dgvJadwalTersedia.Columns["btnBooking"] == null)
                {
                    DataGridViewButtonColumn btnBooking = new DataGridViewButtonColumn();
                    btnBooking.Name = "btnBooking";
                    btnBooking.HeaderText = "Aksi";
                    btnBooking.Text = "📅 Booking";
                    btnBooking.UseColumnTextForButtonValue = true;
                    dgvJadwalTersedia.Columns.Add(btnBooking);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadJadwalTersedia: " + ex.Message);
            }
        }

        // ==================== LOAD RIWAYAT BOOKING ====================
        private void LoadRiwayatBooking()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT b.id_booking, b.tanggal_booking, s.nama_studio, 
                                            b.durasi_jam, b.total_harga, b.status
                                     FROM tbl_booking b
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE b.id_pelanggan = @id_pelanggan
                                     ORDER BY b.tanggal_booking DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRiwayatBooking.DataSource = dt;
                }

                // Atur header kolom
                if (dgvRiwayatBooking.Columns.Count > 0)
                {
                    if (dgvRiwayatBooking.Columns.Contains("id_booking"))
                        dgvRiwayatBooking.Columns["id_booking"].HeaderText = "ID";
                    if (dgvRiwayatBooking.Columns.Contains("tanggal_booking"))
                    {
                        dgvRiwayatBooking.Columns["tanggal_booking"].HeaderText = "Tanggal Booking";
                        dgvRiwayatBooking.Columns["tanggal_booking"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvRiwayatBooking.Columns.Contains("nama_studio"))
                        dgvRiwayatBooking.Columns["nama_studio"].HeaderText = "Studio";
                    if (dgvRiwayatBooking.Columns.Contains("durasi_jam"))
                        dgvRiwayatBooking.Columns["durasi_jam"].HeaderText = "Durasi (Jam)";
                    if (dgvRiwayatBooking.Columns.Contains("total_harga"))
                    {
                        dgvRiwayatBooking.Columns["total_harga"].HeaderText = "Total Harga";
                        dgvRiwayatBooking.Columns["total_harga"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvRiwayatBooking.Columns.Contains("status"))
                        dgvRiwayatBooking.Columns["status"].HeaderText = "Status";
                }

                if (dgvRiwayatBooking.Columns["btnBatalkan"] == null)
                {
                    DataGridViewButtonColumn btnBatalkan = new DataGridViewButtonColumn();
                    btnBatalkan.Name = "btnBatalkan";
                    btnBatalkan.HeaderText = "Aksi";
                    btnBatalkan.Text = "❌ Batalkan";
                    btnBatalkan.UseColumnTextForButtonValue = true;
                    dgvRiwayatBooking.Columns.Add(btnBatalkan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadRiwayatBooking: " + ex.Message);
            }
        }

        // ==================== LOAD DETAIL JADWAL ====================
        private void LoadDetailJadwal(int id_jadwal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                    s.harga_per_jam, 
                                    DATEDIFF(HOUR, j.jam_mulai, j.jam_selesai) as durasi
                             FROM tbl_jadwal j
                             JOIN tbl_studio s ON j.id_studio = s.id_studio
                             WHERE j.id_jadwal = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_jadwal);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cbStudio.Text = reader["nama_studio"].ToString();
                            dtpTanggal.Value = Convert.ToDateTime(reader["tanggal"]);
                            dtpJamMulai.Value = DateTime.Today.Add(((TimeSpan)reader["jam_mulai"]));
                            dtpJamSelesai.Value = DateTime.Today.Add(((TimeSpan)reader["jam_selesai"]));
                            txtHargaPerJam.Text = "Rp " + Convert.ToDecimal(reader["harga_per_jam"]).ToString("N0");

                            int durasi = Convert.ToInt32(reader["durasi"]);
                            decimal hargaPerJam = Convert.ToDecimal(reader["harga_per_jam"]);
                            decimal totalHarga = durasi * hargaPerJam;

                            txtDurasi.Text = durasi + " Jam";
                            txtTotalHarga.Text = "Rp " + totalHarga.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDetailJadwal: " + ex.Message);
            }
        }

        // ==================== MEMBUAT BOOKING BARU ====================
        private void BuatBooking()
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catatan = txtCatatan.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Hitung total harga dan durasi
                    string queryJadwal = @"SELECT s.harga_per_jam, DATEDIFF(HOUR, j.jam_mulai, j.jam_selesai) as durasi 
                                           FROM tbl_jadwal j 
                                           JOIN tbl_studio s ON j.id_studio = s.id_studio 
                                           WHERE j.id_jadwal = @id";
                    SqlCommand cmdJadwal = new SqlCommand(queryJadwal, conn);
                    cmdJadwal.Parameters.AddWithValue("@id", selectedIdJadwal);

                    decimal hargaPerJam = 0;
                    int durasi = 0;

                    using (SqlDataReader reader = cmdJadwal.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hargaPerJam = Convert.ToDecimal(reader["harga_per_jam"]);
                            durasi = Convert.ToInt32(reader["durasi"]);
                        }
                    }

                    decimal totalHarga = durasi * hargaPerJam;

                    // Insert booking
                    string query = @"INSERT INTO tbl_booking (id_pelanggan, id_jadwal, durasi_jam, total_harga, status, catatan) 
                             VALUES (@id_pelanggan, @id_jadwal, @durasi, @total_harga, 'menunggu', @catatan)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                    cmd.Parameters.AddWithValue("@id_jadwal", selectedIdJadwal);
                    cmd.Parameters.AddWithValue("@durasi", durasi);
                    cmd.Parameters.AddWithValue("@total_harga", totalHarga);
                    cmd.Parameters.AddWithValue("@catatan", catatan);
                    cmd.ExecuteNonQuery();

                    // Update status jadwal menjadi 'dipesan'
                    string updateJadwal = "UPDATE tbl_jadwal SET status = 'dipesan' WHERE id_jadwal = @id";
                    SqlCommand cmdUpdate = new SqlCommand(updateJadwal, conn);
                    cmdUpdate.Parameters.AddWithValue("@id", selectedIdJadwal);
                    cmdUpdate.ExecuteNonQuery();
                }

                MessageBox.Show("Booking berhasil dibuat! Menunggu konfirmasi admin.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                selectedIdJadwal = 0;
                txtCatatan.Clear();
                ClearDetailJadwal();
                LoadJadwalTersedia();
                LoadRiwayatBooking();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BuatBooking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== MEMBATALKAN BOOKING ====================
        private void BatalkanBooking(int id_booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Ambil id_jadwal dari booking yang akan dibatalkan
                    string queryGetJadwal = "SELECT id_jadwal FROM tbl_booking WHERE id_booking = @id";
                    SqlCommand cmdGet = new SqlCommand(queryGetJadwal, conn);
                    cmdGet.Parameters.AddWithValue("@id", id_booking);
                    int id_jadwal = Convert.ToInt32(cmdGet.ExecuteScalar());

                    // Update status booking menjadi 'dibatalkan'
                    string query = "UPDATE tbl_booking SET status = 'ditolak' WHERE id_booking = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_booking);
                    cmd.ExecuteNonQuery();

                    // Update status jadwal kembali menjadi 'tersedia'
                    string updateJadwal = "UPDATE tbl_jadwal SET status = 'tersedia' WHERE id_jadwal = @id";
                    SqlCommand cmdUpdate = new SqlCommand(updateJadwal, conn);
                    cmdUpdate.Parameters.AddWithValue("@id", id_jadwal);
                    cmdUpdate.ExecuteNonQuery();
                }

                MessageBox.Show("Booking berhasil dibatalkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadJadwalTersedia();
                LoadRiwayatBooking();
                ClearDetailJadwal();
                selectedIdJadwal = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BatalkanBooking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CLEAR DETAIL JADWAL ====================
        private void ClearDetailJadwal()
        {
            cbStudio.SelectedIndex = -1;
            dtpTanggal.Value = DateTime.Now;
            dtpJamMulai.Value = DateTime.Now.Date.AddHours(10);
            dtpJamSelesai.Value = DateTime.Now.Date.AddHours(12);
            txtHargaPerJam.Text = "";
            txtDurasi.Text = "";
            txtTotalHarga.Text = "";
            txtCatatan.Text = "";
        }

        // ==================== REFRESH SEMUA DATA ====================
        private void RefreshAll()
        {
            LoadJadwalTersedia();
            LoadRiwayatBooking();
            LoadDataPelanggan();
            ClearDetailJadwal();
            selectedIdJadwal = 0;
            txtCatatan.Clear();
            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== HITUNG DURASI ====================
        private void HitungDurasi()
        {
            try
            {
                DateTime jamMulai = dtpJamMulai.Value;
                DateTime jamSelesai = dtpJamSelesai.Value;
                TimeSpan selisih = jamSelesai - jamMulai;
                double durasi = selisih.TotalHours;

                if (durasi <= 0)
                {
                    txtDurasi.Text = "0";
                    txtDurasi.ForeColor = Color.Red;
                }
                else
                {
                    txtDurasi.Text = durasi.ToString("F1");
                    txtDurasi.ForeColor = Color.White;
                }
            }
            catch
            {
                txtDurasi.Text = "0";
            }
        }

        // ==================== HITUNG TOTAL HARGA ====================
        private void HitungTotalHarga()
        {
            try
            {
                if (!double.TryParse(txtDurasi.Text.Replace(" Jam", ""), out double durasi))
                {
                    txtTotalHarga.Text = "Rp 0";
                    return;
                }

                string hargaText = txtHargaPerJam.Text.Replace("Rp ", "").Replace(".", "").Replace(",", "");
                if (!decimal.TryParse(hargaText, out decimal hargaPerJam))
                {
                    txtTotalHarga.Text = "Rp 0";
                    return;
                }

                decimal totalHarga = (decimal)durasi * hargaPerJam;
                txtTotalHarga.Text = "Rp " + totalHarga.ToString("N0");
            }
            catch
            {
                txtTotalHarga.Text = "Rp 0";
            }
        }

        // ==================== EVENT HANDLERS ====================
        private void FormBookingStudio_Load(object sender, EventArgs e) { }

        private void btnCariJadwal_Click(object sender, EventArgs e)
        {
            LoadJadwalTersedia();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BuatBooking();
        }

        private void btnBatalBooking_Click(object sender, EventArgs e)
        {
            selectedIdJadwal = 0;
            txtCatatan.Clear();
            ClearDetailJadwal();
            MessageBox.Show("Proses booking dibatalkan.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBatalkanPesanan_Click(object sender, EventArgs e)
        {
            if (selectedIdBooking == 0)
            {
                MessageBox.Show("Pilih booking yang akan dibatalkan dari daftar riwayat!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin membatalkan booking ini?",
                "Konfirmasi Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                BatalkanBooking(selectedIdBooking);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void dgvJadwalTersedia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvJadwalTersedia.Columns["btnBooking"].Index)
            {
                selectedIdJadwal = Convert.ToInt32(dgvJadwalTersedia.Rows[e.RowIndex].Cells["id_jadwal"].Value);
                LoadDetailJadwal(selectedIdJadwal);
                MessageBox.Show("Silakan klik 'Konfirmasi' untuk melanjutkan booking.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvRiwayatBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvRiwayatBooking.Columns["btnBatalkan"].Index)
            {
                int id_booking = Convert.ToInt32(dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value);
                string status = dgvRiwayatBooking.Rows[e.RowIndex].Cells["status"].Value.ToString();

                if (status == "menunggu")
                {
                    DialogResult result = MessageBox.Show("Yakin ingin membatalkan booking ini?",
                        "Konfirmasi Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        BatalkanBooking(id_booking);
                    }
                }
                else
                {
                    MessageBox.Show($"Booking dengan status '{status}' tidak dapat dibatalkan!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbStudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudio.SelectedItem != null)
            {
                DataRowView drv = cbStudio.SelectedItem as DataRowView;
                if (drv != null)
                {
                    int id_studio = Convert.ToInt32(drv["id_studio"]);

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            conn.Open();
                            string query = "SELECT harga_per_jam FROM tbl_studio WHERE id_studio = @id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", id_studio);
                            decimal harga = Convert.ToDecimal(cmd.ExecuteScalar());
                            txtHargaPerJam.Text = "Rp " + harga.ToString("N0");
                            HitungTotalHarga();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dtpJamMulai_ValueChanged(object sender, EventArgs e)
        {
            HitungDurasi();
            HitungTotalHarga();
        }

        private void dtpJamSelesai_ValueChanged(object sender, EventArgs e)
        {
            HitungDurasi();
            HitungTotalHarga();
        }

        private void txtDurasi_TextChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
            {
                isUpdating = true;
                HitungTotalHarga();
                isUpdating = false;
            }
        }

        // Event handlers kosong yang tidak dipakai
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblJudul_Click(object sender, EventArgs e) { }
        private void lblFilter_Click(object sender, EventArgs e) { }
        private void lblStudioFilter_Click(object sender, EventArgs e) { }
        private void lblTanggalFilter_Click(object sender, EventArgs e) { }
        private void lblDaftarJadwal_Click(object sender, EventArgs e) { }
        private void lblRiwayatBooking_Click(object sender, EventArgs e) { }
        private void lblFormBooking_Click(object sender, EventArgs e) { }
        private void lblDetailJadwal_Click(object sender, EventArgs e) { }
        private void lblStudio_Click(object sender, EventArgs e) { }
        private void lblJamMulai_Click(object sender, EventArgs e) { }
        private void lblTanggal_Click(object sender, EventArgs e) { }
        private void lblJamSelesai_Click(object sender, EventArgs e) { }
        private void lblHargaPerJam_Click(object sender, EventArgs e) { }
        private void lblTotalHarga_Click(object sender, EventArgs e) { }
        private void lblDurasi_Click(object sender, EventArgs e) { }
        private void lblDataPelanggan_Click(object sender, EventArgs e) { }
        private void lblNamaPelanggan_Click(object sender, EventArgs e) { }
        private void lblEmailPelanggan_Click(object sender, EventArgs e) { }
        private void lblNoTelpPelanggan_Click(object sender, EventArgs e) { }
        private void lblCatatan_Click(object sender, EventArgs e) { }
        private void txtNoTelp_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtNama_TextChanged(object sender, EventArgs e) { }
        private void txtCatatan_TextChanged(object sender, EventArgs e) { }
        private void dtpTanggal_ValueChanged(object sender, EventArgs e) { }
    }
}