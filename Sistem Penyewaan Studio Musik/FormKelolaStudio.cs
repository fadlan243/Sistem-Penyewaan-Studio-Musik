using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormKelolaStudio : Form
    {
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";
        private DataTable dtStudio = new DataTable();

        private int selectedIdStudio = 0;
        private string mode = "";

        public FormKelolaStudio()
        {
            InitializeComponent();
            CreateManualNavigator();  // Tambahkan ini
            SetupBinding();
            LoadData();
            ClearForm();
        }

        private void FormKelolaStudio_Load(object sender, EventArgs e)
        {
            SetupBinding();
            LoadData();
            ClearForm();
            CheckBindingSourceStatus(); 
        }

        // ==================== UCP 2: SETUP BINDING ====================
        private void SetupBinding()
        {
            try
            {
                // Hubungkan BindingNavigator ke BindingSource
                bindingNavigator1.BindingSource = bindingSource2;

                // Hubungkan DataGridView ke BindingSource
                dgvStudio.DataSource = bindingSource2;

                // Event saat navigasi berubah
                bindingSource2.CurrentChanged += BindingSource2_CurrentChanged;

                // Aktifkan BindingNavigator
                bindingNavigator1.Enabled = true;

                // Sembunyikan tombol AddNew dan Delete di BindingNavigator (opsional)
                bindingNavigatorAddNewItem.Visible = false;
                bindingNavigatorDeleteItem.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SetupBinding: " + ex.Message);
            }
        }

        // ==================== UCP 2: EVENT BINDING NAVIGATOR ====================
        private void BindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            DataRowView row = bindingSource2.Current as DataRowView;
            if (row == null) return;

            selectedIdStudio = Convert.ToInt32(row["id_studio"]);
            txtNamaStudio.Text = row["nama_studio"].ToString();
            txtKapasitas.Text = row["kapasitas"].ToString();
            txtHargaPerJam.Text = row["harga_per_jam"].ToString();
            txtDeskripsi.Text = row["deskripsi"]?.ToString() ?? "";

            string status = row["status"].ToString();
            rbAktif.Checked = (status == "aktif");
            rbNonaktif.Checked = (status != "aktif");

            btnEdit.Enabled = true;
            btnHapus.Enabled = true;
            btnSimpan.Text = "✏️ Update";
            mode = "edit";
        }

        // ==================== LOAD DATA ====================
        private void LoadData(string search = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_SearchStudio", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@keyword", search);
                    cmd.Parameters.AddWithValue("@status", "semua");
                    cmd.Parameters.AddWithValue("@sort_by", "nama");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtStudio = new DataTable();
                    da.Fill(dtStudio);
                    conn.Close();
                }

                // Isi BindingSource
                bindingSource2.DataSource = dtStudio;
                dgvStudio.DataSource = bindingSource2;

                // ✅ Panggil FormatKolom SETELAH DataGridView terisi
                FormatKolom();

                // Update BindingNavigator
                bindingNavigator1.Enabled = (dtStudio.Rows.Count > 0);

                Console.WriteLine($"Data loaded: {dtStudio.Rows.Count} rows");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadData: " + ex.Message);
            }
        }

        
    }
}