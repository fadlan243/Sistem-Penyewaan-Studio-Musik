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

    }
}