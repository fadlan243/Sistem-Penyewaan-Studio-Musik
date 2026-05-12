namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormKelolaStudio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.lblJudul = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.lblNamaStudio = new System.Windows.Forms.Label();
            this.lblKapasitas = new System.Windows.Forms.Label();
            this.lblHarga = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDeskripsi = new System.Windows.Forms.Label();
            this.txtNamaStudio = new System.Windows.Forms.TextBox();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.txtHargaPerJam = new System.Windows.Forms.TextBox();
            this.txtKapasitas = new System.Windows.Forms.TextBox();
            this.rbAktif = new System.Windows.Forms.RadioButton();
            this.rbNonaktif = new System.Windows.Forms.RadioButton();
            this.dgvStudio = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudio)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCari.Location = new System.Drawing.Point(15, 311);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(95, 43);
            this.btnCari.TabIndex = 0;
            this.btnCari.Text = "🔍 Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTambah.Location = new System.Drawing.Point(196, 360);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(115, 40);
            this.btnTambah.TabIndex = 1;
            this.btnTambah.Text = "\t➕ Tambah Studio";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(559, 362);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(115, 38);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "✏️ Edit Studio";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHapus.Location = new System.Drawing.Point(680, 362);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(115, 38);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "\t🗑️ Hapus Studio";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpan.Location = new System.Drawing.Point(317, 362);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(115, 38);
            this.btnSimpan.TabIndex = 4;
            this.btnSimpan.Text = "\t💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatal.Location = new System.Drawing.Point(438, 362);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(115, 37);
            this.btnBatal.TabIndex = 5;
            this.btnBatal.Text = "\t❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTutup.Location = new System.Drawing.Point(745, 9);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(119, 45);
            this.btnTutup.TabIndex = 6;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // lblJudul
            // 
            this.lblJudul.BackColor = System.Drawing.Color.Transparent;
            this.lblJudul.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(13, 17);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(329, 40);
            this.lblJudul.TabIndex = 13;
            this.lblJudul.Text = "\t🎸 KELOLA STUDIO";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(12, 360);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(163, 26);
            this.txtCari.TabIndex = 19;
            this.txtCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCari_KeyPress);
            // 
            // lblNamaStudio
            // 
            this.lblNamaStudio.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaStudio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaStudio.ForeColor = System.Drawing.Color.White;
            this.lblNamaStudio.Location = new System.Drawing.Point(23, 83);
            this.lblNamaStudio.Name = "lblNamaStudio";
            this.lblNamaStudio.Size = new System.Drawing.Size(146, 25);
            this.lblNamaStudio.TabIndex = 8;
            this.lblNamaStudio.Text = "Nama Studio :";
            this.lblNamaStudio.Click += new System.EventHandler(this.lblNamaStudio_Click);
            // 
            // lblKapasitas
            // 
            this.lblKapasitas.BackColor = System.Drawing.Color.Transparent;
            this.lblKapasitas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKapasitas.ForeColor = System.Drawing.Color.White;
            this.lblKapasitas.Location = new System.Drawing.Point(23, 138);
            this.lblKapasitas.Name = "lblKapasitas";
            this.lblKapasitas.Size = new System.Drawing.Size(136, 25);
            this.lblKapasitas.TabIndex = 9;
            this.lblKapasitas.Text = "Kapasitas : ";
            this.lblKapasitas.Click += new System.EventHandler(this.lblKapasitas_Click);
            // 
            // lblHarga
            // 
            this.lblHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblHarga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHarga.ForeColor = System.Drawing.Color.White;
            this.lblHarga.Location = new System.Drawing.Point(23, 184);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(152, 25);
            this.lblHarga.TabIndex = 10;
            this.lblHarga.Text = "Harga per Jam :";
            this.lblHarga.Click += new System.EventHandler(this.lblHarga_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(23, 264);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status :";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblDeskripsi
            // 
            this.lblDeskripsi.BackColor = System.Drawing.Color.Transparent;
            this.lblDeskripsi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeskripsi.ForeColor = System.Drawing.Color.White;
            this.lblDeskripsi.Location = new System.Drawing.Point(23, 224);
            this.lblDeskripsi.Name = "lblDeskripsi";
            this.lblDeskripsi.Size = new System.Drawing.Size(146, 26);
            this.lblDeskripsi.TabIndex = 12;
            this.lblDeskripsi.Text = "Deskripsi :";
            this.lblDeskripsi.Click += new System.EventHandler(this.lblDeskripsi_Click);
            // 
            // txtNamaStudio
            // 
            this.txtNamaStudio.Location = new System.Drawing.Point(175, 85);
            this.txtNamaStudio.Name = "txtNamaStudio";
            this.txtNamaStudio.Size = new System.Drawing.Size(136, 26);
            this.txtNamaStudio.TabIndex = 14;
            this.txtNamaStudio.TextChanged += new System.EventHandler(this.txtNamaStudio_TextChanged);
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(175, 224);
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(136, 26);
            this.txtDeskripsi.TabIndex = 15;
            this.txtDeskripsi.TextChanged += new System.EventHandler(this.txtDeskripsi_TextChanged);
            // 
            // txtHargaPerJam
            // 
            this.txtHargaPerJam.Location = new System.Drawing.Point(175, 185);
            this.txtHargaPerJam.Name = "txtHargaPerJam";
            this.txtHargaPerJam.Size = new System.Drawing.Size(136, 26);
            this.txtHargaPerJam.TabIndex = 17;
            this.txtHargaPerJam.TextChanged += new System.EventHandler(this.txtHargaPerJam_TextChanged);
            // 
            // txtKapasitas
            // 
            this.txtKapasitas.Location = new System.Drawing.Point(175, 139);
            this.txtKapasitas.Name = "txtKapasitas";
            this.txtKapasitas.Size = new System.Drawing.Size(136, 26);
            this.txtKapasitas.TabIndex = 18;
            this.txtKapasitas.TextChanged += new System.EventHandler(this.txtKapasitas_TextChanged);
            // 
            // rbAktif
            // 
            this.rbAktif.AutoSize = true;
            this.rbAktif.BackColor = System.Drawing.Color.Transparent;
            this.rbAktif.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbAktif.ForeColor = System.Drawing.Color.White;
            this.rbAktif.Location = new System.Drawing.Point(175, 266);
            this.rbAktif.Name = "rbAktif";
            this.rbAktif.Size = new System.Drawing.Size(74, 29);
            this.rbAktif.TabIndex = 19;
            this.rbAktif.TabStop = true;
            this.rbAktif.Text = "Aktif";
            this.rbAktif.UseVisualStyleBackColor = false;
            this.rbAktif.CheckedChanged += new System.EventHandler(this.rbAktif_CheckedChanged);
            // 
            // rbNonaktif
            // 
            this.rbNonaktif.AutoSize = true;
            this.rbNonaktif.BackColor = System.Drawing.Color.Transparent;
            this.rbNonaktif.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbNonaktif.ForeColor = System.Drawing.Color.White;
            this.rbNonaktif.Location = new System.Drawing.Point(175, 310);
            this.rbNonaktif.Name = "rbNonaktif";
            this.rbNonaktif.Size = new System.Drawing.Size(105, 29);
            this.rbNonaktif.TabIndex = 20;
            this.rbNonaktif.TabStop = true;
            this.rbNonaktif.Text = "Nonaktif";
            this.rbNonaktif.UseVisualStyleBackColor = false;
            this.rbNonaktif.CheckedChanged += new System.EventHandler(this.rbNonaktif_CheckedChanged);
            // 
            // dgvStudio
            // 
            this.dgvStudio.AllowUserToAddRows = false;
            this.dgvStudio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudio.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStudio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudio.Location = new System.Drawing.Point(15, 402);
            this.dgvStudio.Name = "dgvStudio";
            this.dgvStudio.ReadOnly = true;
            this.dgvStudio.RowHeadersWidth = 62;
            this.dgvStudio.RowTemplate.Height = 28;
            this.dgvStudio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudio.Size = new System.Drawing.Size(842, 183);
            this.dgvStudio.TabIndex = 22;
            this.dgvStudio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudio_CellClick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-7, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 63);
            this.panel1.TabIndex = 23;
            // 
            // FormKelolaStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(869, 605);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rbNonaktif);
            this.Controls.Add(this.txtKapasitas);
            this.Controls.Add(this.rbAktif);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.txtHargaPerJam);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtNamaStudio);
            this.Controls.Add(this.lblDeskripsi);
            this.Controls.Add(this.lblNamaStudio);
            this.Controls.Add(this.lblKapasitas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStudio);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnCari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormKelolaStudio";
            this.Text = "FormKelolaStudio";
            this.Load += new System.EventHandler(this.FormKelolaStudio_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudio)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label lblNamaStudio;
        private System.Windows.Forms.Label lblKapasitas;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDeskripsi;
        private System.Windows.Forms.TextBox txtNamaStudio;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.TextBox txtHargaPerJam;
        private System.Windows.Forms.TextBox txtKapasitas;
        private System.Windows.Forms.RadioButton rbAktif;
        private System.Windows.Forms.RadioButton rbNonaktif;
        private System.Windows.Forms.DataGridView dgvStudio;
        private System.Windows.Forms.Panel panel1;
    }
}