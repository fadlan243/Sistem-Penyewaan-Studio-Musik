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

        
    }
}