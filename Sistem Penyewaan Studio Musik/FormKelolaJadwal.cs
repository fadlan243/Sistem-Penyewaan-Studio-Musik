using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormKelolaJadwal : Form
    {
        private readonly SqlConnection conn = new SqlConnection("Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True");
        private DataTable dtJadwal;
        private int selectedIdJadwal = 0;
        private string mode = "";

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        public FormKelolaJadwal()
        {
            InitializeComponent();
            SetPlaceholder(txtKeterangan, "Catatan tambahan...");
            LoadStudioCombo();
            LoadData();
            UpdateStatistik();
            ClearForm();

            // BindingNavigator ke BindingSource
            bindingNavigatorJadwal.BindingSource = bindingSourceJadwal;
            dgvJadwal.DataSource = bindingSourceJadwal;
            bindingSourceJadwal.CurrentChanged += BindingSourceJadwal_CurrentChanged;
        }

        private void BindingSourceJadwal_CurrentChanged(object sender, EventArgs e)
        {
            DataRowView row = bindingSourceJadwal.Current as DataRowView;
            if (row == null) return;

            selectedIdJadwal = Convert.ToInt32(row["id_jadwal"]);

            // Set ComboBox Studio
            string studioName = row["nama_studio"].ToString();
            for (int i = 0; i < cbStudio.Items.Count; i++)
            {
                if (cbStudio.Items[i].ToString() == studioName)
                {
                    cbStudio.SelectedIndex = i;
                    break;
                }
            }

            // ✅ PERBAIKAN: Set DateTimePicker dengan benar
            dtpTanggal.Value = Convert.ToDateTime(row["tanggal"]);

            // ✅ PERBAIKAN: Parse TimeSpan ke DateTime
            TimeSpan jamMulai = TimeSpan.Parse(row["jam_mulai"].ToString());
            TimeSpan jamSelesai = TimeSpan.Parse(row["jam_selesai"].ToString());

            dtpJamMulai.Value = DateTime.Today.Add(jamMulai);
            dtpJamSelesai.Value = DateTime.Today.Add(jamSelesai);

            // Set Status ComboBox
            string status = row["status"].ToString();
            if (status == "tersedia") cbStatus.SelectedIndex = 0;
            else if (status == "dipesan") cbStatus.SelectedIndex = 1;
            else cbStatus.SelectedIndex = 2;

            txtKeterangan.Text = row["keterangan"]?.ToString() ?? "";

            btnEdit.Enabled = true;
            btnHapus.Enabled = true;
            btnStatusTersedia.Enabled = true;
            btnStatusDitutup.Enabled = true;
            btnSimpan.Text = "✏️ Update";
            mode = "edit";
        }

    }
}