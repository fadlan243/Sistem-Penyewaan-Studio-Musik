namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormPembayaran
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblTglBayar = new System.Windows.Forms.Label();
            this.lblIdBooking = new System.Windows.Forms.Label();
            this.lblMetodeBayar = new System.Windows.Forms.Label();
            this.lblNoTelp = new System.Windows.Forms.Label();
            this.lblCatatanAdmin = new System.Windows.Forms.Label();
            this.lblPelanggan = new System.Windows.Forms.Label();
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblJumlahBayar = new System.Windows.Forms.Label();
            this.lblTanggalBooking = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblJam = new System.Windows.Forms.Label();
            this.lblStatusPembayaran = new System.Windows.Forms.Label();
            this.lblKembalian = new System.Windows.Forms.Label();
            this.lblPelangganFilter = new System.Windows.Forms.Label();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.lnlIdPembayaran = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDaftarPembayaran = new System.Windows.Forms.Label();
            this.lblTanggalFilter = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbPelangganFilter = new System.Windows.Forms.ComboBox();
            this.dtpTanggalFilter = new System.Windows.Forms.DateTimePicker();
            this.txtIdPembayaran = new System.Windows.Forms.TextBox();
            this.txtIdBooking = new System.Windows.Forms.TextBox();
            this.txtPelanggan = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtJam = new System.Windows.Forms.TextBox();
            this.txtTanggalBooking = new System.Windows.Forms.TextBox();
            this.txtStudio = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtStatusPembayaran = new System.Windows.Forms.TextBox();
            this.txtTanggalBayar = new System.Windows.Forms.TextBox();
            this.txtCatatanAdmin = new System.Windows.Forms.TextBox();
            this.txtMetodeBayar = new System.Windows.Forms.TextBox();
            this.txtKembalian = new System.Windows.Forms.TextBox();
            this.txtJumlahBayar = new System.Windows.Forms.TextBox();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnKonfirmasi = new System.Windows.Forms.Button();
            this.btnTolak = new System.Windows.Forms.Button();
            this.btnSimpanCatatan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(32, 25);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(641, 41);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "\t💰 KELOLA PEMBAYARAN - BLACK ROCK STUDIO";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblTglBayar
            // 
            this.lblTglBayar.AutoSize = true;
            this.lblTglBayar.BackColor = System.Drawing.Color.Transparent;
            this.lblTglBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTglBayar.ForeColor = System.Drawing.Color.White;
            this.lblTglBayar.Location = new System.Drawing.Point(290, 243);
            this.lblTglBayar.Name = "lblTglBayar";
            this.lblTglBayar.Size = new System.Drawing.Size(91, 25);
            this.lblTglBayar.TabIndex = 1;
            this.lblTglBayar.Text = "\tTgl Bayar :";
            this.lblTglBayar.Click += new System.EventHandler(this.lblTglBayar_Click);
            // 
            // lblIdBooking
            // 
            this.lblIdBooking.AutoSize = true;
            this.lblIdBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblIdBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdBooking.ForeColor = System.Drawing.Color.White;
            this.lblIdBooking.Location = new System.Drawing.Point(12, 141);
            this.lblIdBooking.Name = "lblIdBooking";
            this.lblIdBooking.Size = new System.Drawing.Size(110, 25);
            this.lblIdBooking.TabIndex = 2;
            this.lblIdBooking.Text = "\tID Booking :";
            this.lblIdBooking.Click += new System.EventHandler(this.lblIdBooking_Click);
            // 
            // lblMetodeBayar
            // 
            this.lblMetodeBayar.AutoSize = true;
            this.lblMetodeBayar.BackColor = System.Drawing.Color.Transparent;
            this.lblMetodeBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodeBayar.ForeColor = System.Drawing.Color.White;
            this.lblMetodeBayar.Location = new System.Drawing.Point(290, 210);
            this.lblMetodeBayar.Name = "lblMetodeBayar";
            this.lblMetodeBayar.Size = new System.Drawing.Size(131, 25);
            this.lblMetodeBayar.TabIndex = 3;
            this.lblMetodeBayar.Text = "\tMetode Bayar :";
            this.lblMetodeBayar.Click += new System.EventHandler(this.lblMetodeBayar_Click);
            // 
            // lblNoTelp
            // 
            this.lblNoTelp.AutoSize = true;
            this.lblNoTelp.BackColor = System.Drawing.Color.Transparent;
            this.lblNoTelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTelp.ForeColor = System.Drawing.Color.White;
            this.lblNoTelp.Location = new System.Drawing.Point(12, 175);
            this.lblNoTelp.Name = "lblNoTelp";
            this.lblNoTelp.Size = new System.Drawing.Size(115, 25);
            this.lblNoTelp.TabIndex = 4;
            this.lblNoTelp.Text = "\tNo. Telepon :";
            this.lblNoTelp.Click += new System.EventHandler(this.lblNoTelp_Click);
            // 
            // lblCatatanAdmin
            // 
            this.lblCatatanAdmin.AutoSize = true;
            this.lblCatatanAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatatanAdmin.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCatatanAdmin.Location = new System.Drawing.Point(609, 86);
            this.lblCatatanAdmin.Name = "lblCatatanAdmin";
            this.lblCatatanAdmin.Size = new System.Drawing.Size(139, 25);
            this.lblCatatanAdmin.TabIndex = 5;
            this.lblCatatanAdmin.Text = "\tCatatan Admin :";
            this.lblCatatanAdmin.Click += new System.EventHandler(this.lblCatatanAdmin_Click);
            // 
            // lblPelanggan
            // 
            this.lblPelanggan.AutoSize = true;
            this.lblPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblPelanggan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelanggan.ForeColor = System.Drawing.Color.White;
            this.lblPelanggan.Location = new System.Drawing.Point(12, 111);
            this.lblPelanggan.Name = "lblPelanggan";
            this.lblPelanggan.Size = new System.Drawing.Size(103, 25);
            this.lblPelanggan.TabIndex = 6;
            this.lblPelanggan.Text = "Pelanggan :";
            this.lblPelanggan.Click += new System.EventHandler(this.lblPelanggan_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.AutoSize = true;
            this.lblStatistik.BackColor = System.Drawing.Color.Transparent;
            this.lblStatistik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistik.ForeColor = System.Drawing.Color.White;
            this.lblStatistik.Location = new System.Drawing.Point(11, 668);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(140, 25);
            this.lblStatistik.TabIndex = 7;
            this.lblStatistik.Text = "📊 STATISTIK: ...";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblJumlahBayar
            // 
            this.lblJumlahBayar.AutoSize = true;
            this.lblJumlahBayar.BackColor = System.Drawing.Color.Transparent;
            this.lblJumlahBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahBayar.ForeColor = System.Drawing.Color.White;
            this.lblJumlahBayar.Location = new System.Drawing.Point(287, 141);
            this.lblJumlahBayar.Name = "lblJumlahBayar";
            this.lblJumlahBayar.Size = new System.Drawing.Size(124, 25);
            this.lblJumlahBayar.TabIndex = 8;
            this.lblJumlahBayar.Text = "Jumlah Bayar :";
            this.lblJumlahBayar.Click += new System.EventHandler(this.lblJumlahBayar_Click);
            // 
            // lblTanggalBooking
            // 
            this.lblTanggalBooking.AutoSize = true;
            this.lblTanggalBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggalBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalBooking.ForeColor = System.Drawing.Color.White;
            this.lblTanggalBooking.Location = new System.Drawing.Point(12, 273);
            this.lblTanggalBooking.Name = "lblTanggalBooking";
            this.lblTanggalBooking.Size = new System.Drawing.Size(114, 25);
            this.lblTanggalBooking.TabIndex = 9;
            this.lblTanggalBooking.Text = "Tgl Booking :";
            this.lblTanggalBooking.Click += new System.EventHandler(this.lblTanggalBooking_Click);
            // 
            // lblStudio
            // 
            this.lblStudio.AutoSize = true;
            this.lblStudio.BackColor = System.Drawing.Color.Transparent;
            this.lblStudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudio.ForeColor = System.Drawing.Color.White;
            this.lblStudio.Location = new System.Drawing.Point(12, 241);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(72, 25);
            this.lblStudio.TabIndex = 10;
            this.lblStudio.Text = "\tStudio :";
            this.lblStudio.Click += new System.EventHandler(this.lblStudio_Click);
            // 
            // lblJam
            // 
            this.lblJam.AutoSize = true;
            this.lblJam.BackColor = System.Drawing.Color.Transparent;
            this.lblJam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJam.ForeColor = System.Drawing.Color.White;
            this.lblJam.Location = new System.Drawing.Point(287, 81);
            this.lblJam.Name = "lblJam";
            this.lblJam.Size = new System.Drawing.Size(52, 25);
            this.lblJam.TabIndex = 11;
            this.lblJam.Text = "\tJam :";
            this.lblJam.Click += new System.EventHandler(this.lblJam_Click);
            // 
            // lblStatusPembayaran
            // 
            this.lblStatusPembayaran.AutoSize = true;
            this.lblStatusPembayaran.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusPembayaran.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusPembayaran.ForeColor = System.Drawing.Color.White;
            this.lblStatusPembayaran.Location = new System.Drawing.Point(290, 277);
            this.lblStatusPembayaran.Name = "lblStatusPembayaran";
            this.lblStatusPembayaran.Size = new System.Drawing.Size(69, 25);
            this.lblStatusPembayaran.TabIndex = 12;
            this.lblStatusPembayaran.Text = "Status :";
            this.lblStatusPembayaran.Click += new System.EventHandler(this.lblStatusPembayaran_Click);
            // 
            // lblKembalian
            // 
            this.lblKembalian.AutoSize = true;
            this.lblKembalian.BackColor = System.Drawing.Color.Transparent;
            this.lblKembalian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKembalian.ForeColor = System.Drawing.Color.White;
            this.lblKembalian.Location = new System.Drawing.Point(287, 175);
            this.lblKembalian.Name = "lblKembalian";
            this.lblKembalian.Size = new System.Drawing.Size(103, 25);
            this.lblKembalian.TabIndex = 13;
            this.lblKembalian.Text = "\tKembalian :";
            this.lblKembalian.Click += new System.EventHandler(this.lblKembalian_Click);
            // 
            // lblPelangganFilter
            // 
            this.lblPelangganFilter.AutoSize = true;
            this.lblPelangganFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblPelangganFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelangganFilter.ForeColor = System.Drawing.Color.White;
            this.lblPelangganFilter.Location = new System.Drawing.Point(200, 328);
            this.lblPelangganFilter.Name = "lblPelangganFilter";
            this.lblPelangganFilter.Size = new System.Drawing.Size(103, 25);
            this.lblPelangganFilter.TabIndex = 14;
            this.lblPelangganFilter.Text = "Pelanggan :";
            this.lblPelangganFilter.Click += new System.EventHandler(this.lblPelangganFilter_Click);
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFilter.ForeColor = System.Drawing.Color.White;
            this.lblStatusFilter.Location = new System.Drawing.Point(12, 328);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(171, 25);
            this.lblStatusFilter.TabIndex = 15;
            this.lblStatusFilter.Text = "\tStatus Pembayaran :";
            this.lblStatusFilter.Click += new System.EventHandler(this.lblStatusFilter_Click);
            // 
            // lnlIdPembayaran
            // 
            this.lnlIdPembayaran.AutoSize = true;
            this.lnlIdPembayaran.BackColor = System.Drawing.Color.Transparent;
            this.lnlIdPembayaran.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlIdPembayaran.ForeColor = System.Drawing.Color.White;
            this.lnlIdPembayaran.Location = new System.Drawing.Point(12, 85);
            this.lnlIdPembayaran.Name = "lnlIdPembayaran";
            this.lnlIdPembayaran.Size = new System.Drawing.Size(141, 25);
            this.lnlIdPembayaran.TabIndex = 16;
            this.lnlIdPembayaran.Text = "\tID Pembayaran :";
            this.lnlIdPembayaran.Click += new System.EventHandler(this.lnlIdPembayaran_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(12, 210);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 25);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "\tEmail :";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblDaftarPembayaran
            // 
            this.lblDaftarPembayaran.AutoSize = true;
            this.lblDaftarPembayaran.BackColor = System.Drawing.Color.Transparent;
            this.lblDaftarPembayaran.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarPembayaran.ForeColor = System.Drawing.Color.White;
            this.lblDaftarPembayaran.Location = new System.Drawing.Point(12, 400);
            this.lblDaftarPembayaran.Name = "lblDaftarPembayaran";
            this.lblDaftarPembayaran.Size = new System.Drawing.Size(225, 25);
            this.lblDaftarPembayaran.TabIndex = 19;
            this.lblDaftarPembayaran.Text = "📋 DAFTAR PEMBAYARAN";
            this.lblDaftarPembayaran.Click += new System.EventHandler(this.lblDaftarPembayaran_Click);
            // 
            // lblTanggalFilter
            // 
            this.lblTanggalFilter.AutoSize = true;
            this.lblTanggalFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalFilter.ForeColor = System.Drawing.Color.White;
            this.lblTanggalFilter.Location = new System.Drawing.Point(382, 328);
            this.lblTanggalFilter.Name = "lblTanggalFilter";
            this.lblTanggalFilter.Size = new System.Drawing.Size(82, 25);
            this.lblTanggalFilter.TabIndex = 20;
            this.lblTanggalFilter.Text = "Tanggal :";
            this.lblTanggalFilter.Click += new System.EventHandler(this.lblTanggalFilter_Click);
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalHarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.ForeColor = System.Drawing.Color.White;
            this.lblTotalHarga.Location = new System.Drawing.Point(285, 112);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(111, 25);
            this.lblTotalHarga.TabIndex = 22;
            this.lblTotalHarga.Text = "\tTotal Harga :";
            this.lblTotalHarga.Click += new System.EventHandler(this.lblTotalHarga_Click);
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Semua",
            "Menunggu",
            "Dikonfirmasi",
            "Ditolak"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(17, 356);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(134, 28);
            this.cmbStatusFilter.TabIndex = 23;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // cmbPelangganFilter
            // 
            this.cmbPelangganFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPelangganFilter.FormattingEnabled = true;
            this.cmbPelangganFilter.Location = new System.Drawing.Point(205, 356);
            this.cmbPelangganFilter.Name = "cmbPelangganFilter";
            this.cmbPelangganFilter.Size = new System.Drawing.Size(134, 28);
            this.cmbPelangganFilter.TabIndex = 24;
            this.cmbPelangganFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPelangganFilter_SelectedIndexChanged);
            // 
            // dtpTanggalFilter
            // 
            this.dtpTanggalFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalFilter.Location = new System.Drawing.Point(387, 358);
            this.dtpTanggalFilter.Name = "dtpTanggalFilter";
            this.dtpTanggalFilter.Size = new System.Drawing.Size(133, 26);
            this.dtpTanggalFilter.TabIndex = 25;
            this.dtpTanggalFilter.ValueChanged += new System.EventHandler(this.dtpTanggalFilter_ValueChanged);
            // 
            // txtIdPembayaran
            // 
            this.txtIdPembayaran.Location = new System.Drawing.Point(159, 87);
            this.txtIdPembayaran.Name = "txtIdPembayaran";
            this.txtIdPembayaran.ReadOnly = true;
            this.txtIdPembayaran.Size = new System.Drawing.Size(122, 26);
            this.txtIdPembayaran.TabIndex = 26;
            this.txtIdPembayaran.TextChanged += new System.EventHandler(this.txtIdPembayaran_TextChanged);
            // 
            // txtIdBooking
            // 
            this.txtIdBooking.Location = new System.Drawing.Point(159, 146);
            this.txtIdBooking.Name = "txtIdBooking";
            this.txtIdBooking.ReadOnly = true;
            this.txtIdBooking.Size = new System.Drawing.Size(122, 26);
            this.txtIdBooking.TabIndex = 27;
            this.txtIdBooking.TextChanged += new System.EventHandler(this.txtIdBooking_TextChanged);
            // 
            // txtPelanggan
            // 
            this.txtPelanggan.Location = new System.Drawing.Point(159, 115);
            this.txtPelanggan.Name = "txtPelanggan";
            this.txtPelanggan.ReadOnly = true;
            this.txtPelanggan.Size = new System.Drawing.Size(122, 26);
            this.txtPelanggan.TabIndex = 28;
            this.txtPelanggan.TextChanged += new System.EventHandler(this.txtPelanggan_TextChanged);
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Location = new System.Drawing.Point(159, 178);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.ReadOnly = true;
            this.txtNoTelp.Size = new System.Drawing.Size(121, 26);
            this.txtNoTelp.TabIndex = 29;
            this.txtNoTelp.TextChanged += new System.EventHandler(this.txtNoTelp_TextChanged);
            // 
            // txtJam
            // 
            this.txtJam.Location = new System.Drawing.Point(441, 84);
            this.txtJam.Name = "txtJam";
            this.txtJam.ReadOnly = true;
            this.txtJam.Size = new System.Drawing.Size(134, 26);
            this.txtJam.TabIndex = 30;
            this.txtJam.TextChanged += new System.EventHandler(this.txtJam_TextChanged);
            // 
            // txtTanggalBooking
            // 
            this.txtTanggalBooking.Location = new System.Drawing.Point(159, 274);
            this.txtTanggalBooking.Name = "txtTanggalBooking";
            this.txtTanggalBooking.ReadOnly = true;
            this.txtTanggalBooking.Size = new System.Drawing.Size(122, 26);
            this.txtTanggalBooking.TabIndex = 31;
            this.txtTanggalBooking.TextChanged += new System.EventHandler(this.txtTanggalBooking_TextChanged);
            // 
            // txtStudio
            // 
            this.txtStudio.Location = new System.Drawing.Point(159, 242);
            this.txtStudio.Name = "txtStudio";
            this.txtStudio.ReadOnly = true;
            this.txtStudio.Size = new System.Drawing.Size(121, 26);
            this.txtStudio.TabIndex = 32;
            this.txtStudio.TextChanged += new System.EventHandler(this.txtStudio_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(159, 210);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(121, 26);
            this.txtEmail.TabIndex = 33;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtStatusPembayaran
            // 
            this.txtStatusPembayaran.Location = new System.Drawing.Point(441, 279);
            this.txtStatusPembayaran.Name = "txtStatusPembayaran";
            this.txtStatusPembayaran.ReadOnly = true;
            this.txtStatusPembayaran.Size = new System.Drawing.Size(134, 26);
            this.txtStatusPembayaran.TabIndex = 41;
            this.txtStatusPembayaran.TextChanged += new System.EventHandler(this.txtStatusPembayaran_TextChanged);
            // 
            // txtTanggalBayar
            // 
            this.txtTanggalBayar.Location = new System.Drawing.Point(441, 245);
            this.txtTanggalBayar.Name = "txtTanggalBayar";
            this.txtTanggalBayar.ReadOnly = true;
            this.txtTanggalBayar.Size = new System.Drawing.Size(134, 26);
            this.txtTanggalBayar.TabIndex = 40;
            this.txtTanggalBayar.TextChanged += new System.EventHandler(this.txtTanggalBayar_TextChanged);
            // 
            // txtCatatanAdmin
            // 
            this.txtCatatanAdmin.Location = new System.Drawing.Point(614, 126);
            this.txtCatatanAdmin.Name = "txtCatatanAdmin";
            this.txtCatatanAdmin.Size = new System.Drawing.Size(163, 26);
            this.txtCatatanAdmin.TabIndex = 39;
            this.txtCatatanAdmin.TextChanged += new System.EventHandler(this.txtCatatanAdmin_TextChanged);
            // 
            // txtMetodeBayar
            // 
            this.txtMetodeBayar.Location = new System.Drawing.Point(441, 213);
            this.txtMetodeBayar.Name = "txtMetodeBayar";
            this.txtMetodeBayar.ReadOnly = true;
            this.txtMetodeBayar.Size = new System.Drawing.Size(134, 26);
            this.txtMetodeBayar.TabIndex = 37;
            this.txtMetodeBayar.TextChanged += new System.EventHandler(this.txtMetodeBayar_TextChanged);
            // 
            // txtKembalian
            // 
            this.txtKembalian.Location = new System.Drawing.Point(441, 181);
            this.txtKembalian.Name = "txtKembalian";
            this.txtKembalian.ReadOnly = true;
            this.txtKembalian.Size = new System.Drawing.Size(134, 26);
            this.txtKembalian.TabIndex = 36;
            this.txtKembalian.TextChanged += new System.EventHandler(this.txtKembalian_TextChanged);
            // 
            // txtJumlahBayar
            // 
            this.txtJumlahBayar.Location = new System.Drawing.Point(441, 149);
            this.txtJumlahBayar.Name = "txtJumlahBayar";
            this.txtJumlahBayar.ReadOnly = true;
            this.txtJumlahBayar.Size = new System.Drawing.Size(134, 26);
            this.txtJumlahBayar.TabIndex = 35;
            this.txtJumlahBayar.TextChanged += new System.EventHandler(this.txtJumlahBayar_TextChanged);
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Location = new System.Drawing.Point(441, 117);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.ReadOnly = true;
            this.txtTotalHarga.Size = new System.Drawing.Size(134, 26);
            this.txtTotalHarga.TabIndex = 34;
            this.txtTotalHarga.TextChanged += new System.EventHandler(this.txtTotalHarga_TextChanged);
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.Black;
            this.btnCari.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnCari.FlatAppearance.BorderSize = 4;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCari.Location = new System.Drawing.Point(556, 348);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(121, 51);
            this.btnCari.TabIndex = 42;
            this.btnCari.Text = "\t🔍 Cari Pembayaran";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnKonfirmasi
            // 
            this.btnKonfirmasi.BackColor = System.Drawing.Color.Black;
            this.btnKonfirmasi.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnKonfirmasi.FlatAppearance.BorderSize = 4;
            this.btnKonfirmasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonfirmasi.ForeColor = System.Drawing.Color.Firebrick;
            this.btnKonfirmasi.Location = new System.Drawing.Point(581, 169);
            this.btnKonfirmasi.Name = "btnKonfirmasi";
            this.btnKonfirmasi.Size = new System.Drawing.Size(154, 51);
            this.btnKonfirmasi.TabIndex = 43;
            this.btnKonfirmasi.Text = "✅ Konfirmasi";
            this.btnKonfirmasi.UseVisualStyleBackColor = false;
            this.btnKonfirmasi.Click += new System.EventHandler(this.btnKonfirmasi_Click);
            // 
            // btnTolak
            // 
            this.btnTolak.BackColor = System.Drawing.Color.Black;
            this.btnTolak.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnTolak.FlatAppearance.BorderSize = 4;
            this.btnTolak.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTolak.ForeColor = System.Drawing.Color.Firebrick;
            this.btnTolak.Location = new System.Drawing.Point(581, 232);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(154, 51);
            this.btnTolak.TabIndex = 44;
            this.btnTolak.Text = "\t❌ Tolak";
            this.btnTolak.UseVisualStyleBackColor = false;
            this.btnTolak.Click += new System.EventHandler(this.btnTolak_Click);
            // 
            // btnSimpanCatatan
            // 
            this.btnSimpanCatatan.BackColor = System.Drawing.Color.Black;
            this.btnSimpanCatatan.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnSimpanCatatan.FlatAppearance.BorderSize = 4;
            this.btnSimpanCatatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanCatatan.ForeColor = System.Drawing.Color.Firebrick;
            this.btnSimpanCatatan.Location = new System.Drawing.Point(745, 169);
            this.btnSimpanCatatan.Name = "btnSimpanCatatan";
            this.btnSimpanCatatan.Size = new System.Drawing.Size(121, 51);
            this.btnSimpanCatatan.TabIndex = 45;
            this.btnSimpanCatatan.Text = "💾 Simpan Catatan";
            this.btnSimpanCatatan.UseVisualStyleBackColor = false;
            this.btnSimpanCatatan.Click += new System.EventHandler(this.btnSimpanCatatan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnRefresh.FlatAppearance.BorderSize = 4;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRefresh.Location = new System.Drawing.Point(745, 233);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 51);
            this.btnRefresh.TabIndex = 46;
            this.btnRefresh.Text = "\t🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Red;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(988, 25);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(105, 41);
            this.btnTutup.TabIndex = 47;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.AllowUserToAddRows = false;
            this.dgvPembayaran.AllowUserToDeleteRows = false;
            this.dgvPembayaran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPembayaran.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPembayaran.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Location = new System.Drawing.Point(12, 428);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.ReadOnly = true;
            this.dgvPembayaran.RowHeadersVisible = false;
            this.dgvPembayaran.RowHeadersWidth = 62;
            this.dgvPembayaran.RowTemplate.Height = 28;
            this.dgvPembayaran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPembayaran.Size = new System.Drawing.Size(1057, 237);
            this.dgvPembayaran.TabIndex = 48;
            this.dgvPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembayaran_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Location = new System.Drawing.Point(-20, -13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 74);
            this.panel1.TabIndex = 49;
            // 
            // FormPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 702);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPembayaran);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSimpanCatatan);
            this.Controls.Add(this.btnTolak);
            this.Controls.Add(this.btnKonfirmasi);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtStatusPembayaran);
            this.Controls.Add(this.txtTanggalBayar);
            this.Controls.Add(this.txtCatatanAdmin);
            this.Controls.Add(this.txtMetodeBayar);
            this.Controls.Add(this.txtKembalian);
            this.Controls.Add(this.txtJumlahBayar);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtStudio);
            this.Controls.Add(this.txtTanggalBooking);
            this.Controls.Add(this.txtJam);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtPelanggan);
            this.Controls.Add(this.txtIdBooking);
            this.Controls.Add(this.txtIdPembayaran);
            this.Controls.Add(this.dtpTanggalFilter);
            this.Controls.Add(this.cmbPelangganFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.lblTanggalFilter);
            this.Controls.Add(this.lblDaftarPembayaran);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lnlIdPembayaran);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.lblPelangganFilter);
            this.Controls.Add(this.lblKembalian);
            this.Controls.Add(this.lblStatusPembayaran);
            this.Controls.Add(this.lblJam);
            this.Controls.Add(this.lblStudio);
            this.Controls.Add(this.lblTanggalBooking);
            this.Controls.Add(this.lblJumlahBayar);
            this.Controls.Add(this.lblStatistik);
            this.Controls.Add(this.lblPelanggan);
            this.Controls.Add(this.lblCatatanAdmin);
            this.Controls.Add(this.lblNoTelp);
            this.Controls.Add(this.lblMetodeBayar);
            this.Controls.Add(this.lblIdBooking);
            this.Controls.Add(this.lblTglBayar);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormPembayaran";
            this.Text = "FormPembayaran";
            this.Load += new System.EventHandler(this.FormPembayaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTglBayar;
        private System.Windows.Forms.Label lblIdBooking;
        private System.Windows.Forms.Label lblMetodeBayar;
        private System.Windows.Forms.Label lblNoTelp;
        private System.Windows.Forms.Label lblCatatanAdmin;
        private System.Windows.Forms.Label lblPelanggan;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblJumlahBayar;
        private System.Windows.Forms.Label lblTanggalBooking;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblJam;
        private System.Windows.Forms.Label lblStatusPembayaran;
        private System.Windows.Forms.Label lblKembalian;
        private System.Windows.Forms.Label lblPelangganFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Label lnlIdPembayaran;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDaftarPembayaran;
        private System.Windows.Forms.Label lblTanggalFilter;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbPelangganFilter;
        private System.Windows.Forms.DateTimePicker dtpTanggalFilter;
        private System.Windows.Forms.TextBox txtIdPembayaran;
        private System.Windows.Forms.TextBox txtIdBooking;
        private System.Windows.Forms.TextBox txtPelanggan;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtJam;
        private System.Windows.Forms.TextBox txtTanggalBooking;
        private System.Windows.Forms.TextBox txtStudio;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtStatusPembayaran;
        private System.Windows.Forms.TextBox txtTanggalBayar;
        private System.Windows.Forms.TextBox txtCatatanAdmin;
        private System.Windows.Forms.TextBox txtMetodeBayar;
        private System.Windows.Forms.TextBox txtKembalian;
        private System.Windows.Forms.TextBox txtJumlahBayar;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnKonfirmasi;
        private System.Windows.Forms.Button btnTolak;
        private System.Windows.Forms.Button btnSimpanCatatan;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.Panel panel1;
    }
}