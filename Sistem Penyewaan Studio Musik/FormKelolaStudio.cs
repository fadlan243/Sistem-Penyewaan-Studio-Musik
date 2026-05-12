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
    public partial class FormKelolaStudio : Form
    {
        private readonly string connString = "Data Source=FADLANNASRIZAL\\FADLAN;Initial Catalog=StudioMusik_DB;Integrated Security=True";
        private DataTable dtStudio;
        private int selectedIdStudio = 0;
        private string mode = "";

        public FormKelolaStudio()
        {
            InitializeComponent();
        }

        private void FormKelolaStudio_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        // ==================== LOAD DATA ====================
        private void LoadData(string search = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"SELECT id_studio, nama_studio, kapasitas, harga_per_jam, status, deskripsi 
                                     FROM tbl_studio 
                                     WHERE nama_studio LIKE @search
                                     ORDER BY id_studio";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                    dtStudio = new DataTable();
                    da.Fill(dtStudio);

                    dgvStudio.DataSource = null;
                    dgvStudio.Columns.Clear();
                    dgvStudio.DataSource = dtStudio;
                }

                if (dgvStudio.Columns.Count > 0)
                {
                    if (dgvStudio.Columns.Contains("id_studio"))
                    {
                        dgvStudio.Columns["id_studio"].HeaderText = "ID";
                        dgvStudio.Columns["id_studio"].Width = 50;
                    }
                    if (dgvStudio.Columns.Contains("nama_studio"))
                    {
                        dgvStudio.Columns["nama_studio"].HeaderText = "Nama Studio";
                        dgvStudio.Columns["nama_studio"].Width = 200;
                    }
                    if (dgvStudio.Columns.Contains("kapasitas"))
                    {
                        dgvStudio.Columns["kapasitas"].HeaderText = "Kapasitas";
                        dgvStudio.Columns["kapasitas"].Width = 100;
                    }
                    if (dgvStudio.Columns.Contains("harga_per_jam"))
                    {
                        dgvStudio.Columns["harga_per_jam"].HeaderText = "Harga per Jam";
                        dgvStudio.Columns["harga_per_jam"].Width = 120;
                        dgvStudio.Columns["harga_per_jam"].DefaultCellStyle.Format = "N0";
                    }
                    if (dgvStudio.Columns.Contains("status"))
                    {
                        dgvStudio.Columns["status"].HeaderText = "Status";
                        dgvStudio.Columns["status"].Width = 100;
                    }
                    if (dgvStudio.Columns.Contains("deskripsi"))
                    {
                        dgvStudio.Columns["deskripsi"].HeaderText = "Deskripsi";
                        dgvStudio.Columns["deskripsi"].Width = 250;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error LoadData: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (string.IsNullOrWhiteSpace(txtNamaStudio.Text))
            {
                MessageBox.Show("Nama Studio harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaStudio.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtKapasitas.Text))
            {
                MessageBox.Show("Kapasitas harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKapasitas.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtHargaPerJam.Text))
            {
                MessageBox.Show("Harga per Jam harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHargaPerJam.Focus();
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

                    if (mode == "tambah")
                    {
                        string query = @"INSERT INTO tbl_studio (nama_studio, kapasitas, harga_per_jam, status, deskripsi) 
                                         VALUES (@nama, @kapasitas, @harga, @status, @deskripsi)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", txtNamaStudio.Text);
                        cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Studio berhasil ditambahkan!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (selectedIdStudio == 0)
                        {
                            MessageBox.Show("Pilih studio yang akan diupdate!", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = @"UPDATE tbl_studio 
                                         SET nama_studio = @nama, kapasitas = @kapasitas, harga_per_jam = @harga, 
                                             status = @status, deskripsi = @deskripsi
                                         WHERE id_studio = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedIdStudio);
                        cmd.Parameters.AddWithValue("@nama", txtNamaStudio.Text);
                        cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Studio berhasil diupdate!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // ✅ Cek apakah studio punya jadwal yang sudah dibooking
                    string cekQuery = @"SELECT COUNT(*) FROM tbl_booking b
                                        JOIN tbl_jadwal j ON b.id_jadwal = j.id_jadwal
                                        WHERE j.id_studio = @id";
                    SqlCommand cmdCek = new SqlCommand(cekQuery, conn);
                    cmdCek.Parameters.AddWithValue("@id", selectedIdStudio);
                    int jumlahBooking = (int)cmdCek.ExecuteScalar();

                    if (jumlahBooking > 0)
                    {
                        MessageBox.Show(
                            $"Studio ini tidak dapat dihapus karena memiliki {jumlahBooking} booking terkait!\n\n" +
                            "Ubah status studio menjadi 'Nonaktif' untuk menonaktifkannya.",
                            "Tidak Dapat Dihapus",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    DialogResult result = MessageBox.Show("Yakin ingin menghapus studio ini?",
                        "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Hapus jadwal terkait dulu, baru hapus studio
                        string hapusJadwal = "DELETE FROM tbl_jadwal WHERE id_studio = @id";
                        SqlCommand cmdJadwal = new SqlCommand(hapusJadwal, conn);
                        cmdJadwal.Parameters.AddWithValue("@id", selectedIdStudio);
                        cmdJadwal.ExecuteNonQuery();

                        string hapusStudio = "DELETE FROM tbl_studio WHERE id_studio = @id";
                        SqlCommand cmdStudio = new SqlCommand(hapusStudio, conn);
                        cmdStudio.Parameters.AddWithValue("@id", selectedIdStudio);
                        cmdStudio.ExecuteNonQuery();

                        MessageBox.Show("Studio berhasil dihapus!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData(txtCari.Text);
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENT HANDLERS ====================
        private void dgvStudio_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudio.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedIdStudio = Convert.ToInt32(dgvStudio.Rows[e.RowIndex].Cells[0].Value);
                txtNamaStudio.Text = dgvStudio.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtKapasitas.Text = dgvStudio.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtHargaPerJam.Text = dgvStudio.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDeskripsi.Text = dgvStudio.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";

                string status = dgvStudio.Rows[e.RowIndex].Cells[4].Value.ToString();
                rbAktif.Checked = (status == "aktif");
                rbNonaktif.Checked = (status != "aktif");

                btnEdit.Enabled = true;
                btnHapus.Enabled = true;
                btnSimpan.Text = "✏️ Update";
                mode = "edit";
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

        // Event handlers kosong
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
    }
}