namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormRiwayatBooking
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
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.lblCatatan = new System.Windows.Forms.Label();
            this.lblJamMulai = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblNoTelp = new System.Windows.Forms.Label();
            this.lblDurasi = new System.Windows.Forms.Label();
            this.lblJamSelesai = new System.Windows.Forms.Label();
            this.lblTanggalBooking = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPelanggan = new System.Windows.Forms.Label();
            this.lblIdBooking = new System.Windows.Forms.Label();
            this.lblDetailBooking = new System.Windows.Forms.Label();
            this.lblDaftarBooking = new System.Windows.Forms.Label();
            this.lblTanggalFilter = new System.Windows.Forms.Label();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.lblPelangganFilter = new System.Windows.Forms.Label();
            this.cbPelangganFilter = new System.Windows.Forms.ComboBox();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dtpTanggalFilter = new System.Windows.Forms.DateTimePicker();
            this.txtIDBooking = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtPelanggan = new System.Windows.Forms.TextBox();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtJamSelesai = new System.Windows.Forms.TextBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.txtTanggalBooking = new System.Windows.Forms.TextBox();
            this.txtJamMulai = new System.Windows.Forms.TextBox();
            this.txtStudio = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTolak = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnSetujui = new System.Windows.Forms.Button();
            this.dgvBooking = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(6, 6);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(344, 50);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📋 KELOLA BOOKING";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistik.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStatistik.Location = new System.Drawing.Point(343, 406);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(625, 24);
            this.lblStatistik.TabIndex = 1;
            this.lblStatistik.Text = "\t📊 STATISTIK: ...";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTotalHarga.Location = new System.Drawing.Point(280, 243);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(111, 25);
            this.lblTotalHarga.TabIndex = 3;
            this.lblTotalHarga.Text = "\tTotal Harga :";
            this.lblTotalHarga.Click += new System.EventHandler(this.lblTotalHarga_Click);
            // 
            // lblCatatan
            // 
            this.lblCatatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatatan.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCatatan.Location = new System.Drawing.Point(27, 281);
            this.lblCatatan.Name = "lblCatatan";
            this.lblCatatan.Size = new System.Drawing.Size(91, 27);
            this.lblCatatan.TabIndex = 4;
            this.lblCatatan.Text = "\tCatatan :";
            this.lblCatatan.Click += new System.EventHandler(this.lblCatatan_Click);
            // 
            // lblJamMulai
            // 
            this.lblJamMulai.AutoSize = true;
            this.lblJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJamMulai.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJamMulai.Location = new System.Drawing.Point(280, 141);
            this.lblJamMulai.Name = "lblJamMulai";
            this.lblJamMulai.Size = new System.Drawing.Size(100, 25);
            this.lblJamMulai.TabIndex = 5;
            this.lblJamMulai.Text = "\tJam Mulai :";
            this.lblJamMulai.Click += new System.EventHandler(this.lblJamMulai_Click);
            // 
            // lblStudio
            // 
            this.lblStudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudio.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStudio.Location = new System.Drawing.Point(27, 242);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(79, 28);
            this.lblStudio.TabIndex = 6;
            this.lblStudio.Text = "Studio :";
            this.lblStudio.Click += new System.EventHandler(this.lblStudio_Click);
            // 
            // lblNoTelp
            // 
            this.lblNoTelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTelp.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNoTelp.Location = new System.Drawing.Point(27, 174);
            this.lblNoTelp.Name = "lblNoTelp";
            this.lblNoTelp.Size = new System.Drawing.Size(110, 26);
            this.lblNoTelp.TabIndex = 7;
            this.lblNoTelp.Text = "\tNo. Telepon :";
            this.lblNoTelp.Click += new System.EventHandler(this.lblNoTelp_Click);
            // 
            // lblDurasi
            // 
            this.lblDurasi.AutoSize = true;
            this.lblDurasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurasi.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDurasi.Location = new System.Drawing.Point(280, 208);
            this.lblDurasi.Name = "lblDurasi";
            this.lblDurasi.Size = new System.Drawing.Size(71, 25);
            this.lblDurasi.TabIndex = 9;
            this.lblDurasi.Text = "\tDurasi :";
            this.lblDurasi.Click += new System.EventHandler(this.lblDurasi_Click);
            // 
            // lblJamSelesai
            // 
            this.lblJamSelesai.AutoSize = true;
            this.lblJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJamSelesai.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJamSelesai.Location = new System.Drawing.Point(280, 174);
            this.lblJamSelesai.Name = "lblJamSelesai";
            this.lblJamSelesai.Size = new System.Drawing.Size(110, 25);
            this.lblJamSelesai.TabIndex = 10;
            this.lblJamSelesai.Text = "\tJam Selesai :";
            this.lblJamSelesai.Click += new System.EventHandler(this.lblJamSelesai_Click);
            // 
            // lblTanggalBooking
            // 
            this.lblTanggalBooking.AutoSize = true;
            this.lblTanggalBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalBooking.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTanggalBooking.Location = new System.Drawing.Point(275, 106);
            this.lblTanggalBooking.Name = "lblTanggalBooking";
            this.lblTanggalBooking.Size = new System.Drawing.Size(153, 25);
            this.lblTanggalBooking.TabIndex = 11;
            this.lblTanggalBooking.Text = "\tTanggal Booking :";
            this.lblTanggalBooking.Click += new System.EventHandler(this.lblTanggalBooking_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Firebrick;
            this.lblEmail.Location = new System.Drawing.Point(27, 207);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(88, 26);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "\tEmail :";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblPelanggan
            // 
            this.lblPelanggan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelanggan.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPelanggan.Location = new System.Drawing.Point(27, 140);
            this.lblPelanggan.Name = "lblPelanggan";
            this.lblPelanggan.Size = new System.Drawing.Size(101, 28);
            this.lblPelanggan.TabIndex = 13;
            this.lblPelanggan.Text = "\tPelanggan :";
            this.lblPelanggan.Click += new System.EventHandler(this.lblPelanggan_Click);
            // 
            // lblIdBooking
            // 
            this.lblIdBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdBooking.ForeColor = System.Drawing.Color.Firebrick;
            this.lblIdBooking.Location = new System.Drawing.Point(27, 109);
            this.lblIdBooking.Name = "lblIdBooking";
            this.lblIdBooking.Size = new System.Drawing.Size(101, 27);
            this.lblIdBooking.TabIndex = 14;
            this.lblIdBooking.Text = "ID Booking : ";
            this.lblIdBooking.Click += new System.EventHandler(this.lblIdBooking_Click);
            // 
            // lblDetailBooking
            // 
            this.lblDetailBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailBooking.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDetailBooking.Location = new System.Drawing.Point(27, 75);
            this.lblDetailBooking.Name = "lblDetailBooking";
            this.lblDetailBooking.Size = new System.Drawing.Size(188, 32);
            this.lblDetailBooking.TabIndex = 15;
            this.lblDetailBooking.Text = "\t📝 DETAIL BOOKING";
            this.lblDetailBooking.Click += new System.EventHandler(this.lblDetailBooking_Click);
            // 
            // lblDaftarBooking
            // 
            this.lblDaftarBooking.AutoSize = true;
            this.lblDaftarBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaftarBooking.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDaftarBooking.Location = new System.Drawing.Point(27, 406);
            this.lblDaftarBooking.Name = "lblDaftarBooking";
            this.lblDaftarBooking.Size = new System.Drawing.Size(190, 25);
            this.lblDaftarBooking.TabIndex = 16;
            this.lblDaftarBooking.Text = "\t📋 DAFTAR BOOKING";
            this.lblDaftarBooking.Click += new System.EventHandler(this.lblDaftarBooking_Click);
            // 
            // lblTanggalFilter
            // 
            this.lblTanggalFilter.AutoSize = true;
            this.lblTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalFilter.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTanggalFilter.Location = new System.Drawing.Point(293, 321);
            this.lblTanggalFilter.Name = "lblTanggalFilter";
            this.lblTanggalFilter.Size = new System.Drawing.Size(82, 25);
            this.lblTanggalFilter.TabIndex = 17;
            this.lblTanggalFilter.Text = "Tanggal :";
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFilter.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStatusFilter.Location = new System.Drawing.Point(143, 321);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(140, 25);
            this.lblStatusFilter.TabIndex = 18;
            this.lblStatusFilter.Text = "Status Booking :";
            // 
            // lblPelangganFilter
            // 
            this.lblPelangganFilter.AutoSize = true;
            this.lblPelangganFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelangganFilter.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPelangganFilter.Location = new System.Drawing.Point(31, 321);
            this.lblPelangganFilter.Name = "lblPelangganFilter";
            this.lblPelangganFilter.Size = new System.Drawing.Size(103, 25);
            this.lblPelangganFilter.TabIndex = 19;
            this.lblPelangganFilter.Text = "Pelanggan :";
            // 
            // cbPelangganFilter
            // 
            this.cbPelangganFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPelangganFilter.FormattingEnabled = true;
            this.cbPelangganFilter.Location = new System.Drawing.Point(21, 361);
            this.cbPelangganFilter.Name = "cbPelangganFilter";
            this.cbPelangganFilter.Size = new System.Drawing.Size(113, 28);
            this.cbPelangganFilter.TabIndex = 20;
            this.cbPelangganFilter.SelectedIndexChanged += new System.EventHandler(this.cbPelangganFilter_SelectedIndexChanged);
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
            "Semua",
            "Menunggu",
            "Disetujui",
            "Ditolak",
            "Selesai"});
            this.cbStatusFilter.Location = new System.Drawing.Point(148, 361);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(121, 28);
            this.cbStatusFilter.TabIndex = 21;
            this.cbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilter_SelectedIndexChanged);
            // 
            // dtpTanggalFilter
            // 
            this.dtpTanggalFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalFilter.Location = new System.Drawing.Point(298, 363);
            this.dtpTanggalFilter.Name = "dtpTanggalFilter";
            this.dtpTanggalFilter.Size = new System.Drawing.Size(121, 26);
            this.dtpTanggalFilter.TabIndex = 22;
            this.dtpTanggalFilter.ValueChanged += new System.EventHandler(this.dtpTanggalFilter_ValueChanged);
            // 
            // txtIDBooking
            // 
            this.txtIDBooking.Location = new System.Drawing.Point(143, 110);
            this.txtIDBooking.Name = "txtIDBooking";
            this.txtIDBooking.ReadOnly = true;
            this.txtIDBooking.Size = new System.Drawing.Size(115, 26);
            this.txtIDBooking.TabIndex = 23;
            this.txtIDBooking.TextChanged += new System.EventHandler(this.txtIDBooking_TextChanged);
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Location = new System.Drawing.Point(143, 174);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.ReadOnly = true;
            this.txtNoTelp.Size = new System.Drawing.Size(115, 26);
            this.txtNoTelp.TabIndex = 32;
            this.txtNoTelp.TextChanged += new System.EventHandler(this.txtNoTelp_TextChanged);
            // 
            // txtPelanggan
            // 
            this.txtPelanggan.Location = new System.Drawing.Point(143, 142);
            this.txtPelanggan.Name = "txtPelanggan";
            this.txtPelanggan.ReadOnly = true;
            this.txtPelanggan.Size = new System.Drawing.Size(115, 26);
            this.txtPelanggan.TabIndex = 33;
            this.txtPelanggan.TextChanged += new System.EventHandler(this.txtPelanggan_TextChanged);
            // 
            // txtDurasi
            // 
            this.txtDurasi.Location = new System.Drawing.Point(434, 207);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.ReadOnly = true;
            this.txtDurasi.Size = new System.Drawing.Size(115, 26);
            this.txtDurasi.TabIndex = 36;
            this.txtDurasi.TextChanged += new System.EventHandler(this.txtDurasi_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(143, 206);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(115, 26);
            this.txtEmail.TabIndex = 35;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtJamSelesai
            // 
            this.txtJamSelesai.Location = new System.Drawing.Point(434, 175);
            this.txtJamSelesai.Name = "txtJamSelesai";
            this.txtJamSelesai.ReadOnly = true;
            this.txtJamSelesai.Size = new System.Drawing.Size(115, 26);
            this.txtJamSelesai.TabIndex = 34;
            this.txtJamSelesai.TextChanged += new System.EventHandler(this.txtJamSelesai_TextChanged);
            // 
            // txtCatatan
            // 
            this.txtCatatan.Location = new System.Drawing.Point(143, 282);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ReadOnly = true;
            this.txtCatatan.Size = new System.Drawing.Size(115, 26);
            this.txtCatatan.TabIndex = 39;
            this.txtCatatan.TextChanged += new System.EventHandler(this.txtCatatan_TextChanged);
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Location = new System.Drawing.Point(434, 244);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.ReadOnly = true;
            this.txtTotalHarga.Size = new System.Drawing.Size(115, 26);
            this.txtTotalHarga.TabIndex = 37;
            this.txtTotalHarga.TextChanged += new System.EventHandler(this.txtTotalHarga_TextChanged);
            // 
            // txtTanggalBooking
            // 
            this.txtTanggalBooking.Location = new System.Drawing.Point(434, 110);
            this.txtTanggalBooking.Name = "txtTanggalBooking";
            this.txtTanggalBooking.ReadOnly = true;
            this.txtTanggalBooking.Size = new System.Drawing.Size(115, 26);
            this.txtTanggalBooking.TabIndex = 42;
            this.txtTanggalBooking.TextChanged += new System.EventHandler(this.txtTanggalBooking_TextChanged);
            // 
            // txtJamMulai
            // 
            this.txtJamMulai.Location = new System.Drawing.Point(434, 142);
            this.txtJamMulai.Name = "txtJamMulai";
            this.txtJamMulai.ReadOnly = true;
            this.txtJamMulai.Size = new System.Drawing.Size(115, 26);
            this.txtJamMulai.TabIndex = 41;
            this.txtJamMulai.TextChanged += new System.EventHandler(this.txtJamMulai_TextChanged);
            // 
            // txtStudio
            // 
            this.txtStudio.Location = new System.Drawing.Point(143, 243);
            this.txtStudio.Name = "txtStudio";
            this.txtStudio.ReadOnly = true;
            this.txtStudio.Size = new System.Drawing.Size(115, 26);
            this.txtStudio.TabIndex = 40;
            this.txtStudio.TextChanged += new System.EventHandler(this.txtStudio_TextChanged);
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.Black;
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCari.Location = new System.Drawing.Point(443, 354);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(136, 41);
            this.btnCari.TabIndex = 43;
            this.btnCari.Text = "🔍 Cari Booking";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTolak
            // 
            this.btnTolak.BackColor = System.Drawing.Color.Black;
            this.btnTolak.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnTolak.FlatAppearance.BorderSize = 3;
            this.btnTolak.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTolak.ForeColor = System.Drawing.Color.Firebrick;
            this.btnTolak.Location = new System.Drawing.Point(399, 276);
            this.btnTolak.Name = "btnTolak";
            this.btnTolak.Size = new System.Drawing.Size(101, 43);
            this.btnTolak.TabIndex = 44;
            this.btnTolak.Text = "\t❌ Tolak";
            this.btnTolak.UseVisualStyleBackColor = false;
            this.btnTolak.Click += new System.EventHandler(this.btnTolak_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.BackColor = System.Drawing.Color.Black;
            this.btnSelesai.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnSelesai.FlatAppearance.BorderSize = 3;
            this.btnSelesai.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSelesai.ForeColor = System.Drawing.Color.Firebrick;
            this.btnSelesai.Location = new System.Drawing.Point(506, 276);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(90, 43);
            this.btnSelesai.TabIndex = 46;
            this.btnSelesai.Text = "\t✓ Selesai";
            this.btnSelesai.UseVisualStyleBackColor = false;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnRefresh.FlatAppearance.BorderSize = 3;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRefresh.Location = new System.Drawing.Point(602, 276);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 43);
            this.btnRefresh.TabIndex = 47;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTutup.Location = new System.Drawing.Point(871, 12);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(105, 43);
            this.btnTutup.TabIndex = 49;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnSetujui
            // 
            this.btnSetujui.BackColor = System.Drawing.Color.Black;
            this.btnSetujui.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnSetujui.FlatAppearance.BorderSize = 3;
            this.btnSetujui.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSetujui.ForeColor = System.Drawing.Color.Firebrick;
            this.btnSetujui.Location = new System.Drawing.Point(285, 274);
            this.btnSetujui.Name = "btnSetujui";
            this.btnSetujui.Size = new System.Drawing.Size(108, 43);
            this.btnSetujui.TabIndex = 50;
            this.btnSetujui.Text = "\t✅ Setujui";
            this.btnSetujui.UseVisualStyleBackColor = false;
            this.btnSetujui.Click += new System.EventHandler(this.btnSetujui_Click);
            // 
            // dgvBooking
            // 
            this.dgvBooking.AllowUserToAddRows = false;
            this.dgvBooking.AllowUserToDeleteRows = false;
            this.dgvBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooking.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooking.Location = new System.Drawing.Point(12, 434);
            this.dgvBooking.Name = "dgvBooking";
            this.dgvBooking.ReadOnly = true;
            this.dgvBooking.RowHeadersVisible = false;
            this.dgvBooking.RowHeadersWidth = 62;
            this.dgvBooking.RowTemplate.Height = 28;
            this.dgvBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooking.Size = new System.Drawing.Size(956, 228);
            this.dgvBooking.TabIndex = 51;
            this.dgvBooking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooking_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-8, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 61);
            this.panel1.TabIndex = 52;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FormRiwayatBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(980, 698);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBooking);
            this.Controls.Add(this.btnSetujui);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.btnTolak);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtTanggalBooking);
            this.Controls.Add(this.txtJamMulai);
            this.Controls.Add(this.txtStudio);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtJamSelesai);
            this.Controls.Add(this.txtPelanggan);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtIDBooking);
            this.Controls.Add(this.dtpTanggalFilter);
            this.Controls.Add(this.cbStatusFilter);
            this.Controls.Add(this.cbPelangganFilter);
            this.Controls.Add(this.lblPelangganFilter);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.lblTanggalFilter);
            this.Controls.Add(this.lblDaftarBooking);
            this.Controls.Add(this.lblDetailBooking);
            this.Controls.Add(this.lblIdBooking);
            this.Controls.Add(this.lblPelanggan);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTanggalBooking);
            this.Controls.Add(this.lblJamSelesai);
            this.Controls.Add(this.lblDurasi);
            this.Controls.Add(this.lblNoTelp);
            this.Controls.Add(this.lblStudio);
            this.Controls.Add(this.lblJamMulai);
            this.Controls.Add(this.lblCatatan);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.lblStatistik);
            this.Name = "FormRiwayatBooking";
            this.Text = "FormBooking";
            this.Load += new System.EventHandler(this.FormRiwayatBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.Label lblJamMulai;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblNoTelp;
        private System.Windows.Forms.Label lblDurasi;
        private System.Windows.Forms.Label lblJamSelesai;
        private System.Windows.Forms.Label lblTanggalBooking;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPelanggan;
        private System.Windows.Forms.Label lblIdBooking;
        private System.Windows.Forms.Label lblDetailBooking;
        private System.Windows.Forms.Label lblDaftarBooking;
        private System.Windows.Forms.Label lblTanggalFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Label lblPelangganFilter;
        private System.Windows.Forms.ComboBox cbPelangganFilter;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.DateTimePicker dtpTanggalFilter;
        private System.Windows.Forms.TextBox txtIDBooking;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtPelanggan;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtJamSelesai;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.TextBox txtTanggalBooking;
        private System.Windows.Forms.TextBox txtJamMulai;
        private System.Windows.Forms.TextBox txtStudio;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTolak;
        private System.Windows.Forms.Button btnSelesai;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnSetujui;
        private System.Windows.Forms.DataGridView dgvBooking;
        private System.Windows.Forms.Panel panel1;
    }
}