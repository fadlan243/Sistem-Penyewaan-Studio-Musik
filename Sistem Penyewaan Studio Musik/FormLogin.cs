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
        SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");
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

        
    }
}
