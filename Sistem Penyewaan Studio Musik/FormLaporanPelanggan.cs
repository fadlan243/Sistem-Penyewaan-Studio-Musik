using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormLaporanPelanggan : Form
    {
        private int id_pelanggan;
        private string nama_pelanggan;

        public FormLaporanPelanggan(int id_pelanggan, string nama_pelanggan)
        {
            InitializeComponent();
            this.id_pelanggan = id_pelanggan;
            this.nama_pelanggan = nama_pelanggan;

            // Load laporan
            LoadLaporan();
        }

        private void FormLaporanPelanggan_Load(object sender, EventArgs e)
        {

        }

        private void LoadLaporan()
        {
            // Kode untuk load laporan pelanggan
        }
    }
}
