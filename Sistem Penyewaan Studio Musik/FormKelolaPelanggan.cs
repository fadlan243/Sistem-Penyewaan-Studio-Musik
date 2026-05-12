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
    public partial class FormKelolaPelanggan : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");

        private DataTable dtUser;
        private int selectedIdUser = 0;
        private int selectedIdPelanggan = 0;
        private int selectedIdAdmin = 0;
        private string mode = ""; // "tambah" atau "edit"

        // Placeholder menggunakan SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        public FormKelolaPelanggan()
        {
            InitializeComponent();
            SetPlaceholders();
            LoadData();
            UpdateStatistik();
            ClearForm();
        }

        private void SetPlaceholders()
        {
            SetPlaceholder(txtCari, "🔍 Cari nama atau email...");
            SetPlaceholder(txtNamaLengkap, "Masukkan nama lengkap");
            SetPlaceholder(txtUsername, "Masukkan username");
            SetPlaceholder(txtPassword, "Masukkan password");
            SetPlaceholder(txtNoTelp, "081234567890");
            SetPlaceholder(txtEmail, "user@example.com");
            SetPlaceholder(txtAlamat, "Masukkan alamat");
            SetPlaceholder(txtJabatan, "Staff / Admin");
        }

        private void LoadData(string search = "")
        {
            try
            {
                conn.Open();
                string query = @"SELECT u.id_user, u.Username, u.Email, u.role, u.is_active,
                                        p.Nama as NamaPelanggan, p.NoTelp, p.Alamat,
                                        a.Nama as NamaAdmin, a.jabatan, a.NoTelp as AdminTelp
                                 FROM users u
                                 LEFT JOIN pelanggan p ON u.id_user = p.id_user
                                 LEFT JOIN tbl_admin a ON u.id_user = a.id_user
                                 WHERE u.Username LIKE @search OR u.Email LIKE @search
                                 ORDER BY u.id_user";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                dtUser = new DataTable();
                da.Fill(dtUser);
                conn.Close();

                dgvUser.DataSource = dtUser;

                // Atur header kolom
                if (dgvUser.Columns.Count > 0)
                {
                    if (dgvUser.Columns.Contains("id_user"))
                        dgvUser.Columns["id_user"].HeaderText = "ID";
                    if (dgvUser.Columns.Contains("NamaPelanggan"))
                        dgvUser.Columns["NamaPelanggan"].HeaderText = "Nama";
                    if (dgvUser.Columns.Contains("NamaAdmin"))
                        dgvUser.Columns["NamaAdmin"].HeaderText = "Nama Admin";
                    if (dgvUser.Columns.Contains("Username"))
                        dgvUser.Columns["Username"].HeaderText = "Username";
                    if (dgvUser.Columns.Contains("Email"))
                        dgvUser.Columns["Email"].HeaderText = "Email";
                    if (dgvUser.Columns.Contains("role"))
                        dgvUser.Columns["role"].HeaderText = "Role";
                    if (dgvUser.Columns.Contains("is_active"))
                        dgvUser.Columns["is_active"].HeaderText = "Status";
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
            string filter = "";
            if (rbAdmin.Checked)
                filter = "admin";
            else if (rbPelanggan.Checked)
                filter = "pelanggan";

            string search = txtCari.Text;

            try
            {
                conn.Open();
                string query;
                if (filter != "")
                {
                    query = @"SELECT u.id_user, u.Username, u.Email, u.role, u.is_active,
                                     p.Nama as NamaPelanggan, p.NoTelp, p.Alamat,
                                     a.Nama as NamaAdmin, a.jabatan
                              FROM users u
                              LEFT JOIN pelanggan p ON u.id_user = p.id_user
                              LEFT JOIN tbl_admin a ON u.id_user = a.id_user
                              WHERE (u.Username LIKE @search OR u.Email LIKE @search)
                              AND u.role = @role
                              ORDER BY u.id_user";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                    da.SelectCommand.Parameters.AddWithValue("@role", filter);
                    dtUser = new DataTable();
                    da.Fill(dtUser);
                }
                else
                {
                    query = @"SELECT u.id_user, u.Username, u.Email, u.role, u.is_active,
                                     p.Nama as NamaPelanggan, p.NoTelp, p.Alamat,
                                     a.Nama as NamaAdmin, a.jabatan
                              FROM users u
                              LEFT JOIN pelanggan p ON u.id_user = p.id_user
                              LEFT JOIN tbl_admin a ON u.id_user = a.id_user
                              WHERE u.Username LIKE @search OR u.Email LIKE @search
                              ORDER BY u.id_user";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                    dtUser = new DataTable();
                    da.Fill(dtUser);
                }
                conn.Close();
                dgvUser.DataSource = dtUser;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== UPDATE STATISTIK ====================
        private void UpdateStatistik()
        {
            try
            {
                conn.Open();

                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM users", conn);
                int totalUser = (int)cmdTotal.ExecuteScalar();

                SqlCommand cmdAdmin = new SqlCommand("SELECT COUNT(*) FROM users WHERE role = 'admin'", conn);
                int totalAdmin = (int)cmdAdmin.ExecuteScalar();

                SqlCommand cmdPelanggan = new SqlCommand("SELECT COUNT(*) FROM users WHERE role = 'pelanggan'", conn);
                int totalPelanggan = (int)cmdPelanggan.ExecuteScalar();

                SqlCommand cmdAktif = new SqlCommand("SELECT COUNT(*) FROM users WHERE is_active = 1", conn);
                int totalAktif = (int)cmdAktif.ExecuteScalar();

                SqlCommand cmdNonaktif = new SqlCommand("SELECT COUNT(*) FROM users WHERE is_active = 0", conn);
                int totalNonaktif = (int)cmdNonaktif.ExecuteScalar();

                conn.Close();

                lblStatistik.Text = $"📊 STATISTIK: Total User: {totalUser} | Admin: {totalAdmin} | Pelanggan: {totalPelanggan} | Aktif: {totalAktif} | Nonaktif: {totalNonaktif}";
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
            txtNamaLengkap.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtNoTelp.Clear();
            txtAlamat.Clear();
            txtJabatan.Clear();
            cbRole.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            selectedIdUser = 0;
            selectedIdPelanggan = 0;
            selectedIdAdmin = 0;
            mode = "";
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            btnAktifkan.Enabled = false;
            btnNonaktifkan.Enabled = false;
            btnSimpan.Text = "💾 Simpan";

            // Tampilkan field sesuai role default
            bool isAdmin = (cbRole.SelectedItem?.ToString() == "Admin");
            txtJabatan.Visible = isAdmin;
            lblJabatan.Visible = isAdmin;
            txtAlamat.Visible = !isAdmin;
            lblAlamat.Visible = !isAdmin;
        }

        // ==================== AMBIL DATA DARI FORM ====================
        private (string nama, string username, string email, string password, string noTelp, string alamat, string jabatan) GetFormData()
        {
            return (
                txtNamaLengkap.Text,
                txtUsername.Text,
                txtEmail.Text,
                txtPassword.Text,
                txtNoTelp.Text,
                txtAlamat.Text,
                txtJabatan.Text
            );
        }

        // ==================== VALIDASI FORM ====================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text))
            {
                MessageBox.Show("Nama Lengkap harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaLengkap.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (mode == "tambah" && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password harus diisi untuk user baru!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }


        private void label5_Click(object sender, EventArgs e)
        {
   
        }

        private void FormKelolaPelanggan_Load(object sender, EventArgs e)
        {
            if (dgvUser.Columns.Contains("id_user")) dgvUser.Columns["id_user"].Width = 50;
            if (dgvUser.Columns.Contains("NamaPelanggan")) dgvUser.Columns["NamaPelanggan"].Width = 150;
            if (dgvUser.Columns.Contains("NamaAdmin")) dgvUser.Columns["NamaAdmin"].Width = 150;
            if (dgvUser.Columns.Contains("Username")) dgvUser.Columns["Username"].Width = 120;
            if (dgvUser.Columns.Contains("Email")) dgvUser.Columns["Email"].Width = 150;
            if (dgvUser.Columns.Contains("role")) dgvUser.Columns["role"].Width = 80;
            if (dgvUser.Columns.Contains("is_active")) dgvUser.Columns["is_active"].Width = 70;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isAdmin = (cbRole.SelectedItem?.ToString() == "Admin");
            txtJabatan.Visible = isAdmin;
            lblJabatan.Visible = isAdmin;
            txtAlamat.Visible = !isAdmin;
            lblAlamat.Visible = !isAdmin;
        }

        private void lblLengkap_Click(object sender, EventArgs e)
        {

        }

        private void txtNamaLengkap_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNoTelp_Click(object sender, EventArgs e)
        {

        }

        private void txtNoTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAlamat_Click(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblJabatan_Click(object sender, EventArgs e)
        {

        }

        private void txtJabatan_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var data = GetFormData();
            string role = cbRole.SelectedItem?.ToString() == "Admin" ? "admin" : "pelanggan";
            int isActive = cmbStatus.SelectedItem?.ToString() == "Active" ? 1 : 0;

            try
            {
                conn.Open();

                if (mode == "tambah")
                {
                    // Insert ke users
                    string queryUser = @"INSERT INTO users (Username, Email, Password, role, is_active) 
                                         VALUES (@username, @email, @password, @role, @is_active);
                                         SELECT SCOPE_IDENTITY()";
                    SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                    cmdUser.Parameters.AddWithValue("@username", data.username);
                    cmdUser.Parameters.AddWithValue("@email", data.email);
                    cmdUser.Parameters.AddWithValue("@password", data.password);
                    cmdUser.Parameters.AddWithValue("@role", role);
                    cmdUser.Parameters.AddWithValue("@is_active", isActive);
                    int newIdUser = Convert.ToInt32(cmdUser.ExecuteScalar());

                    if (role == "admin")
                    {
                        string queryAdmin = @"INSERT INTO tbl_admin (id_user, Nama, jabatan, NoTelp) 
                                              VALUES (@id_user, @nama, @jabatan, @notelp)";
                        SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn);
                        cmdAdmin.Parameters.AddWithValue("@id_user", newIdUser);
                        cmdAdmin.Parameters.AddWithValue("@nama", data.nama);
                        cmdAdmin.Parameters.AddWithValue("@jabatan", data.jabatan);
                        cmdAdmin.Parameters.AddWithValue("@notelp", data.noTelp);
                        cmdAdmin.ExecuteNonQuery();
                    }
                    else
                    {
                        string queryPelanggan = @"INSERT INTO pelanggan (id_user, Nama, Username, NoTelp, Email, Alamat, Password) 
                                                  VALUES (@id_user, @nama, @username, @notelp, @email, @alamat, @password)";
                        SqlCommand cmdPelanggan = new SqlCommand(queryPelanggan, conn);
                        cmdPelanggan.Parameters.AddWithValue("@id_user", newIdUser);
                        cmdPelanggan.Parameters.AddWithValue("@nama", data.nama);
                        cmdPelanggan.Parameters.AddWithValue("@username", data.username);
                        cmdPelanggan.Parameters.AddWithValue("@notelp", data.noTelp);
                        cmdPelanggan.Parameters.AddWithValue("@email", data.email);
                        cmdPelanggan.Parameters.AddWithValue("@alamat", data.alamat);
                        cmdPelanggan.Parameters.AddWithValue("@password", data.password);
                        cmdPelanggan.ExecuteNonQuery();
                    }
                    MessageBox.Show("User berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // EDIT
                {
                    string queryUser = @"UPDATE users 
                                         SET Username = @username, Email = @email, is_active = @is_active";
                    if (!string.IsNullOrWhiteSpace(data.password))
                        queryUser += ", Password = @password";
                    queryUser += " WHERE id_user = @id_user";

                    SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                    cmdUser.Parameters.AddWithValue("@username", data.username);
                    cmdUser.Parameters.AddWithValue("@email", data.email);
                    cmdUser.Parameters.AddWithValue("@is_active", isActive);
                    cmdUser.Parameters.AddWithValue("@id_user", selectedIdUser);
                    if (!string.IsNullOrWhiteSpace(data.password))
                        cmdUser.Parameters.AddWithValue("@password", data.password);
                    cmdUser.ExecuteNonQuery();

                    if (role == "admin")
                    {
                        string queryAdmin = @"UPDATE tbl_admin SET Nama = @nama, jabatan = @jabatan, NoTelp = @notelp 
                                              WHERE id_user = @id_user";
                        SqlCommand cmdAdmin = new SqlCommand(queryAdmin, conn);
                        cmdAdmin.Parameters.AddWithValue("@id_user", selectedIdUser);
                        cmdAdmin.Parameters.AddWithValue("@nama", data.nama);
                        cmdAdmin.Parameters.AddWithValue("@jabatan", data.jabatan);
                        cmdAdmin.Parameters.AddWithValue("@notelp", data.noTelp);
                        cmdAdmin.ExecuteNonQuery();
                    }
                    else
                    {
                        string queryPelanggan = @"UPDATE pelanggan 
                                                  SET Nama = @nama, Username = @username, NoTelp = @notelp, 
                                                      Email = @email, Alamat = @alamat
                                                  WHERE id_user = @id_user";
                        SqlCommand cmdPelanggan = new SqlCommand(queryPelanggan, conn);
                        cmdPelanggan.Parameters.AddWithValue("@id_user", selectedIdUser);
                        cmdPelanggan.Parameters.AddWithValue("@nama", data.nama);
                        cmdPelanggan.Parameters.AddWithValue("@username", data.username);
                        cmdPelanggan.Parameters.AddWithValue("@notelp", data.noTelp);
                        cmdPelanggan.Parameters.AddWithValue("@email", data.email);
                        cmdPelanggan.Parameters.AddWithValue("@alamat", data.alamat);
                        cmdPelanggan.ExecuteNonQuery();
                    }
                    MessageBox.Show("User berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                LoadDataWithFilter();
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
            dgvUser.ClearSelection();
            btnSimpan.Text = "💾 Simpan";
            mode = "";
        }

        private void lblDaftarUser_Click(object sender, EventArgs e)
        {

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            LoadDataWithFilter();
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {

        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdmin.Checked) LoadDataWithFilter();
        }

        private void rbPelanggan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPelanggan.Checked) LoadDataWithFilter();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            ClearForm();
            selectedIdUser = 0;
            mode = "tambah";
            txtNamaLengkap.Focus();
            btnSimpan.Text = "💾 Simpan";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIdUser == 0)
            {
                MessageBox.Show("Pilih user yang akan diedit!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNamaLengkap.Focus();
            btnSimpan.Text = "✏️ Update";
            mode = "edit";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (selectedIdUser == 0)
            {
                MessageBox.Show("Pilih user yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus user ini? Semua data terkait akan terhapus!",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE id_user = @id_user";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_user", selectedIdUser);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("User berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataWithFilter();
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

        private void btnAktifkan_Click(object sender, EventArgs e)
        {
            if (selectedIdUser == 0)
            {
                MessageBox.Show("Pilih user yang akan diaktifkan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                string query = "UPDATE users SET is_active = 1 WHERE id_user = @id_user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", selectedIdUser);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("User berhasil diaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataWithFilter();
                UpdateStatistik();
                ClearForm();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNonaktifkan_Click(object sender, EventArgs e)
        {
            if (selectedIdUser == 0)
            {
                MessageBox.Show("Pilih user yang akan dinonaktifkan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menonaktifkan user ini?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET is_active = 0 WHERE id_user = @id_user";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_user", selectedIdUser);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("User berhasil dinonaktifkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataWithFilter();
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

        private void lblStatistik_Click(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUser.Rows[e.RowIndex].Cells[0].Value != null)
            {
                try
                {
                    DataGridViewRow row = dgvUser.Rows[e.RowIndex];

                    // Gunakan indeks kolom (lebih aman dari error nama kolom)
                    selectedIdUser = Convert.ToInt32(row.Cells[0].Value);
                    string role = row.Cells[3].Value?.ToString() ?? ""; // kolom ke-4 (index 3)

                    txtUsername.Text = row.Cells[1].Value?.ToString() ?? ""; // kolom Username
                    txtEmail.Text = row.Cells[2].Value?.ToString() ?? "";    // kolom Email

                    if (role == "admin")
                    {
                        cbRole.SelectedItem = "Admin";
                        txtNamaLengkap.Text = row.Cells[6].Value?.ToString() ?? ""; // NamaAdmin
                        txtJabatan.Text = row.Cells[8].Value?.ToString() ?? "";      // jabatan
                        txtNoTelp.Text = row.Cells[9].Value?.ToString() ?? "";       // AdminTelp
                        selectedIdAdmin = Convert.ToInt32(row.Cells[0].Value);

                        // Sembunyikan field pelanggan, tampilkan field admin
                        txtJabatan.Visible = true;
                        lblJabatan.Visible = true;
                        txtAlamat.Visible = false;
                        lblAlamat.Visible = false;
                    }
                    else
                    {
                        cbRole.SelectedItem = "Pelanggan";
                        txtNamaLengkap.Text = row.Cells[5].Value?.ToString() ?? ""; // NamaPelanggan
                        txtAlamat.Text = row.Cells[7].Value?.ToString() ?? "";      // Alamat
                        txtNoTelp.Text = row.Cells[9].Value?.ToString() ?? "";      // NoTelp
                        selectedIdPelanggan = Convert.ToInt32(row.Cells[0].Value);

                        // Sembunyikan field admin, tampilkan field pelanggan
                        txtJabatan.Visible = false;
                        lblJabatan.Visible = false;
                        txtAlamat.Visible = true;
                        lblAlamat.Visible = true;
                    }

                    int isActive = Convert.ToInt32(row.Cells[4].Value); // kolom is_active
                    cmbStatus.SelectedItem = (isActive == 1) ? "Active" : "Nonactive";

                    btnEdit.Enabled = true;
                    btnHapus.Enabled = true;
                    btnAktifkan.Enabled = true;
                    btnNonaktifkan.Enabled = true;
                    btnSimpan.Text = "✏️ Update";
                    mode = "edit";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat memilih data: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
