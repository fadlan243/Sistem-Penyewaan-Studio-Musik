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

    }
}
