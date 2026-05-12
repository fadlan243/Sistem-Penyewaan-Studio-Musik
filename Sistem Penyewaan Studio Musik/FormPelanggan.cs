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
    public partial class FormPelanggan : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");

        private int id_pelanggan;
        private string nama_pelanggan;
        private string username_pelanggan;
        public FormPelanggan(int id_pelanggan = 1, string nama_pelanggan = "Pelanggan", string username_pelanggan = "")
        {
            InitializeComponent();
            this.id_pelanggan = id_pelanggan;
            this.nama_pelanggan = nama_pelanggan;
            this.username_pelanggan = username_pelanggan;

            // Tampilkan nama pelanggan di label Halo
            lblHalo.Text = $"👋 HALO, {nama_pelanggan.ToUpper()}!";

            // Apply styling

        }

        

        private void FormPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHalo_Click(object sender, EventArgs e)
        {

        }

        private void lblSelamatDatang_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            // Buka Form Profil Pelanggan
            FormProfilPelanggan formProfil = new FormProfilPelanggan(id_pelanggan, nama_pelanggan, username_pelanggan);
            formProfil.ShowDialog();

            // Refresh nama setelah edit profil (jika ada perubahan)
            LoadUpdatedProfile();
        }


    }
}
