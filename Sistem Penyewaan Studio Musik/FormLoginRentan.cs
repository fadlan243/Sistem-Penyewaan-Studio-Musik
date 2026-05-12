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
    public partial class FormLoginRentan : Form
    {
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";
        public FormLoginRentan()
        {
            InitializeComponent();
        }

        private void lblJudul_Click(object sender, EventArgs e)
        {

        }

        private void FormLoginRentan_Load(object sender, EventArgs e)
        {

        }

        private void btnLoginRentan_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // ⚠️ PERINGATAN: KODE INI RENTAN SQL INJECTION!
            // JANGAN DIGUNAKAN UNTUK APLIKASI NYATA!
            string query = $"SELECT * FROM users WHERE Username = '{username}' AND Password = '{password}'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show($"✅ LOGIN BERHASIL! (Rentan SQL Injection)\n\n" +
                                       $"Query yang dijalankan:\n{query}",
                                       "BERHASIL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"❌ LOGIN GAGAL!\n\nQuery yang dijalankan:\n{query}",
                                       "GAGAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLoginAman_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // ✅ KODE AMAN: Menggunakan Parameterized Query
            string query = "SELECT * FROM users WHERE Username = @username AND Password = @password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("✅ LOGIN BERHASIL! (Aman - Parameterized Query)",
                                       "BERHASIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("❌ LOGIN GAGAL!",
                                       "GAGAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
