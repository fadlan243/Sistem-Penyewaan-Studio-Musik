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

    
    }
}