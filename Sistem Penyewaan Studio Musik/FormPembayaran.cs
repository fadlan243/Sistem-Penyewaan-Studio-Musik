using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormPembayaran : Form
    {
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";

        private DataTable dtPembayaran;
        private int selectedIdPembayaran = 0;
        private int id_admin;
        private string nama_admin;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        public FormPembayaran(int id_admin = 0, string nama_admin = "")
        {
            InitializeComponent();
            this.id_admin = id_admin;
            this.nama_admin = nama_admin;
            SetPlaceholder(txtCatatanAdmin, "Catatan dari admin...");
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
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT id_pelanggan, Nama FROM pelanggan ORDER BY Nama";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dtPelanggan = new DataTable();
                    da.Fill(dtPelanggan);

                    cmbPelangganFilter.DataSource = dtPelanggan;
                    cmbPelangganFilter.DisplayMember = "Nama";
                    cmbPelangganFilter.ValueMember = "id_pelanggan";
                    cmbPelangganFilter.SelectedIndex = -1;
                }

                cmbStatusFilter.Items.Clear();
                cmbStatusFilter.Items.Add("Semua");
                cmbStatusFilter.Items.Add("menunggu");
                cmbStatusFilter.Items.Add("dikonfirmasi");
                cmbStatusFilter.Items.Add("ditolak");
                cmbStatusFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadPelanggan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DATA ====================
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT p.id_pembayaran, pel.Nama as NamaPelanggan, s.nama_studio, 
                                            b.tanggal_booking, b.total_harga, p.jumlah_bayar, 
                                            p.status, p.tgl_pembayaran, p.id_booking
                                     FROM tbl_pembayaran p
                                     JOIN tbl_booking b ON p.id_booking = b.id_booking
                                     JOIN pelanggan pel ON b.id_pelanggan = pel.id_pelanggan
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     ORDER BY p.tgl_pembayaran DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtPembayaran = new DataTable();
                    da.Fill(dtPembayaran);
                    dgvPembayaran.DataSource = dtPembayaran;
                }

                if (dgvPembayaran.Columns.Count > 0)
                {
                    if (dgvPembayaran.Columns.Contains("id_pembayaran")) dgvPembayaran.Columns["id_pembayaran"].HeaderText = "ID";
                    if (dgvPembayaran.Columns.Contains("NamaPelanggan")) dgvPembayaran.Columns["NamaPelanggan"].HeaderText = "Pelanggan";
                    if (dgvPembayaran.Columns.Contains("nama_studio")) dgvPembayaran.Columns["nama_studio"].HeaderText = "Studio";
                    if (dgvPembayaran.Columns.Contains("tanggal_booking")) { dgvPembayaran.Columns["tanggal_booking"].HeaderText = "Tgl Booking"; dgvPembayaran.Columns["tanggal_booking"].DefaultCellStyle.Format = "dd/MM/yyyy"; }
                    if (dgvPembayaran.Columns.Contains("total_harga")) { dgvPembayaran.Columns["total_harga"].HeaderText = "Total Harga"; dgvPembayaran.Columns["total_harga"].DefaultCellStyle.Format = "N0"; }
                    if (dgvPembayaran.Columns.Contains("jumlah_bayar")) { dgvPembayaran.Columns["jumlah_bayar"].HeaderText = "Jumlah Bayar"; dgvPembayaran.Columns["jumlah_bayar"].DefaultCellStyle.Format = "N0"; }
                    if (dgvPembayaran.Columns.Contains("status")) dgvPembayaran.Columns["status"].HeaderText = "Status";
                    if (dgvPembayaran.Columns.Contains("tgl_pembayaran")) { dgvPembayaran.Columns["tgl_pembayaran"].HeaderText = "Tgl Bayar"; dgvPembayaran.Columns["tgl_pembayaran"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; }
                    if (dgvPembayaran.Columns.Contains("id_booking")) dgvPembayaran.Columns["id_booking"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadData: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DATA DENGAN FILTER ====================
        private void LoadDataWithFilter()
        {
            try
            {
                string pelangganFilter = cmbPelangganFilter.SelectedValue?.ToString() ?? "";
                string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "Semua";
                if (statusFilter == "Semua") statusFilter = "";
                DateTime tanggalFilter = dtpTanggalFilter.Value.Date;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT p.id_pembayaran, pel.Nama as NamaPelanggan, s.nama_studio, 
                                            b.tanggal_booking, b.total_harga, p.jumlah_bayar, 
                                            p.status, p.tgl_pembayaran, p.id_booking
                                     FROM tbl_pembayaran p
                                     JOIN tbl_booking b ON p.id_booking = b.id_booking
                                     JOIN pelanggan pel ON b.id_pelanggan = pel.id_pelanggan
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE (@pelanggan = '' OR b.id_pelanggan = @pelanggan)
                                     AND (@status = '' OR p.status = @status)
                                     AND (@tanggal = '1900-01-01' OR CAST(p.tgl_pembayaran AS DATE) = @tanggal)
                                     ORDER BY p.tgl_pembayaran DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@pelanggan", string.IsNullOrEmpty(pelangganFilter) ? "" : pelangganFilter);
                    da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);
                    da.SelectCommand.Parameters.AddWithValue("@tanggal", tanggalFilter);
                    dtPembayaran = new DataTable();
                    da.Fill(dtPembayaran);
                    dgvPembayaran.DataSource = dtPembayaran;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDataWithFilter: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== UPDATE STATISTIK ====================
        private void UpdateStatistik()
        {
            try
            {
                int total = 0, menunggu = 0, dikonfirmasi = 0, ditolak = 0;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    total = (int)new SqlCommand("SELECT COUNT(*) FROM tbl_pembayaran", conn).ExecuteScalar();
                    menunggu = (int)new SqlCommand("SELECT COUNT(*) FROM tbl_pembayaran WHERE status = 'menunggu'", conn).ExecuteScalar();
                    dikonfirmasi = (int)new SqlCommand("SELECT COUNT(*) FROM tbl_pembayaran WHERE status = 'dikonfirmasi'", conn).ExecuteScalar();
                    ditolak = (int)new SqlCommand("SELECT COUNT(*) FROM tbl_pembayaran WHERE status = 'ditolak'", conn).ExecuteScalar();
                }

                lblStatistik.Text = $"📊 STATISTIK: Total: {total} | Menunggu: {menunggu} | Dikonfirmasi: {dikonfirmasi} | Ditolak: {ditolak}";
            }
            catch
            {
                lblStatistik.Text = "📊 STATISTIK: Error loading data";
            }
        }

        // ==================== CLEAR DETAIL ====================
        private void ClearDetail()
        {
            txtIdPembayaran.Clear();
            txtIdBooking.Clear();
            txtPelanggan.Clear();
            txtNoTelp.Clear();
            txtEmail.Clear();
            txtStudio.Clear();
            txtTanggalBooking.Clear();
            txtJam.Clear();
            txtTotalHarga.Clear();
            txtJumlahBayar.Clear();
            txtKembalian.Clear();
            txtMetodeBayar.Clear();
            txtStatusPembayaran.Clear();
            txtTanggalBayar.Clear();
            txtCatatanAdmin.Clear();
            selectedIdPembayaran = 0;
            btnKonfirmasi.Enabled = false;
            btnTolak.Enabled = false;
            btnSimpanCatatan.Enabled = false;
        }

        // ==================== LOAD DETAIL PEMBAYARAN ====================
        private void LoadDetailPembayaran(int id_pembayaran)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT p.id_pembayaran, p.id_booking, pel.Nama as NamaPelanggan, 
                                            pel.NoTelp, pel.Email, s.nama_studio, j.tanggal, 
                                            j.jam_mulai, j.jam_selesai, b.total_harga, p.jumlah_bayar,
                                            p.metode_bayar, p.status, p.tgl_pembayaran, p.catatan_admin
                                     FROM tbl_pembayaran p
                                     JOIN tbl_booking b ON p.id_booking = b.id_booking
                                     JOIN pelanggan pel ON b.id_pelanggan = pel.id_pelanggan
                                     JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                     JOIN tbl_studio s ON j.id_studio = s.id_studio
                                     WHERE p.id_pembayaran = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id_pembayaran);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdPembayaran.Text = reader["id_pembayaran"].ToString();
                            txtIdBooking.Text = reader["id_booking"].ToString();
                            txtPelanggan.Text = reader["NamaPelanggan"].ToString();
                            txtNoTelp.Text = reader["NoTelp"]?.ToString() ?? "-";
                            txtEmail.Text = reader["Email"]?.ToString() ?? "-";
                            txtStudio.Text = reader["nama_studio"].ToString();
                            txtTanggalBooking.Text = Convert.ToDateTime(reader["tanggal"]).ToString("dd/MM/yyyy");
                            txtJam.Text = $"{reader["jam_mulai"]} - {reader["jam_selesai"]}";
                            txtTotalHarga.Text = "Rp " + Convert.ToDecimal(reader["total_harga"]).ToString("N0");
                            txtJumlahBayar.Text = "Rp " + Convert.ToDecimal(reader["jumlah_bayar"]).ToString("N0");

                            decimal totalHarga = Convert.ToDecimal(reader["total_harga"]);
                            decimal jumlahBayar = Convert.ToDecimal(reader["jumlah_bayar"]);
                            decimal kembalian = jumlahBayar - totalHarga;
                            txtKembalian.Text = kembalian > 0 ? "Rp " + kembalian.ToString("N0") : "Rp 0";

                            txtMetodeBayar.Text = reader["metode_bayar"]?.ToString() ?? "-";
                            txtStatusPembayaran.Text = reader["status"].ToString();
                            txtTanggalBayar.Text = reader["tgl_pembayaran"] != DBNull.Value
                                ? Convert.ToDateTime(reader["tgl_pembayaran"]).ToString("dd/MM/yyyy HH:mm") : "-";
                            txtCatatanAdmin.Text = reader["catatan_admin"]?.ToString() ?? "";

                            string status = reader["status"].ToString();
                            btnKonfirmasi.Enabled = (status == "menunggu");
                            btnTolak.Enabled = (status == "menunggu");
                            btnSimpanCatatan.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadDetail: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== KONFIRMASI PEMBAYARAN ====================
        private void KonfirmasiPembayaran()
        {
            if (selectedIdPembayaran == 0)
            {
                MessageBox.Show("Pilih pembayaran terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validasi id_admin
            if (id_admin == 0)
            {
                MessageBox.Show("ID Admin tidak valid! Pastikan Anda login sebagai admin.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Konfirmasi pembayaran ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        // Update status pembayaran
                        string query = @"UPDATE tbl_pembayaran 
                                         SET status = 'dikonfirmasi', 
                                             dikonfirmasi_oleh = @id_admin,
                                             catatan_admin = @catatan
                                         WHERE id_pembayaran = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedIdPembayaran);
                        cmd.Parameters.AddWithValue("@id_admin", id_admin);
                        cmd.Parameters.AddWithValue("@catatan", txtCatatanAdmin.Text);
                        cmd.ExecuteNonQuery();

                        // Update status booking
                        int idBooking = Convert.ToInt32(txtIdBooking.Text);
                        string updateBooking = "UPDATE tbl_booking SET status = 'disetujui' WHERE id_booking = @id";
                        SqlCommand cmdBooking = new SqlCommand(updateBooking, conn);
                        cmdBooking.Parameters.AddWithValue("@id", idBooking);
                        cmdBooking.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pembayaran berhasil dikonfirmasi!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    UpdateStatistik();
                    LoadDetailPembayaran(selectedIdPembayaran);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Konfirmasi: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== TOLAK PEMBAYARAN ====================
        private void TolakPembayaran()
        {
            if (selectedIdPembayaran == 0)
            {
                MessageBox.Show("Pilih pembayaran terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Validasi id_admin
            if (id_admin == 0)
            {
                MessageBox.Show("ID Admin tidak valid! Pastikan Anda login sebagai admin.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Tolak pembayaran ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        string query = @"UPDATE tbl_pembayaran 
                                         SET status = 'ditolak', 
                                             dikonfirmasi_oleh = @id_admin,
                                             catatan_admin = @catatan
                                         WHERE id_pembayaran = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedIdPembayaran);
                        cmd.Parameters.AddWithValue("@id_admin", id_admin);
                        cmd.Parameters.AddWithValue("@catatan", txtCatatanAdmin.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pembayaran ditolak!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    UpdateStatistik();
                    LoadDetailPembayaran(selectedIdPembayaran);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Tolak: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== SIMPAN CATATAN ====================
        private void SimpanCatatanAdmin()
        {
            if (selectedIdPembayaran == 0)
            {
                MessageBox.Show("Pilih pembayaran terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "UPDATE tbl_pembayaran SET catatan_admin = @catatan WHERE id_pembayaran = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedIdPembayaran);
                    cmd.Parameters.AddWithValue("@catatan", txtCatatanAdmin.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Catatan berhasil disimpan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENT HANDLERS ====================
        private void FormPembayaran_Load(object sender, EventArgs e)
        {
            if (dgvPembayaran.Columns.Contains("id_pembayaran")) dgvPembayaran.Columns["id_pembayaran"].Width = 50;
            if (dgvPembayaran.Columns.Contains("NamaPelanggan")) dgvPembayaran.Columns["NamaPelanggan"].Width = 150;
            if (dgvPembayaran.Columns.Contains("nama_studio")) dgvPembayaran.Columns["nama_studio"].Width = 120;
            if (dgvPembayaran.Columns.Contains("tanggal_booking")) dgvPembayaran.Columns["tanggal_booking"].Width = 100;
            if (dgvPembayaran.Columns.Contains("total_harga")) dgvPembayaran.Columns["total_harga"].Width = 120;
            if (dgvPembayaran.Columns.Contains("jumlah_bayar")) dgvPembayaran.Columns["jumlah_bayar"].Width = 120;
            if (dgvPembayaran.Columns.Contains("status")) dgvPembayaran.Columns["status"].Width = 100;
            if (dgvPembayaran.Columns.Contains("tgl_pembayaran")) dgvPembayaran.Columns["tgl_pembayaran"].Width = 120;
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e) { KonfirmasiPembayaran(); }
        private void btnTolak_Click(object sender, EventArgs e) { TolakPembayaran(); }
        private void btnSimpanCatatan_Click(object sender, EventArgs e) { SimpanCatatanAdmin(); }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            UpdateStatistik();
            ClearDetail();
            cmbPelangganFilter.SelectedIndex = -1;
            cmbStatusFilter.SelectedIndex = 0;
            dtpTanggalFilter.Value = DateTime.Now;
            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCari_Click(object sender, EventArgs e) { LoadDataWithFilter(); }
        private void btnTutup_Click(object sender, EventArgs e) { this.Close(); }

        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPembayaran.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedIdPembayaran = Convert.ToInt32(dgvPembayaran.Rows[e.RowIndex].Cells[0].Value);
                LoadDetailPembayaran(selectedIdPembayaran);
            }
        }

        // Event handlers kosong
        private void txtMetodeBayar_TextChanged(object sender, EventArgs e) { }
        private void lblJudul_Click(object sender, EventArgs e) { }
        private void lnlIdPembayaran_Click(object sender, EventArgs e) { }
        private void lblPelanggan_Click(object sender, EventArgs e) { }
        private void lblIdBooking_Click(object sender, EventArgs e) { }
        private void lblNoTelp_Click(object sender, EventArgs e) { }
        private void lblEmail_Click(object sender, EventArgs e) { }
        private void lblStudio_Click(object sender, EventArgs e) { }
        private void lblTanggalBooking_Click(object sender, EventArgs e) { }
        private void lblJam_Click(object sender, EventArgs e) { }
        private void lblTotalHarga_Click(object sender, EventArgs e) { }
        private void lblJumlahBayar_Click(object sender, EventArgs e) { }
        private void lblKembalian_Click(object sender, EventArgs e) { }
        private void lblMetodeBayar_Click(object sender, EventArgs e) { }
        private void lblTglBayar_Click(object sender, EventArgs e) { }
        private void lblStatusPembayaran_Click(object sender, EventArgs e) { }
        private void lblCatatanAdmin_Click(object sender, EventArgs e) { }
        private void lblStatusFilter_Click(object sender, EventArgs e) { }
        private void lblPelangganFilter_Click(object sender, EventArgs e) { }
        private void lblTanggalFilter_Click(object sender, EventArgs e) { }
        private void lblDaftarPembayaran_Click(object sender, EventArgs e) { }
        private void lblStatistik_Click(object sender, EventArgs e) { }
        private void txtIdPembayaran_TextChanged(object sender, EventArgs e) { }
        private void txtPelanggan_TextChanged(object sender, EventArgs e) { }
        private void txtIdBooking_TextChanged(object sender, EventArgs e) { }
        private void txtNoTelp_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtStudio_TextChanged(object sender, EventArgs e) { }
        private void txtTanggalBooking_TextChanged(object sender, EventArgs e) { }
        private void txtJam_TextChanged(object sender, EventArgs e) { }
        private void txtTotalHarga_TextChanged(object sender, EventArgs e) { }
        private void txtJumlahBayar_TextChanged(object sender, EventArgs e) { }
        private void txtKembalian_TextChanged(object sender, EventArgs e) { }
        private void txtTanggalBayar_TextChanged(object sender, EventArgs e) { }
        private void txtStatusPembayaran_TextChanged(object sender, EventArgs e) { }
        private void txtCatatanAdmin_TextChanged(object sender, EventArgs e) { }
        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbPelangganFilter_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpTanggalFilter_ValueChanged(object sender, EventArgs e) { }
    }
}