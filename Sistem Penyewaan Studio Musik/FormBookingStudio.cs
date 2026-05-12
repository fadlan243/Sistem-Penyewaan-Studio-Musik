using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormBookingStudio : Form
    {
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

        // ==================== LOAD JADWAL TERSEDIA (UCP 2: PAKAI VIEW) ====================
        private void LoadJadwalTersedia()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // ✅ UCP 2: Gunakan VIEW vw_JadwalTersedia
                    string query = @"SELECT id_jadwal, nama_studio, tanggal, jam_mulai, jam_selesai, 
                                            harga_per_jam, durasi_jam AS durasi
                                     FROM vw_JadwalTersedia
                                     ORDER BY tanggal, jam_mulai";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();

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

                // Tambah kolom button Booking
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

        // ==================== LOAD RIWAYAT BOOKING (UCP 2: PAKAI VIEW & SP) ====================
        private void LoadRiwayatBooking()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // ✅ UCP 2: Gunakan Stored Procedure sp_SearchRiwayatBooking
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

                // Tambah kolom button Batalkan
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
                MessageBox.Show("Error LoadDetailJadwal: " + ex.Message);
            }
        }

        // ==================== UCP 2: MEMBUAT BOOKING PAKAI SP ====================
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

                    // ✅ UCP 2: Gunakan Stored Procedure sp_InsertBooking
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
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error BuatBooking: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== UCP 2: MEMBATALKAN BOOKING PAKAI SP ====================
        private void BatalkanBooking(int id_booking)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // ✅ UCP 2: Gunakan Stored Procedure sp_CancelBooking
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
                        selectedIdJadwal = 0;
                    }
                    conn.Close();
                }
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

        
    }
}