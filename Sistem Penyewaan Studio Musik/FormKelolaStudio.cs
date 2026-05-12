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

        private void CheckBindingSourceStatus()
        {
            if (bindingSource2 == null)
                MessageBox.Show("bindingSource2 is NULL!");
            else if (bindingSource2.DataSource == null)
                MessageBox.Show("bindingSource2.DataSource is NULL!");
            else if (bindingSource2.Count == 0)
                MessageBox.Show("bindingSource2 is EMPTY (0 rows)!");
            else
                MessageBox.Show($"bindingSource2 OK: {bindingSource2.Count} rows");
        }

        // Buat panel untuk navigasi
        private void CreateManualNavigator()
        {
            Panel navPanel = new Panel();
            navPanel.Dock = DockStyle.Top;
            navPanel.Height = 40;
            navPanel.BackColor = Color.FromArgb(30, 30, 30);

            // Tombol First
            Button btnFirst = new Button();
            btnFirst.Text = "|◄";
            btnFirst.Size = new Size(50, 30);
            btnFirst.Location = new Point(10, 5);
            btnFirst.Click += (s, e) => { if (bindingSource2.Count > 0) bindingSource2.Position = 0; };

            // Tombol Previous
            Button btnPrev = new Button();
            btnPrev.Text = "◄";
            btnPrev.Size = new Size(50, 30);
            btnPrev.Location = new Point(65, 5);
            btnPrev.Click += (s, e) => { if (bindingSource2.Position > 0) bindingSource2.Position--; };

            // Label posisi
            Label lblPosition = new Label();
            lblPosition.Text = "0 of 0";
            lblPosition.Size = new Size(80, 30);
            lblPosition.Location = new Point(120, 5);
            lblPosition.ForeColor = Color.White;
            lblPosition.TextAlign = ContentAlignment.MiddleCenter;

            // Tombol Next
            Button btnNext = new Button();
            btnNext.Text = "►";
            btnNext.Size = new Size(50, 30);
            btnNext.Location = new Point(205, 5);
            btnNext.Click += (s, e) => { if (bindingSource2.Position < bindingSource2.Count - 1) bindingSource2.Position++; };

            // Tombol Last
            Button btnLast = new Button();
            btnLast.Text = "►|";
            btnLast.Size = new Size(50, 30);
            btnLast.Location = new Point(260, 5);
            btnLast.Click += (s, e) => { if (bindingSource2.Count > 0) bindingSource2.Position = bindingSource2.Count - 1; };

            // Update label posisi saat posisi berubah
            bindingSource2.PositionChanged += (s, e) => {
                lblPosition.Text = $"{bindingSource2.Position + 1} of {bindingSource2.Count}";
            };
            bindingSource2.ListChanged += (s, e) => {
                lblPosition.Text = $"{bindingSource2.Position + 1} of {bindingSource2.Count}";
            };

            navPanel.Controls.Add(btnFirst);
            navPanel.Controls.Add(btnPrev);
            navPanel.Controls.Add(lblPosition);
            navPanel.Controls.Add(btnNext);
                navPanel.Controls.Add(btnLast);

                this.Controls.Add(navPanel);
                navPanel.BringToFront();
            }

            // ==================== FORMAT KOLOM DGV ====================
            private void FormatKolom()
            {
                // Tunggu sampai DataGridView selesai dibuat
                if (dgvStudio == null || dgvStudio.Columns == null || dgvStudio.Columns.Count == 0)
                    return;

                // Gunakan try-catch untuk setiap kolom
                try
                {
                    if (dgvStudio.Columns.Contains("id_studio"))
                    {
                        dgvStudio.Columns["id_studio"].HeaderText = "ID";
                        dgvStudio.Columns["id_studio"].Width = 50;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error id_studio: " + ex.Message); }

                try
                {
                    if (dgvStudio.Columns.Contains("nama_studio"))
                    {
                        dgvStudio.Columns["nama_studio"].HeaderText = "Nama Studio";
                        dgvStudio.Columns["nama_studio"].Width = 200;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error nama_studio: " + ex.Message); }

                try
                {
                    if (dgvStudio.Columns.Contains("kapasitas"))
                    {
                        dgvStudio.Columns["kapasitas"].HeaderText = "Kapasitas";
                        dgvStudio.Columns["kapasitas"].Width = 100;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error kapasitas: " + ex.Message); }

                try
                {
                    if (dgvStudio.Columns.Contains("harga_per_jam"))
                    {
                        dgvStudio.Columns["harga_per_jam"].HeaderText = "Harga per Jam";
                        dgvStudio.Columns["harga_per_jam"].Width = 120;
                        dgvStudio.Columns["harga_per_jam"].DefaultCellStyle.Format = "N0";
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error harga_per_jam: " + ex.Message); }

                try
                {
                    if (dgvStudio.Columns.Contains("status"))
                    {
                        dgvStudio.Columns["status"].HeaderText = "Status";
                        dgvStudio.Columns["status"].Width = 100;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error status: " + ex.Message); }

                try
                {
                    if (dgvStudio.Columns.Contains("deskripsi"))
                    {
                        dgvStudio.Columns["deskripsi"].HeaderText = "Deskripsi";
                        dgvStudio.Columns["deskripsi"].Width = 250;
                    }
                }
                catch (Exception ex) { Console.WriteLine("Error deskripsi: " + ex.Message); }
            }

    }
}