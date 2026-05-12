namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormKelolaPelanggan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblJudul = new System.Windows.Forms.Label();
            this.btnTutup = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblNoTelp = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblLengkap = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblJabatan = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.txtNamaLengkap = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtJabatan = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNonaktifkan = new System.Windows.Forms.Button();
            this.btnAktifkan = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.rbPelanggan = new System.Windows.Forms.RadioButton();
            this.lblDaftarUser = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-7, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 69);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(15, 14);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(328, 44);
            this.lblJudul.TabIndex = 1;
            this.lblJudul.Text = "👥 KELOLA USER";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTutup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTutup.Location = new System.Drawing.Point(768, 14);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(124, 44);
            this.btnTutup.TabIndex = 28;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(12, 82);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(139, 25);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "📝 FORM USER";
            this.lblFormTitle.Click += new System.EventHandler(this.lblFormTitle_Click);
            // 
            // lblNoTelp
            // 
            this.lblNoTelp.AutoSize = true;
            this.lblNoTelp.BackColor = System.Drawing.Color.Transparent;
            this.lblNoTelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTelp.ForeColor = System.Drawing.Color.White;
            this.lblNoTelp.Location = new System.Drawing.Point(261, 121);
            this.lblNoTelp.Name = "lblNoTelp";
            this.lblNoTelp.Size = new System.Drawing.Size(115, 25);
            this.lblNoTelp.TabIndex = 3;
            this.lblNoTelp.Text = "No. Telepon :";
            this.lblNoTelp.Click += new System.EventHandler(this.lblNoTelp_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(12, 264);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(96, 25);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password :";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(12, 117);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(55, 25);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role :";
            this.lblRole.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblLengkap
            // 
            this.lblLengkap.AutoSize = true;
            this.lblLengkap.BackColor = System.Drawing.Color.Transparent;
            this.lblLengkap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLengkap.ForeColor = System.Drawing.Color.White;
            this.lblLengkap.Location = new System.Drawing.Point(8, 172);
            this.lblLengkap.Name = "lblLengkap";
            this.lblLengkap.Size = new System.Drawing.Size(140, 25);
            this.lblLengkap.TabIndex = 6;
            this.lblLengkap.Text = "Nama Lengkap :";
            this.lblLengkap.Click += new System.EventHandler(this.lblLengkap_Click);
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.BackColor = System.Drawing.Color.Transparent;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamat.ForeColor = System.Drawing.Color.White;
            this.lblAlamat.Location = new System.Drawing.Point(261, 223);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(77, 25);
            this.lblAlamat.TabIndex = 7;
            this.lblAlamat.Text = "Alamat :";
            this.lblAlamat.Click += new System.EventHandler(this.lblAlamat_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Location = new System.Drawing.Point(520, 121);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 20);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status :";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblJabatan
            // 
            this.lblJabatan.AutoSize = true;
            this.lblJabatan.BackColor = System.Drawing.Color.Transparent;
            this.lblJabatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJabatan.ForeColor = System.Drawing.Color.White;
            this.lblJabatan.Location = new System.Drawing.Point(261, 264);
            this.lblJabatan.Name = "lblJabatan";
            this.lblJabatan.Size = new System.Drawing.Size(81, 25);
            this.lblJabatan.TabIndex = 9;
            this.lblJabatan.Text = "Jabatan :";
            this.lblJabatan.Click += new System.EventHandler(this.lblJabatan_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(8, 217);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 25);
            this.lblUsername.TabIndex = 10;
            this.lblUsername.Text = "\tUsername :";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.AutoSize = true;
            this.lblStatistik.Location = new System.Drawing.Point(14, 604);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(129, 20);
            this.lblStatistik.TabIndex = 11;
            this.lblStatistik.Text = "📊 STATISTIK: ...";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(261, 175);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 25);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email :";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(171, 333);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(130, 26);
            this.txtCari.TabIndex = 13;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // txtNamaLengkap
            // 
            this.txtNamaLengkap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamaLengkap.ForeColor = System.Drawing.Color.Firebrick;
            this.txtNamaLengkap.Location = new System.Drawing.Point(151, 172);
            this.txtNamaLengkap.Name = "txtNamaLengkap";
            this.txtNamaLengkap.Size = new System.Drawing.Size(94, 31);
            this.txtNamaLengkap.TabIndex = 14;
            this.txtNamaLengkap.TextChanged += new System.EventHandler(this.txtNamaLengkap_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Firebrick;
            this.txtUsername.Location = new System.Drawing.Point(151, 217);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(94, 31);
            this.txtUsername.TabIndex = 15;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Firebrick;
            this.txtEmail.Location = new System.Drawing.Point(369, 175);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(94, 31);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Firebrick;
            this.txtPassword.Location = new System.Drawing.Point(151, 264);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(94, 31);
            this.txtPassword.TabIndex = 17;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoTelp.ForeColor = System.Drawing.Color.Firebrick;
            this.txtNoTelp.Location = new System.Drawing.Point(369, 121);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(94, 31);
            this.txtNoTelp.TabIndex = 18;
            this.txtNoTelp.TextChanged += new System.EventHandler(this.txtNoTelp_TextChanged);
            // 
            // txtAlamat
            // 
            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlamat.ForeColor = System.Drawing.Color.Firebrick;
            this.txtAlamat.Location = new System.Drawing.Point(369, 217);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(94, 31);
            this.txtAlamat.TabIndex = 19;
            this.txtAlamat.TextChanged += new System.EventHandler(this.txtAlamat_TextChanged);
            // 
            // txtJabatan
            // 
            this.txtJabatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJabatan.ForeColor = System.Drawing.Color.Firebrick;
            this.txtJabatan.Location = new System.Drawing.Point(369, 258);
            this.txtJabatan.Name = "txtJabatan";
            this.txtJabatan.Size = new System.Drawing.Size(94, 31);
            this.txtJabatan.TabIndex = 20;
            this.txtJabatan.TextChanged += new System.EventHandler(this.txtJabatan_TextChanged);
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(317, 329);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(69, 34);
            this.btnCari.TabIndex = 21;
            this.btnCari.Text = "🔍 Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(337, 379);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(113, 44);
            this.btnTambah.TabIndex = 22;
            this.btnTambah.Text = "➕ Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(544, 379);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(100, 44);
            this.btnHapus.TabIndex = 23;
            this.btnHapus.Text = "🗑️ Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(456, 379);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(82, 44);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNonaktifkan
            // 
            this.btnNonaktifkan.Location = new System.Drawing.Point(761, 379);
            this.btnNonaktifkan.Name = "btnNonaktifkan";
            this.btnNonaktifkan.Size = new System.Drawing.Size(124, 44);
            this.btnNonaktifkan.TabIndex = 24;
            this.btnNonaktifkan.Text = "🔒 Nonaktifkan";
            this.btnNonaktifkan.UseVisualStyleBackColor = true;
            this.btnNonaktifkan.Click += new System.EventHandler(this.btnNonaktifkan_Click);
            // 
            // btnAktifkan
            // 
            this.btnAktifkan.Location = new System.Drawing.Point(650, 379);
            this.btnAktifkan.Name = "btnAktifkan";
            this.btnAktifkan.Size = new System.Drawing.Size(105, 44);
            this.btnAktifkan.TabIndex = 25;
            this.btnAktifkan.Text = "✅ Aktifkan";
            this.btnAktifkan.UseVisualStyleBackColor = true;
            this.btnAktifkan.Click += new System.EventHandler(this.btnAktifkan_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(524, 160);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(111, 44);
            this.btnSimpan.TabIndex = 26;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(643, 160);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 44);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "🔄 Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Nonaktif"});
            this.cmbStatus.Location = new System.Drawing.Point(619, 114);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(126, 28);
            this.cmbStatus.TabIndex = 29;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(76, 367);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(99, 24);
            this.rbAdmin.TabIndex = 30;
            this.rbAdmin.Text = "👑 Admin";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.CheckedChanged += new System.EventHandler(this.rbAdmin_CheckedChanged);
            // 
            // rbPelanggan
            // 
            this.rbPelanggan.AutoSize = true;
            this.rbPelanggan.Location = new System.Drawing.Point(76, 399);
            this.rbPelanggan.Name = "rbPelanggan";
            this.rbPelanggan.Size = new System.Drawing.Size(130, 24);
            this.rbPelanggan.TabIndex = 31;
            this.rbPelanggan.Text = "👤 Pelanggan";
            this.rbPelanggan.UseVisualStyleBackColor = true;
            this.rbPelanggan.CheckedChanged += new System.EventHandler(this.rbPelanggan_CheckedChanged);
            // 
            // lblDaftarUser
            // 
            this.lblDaftarUser.AutoSize = true;
            this.lblDaftarUser.BackColor = System.Drawing.Color.Transparent;
            this.lblDaftarUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarUser.ForeColor = System.Drawing.Color.White;
            this.lblDaftarUser.Location = new System.Drawing.Point(12, 333);
            this.lblDaftarUser.Name = "lblDaftarUser";
            this.lblDaftarUser.Size = new System.Drawing.Size(154, 25);
            this.lblDaftarUser.TabIndex = 32;
            this.lblDaftarUser.Text = "📋 DAFTAR USER";
            this.lblDaftarUser.Click += new System.EventHandler(this.lblDaftarUser_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Location = new System.Drawing.Point(14, 369);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(64, 25);
            this.lblFilter.TabIndex = 33;
            this.lblFilter.Text = "Filter : ";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(16, 429);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 62;
            this.dgvUser.RowTemplate.Height = 28;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(869, 170);
            this.dgvUser.TabIndex = 34;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            // 
            // cbRole
            // 
            this.cbRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Pelanggan"});
            this.cbRole.Location = new System.Drawing.Point(76, 113);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(143, 33);
            this.cbRole.TabIndex = 35;
            this.cbRole.SelectedIndexChanged += new System.EventHandler(this.cbRole_SelectedIndexChanged);
            // 
            // FormKelolaPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(897, 633);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblDaftarUser);
            this.Controls.Add(this.rbPelanggan);
            this.Controls.Add(this.rbAdmin);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnAktifkan);
            this.Controls.Add(this.btnNonaktifkan);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtJabatan);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNamaLengkap);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblStatistik);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblJabatan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.lblLengkap);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblNoTelp);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.panel1);
            this.Name = "FormKelolaPelanggan";
            this.Text = "FormKelolaPelanggan";
            this.Load += new System.EventHandler(this.FormKelolaPelanggan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblNoTelp;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblLengkap;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblJabatan;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.TextBox txtNamaLengkap;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtJabatan;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNonaktifkan;
        private System.Windows.Forms.Button btnAktifkan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.RadioButton rbPelanggan;
        private System.Windows.Forms.Label lblDaftarUser;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.ComboBox cbRole;
    }
}