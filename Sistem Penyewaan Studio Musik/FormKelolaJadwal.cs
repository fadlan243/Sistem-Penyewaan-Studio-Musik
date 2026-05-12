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

        private void LoadStudioCombo()
        {
            try
            {
                conn.Open();
                string query = "SELECT id_studio, nama_studio FROM tbl_studio WHERE status = 'aktif' ORDER BY nama_studio";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtStudio = new DataTable();
                da.Fill(dtStudio);
                conn.Close();

                cbStudioFilter.DataSource = dtStudio;
                cbStudioFilter.DisplayMember = "nama_studio";
                cbStudioFilter.ValueMember = "id_studio";

                cbStudio.DataSource = dtStudio.Copy();
                cbStudio.DisplayMember = "nama_studio";
                cbStudio.ValueMember = "id_studio";

                if (cbStudioFilter.Items.Count > 0)
                    cbStudioFilter.SelectedIndex = -1;
            }
            catch (Exception ex) { if (conn.State == ConnectionState.Open) conn.Close(); MessageBox.Show("Error LoadStudio: " + ex.Message); }
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = @"SELECT j.id_jadwal, s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                        j.status, j.keterangan
                                 FROM tbl_jadwal j
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 ORDER BY j.tanggal DESC, j.jam_mulai";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtJadwal = new DataTable();
                da.Fill(dtJadwal);
                conn.Close();

                bindingSourceJadwal.DataSource = dtJadwal;
                dgvJadwal.DataSource = bindingSourceJadwal;
                FormatDataGridView();
            }
            catch (Exception ex) { if (conn.State == ConnectionState.Open) conn.Close(); MessageBox.Show("Error LoadData: " + ex.Message); }
        }

        private void LoadDataWithFilter()
        {
            try
            {
                string studioFilter = "";
                if (cbStudioFilter.SelectedValue != null)
                    studioFilter = cbStudioFilter.SelectedValue.ToString();
                DateTime tanggalFilter = dtpTanggalFilter.Value.Date;

                conn.Open();
                string query = @"SELECT j.id_jadwal, s.nama_studio, j.tanggal, j.jam_mulai, j.jam_selesai, 
                                        j.status, j.keterangan
                                 FROM tbl_jadwal j
                                 JOIN tbl_studio s ON j.id_studio = s.id_studio
                                 WHERE (@studio = '' OR j.id_studio = @studio)
                                 AND (j.tanggal = @tanggal)
                                 ORDER BY j.tanggal DESC, j.jam_mulai";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@studio", string.IsNullOrEmpty(studioFilter) ? "" : studioFilter);
                da.SelectCommand.Parameters.AddWithValue("@tanggal", tanggalFilter);
                dtJadwal = new DataTable();
                da.Fill(dtJadwal);
                conn.Close();

                bindingSourceJadwal.DataSource = dtJadwal;
                dgvJadwal.DataSource = bindingSourceJadwal;
                FormatDataGridView();
            }
            catch (Exception ex) { if (conn.State == ConnectionState.Open) conn.Close(); MessageBox.Show("Error LoadDataWithFilter: " + ex.Message); }
        }

    }
}