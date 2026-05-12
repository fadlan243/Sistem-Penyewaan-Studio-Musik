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
        SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");
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
    }
}
