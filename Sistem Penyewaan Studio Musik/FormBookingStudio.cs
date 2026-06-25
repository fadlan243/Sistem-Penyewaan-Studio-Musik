using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormBookingStudio : Form
    {
        private readonly string connString = ("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");

        private int id_pelanggan;
        private string nama_pelanggan;
        private int selectedIdJadwal = 0;
        private int selectedIdBooking = 0;

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

            // Menghubungkan secara dinamis event value changed untuk perhitungan real-time
            dtpJamMulai.ValueChanged += dtpJamMulai_ValueChanged;
            dtpJamSelesai.ValueChanged += dtpJamSelesai_ValueChanged;

            // Menghubungkan secara dinamis klik tabel DataGridView ke fungsi handler
            dgvJadwalTersedia.CellClick += dgvJadwalTersedia_CellClick;
            dgvRiwayatBooking.CellClick += dgvRiwayatBooking_CellClick;
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
                MessageBox.Show("Error LoadDataPelanggan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error LoadStudioCombo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = @"SELECT id_jadwal, nama_studio, tanggal, jam_mulai, jam_selesai, 
                                            harga_per_jam, durasi_jam AS durasi
                                     FROM vw_JadwalTersedia
                                     ORDER BY tanggal, jam_mulai";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvJadwalTersedia.DataSource = dt;
                }

                // Pengaturan Header Kolom jika data terisi
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadJadwalTersedia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    SqlCommand cmd = new SqlCommand("sp_SearchRiwayatBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                    cmd.Parameters.AddWithValue("@status", "semua");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRiwayatBooking.DataSource = dt;
                }

                // Pengaturan Header Kolom jika data terisi
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadRiwayatBooking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DETAIL JADWAL KETIKA BARIS DIKLIK ====================
        private void LoadDetailJadwal(int id_jadwal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                            s.harga_per_jam, 
                                            DATEDIFF(MINUTE, j.jam_mulai, j.jam_selesai) / 60 AS durasi
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
                MessageBox.Show("Error LoadDetailJadwal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== MEMBUAT BOOKING ====================
        private void BuatBooking()
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu dari tabel Daftar Jadwal Tersedia!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catatan = txtCatatan.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                    cmd.Parameters.AddWithValue("@id_jadwal", selectedIdJadwal);
                    cmd.Parameters.AddWithValue("@catatan", catatan);

                    SqlParameter paramId = new SqlParameter("@new_id", SqlDbType.Int);
                    paramId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramPesan = new SqlParameter("@pesan", SqlDbType.VarChar, 255);
                    paramPesan.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramPesan);

                    cmd.ExecuteNonQuery();

                    string pesan = paramPesan.Value.ToString();
                    MessageBox.Show(pesan, pesan.StartsWith("SUKSES") ? "Sukses" : "Peringatan",
                        MessageBoxButtons.OK, pesan.StartsWith("SUKSES") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (pesan.StartsWith("SUKSES"))
                    {
                        selectedIdJadwal = 0;
                        txtCatatan.Clear();
                        ClearDetailJadwal();
                        LoadJadwalTersedia();
                        LoadRiwayatBooking();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BuatBooking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    SqlCommand cmd = new SqlCommand("sp_CancelBooking", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_booking", id_booking);
                    cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);

                    SqlParameter paramPesan = new SqlParameter("@pesan", SqlDbType.VarChar, 255);
                    paramPesan.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramPesan);

                    cmd.ExecuteNonQuery();

                    string pesan = paramPesan.Value.ToString();
                    MessageBox.Show(pesan, pesan.StartsWith("SUKSES") ? "Sukses" : "Peringatan",
                        MessageBoxButtons.OK, pesan.StartsWith("SUKSES") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (pesan.StartsWith("SUKSES"))
                    {
                        LoadJadwalTersedia();
                        LoadRiwayatBooking();
                        ClearDetailJadwal();
                        selectedIdBooking = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BatalkanBooking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== CLEAR FORM DETAIL ====================
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

        // ==================== REFRESH ALL DATA ====================
        private void RefreshAll()
        {
            LoadJadwalTersedia();
            LoadRiwayatBooking();
            LoadDataPelanggan();
            ClearDetailJadwal();
            selectedIdJadwal = 0;
            selectedIdBooking = 0;
            txtCatatan.Clear();
            MessageBox.Show("Data berhasil direfresh!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== CALCULATE DURATION & PRICE ====================
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

        // ==================== GRID & COMPONENT EVENT HANDLERS ====================
        private void dgvJadwalTersedia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIdJadwal = Convert.ToInt32(dgvJadwalTersedia.Rows[e.RowIndex].Cells["id_jadwal"].Value);
                LoadDetailJadwal(selectedIdJadwal);
            }
        }

        private void dgvRiwayatBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedIdBooking = Convert.ToInt32(dgvRiwayatBooking.Rows[e.RowIndex].Cells["id_booking"].Value);
                dgvRiwayatBooking.Rows[e.RowIndex].Selected = true;
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
            MessageBox.Show("Proses booking dibatalkan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBatalkanPesanan_Click(object sender, EventArgs e)
        {
            if (selectedIdBooking == 0)
            {
                MessageBox.Show("Pilih booking terlebih dahulu dari daftar riwayat di bawah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin membatalkan booking ini?", "Konfirmasi Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BatalkanBooking(selectedIdBooking);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void FormBookingStudio_Load(object sender, EventArgs e) { }
    }
}