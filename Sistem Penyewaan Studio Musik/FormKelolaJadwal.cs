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
    public partial class FormKelolaJadwal : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");

        private DataTable dtJadwal;
        private int selectedIdJadwal = 0;
        private string mode = ""; // "tambah" atau "edit"

        // Placeholder menggunakan SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        public FormKelolaJadwal()
        {
            InitializeComponent();
            SetPlaceholder(txtKeterangan, "Catatan tambahan...");
            LoadStudioCombo();
            LoadData();
            UpdateStatistik();
            ClearForm();
        }

        // ==================== LOAD COMBOBOX STUDIO ====================
        private void LoadStudioCombo()
        {
            try
            {
                conn.Open();
                string query = "SELECT id_studio, nama_studio FROM tbl_studio WHERE status = 'aktif' ORDER BY nama_studio";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtStudio = new DataTable();
                da.Fill(dtStudio);
                conn.Close();

                cbStudioFilter.DataSource = dtStudio;
                cbStudioFilter.DisplayMember = "nama_studio";
                cbStudioFilter.ValueMember = "id_studio";

                cbStudio.DataSource = dtStudio.Copy();
                cbStudio.DisplayMember = "nama_studio";
                cbStudio.ValueMember = "id_studio";

                if (cbStudioFilter.Items.Count > 0)
                    cbStudioFilter.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadStudio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DATA KE DATAGRIDVIEW ====================
        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = @"SELECT j.id_jadwal, s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                        j.status, j.keterangan
                                 FROM tbl_jadwal j
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 ORDER BY j.tanggal DESC, j.jam_mulai";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtJadwal = new DataTable();
                da.Fill(dtJadwal);
                conn.Close();

                dgvJadwal.DataSource = dtJadwal;

                // Atur header kolom
                if (dgvJadwal.Columns.Count > 0)
                {
                    if (dgvJadwal.Columns.Contains("id_jadwal")) dgvJadwal.Columns["id_jadwal"].HeaderText = "ID";
                    if (dgvJadwal.Columns.Contains("nama_studio")) dgvJadwal.Columns["nama_studio"].HeaderText = "Studio";
                    if (dgvJadwal.Columns.Contains("tanggal"))
                    {
                        dgvJadwal.Columns["tanggal"].HeaderText = "Tanggal";
                        dgvJadwal.Columns["tanggal"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }
                    if (dgvJadwal.Columns.Contains("jam_mulai")) dgvJadwal.Columns["jam_mulai"].HeaderText = "Jam Mulai";
                    if (dgvJadwal.Columns.Contains("jam_selesai")) dgvJadwal.Columns["jam_selesai"].HeaderText = "Jam Selesai";
                    if (dgvJadwal.Columns.Contains("status")) dgvJadwal.Columns["status"].HeaderText = "Status";
                    if (dgvJadwal.Columns.Contains("keterangan")) dgvJadwal.Columns["keterangan"].HeaderText = "Keterangan";
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadData: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== LOAD DATA DENGAN FILTER ====================
        private void LoadDataWithFilter()
        {
            try
            {
                string studioFilter = "";
                if (cbStudioFilter.SelectedValue != null)
                    studioFilter = cbStudioFilter.SelectedValue.ToString();

                DateTime tanggalFilter = dtpTanggalFilter.Value.Date;

                conn.Open();
                string query = @"SELECT j.id_jadwal, s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                        j.status, j.keterangan
                                 FROM tbl_jadwal j
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 WHERE (@studio = '' OR j.id_studio = @studio)
                                 AND (@tanggal = '1900-01-01' OR j.tanggal = @tanggal)
                                 ORDER BY j.tanggal DESC, j.jam_mulai";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@studio", string.IsNullOrEmpty(studioFilter) ? "" : studioFilter);
                da.SelectCommand.Parameters.AddWithValue("@tanggal", tanggalFilter);
                dtJadwal = new DataTable();
                da.Fill(dtJadwal);
                conn.Close();

                dgvJadwal.DataSource = dtJadwal;
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
                conn.Open();

                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM tbl_jadwal", conn);
                int total = (int)cmdTotal.ExecuteScalar();

                SqlCommand cmdTersedia = new SqlCommand("SELECT COUNT(*) FROM tbl_jadwal WHERE status = 'tersedia'", conn);
                int tersedia = (int)cmdTersedia.ExecuteScalar();

                SqlCommand cmdDipesan = new SqlCommand("SELECT COUNT(*) FROM tbl_jadwal WHERE status = 'dipesan'", conn);
                int dipesan = (int)cmdDipesan.ExecuteScalar();

                SqlCommand cmdDitutup = new SqlCommand("SELECT COUNT(*) FROM tbl_jadwal WHERE status = 'ditutup'", conn);
                int ditutup = (int)cmdDitutup.ExecuteScalar();

                conn.Close();

                lblStatistik.Text = $"📊 STATISTIK: Total Jadwal: {total} | Tersedia: {tersedia} | Dipesan: {dipesan} | Ditutup: {ditutup}";
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                lblStatistik.Text = "📊 STATISTIK: Error loading data";
            }
        }

        // ==================== KOSONGKAN FORM ====================
        private void ClearForm()
        {
            if (cbStudio.Items.Count > 0)
                cbStudio.SelectedIndex = 0;
            dtpTanggal.Value = DateTime.Now;
            dtpJamMulai.Value = DateTime.Now;
            dtpJamSelesai.Value = DateTime.Now.AddHours(1);
            cbStatus.SelectedIndex = 0;
            txtKeterangan.Clear();
            selectedIdJadwal = 0;
            mode = "";
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            btnStatusTersedia.Enabled = false;
            btnStatusDitutup.Enabled = false;
            btnSimpan.Text = "💾 Simpan";
        }

        // ==================== VALIDASI FORM ====================
        private bool ValidateForm()
        {
            if (cbStudio.SelectedValue == null)
            {
                MessageBox.Show("Pilih Studio terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbStudio.Focus();
                return false;
            }

            if (dtpJamMulai.Value.TimeOfDay >= dtpJamSelesai.Value.TimeOfDay)
            {
                MessageBox.Show("Jam Mulai harus lebih awal dari Jam Selesai!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpJamMulai.Focus();
                return false;
            }

            return true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpJamMulai_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvJadwal.Rows[e.RowIndex].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvJadwal.Rows[e.RowIndex];
                selectedIdJadwal = Convert.ToInt32(row.Cells[0].Value);

                // Cari studio di combobox
                string studioName = row.Cells[1].Value.ToString();
                for (int i = 0; i < cbStudio.Items.Count; i++)
                {
                    if (cbStudio.Items[i].ToString() == studioName)
                    {
                        cbStudio.SelectedIndex = i;
                        break;
                    }
                }

                dtpTanggal.Value = Convert.ToDateTime(row.Cells[2].Value);
                dtpJamMulai.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells[3].Value.ToString()));
                dtpJamSelesai.Value = DateTime.Today.Add(TimeSpan.Parse(row.Cells[4].Value.ToString()));

                string status = row.Cells[5].Value.ToString();
                if (status == "tersedia") cbStatus.SelectedIndex = 0;
                else if (status == "dipesan") cbStatus.SelectedIndex = 1;
                else cbStatus.SelectedIndex = 2;

                txtKeterangan.Text = row.Cells[6].Value?.ToString() ?? "";

                btnEdit.Enabled = true;
                btnHapus.Enabled = true;
                btnStatusTersedia.Enabled = true;
                btnStatusDitutup.Enabled = true;
                btnSimpan.Text = "✏️ Update";
                mode = "edit";
            }
        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDaftarJadwal_Click(object sender, EventArgs e)
        {

        }

        private void lblStudioFilter_Click(object sender, EventArgs e)
        {

        }

        private void cbStudioFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpTanggalFilter_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblStatistik_Click(object sender, EventArgs e)
        {

        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblStudio_Click(object sender, EventArgs e)
        {

        }

        private void cbStudio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTanggal_Click(object sender, EventArgs e)
        {

        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblJamMulai_Click(object sender, EventArgs e)
        {

        }

        private void FormKelolaJadwal_Load(object sender, EventArgs e)
        {

            if (dgvJadwal.Columns.Contains("id_jadwal")) dgvJadwal.Columns["id_jadwal"].Width = 50;
            if (dgvJadwal.Columns.Contains("nama_studio")) dgvJadwal.Columns["nama_studio"].Width = 150;
            if (dgvJadwal.Columns.Contains("tanggal")) dgvJadwal.Columns["tanggal"].Width = 100;
            if (dgvJadwal.Columns.Contains("jam_mulai")) dgvJadwal.Columns["jam_mulai"].Width = 80;
            if (dgvJadwal.Columns.Contains("jam_selesai")) dgvJadwal.Columns["jam_selesai"].Width = 80;
            if (dgvJadwal.Columns.Contains("status")) dgvJadwal.Columns["status"].Width = 100;
            if (dgvJadwal.Columns.Contains("keterangan")) dgvJadwal.Columns["keterangan"].Width = 150;
        }

        private void lblJamSelesai_Click(object sender, EventArgs e)
        {

        }

        private void dtpJamSelesai_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblKeterangan_Click(object sender, EventArgs e)
        {

        }

        private void txtKeterangan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedIdJadwal = 0;
            mode = "tambah";
            cbStudio.Focus();
            btnSimpan.Text = "💾 Simpan";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal yang akan diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cbStudio.Focus();
            btnSimpan.Text = "✏️ Update";
            mode = "edit";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus jadwal ini?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM tbl_jadwal WHERE id_jadwal = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedIdJadwal);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Jadwal berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    UpdateStatistik();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStatusTersedia_Click(object sender, EventArgs e)
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateStatusJadwal("tersedia");
        }

        private void btnStatusDitutup_Click(object sender, EventArgs e)
        {
            if (selectedIdJadwal == 0)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateStatusJadwal("ditutup");
        }

        private void UpdateStatusJadwal(string status)
        {
            try
            {
                conn.Open();
                string query = "UPDATE tbl_jadwal SET status = @status WHERE id_jadwal = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedIdJadwal);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Status jadwal berhasil diubah menjadi {status}!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                UpdateStatistik();
                ClearForm();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            int idStudio = Convert.ToInt32(cbStudio.SelectedValue);
            DateTime tanggal = dtpTanggal.Value.Date;
            TimeSpan jamMulai = dtpJamMulai.Value.TimeOfDay;
            TimeSpan jamSelesai = dtpJamSelesai.Value.TimeOfDay;
            string status = cbStatus.SelectedItem?.ToString().ToLower() ?? "tersedia";
            string keterangan = txtKeterangan.Text;

            try
            {
                conn.Open();

                if (mode == "tambah")
                {
                    string query = @"INSERT INTO tbl_jadwal (id_studio, tanggal, jam_mulai, jam_selesai, status, keterangan) 
                                     VALUES (@id_studio, @tanggal, @jam_mulai, @jam_selesai, @status, @keterangan)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_studio", idStudio);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                    cmd.Parameters.AddWithValue("@jam_mulai", jamMulai);
                    cmd.Parameters.AddWithValue("@jam_selesai", jamSelesai);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@keterangan", keterangan);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = @"UPDATE tbl_jadwal 
                                     SET id_studio = @id_studio, tanggal = @tanggal, jam_mulai = @jam_mulai, 
                                         jam_selesai = @jam_selesai, status = @status, keterangan = @keterangan
                                     WHERE id_jadwal = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedIdJadwal);
                    cmd.Parameters.AddWithValue("@id_studio", idStudio);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                    cmd.Parameters.AddWithValue("@jam_mulai", jamMulai);
                    cmd.Parameters.AddWithValue("@jam_selesai", jamSelesai);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@keterangan", keterangan);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Jadwal berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                LoadData();
                UpdateStatistik();
                ClearForm();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvJadwal.ClearSelection();
            btnSimpan.Text = "💾 Simpan";
            mode = "";
        }
    }
}
