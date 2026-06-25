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
    public partial class FormProfilPelanggan : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");

        private int id_pelanggan;
        private string nama_pelanggan;
        private string username_pelanggan;
        private string email_pelanggan;
        private string noTelp_pelanggan;
        private string alamat_pelanggan;


        public FormProfilPelanggan(int id_pelanggan, string nama_pelanggan, string username_pelanggan)
        {
            InitializeComponent();
            this.id_pelanggan = id_pelanggan;
            this.nama_pelanggan = nama_pelanggan;
            this.username_pelanggan = username_pelanggan;

            // Tampilkan data profil dari database
            LoadProfil();
        }

        private void FormProfilPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void LoadProfil()
        {
            try
            {
                conn.Open();
                string query = @"SELECT p.Nama, p.Username, p.Email, p.NoTelp, p.Alamat, u.Email as UserEmail
                                 FROM pelanggan p
                                 JOIN users u ON p.id_user = u.id_user
                                 WHERE p.id_pelanggan = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_pelanggan);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNama.Text = reader["Nama"].ToString();
                    txtUsername.Text = reader["Username"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtNoTelp.Text = reader["NoTelp"]?.ToString() ?? "";
                    txtAlamat.Text = reader["Alamat"]?.ToString() ?? "";

                    // Simpan data asli untuk keperluan reset
                    email_pelanggan = reader["Email"].ToString();
                    noTelp_pelanggan = reader["NoTelp"]?.ToString() ?? "";
                    alamat_pelanggan = reader["Alamat"]?.ToString() ?? "";
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error LoadProfil: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== SIMPAN PERUBAHAN PROFIL ====================
        private void SimpanProfil()
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama Lengkap tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validasi email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Format email tidak valid!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // Validasi password baru
            string passwordBaru = txtPasswordBaru.Text.Trim();
            string konfirmasiPassword = txtKonfirmasiPassword.Text.Trim();

            if (!string.IsNullOrEmpty(passwordBaru) && passwordBaru != konfirmasiPassword)
            {
                MessageBox.Show("Password Baru dan Konfirmasi Password tidak cocok!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordBaru.Focus();
                return;
            }

            try
            {
                conn.Open();

                // Update tabel pelanggan
                string queryPelanggan = @"UPDATE pelanggan 
                                          SET Nama = @nama, NoTelp = @notelp, Alamat = @alamat, Email = @email
                                          WHERE id_pelanggan = @id";
                SqlCommand cmdPelanggan = new SqlCommand(queryPelanggan, conn);
                cmdPelanggan.Parameters.AddWithValue("@nama", txtNama.Text);
                cmdPelanggan.Parameters.AddWithValue("@notelp", txtNoTelp.Text);
                cmdPelanggan.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                cmdPelanggan.Parameters.AddWithValue("@email", txtEmail.Text);
                cmdPelanggan.Parameters.AddWithValue("@id", id_pelanggan);
                cmdPelanggan.ExecuteNonQuery();

                // Update tabel users (email dan password jika ada perubahan)
                if (!string.IsNullOrEmpty(passwordBaru))
                {
                    string queryUser = "UPDATE users SET Email = @email, Password = @password WHERE id_user = (SELECT id_user FROM pelanggan WHERE id_pelanggan = @id)";
                    SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                    cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdUser.Parameters.AddWithValue("@password", passwordBaru);
                    cmdUser.Parameters.AddWithValue("@id", id_pelanggan);
                    cmdUser.ExecuteNonQuery();
                }
                else
                {
                    string queryUser = "UPDATE users SET Email = @email WHERE id_user = (SELECT id_user FROM pelanggan WHERE id_pelanggan = @id)";
                    SqlCommand cmdUser = new SqlCommand(queryUser, conn);
                    cmdUser.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmdUser.Parameters.AddWithValue("@id", id_pelanggan);
                    cmdUser.ExecuteNonQuery();
                }

                conn.Close();

                MessageBox.Show("Profil berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update data lokal
                nama_pelanggan = txtNama.Text;
                email_pelanggan = txtEmail.Text;
                noTelp_pelanggan = txtNoTelp.Text;
                alamat_pelanggan = txtAlamat.Text;

                // Kosongkan field password
                txtPasswordBaru.Clear();
                txtKonfirmasiPassword.Clear();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Error SimpanProfil: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== RESET FORM KE DATA ASLI ====================
        private void ResetForm()
        {
            txtNama.Text = nama_pelanggan;
            txtUsername.Text = username_pelanggan;
            txtEmail.Text = email_pelanggan;
            txtNoTelp.Text = noTelp_pelanggan;
            txtAlamat.Text = alamat_pelanggan;
            txtPasswordBaru.Clear();
            txtKonfirmasiPassword.Clear();
        }

        // ==================== REFRESH (LOAD ULANG DARI DATABASE) ====================
        private void RefreshForm()
        {
            LoadProfil();
        }

        // ==================== VALIDASI EMAIL ====================
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void lblRiwayatBooking_Click(object sender, EventArgs e)
        {

        }

        private void lblKonfirmasiPassword_Click(object sender, EventArgs e)
        {

        }

        private void lblPasswordBaru_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblNoTelp_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblNamaLengkapi_Click(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSubJudul_Click(object sender, EventArgs e)
        {

        }

        private void lblAlamat_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPasswordBaru_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKonfirmasiPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanProfil();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
            MessageBox.Show("Data profil berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
