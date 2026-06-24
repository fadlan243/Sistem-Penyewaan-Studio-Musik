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
using System.Runtime.InteropServices;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormRiwayatBooking : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");

        private DataTable dtBooking;
        private int selectedIdBooking = 0;
        private int id_admin;

        // Placeholder menggunakan SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }
        public FormRiwayatBooking(int id_admin = 0)
        {
            InitializeComponent();
            this.id_admin = id_admin;
            LoadPelangganCombo();
            LoadData();
            UpdateStatistik();
            ClearDetail();
        }

        // ==================== LOAD COMBOBOX PELANGGAN ====================
        private void LoadPelangganCombo()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                string query = "SELECT id_pelanggan, Nama FROM pelanggan ORDER BY Nama";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtPelanggan = new DataTable();
                da.Fill(dtPelanggan);
                conn.Close();

                cbPelangganFilter.DataSource = dtPelanggan;
                cbPelangganFilter.DisplayMember = "Nama";
                cbPelangganFilter.ValueMember = "id_pelanggan";
                cbPelangganFilter.SelectedIndex = -1;

                // Isi status filter
                cbStatusFilter.Items.Clear();
                cbStatusFilter.Items.Add("Semua");
                cbStatusFilter.Items.Add("menunggu");
                cbStatusFilter.Items.Add("disetujui");
                cbStatusFilter.Items.Add("ditolak");
                cbStatusFilter.Items.Add("selesai");
                cbStatusFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadPelanggan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ==================== LOAD DATA KE DATAGRIDVIEW ====================
        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                string query = @"SELECT b.id_booking, p.Nama as NamaPelanggan, s.nama_studio, 
                                j.tanggal, j.jam_mulai, j.jam_selesai, b.durasi_jam, 
                                b.total_harga, b.status, b.tanggal_booking, b.catatan
                         FROM tbl_booking b
                         JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                         JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                         JOIN tbl_studio s ON j.id_studio = s.id_studio
                         ORDER BY b.tanggal_booking DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtBooking = new DataTable();
                da.Fill(dtBooking);
                conn.Close();

                // Kosongkan dulu sebelum bind ulang
                dgvBooking.DataSource = null;
                dgvBooking.DataSource = dtBooking;

                // Tunggu kolom ter-generate dulu
                if (dgvBooking.Columns.Count == 0) return;

                // Sembunyikan kolom yang tidak perlu ditampilkan
                string[] kolomSembunyi = { "tanggal_booking", "catatan", "jam_selesai" };
                foreach (string kol in kolomSembunyi)
                {
                    if (dgvBooking.Columns.Contains(kol))
                        dgvBooking.Columns[kol].Visible = false;
                }

                // Atur header dengan null check
                void AturKolom(string nama, string header, string format = "")
                {
                    if (!dgvBooking.Columns.Contains(nama)) return;
                    dgvBooking.Columns[nama].HeaderText = header;
                    if (!string.IsNullOrEmpty(format))
                        dgvBooking.Columns[nama].DefaultCellStyle.Format = format;
                }

                AturKolom("id_booking", "ID");
                AturKolom("NamaPelanggan", "Pelanggan");
                AturKolom("nama_studio", "Studio");
                AturKolom("tanggal", "Tanggal", "dd/MM/yyyy");
                AturKolom("jam_mulai", "Jam Mulai");
                AturKolom("durasi_jam", "Durasi");
                AturKolom("total_harga", "Total Harga", "N0");
                AturKolom("status", "Status");
            }
            catch(Exception ex)
{
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show(ex.ToString(), "Full Error"); // tampilkan full stack trace
            }
        }

        // ==================== LOAD DATA DENGAN FILTER ====================
        private void LoadDataWithFilter()
        {
            try
            {

                string pelangganFilter = "";
                if (cbPelangganFilter.SelectedValue != null)
                    pelangganFilter = cbPelangganFilter.SelectedValue.ToString();

                string statusFilter = cbStatusFilter.SelectedItem?.ToString();
                if (statusFilter == "Semua") statusFilter = "";

                DateTime tanggalFilter = dtpTanggalFilter.Value.Date;

                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                string query = @"SELECT b.id_booking, p.Nama as NamaPelanggan, s.nama_studio, 
                                        j.tanggal, j.jam_mulai, j.jam_selesai, b.durasi_jam, 
                                        b.total_harga, b.status, b.tanggal_booking, b.catatan
                                 FROM tbl_booking b
                                 JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                                 JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 WHERE (@pelanggan = '' OR b.id_pelanggan = @pelanggan)
                                 AND (@status = '' OR b.status = @status)
                                 AND (@tanggal = '1900-01-01' OR j.tanggal = @tanggal)
                                 ORDER BY b.tanggal_booking DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@pelanggan", string.IsNullOrEmpty(pelangganFilter) ? "" : pelangganFilter);
                da.SelectCommand.Parameters.AddWithValue("@status", string.IsNullOrEmpty(statusFilter) ? "" : statusFilter);
                da.SelectCommand.Parameters.AddWithValue("@tanggal", tanggalFilter);
                dtBooking = new DataTable();
                da.Fill(dtBooking);
                conn.Close();

                dgvBooking.DataSource = dtBooking;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadDataWithFilter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== UPDATE STATISTIK ====================
        private void UpdateStatistik()
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM tbl_booking", conn);
                int total = (int)cmdTotal.ExecuteScalar();

                SqlCommand cmdMenunggu = new SqlCommand("SELECT COUNT(*) FROM tbl_booking WHERE status = 'menunggu'", conn);
                int menunggu = (int)cmdMenunggu.ExecuteScalar();

                SqlCommand cmdDisetujui = new SqlCommand("SELECT COUNT(*) FROM tbl_booking WHERE status = 'disetujui'", conn);
                int disetujui = (int)cmdDisetujui.ExecuteScalar();

                SqlCommand cmdSelesai = new SqlCommand("SELECT COUNT(*) FROM tbl_booking WHERE status = 'selesai'", conn);
                int selesai = (int)cmdSelesai.ExecuteScalar();

                SqlCommand cmdDitolak = new SqlCommand("SELECT COUNT(*) FROM tbl_booking WHERE status = 'ditolak'", conn);
                int ditolak = (int)cmdDitolak.ExecuteScalar();

                conn.Close();

                lblStatistik.Text = $"📊 STATISTIK: Total Booking: {total} | Menunggu: {menunggu} | Disetujui: {disetujui} | Selesai: {selesai} | Ditolak: {ditolak}";
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                lblStatistik.Text = "📊 STATISTIK: Error loading data";
            }
        }

        // ==================== KOSONGKAN DETAIL ====================
        private void ClearDetail()
        {
            txtIDBooking.Clear();
            txtPelanggan.Clear();
            txtNoTelp.Clear();
            txtEmail.Clear();
            txtStudio.Clear();
            txtTanggalBooking.Clear();
            txtJamMulai.Clear();
            txtJamSelesai.Clear();
            txtDurasi.Clear();
            txtTotalHarga.Clear();
            txtCatatan.Clear();
            selectedIdBooking = 0;
            btnSetujui.Enabled = false;
            btnTolak.Enabled = false;
            btnSelesai.Enabled = false;
        }

        // ==================== LOAD DETAIL BOOKING ====================
        private void LoadDetailBooking(int id_booking)
        {
            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();
                string query = @"SELECT b.id_booking, p.Nama as NamaPelanggan, p.NoTelp, p.Email,
                                        s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                        b.durasi_jam, b.total_harga, b.status, b.tanggal_booking, b.catatan
                                 FROM tbl_booking b
                                 JOIN pelanggan p ON b.id_pelanggan = p.id_pelanggan
                                 JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 WHERE b.id_booking = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_booking);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtIDBooking.Text = reader["id_booking"].ToString();
                    txtPelanggan.Text = reader["NamaPelanggan"].ToString();
                    txtNoTelp.Text = reader["NoTelp"]?.ToString() ?? "-";
                    txtEmail.Text = reader["Email"]?.ToString() ?? "-";
                    txtStudio.Text = reader["nama_studio"].ToString();
                    txtTanggalBooking.Text = Convert.ToDateTime(reader["tanggal"]).ToString("dd/MM/yyyy");
                    txtJamMulai.Text = reader["jam_mulai"].ToString();
                    txtJamSelesai.Text = reader["jam_selesai"].ToString();
                    txtDurasi.Text = reader["durasi_jam"].ToString() + " Jam";
                    txtTotalHarga.Text = "Rp " + Convert.ToDecimal(reader["total_harga"]).ToString("N0");
                    txtCatatan.Text = reader["catatan"]?.ToString() ?? "-";

                    string status = reader["status"].ToString();

                    // Enable/disable button berdasarkan status
                    if (status == "menunggu")
                    {
                        btnSetujui.Enabled = true;
                        btnTolak.Enabled = true;
                        btnSelesai.Enabled = false;
                    }
                    else if (status == "disetujui")
                    {
                        btnSetujui.Enabled = false;
                        btnTolak.Enabled = false;
                        btnSelesai.Enabled = true;
                    }
                    else
                    {
                        btnSetujui.Enabled = false;
                        btnTolak.Enabled = false;
                        btnSelesai.Enabled = false;
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadDetail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== UPDATE STATUS BOOKING ====================
        private void UpdateStatusBooking(string status)
        {
            if (selectedIdBooking == 0)
            {
                MessageBox.Show("Pilih booking terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Open();

                // Cukup update status di tbl_booking saja
                string query = "UPDATE tbl_booking SET status = @status WHERE id_booking = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedIdBooking);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();

                conn.Close();

                // 💡 CATATAN UNTUK SIDANG: 
                // Jika status yang dikirim 'disetujui', tabel 'tbl_jadwal' otomatis ter-update 
                // menjadi 'dipesan' via TRIGGER di database server, bukan lewat baris kode C# ini lagi.

                MessageBox.Show($"Status booking berhasil diubah menjadi {status}!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataWithFilter();
                UpdateStatistik();
                LoadDetailBooking(selectedIdBooking);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== SIMPAN CATATAN ADMIN ====================


        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPelanggan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRiwayatBooking_Load(object sender, EventArgs e)
        {
            // Atur lebar kolom setelah form load sempurna
            if (dgvBooking.Columns.Contains("id_booking")) dgvBooking.Columns["id_booking"].Width = 50;
            if (dgvBooking.Columns.Contains("NamaPelanggan")) dgvBooking.Columns["NamaPelanggan"].Width = 150;
            if (dgvBooking.Columns.Contains("nama_studio")) dgvBooking.Columns["nama_studio"].Width = 120;
            if (dgvBooking.Columns.Contains("tanggal")) dgvBooking.Columns["tanggal"].Width = 100;
            if (dgvBooking.Columns.Contains("jam_mulai")) dgvBooking.Columns["jam_mulai"].Width = 80;
            if (dgvBooking.Columns.Contains("durasi_jam")) dgvBooking.Columns["durasi_jam"].Width = 70;
            if (dgvBooking.Columns.Contains("total_harga")) dgvBooking.Columns["total_harga"].Width = 120;
            if (dgvBooking.Columns.Contains("status")) dgvBooking.Columns["status"].Width = 100;
        }// pastikan koneksi dan query tidak error

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblJudul_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDetailBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblIdBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblPelanggan_Click(object sender, EventArgs e)
        {

        }

        private void lblNoTelp_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblStudio_Click(object sender, EventArgs e)
        {

        }

        private void lblCatatan_Click(object sender, EventArgs e)
        {

        }

        private void lblTanggalBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblJamMulai_Click(object sender, EventArgs e)
        {

        }

        private void lblJamSelesai_Click(object sender, EventArgs e)
        {

        }

        private void lblDurasi_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalHarga_Click(object sender, EventArgs e)
        {

        }

        private void lblCatatanAdmin_Click(object sender, EventArgs e)
        {

        }

        private void lblDaftarBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblStatistik_Click(object sender, EventArgs e)
        {

        }

        private void txtIDBooking_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTanggalBooking_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJamMulai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCatatanAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJamSelesai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDurasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCatatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalHarga_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSetujui_Click(object sender, EventArgs e)
        {
            UpdateStatusBooking("disetujui");
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            UpdateStatusBooking("selesai");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            UpdateStatistik();
            ClearDetail();
            cbPelangganFilter.SelectedIndex = -1;
            cbStatusFilter.SelectedIndex = 0;
            dtpTanggalFilter.Value = DateTime.Now;

            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void dtpTanggalFilter_ValueChanged(object sender, EventArgs e)
        {
            // Optional: auto search when date changes
        }

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: auto search when filter changes
        }

        private void cbPelangganFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: auto search when filter changes
        }

        private void dgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooking.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedIdBooking = Convert.ToInt32(dgvBooking.Rows[e.RowIndex].Cells[0].Value);
                LoadDetailBooking(selectedIdBooking);
            }
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin menolak booking ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateStatusBooking("ditolak");
            }
        }
    }
}
