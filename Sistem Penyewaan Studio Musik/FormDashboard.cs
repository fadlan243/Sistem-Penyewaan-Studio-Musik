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
    public partial class FormDashboard : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Membuka form registrasi
            FormRegister formRegister = new FormRegister();
            formRegister.Show();
            this.Hide(); // Menyembunyikan form dashboard
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Efek sederhana ketika title diklik - mengubah warna sementara
            lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (s, args) =>
            {
                lblTitle.ForeColor = Color.White;
                timer.Stop();
            };
            timer.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Membuka form login yang memiliki pilihan user (Admin/Pelanggan)
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblBlack_Click(object sender, EventArgs e)
        {

        }

        private void lblStudio_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Tambahkan border bawah pada panel
            using (Pen pen = new Pen(Color.FromArgb(230, 57, 70), 2))
            {
                e.Graphics.DrawLine(pen, 0, ((Panel)sender).Height - 1,
                    ((Panel)sender).Width, ((Panel)sender).Height - 1);
            }
        }

        private void btnSqlInjectionDemo_Click(object sender, EventArgs e)
        {
            FormLoginRentan form = new FormLoginRentan();
            form.ShowDialog();
        }
    }
}
