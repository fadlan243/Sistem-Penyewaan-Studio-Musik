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
    public partial class FormAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");

        private int id_admin;
        private string nama_admin;

        public FormAdmin(int id_admin = 1, string nama_admin = "Admin")
        {
            InitializeComponent();
            // Inisialisasi variabel
            this.id_admin = id_admin;
            this.nama_admin = nama_admin;

            // Tampilkan nama admin di label (pastikan label lblAdmin ada di Designer)
            if (lblAdmin != null)
            {
                lblAdmin.Text = $"Halo, {nama_admin}!";
            }

            // Panggil styling
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
        }

        private void PanelAdmin_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Tambahkan border bawah pada panel
            using (Pen pen = new Pen(Color.FromArgb(230, 57, 70), 2))
            {
                e.Graphics.DrawLine(pen, 0, ((Panel)sender).Height - 1,
                    ((Panel)sender).Width, ((Panel)sender).Height - 1);
            }
        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {
            // Optional: Tampilkan info admin saat diklik
            MessageBox.Show($"Admin: {nama_admin}\nID Admin: {id_admin}",
                "Informasi Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            // Form Laporan untuk admin
            FormLaporan formLaporan = new FormLaporan();
            formLaporan.ShowDialog();
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            // Form Riwayat Booking
            FormRiwayatBooking formRiwayat = new FormRiwayatBooking();
            formRiwayat.ShowDialog();
        }

        private void btnKelolaStudio_Click(object sender, EventArgs e)
        {
            // Form Kelola Studio
            FormKelolaStudio formStudio = new FormKelolaStudio();
            formStudio.ShowDialog();
        }

       
    }
}
