using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistem_Penyewaan_Studio_Musik
{
    public partial class FormKelolaStudio : Form
    {
        private readonly string connString = ("Data Source=192.168.110.121,1433;Initial Catalog=StudioMusik_DB;User ID=sa;Password=Masamba24032006;");
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

            // ==================== CLEAR FORM ====================
            private void ClearForm()
            {
                txtNamaStudio.Clear();
                txtKapasitas.Clear();
                txtHargaPerJam.Clear();
                txtDeskripsi.Clear();
                rbAktif.Checked = true;
                rbNonaktif.Checked = false;
                selectedIdStudio = 0;
                mode = "";
                btnEdit.Enabled = false;
                btnHapus.Enabled = false;
                btnSimpan.Text = "💾 Simpan";
            }

            // ==================== SIMPAN / UPDATE ====================
            private void btnSimpan_Click(object sender, EventArgs e)
            {
                // Validasi input
                if (string.IsNullOrWhiteSpace(txtNamaStudio.Text))
                {
                    MessageBox.Show("Nama Studio harus diisi!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamaStudio.Focus();
                    return;
                }
                if (!int.TryParse(txtKapasitas.Text, out int kapasitas))
                {
                    MessageBox.Show("Kapasitas harus berupa angka!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKapasitas.Focus();
                    return;
                }
                if (!decimal.TryParse(txtHargaPerJam.Text, out decimal harga))
                {
                    MessageBox.Show("Harga per Jam harus berupa angka!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHargaPerJam.Focus();
                    return;
                }

                string status = rbAktif.Checked ? "aktif" : "nonaktif";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        SqlParameter paramPesan = new SqlParameter("@pesan", SqlDbType.VarChar, 255);
                        paramPesan.Direction = ParameterDirection.Output;

                        if (mode == "tambah")
                        {
                            SqlCommand cmd = new SqlCommand("sp_InsertStudio", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@nama_studio", txtNamaStudio.Text.Trim());
                            cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                            cmd.Parameters.AddWithValue("@harga_per_jam", harga);
                            cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", status);

                            SqlParameter paramId = new SqlParameter("@new_id", SqlDbType.Int);
                            paramId.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(paramId);
                            cmd.Parameters.Add(paramPesan);

                            cmd.ExecuteNonQuery();

                            string pesan = paramPesan.Value.ToString();
                            MessageBox.Show(pesan,
                                pesan.StartsWith("SUKSES") ? "Sukses" : "Peringatan",
                                MessageBoxButtons.OK,
                                pesan.StartsWith("SUKSES") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (selectedIdStudio == 0)
                            {
                                MessageBox.Show("Pilih studio yang akan diupdate!", "Peringatan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            SqlCommand cmd = new SqlCommand("sp_UpdateStudio", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_studio", selectedIdStudio);
                            cmd.Parameters.AddWithValue("@nama_studio", txtNamaStudio.Text.Trim());
                            cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                            cmd.Parameters.AddWithValue("@harga_per_jam", harga);
                            cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.Add(paramPesan);

                            cmd.ExecuteNonQuery();

                            string pesan = paramPesan.Value.ToString();
                            MessageBox.Show(pesan,
                                pesan.StartsWith("SUKSES") ? "Sukses" : "Peringatan",
                                MessageBoxButtons.OK,
                                pesan.StartsWith("SUKSES") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                        }
                    }

                    LoadData(txtCari.Text);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // ==================== HAPUS ====================
            private void btnHapus_Click(object sender, EventArgs e)
            {
                if (selectedIdStudio == 0)
                {
                    MessageBox.Show("Pilih studio yang akan dihapus!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Yakin ingin menghapus studio ini?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes) return;

                try
                {
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("sp_DeleteStudio", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_studio", selectedIdStudio);

                        SqlParameter paramPesan = new SqlParameter("@pesan", SqlDbType.VarChar, 255);
                        paramPesan.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramPesan);

                        cmd.ExecuteNonQuery();

                        string pesan = paramPesan.Value.ToString();
                        MessageBox.Show(pesan,
                            pesan.StartsWith("SUKSES") ? "Sukses" : "Peringatan",
                            MessageBoxButtons.OK,
                            pesan.StartsWith("SUKSES") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    }

                    LoadData(txtCari.Text);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // ==================== EVENT HANDLERS ====================
            private void dgvStudio_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                // Pastikan klik pada baris yang valid (bukan header)
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        // Ambil baris yang diklik
                        DataGridViewRow row = dgvStudio.Rows[e.RowIndex];

                        // Ambil data dari baris yang diklik
                        selectedIdStudio = Convert.ToInt32(row.Cells["id_studio"].Value);
                        txtNamaStudio.Text = row.Cells["nama_studio"].Value.ToString();
                        txtKapasitas.Text = row.Cells["kapasitas"].Value.ToString();
                        txtHargaPerJam.Text = row.Cells["harga_per_jam"].Value.ToString();

                        // Cek apakah ada kolom deskripsi
                        if (row.Cells["deskripsi"].Value != null)
                            txtDeskripsi.Text = row.Cells["deskripsi"].Value.ToString();
                        else
                            txtDeskripsi.Text = "";

                        // Set status radio button
                        string status = row.Cells["status"].Value.ToString();
                        rbAktif.Checked = (status == "aktif");
                        rbNonaktif.Checked = (status != "aktif");

                        // Aktifkan tombol Edit dan Hapus
                        btnEdit.Enabled = true;
                        btnHapus.Enabled = true;

                        // Ubah teks tombol Simpan menjadi Update
                        btnSimpan.Text = "✏️ Update";
                        mode = "edit";

                        // Optional: Tampilkan pesan debug
                        Console.WriteLine($"Studio dipilih: ID={selectedIdStudio}, Nama={txtNamaStudio.Text}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat memilih data: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            private void btnTambah_Click(object sender, EventArgs e)
            {
                ClearForm();
                selectedIdStudio = 0;
                mode = "tambah";
                txtNamaStudio.Focus();
                btnSimpan.Text = "💾 Simpan";
            }

            private void btnEdit_Click(object sender, EventArgs e)
            {
                if (selectedIdStudio == 0)
                {
                    MessageBox.Show("Pilih studio yang akan diedit!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtNamaStudio.Focus();
                btnSimpan.Text = "✏️ Update";
                mode = "edit";
            }

            private void btnBatal_Click(object sender, EventArgs e)
            {
                ClearForm();
                dgvStudio.ClearSelection();
                btnSimpan.Text = "💾 Simpan";
                mode = "";
            }

            private void btnCari_Click(object sender, EventArgs e)
            {
                LoadData(txtCari.Text);
            }

            private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter)
                    LoadData(txtCari.Text);
            }

            private void btnTutup_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            // Event handlers kosong (dari Designer)
            private void FormKelolaStudio_Load_1(object sender, EventArgs e) { }
            private void lblJudul_Click(object sender, EventArgs e) { }
            private void lblNamaStudio_Click(object sender, EventArgs e) { }
            private void lblKapasitas_Click(object sender, EventArgs e) { }
            private void lblHarga_Click(object sender, EventArgs e) { }
            private void lblStatus_Click(object sender, EventArgs e) { }
            private void lblDeskripsi_Click(object sender, EventArgs e) { }
            private void txtNamaStudio_TextChanged(object sender, EventArgs e) { }
            private void txtKapasitas_TextChanged(object sender, EventArgs e) { }
            private void txtHargaPerJam_TextChanged(object sender, EventArgs e) { }
            private void txtDeskripsi_TextChanged(object sender, EventArgs e) { }
            private void rbAktif_CheckedChanged(object sender, EventArgs e) { }
            private void rbNonaktif_CheckedChanged(object sender, EventArgs e) { }
            private void gbInput_Enter_1(object sender, EventArgs e) { }
            private void lblDaftarStudio_Click(object sender, EventArgs e) { }
            private void bindingNavigator1_RefreshItems(object sender, EventArgs e) { }
            private void bindingNavigatorPositionItem_Click(object sender, EventArgs e) { }
            private void bindingNavigator1_RefreshItems_1(object sender, EventArgs e) { }
            private void bindingSource2_CurrentChanged(object sender, EventArgs e) { }
    }
}