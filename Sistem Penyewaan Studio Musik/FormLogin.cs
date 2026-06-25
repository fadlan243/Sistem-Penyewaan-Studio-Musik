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
    public partial class FormLogin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");
        private int id_admin;
        private string nama_admin;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextBox untuk username - tidak perlu aksi khusus
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Efek saat judul diklik - berubah warna oranye sebentar
            lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (s, args) =>
            {
                lblTitle.ForeColor = Color.Black;
                timer.Stop();
            };
            timer.Start();
        }

        private void lblUserType_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke ComboBox ketika label diklik
            comboBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Opsional: Menampilkan pesan welcome sesuai pilihan
            string selectedUser = comboBox1.SelectedItem?.ToString() ?? "Pelanggan";
            // Bisa ditambahkan efek suara atau perubahan background
            System.Diagnostics.Debug.WriteLine($"User memilih: {selectedUser}");
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Username ketika label diklik
            txtUsername.Focus();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            // Memindahkan fokus ke TextBox Password ketika label diklik
            txtPassword.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Opsional: Bisa ditambahkan validasi real-time jika diperlukan
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Menampilkan atau menyembunyikan password saat checkbox dicentang
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Menampilkan teks asli
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Menampilkan bullet
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Harap masukkan Username!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Harap masukkan Password!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            string userType = comboBox1.SelectedItem?.ToString() ?? "Pelanggan";
            string role = (userType == "Admin") ? "admin" : "pelanggan";

            try
            {
                conn.Open();

                // ✅ PERBAIKAN: Query lengkap dengan JOIN ke pelanggan
                string query = @"SELECT u.id_user, u.Username, u.role, 
                                        a.id_admin, a.Nama as NamaAdmin,
                                        p.id_pelanggan, p.Nama as NamaPelanggan
                                 FROM users u
                                 LEFT JOIN tbl_admin a ON u.id_user = a.id_user
                                 LEFT JOIN pelanggan p ON u.id_user = p.id_user
                                 WHERE u.Username = @Username 
                                 AND u.Password = @Password 
                                 AND u.role = @role 
                                 AND u.is_active = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@role", role);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string namaRole = reader["role"].ToString();
                    string username = reader["Username"].ToString();

                    reader.Close();
                    conn.Close();

                    MessageBox.Show($"Selamat datang {userType} {username}!", "Login Berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (namaRole == "admin")
                    {
                        // Ambil data admin
                        int id_admin = 1;
                        string nama_admin = username;

                        conn.Open();
                        SqlCommand cmdAdmin = new SqlCommand(
                            "SELECT id_admin, Nama FROM tbl_admin WHERE id_user = (SELECT id_user FROM users WHERE Username = @Username)",
                            conn);
                        cmdAdmin.Parameters.AddWithValue("@Username", username);
                        SqlDataReader readerAdmin = cmdAdmin.ExecuteReader();

                        if (readerAdmin.Read())
                        {
                            id_admin = Convert.ToInt32(readerAdmin["id_admin"]);
                            nama_admin = readerAdmin["Nama"].ToString();
                        }
                        readerAdmin.Close();
                        conn.Close();

                        // Buka FormAdmin
                        FormAdmin formAdmin = new FormAdmin(id_admin, nama_admin);
                        formAdmin.Show();
                        this.Hide();
                    }
                    else // PELANGGAN
                    {
                        // ✅ PERBAIKAN: Ambil data pelanggan dari database
                        int id_pelanggan = 1;
                        string nama_pelanggan = username;
                        string username_pelanggan = username;

                        conn.Open();
                        SqlCommand cmdPelanggan = new SqlCommand(
                            "SELECT id_pelanggan, Nama FROM pelanggan WHERE id_user = (SELECT id_user FROM users WHERE Username = @Username)",
                            conn);
                        cmdPelanggan.Parameters.AddWithValue("@Username", username);
                        SqlDataReader readerPelanggan = cmdPelanggan.ExecuteReader();

                        if (readerPelanggan.Read())
                        {
                            id_pelanggan = Convert.ToInt32(readerPelanggan["id_pelanggan"]);
                            nama_pelanggan = readerPelanggan["Nama"].ToString();
                        }
                        readerPelanggan.Close();
                        conn.Close();

                        // ✅ PERBAIKAN: Buka FormPelanggan dengan parameter
                        FormPelanggan formPelanggan = new FormPelanggan(id_pelanggan, nama_pelanggan, username_pelanggan);
                        formPelanggan.Show();
                        this.Hide();
                    }
                }
                else
                {
                    reader.Close();
                    conn.Close();
                    MessageBox.Show("Username atau Password salah!\nPastikan Role yang dipilih sesuai.",
                        "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kembali ke form dashboard
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin kembali?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
                this.Close();
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            // Opsional: Memberikan efek visual saat TextBox diklik
            txtUsername.BackColor = Color.FromArgb(240, 240, 255);

            // Timer untuk mengembalikan warna asli
            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Tick += (s, args) =>
            {
                txtUsername.BackColor = Color.White;
                timer.Stop();
            };
            timer.Start();
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            comboBox1.SelectedIndex = 0; // Pilih item pertama (Admin)
            chkShowPassword.Checked = false;
            txtUsername.Focus();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        // Event untuk form loading (tambahkan di designer jika perlu)
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Set default selection
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; // Pilih Admin sebagai default
            }

            // Set placeholder text jika diperlukan
            // txtUsername.Text = "Masukkan Username";
            // txtUsername.ForeColor = Color.Gray;

            // Atur properti password
            txtPassword.PasswordChar = '●';
            txtPassword.UseSystemPasswordChar = true;

            // Fokus ke username
            txtUsername.Focus();
        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
