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
    public partial class FormRegister : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");
        public FormRegister()
        {
            InitializeComponent();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Efek saat judul diklik
            lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (s, args) =>
            {
                lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
                timer.Stop();
            };
            timer.Start();
        }

        private void lblNama_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Nama Lengkap
            txtNama.Focus();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Username
            txtUsername.Focus();
        }

        private void lblTelp_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox No. Telepon
            txtTelp.Focus();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Email
            txtEmail.Focus();
        }

        private void lblAlamat_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Alamat
            txtAlamat.Focus();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Password
            txtPassword.Focus();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Set properti awal untuk password
            txtPassword.PasswordChar = '●';
            txtPassword.UseSystemPasswordChar = true;

            txtKonfPass.PasswordChar = '●';
            txtKonfPass.UseSystemPasswordChar = true;

            // Set placeholder text jika diperlukan
            SetPlaceholders();
        }

        private void lblKonfPass_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Konfirmasi Password
            txtKonfPass.Focus();
        }

        private void SetPlaceholders()
        {
            // Menambahkan placeholder untuk TextBox (opsional)
            txtNama.Tag = "Masukkan nama lengkap";
            txtUsername.Tag = "Minimal 3 karakter";
            txtTelp.Tag = "Masukkan nomor telepon";
            txtEmail.Tag = "contoh: email@domain.com";
            txtAlamat.Tag = "Masukkan alamat lengkap";
            txtPassword.Tag = "Minimal 6 karakter";
            txtKonfPass.Tag = "Ketik ulang password";
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Nama berubah
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Username berubah
        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks No Telepon berubah
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Email berubah
        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Alamat berubah
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Password berubah
            // Bisa ditambahkan validasi real-time untuk kekuatan password
        }

        private void txtKonfPass_TextChanged(object sender, EventArgs e)
        {
            // Event ketika teks Konfirmasi Password berubah
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validasi input (tetap sama seperti sebelumnya)
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama Lengkap tidak boleh kosong!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Username minimal 3 karakter!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtTelp.Text))
            {
                MessageBox.Show("Nomor Telepon tidak boleh kosong!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelp.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Format email tidak valid!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password minimal 6 karakter!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus(); return;
            }
            if (txtPassword.Text != txtKonfPass.Text)
            {
                MessageBox.Show("Konfirmasi Password tidak cocok!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKonfPass.Focus(); return;
            }

            DialogResult result = MessageBox.Show(
                $"Nama: {txtNama.Text}\nUsername: {txtUsername.Text}\nEmail: {txtEmail.Text}\n\nSimpan data?",
                "Konfirmasi Registrasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                conn.Open();

                // Cek username sudah ada belum
                string cekQuery = "SELECT COUNT(*) FROM pelanggan WHERE Username = @Username";
                SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                cekCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                int count = (int)cekCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Username sudah digunakan! Pilih username lain.", "Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    txtUsername.Focus();
                    return;
                }

                // Insert ke tabel users dulu
                string queryUsers = "INSERT INTO users (Username, Email, Password, role) " +
                                    "VALUES (@Username, @Email, @Password, 'pelanggan'); " +
                                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmdUsers = new SqlCommand(queryUsers, conn);
                cmdUsers.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmdUsers.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdUsers.Parameters.AddWithValue("@Password", txtPassword.Text);
                int newIdUser = Convert.ToInt32(cmdUsers.ExecuteScalar());

                // Insert ke tabel pelanggan
                string queryPelanggan = "INSERT INTO pelanggan (id_user, Nama, Username, NoTelp, Email, Alamat, Password) " +
                                        "VALUES (@id_user, @Nama, @Username, @NoTelp, @Email, @Alamat, @Password)";
                SqlCommand cmdPelanggan = new SqlCommand(queryPelanggan, conn);
                cmdPelanggan.Parameters.AddWithValue("@id_user", newIdUser);
                cmdPelanggan.Parameters.AddWithValue("@Nama", txtNama.Text);
                cmdPelanggan.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmdPelanggan.Parameters.AddWithValue("@NoTelp", txtTelp.Text);
                cmdPelanggan.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdPelanggan.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                cmdPelanggan.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmdPelanggan.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Registrasi Berhasil! Silakan login.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRegistrationData()
        {
            // Method untuk menyimpan data ke database
            // Contoh sementara - ganti dengan implementasi database sebenarnya

            // Simulasi penyimpanan
            MessageBox.Show("Registrasi Berhasil!\n\nSilakan login menggunakan akun Anda.",
                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Buka form login
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Konfirmasi sebelum kembali
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin kembali?\nData yang belum disimpan akan hilang.",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
                this.Close();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Menampilkan atau menyembunyikan password
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.UseSystemPasswordChar = false;
                txtKonfPass.PasswordChar = '\0';
                txtKonfPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.PasswordChar = '●';
                txtPassword.UseSystemPasswordChar = true;
                txtKonfPass.PasswordChar = '●';
                txtKonfPass.UseSystemPasswordChar = true;
            }
        }

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

        // Method tambahan untuk mendukung Enter key
        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtUsername.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtTelp.Focus();
        }

        private void txtTelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtEmail.Focus();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtAlamat.Focus();
        }

        private void txtAlamat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtKonfPass.Focus();
        }

        private void txtKonfPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnRegister_Click(sender, e);
        }

        // Method untuk clear form setelah registrasi berhasil
        private void ClearForm()
        {
            txtNama.Clear();
            txtUsername.Clear();
            txtTelp.Clear();
            txtEmail.Clear();
            txtAlamat.Clear();
            txtPassword.Clear();
            txtKonfPass.Clear();
            chkShowPassword.Checked = false;
            txtNama.Focus();
        }
    }
}
