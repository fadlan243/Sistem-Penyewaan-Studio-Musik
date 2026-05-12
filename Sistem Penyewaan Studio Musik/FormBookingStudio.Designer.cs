namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormBookingStudio
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
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblStudioFilter = new System.Windows.Forms.Label();
            this.lblTanggalFilter = new System.Windows.Forms.Label();
            this.lblDaftarJadwal = new System.Windows.Forms.Label();
            this.lblFormBooking = new System.Windows.Forms.Label();
            this.lblDetailJadwal = new System.Windows.Forms.Label();
            this.lblDataPelanggan = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblRiwayatBooking = new System.Windows.Forms.Label();
            this.lblNoTelpPelanggan = new System.Windows.Forms.Label();
            this.lblEmailPelanggan = new System.Windows.Forms.Label();
            this.lblNamaPelanggan = new System.Windows.Forms.Label();
            this.lblCatatan = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.lblDurasi = new System.Windows.Forms.Label();
            this.lblHargaPerJam = new System.Windows.Forms.Label();
            this.lblJamSelesai = new System.Windows.Forms.Label();
            this.lblJamMulai = new System.Windows.Forms.Label();
            this.cbStudioFilter = new System.Windows.Forms.ComboBox();
            this.dtpTanggalFilter = new System.Windows.Forms.DateTimePicker();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.btnCariJadwal = new System.Windows.Forms.Button();
            this.btnBooking = new System.Windows.Forms.Button();
            this.btnBatalBooking = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.dgvJadwalTersedia = new System.Windows.Forms.DataGridView();
            this.dgvRiwayatBooking = new System.Windows.Forms.DataGridView();
            this.cbStudio = new System.Windows.Forms.ComboBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.dtpJamSelesai = new System.Windows.Forms.DateTimePicker();
            this.dtpJamMulai = new System.Windows.Forms.DateTimePicker();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.txtHargaPerJam = new System.Windows.Forms.TextBox();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwalTersedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatBooking)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(19, 26);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(500, 32);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📅 BOOKING STUDIO - BLACK ROCK STUDIO";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Location = new System.Drawing.Point(88, 104);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(146, 28);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "FILTER JADWAL";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // lblStudioFilter
            // 
            this.lblStudioFilter.AutoSize = true;
            this.lblStudioFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblStudioFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudioFilter.ForeColor = System.Drawing.Color.White;
            this.lblStudioFilter.Location = new System.Drawing.Point(62, 145);
            this.lblStudioFilter.Name = "lblStudioFilter";
            this.lblStudioFilter.Size = new System.Drawing.Size(72, 25);
            this.lblStudioFilter.TabIndex = 2;
            this.lblStudioFilter.Text = "\tStudio :";
            this.lblStudioFilter.Click += new System.EventHandler(this.lblStudioFilter_Click);
            // 
            // lblTanggalFilter
            // 
            this.lblTanggalFilter.AutoSize = true;
            this.lblTanggalFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalFilter.ForeColor = System.Drawing.Color.White;
            this.lblTanggalFilter.Location = new System.Drawing.Point(220, 145);
            this.lblTanggalFilter.Name = "lblTanggalFilter";
            this.lblTanggalFilter.Size = new System.Drawing.Size(82, 25);
            this.lblTanggalFilter.TabIndex = 3;
            this.lblTanggalFilter.Text = "Tanggal :";
            this.lblTanggalFilter.Click += new System.EventHandler(this.lblTanggalFilter_Click);
            // 
            // lblDaftarJadwal
            // 
            this.lblDaftarJadwal.AutoSize = true;
            this.lblDaftarJadwal.BackColor = System.Drawing.Color.Transparent;
            this.lblDaftarJadwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDaftarJadwal.ForeColor = System.Drawing.Color.White;
            this.lblDaftarJadwal.Location = new System.Drawing.Point(18, 242);
            this.lblDaftarJadwal.Name = "lblDaftarJadwal";
            this.lblDaftarJadwal.Size = new System.Drawing.Size(284, 28);
            this.lblDaftarJadwal.TabIndex = 4;
            this.lblDaftarJadwal.Text = "📋 DAFTAR JADWAL TERSEDIA";
            this.lblDaftarJadwal.Click += new System.EventHandler(this.lblDaftarJadwal_Click);
            // 
            // lblFormBooking
            // 
            this.lblFormBooking.AutoSize = true;
            this.lblFormBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblFormBooking.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFormBooking.ForeColor = System.Drawing.Color.White;
            this.lblFormBooking.Location = new System.Drawing.Point(1084, 141);
            this.lblFormBooking.Name = "lblFormBooking";
            this.lblFormBooking.Size = new System.Drawing.Size(191, 28);
            this.lblFormBooking.TabIndex = 5;
            this.lblFormBooking.Text = "📝 FORM BOOKING";
            this.lblFormBooking.Click += new System.EventHandler(this.lblFormBooking_Click);
            // 
            // lblDetailJadwal
            // 
            this.lblDetailJadwal.AutoSize = true;
            this.lblDetailJadwal.BackColor = System.Drawing.Color.Transparent;
            this.lblDetailJadwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetailJadwal.ForeColor = System.Drawing.Color.White;
            this.lblDetailJadwal.Location = new System.Drawing.Point(917, 168);
            this.lblDetailJadwal.Name = "lblDetailJadwal";
            this.lblDetailJadwal.Size = new System.Drawing.Size(164, 28);
            this.lblDetailJadwal.TabIndex = 6;
            this.lblDetailJadwal.Text = "DETAIL BOOKING";
            this.lblDetailJadwal.Click += new System.EventHandler(this.lblDetailJadwal_Click);
            // 
            // lblDataPelanggan
            // 
            this.lblDataPelanggan.AutoSize = true;
            this.lblDataPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblDataPelanggan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDataPelanggan.ForeColor = System.Drawing.Color.White;
            this.lblDataPelanggan.Location = new System.Drawing.Point(1217, 168);
            this.lblDataPelanggan.Name = "lblDataPelanggan";
            this.lblDataPelanggan.Size = new System.Drawing.Size(180, 28);
            this.lblDataPelanggan.TabIndex = 7;
            this.lblDataPelanggan.Text = "DATA PELANGGAN";
            this.lblDataPelanggan.Click += new System.EventHandler(this.lblDataPelanggan_Click);
            // 
            // lblStudio
            // 
            this.lblStudio.AutoSize = true;
            this.lblStudio.BackColor = System.Drawing.Color.Transparent;
            this.lblStudio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudio.ForeColor = System.Drawing.Color.White;
            this.lblStudio.Location = new System.Drawing.Point(917, 198);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(77, 25);
            this.lblStudio.TabIndex = 8;
            this.lblStudio.Text = "Studio : ";
            this.lblStudio.Click += new System.EventHandler(this.lblStudio_Click);
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTanggal.ForeColor = System.Drawing.Color.White;
            this.lblTanggal.Location = new System.Drawing.Point(917, 231);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(87, 25);
            this.lblTanggal.TabIndex = 9;
            this.lblTanggal.Text = "Tanggal : ";
            this.lblTanggal.Click += new System.EventHandler(this.lblTanggal_Click);
            // 
            // lblRiwayatBooking
            // 
            this.lblRiwayatBooking.AutoSize = true;
            this.lblRiwayatBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblRiwayatBooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiwayatBooking.ForeColor = System.Drawing.Color.White;
            this.lblRiwayatBooking.Location = new System.Drawing.Point(29, 462);
            this.lblRiwayatBooking.Name = "lblRiwayatBooking";
            this.lblRiwayatBooking.Size = new System.Drawing.Size(264, 28);
            this.lblRiwayatBooking.TabIndex = 19;
            this.lblRiwayatBooking.Text = "📜 RIWAYAT BOOKING SAYA";
            this.lblRiwayatBooking.Click += new System.EventHandler(this.lblRiwayatBooking_Click);
            // 
            // lblNoTelpPelanggan
            // 
            this.lblNoTelpPelanggan.AutoSize = true;
            this.lblNoTelpPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblNoTelpPelanggan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoTelpPelanggan.ForeColor = System.Drawing.Color.White;
            this.lblNoTelpPelanggan.Location = new System.Drawing.Point(1220, 262);
            this.lblNoTelpPelanggan.Name = "lblNoTelpPelanggan";
            this.lblNoTelpPelanggan.Size = new System.Drawing.Size(115, 25);
            this.lblNoTelpPelanggan.TabIndex = 18;
            this.lblNoTelpPelanggan.Text = "No. Telepon :";
            this.lblNoTelpPelanggan.Click += new System.EventHandler(this.lblNoTelpPelanggan_Click);
            // 
            // lblEmailPelanggan
            // 
            this.lblEmailPelanggan.AutoSize = true;
            this.lblEmailPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailPelanggan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailPelanggan.ForeColor = System.Drawing.Color.White;
            this.lblEmailPelanggan.Location = new System.Drawing.Point(1220, 232);
            this.lblEmailPelanggan.Name = "lblEmailPelanggan";
            this.lblEmailPelanggan.Size = new System.Drawing.Size(68, 25);
            this.lblEmailPelanggan.TabIndex = 17;
            this.lblEmailPelanggan.Text = "Email : ";
            this.lblEmailPelanggan.Click += new System.EventHandler(this.lblEmailPelanggan_Click);
            // 
            // lblNamaPelanggan
            // 
            this.lblNamaPelanggan.AutoSize = true;
            this.lblNamaPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaPelanggan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaPelanggan.ForeColor = System.Drawing.Color.White;
            this.lblNamaPelanggan.Location = new System.Drawing.Point(1217, 198);
            this.lblNamaPelanggan.Name = "lblNamaPelanggan";
            this.lblNamaPelanggan.Size = new System.Drawing.Size(73, 25);
            this.lblNamaPelanggan.TabIndex = 16;
            this.lblNamaPelanggan.Text = "Nama : ";
            this.lblNamaPelanggan.Click += new System.EventHandler(this.lblNamaPelanggan_Click);
            // 
            // lblCatatan
            // 
            this.lblCatatan.AutoSize = true;
            this.lblCatatan.BackColor = System.Drawing.Color.Transparent;
            this.lblCatatan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCatatan.ForeColor = System.Drawing.Color.White;
            this.lblCatatan.Location = new System.Drawing.Point(1220, 302);
            this.lblCatatan.Name = "lblCatatan";
            this.lblCatatan.Size = new System.Drawing.Size(86, 25);
            this.lblCatatan.TabIndex = 15;
            this.lblCatatan.Text = "Catatan : ";
            this.lblCatatan.Click += new System.EventHandler(this.lblCatatan_Click);
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalHarga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalHarga.ForeColor = System.Drawing.Color.White;
            this.lblTotalHarga.Location = new System.Drawing.Point(917, 392);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(116, 25);
            this.lblTotalHarga.TabIndex = 14;
            this.lblTotalHarga.Text = "Total Harga : ";
            this.lblTotalHarga.Click += new System.EventHandler(this.lblTotalHarga_Click);
            // 
            // lblDurasi
            // 
            this.lblDurasi.AutoSize = true;
            this.lblDurasi.BackColor = System.Drawing.Color.Transparent;
            this.lblDurasi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDurasi.ForeColor = System.Drawing.Color.White;
            this.lblDurasi.Location = new System.Drawing.Point(917, 358);
            this.lblDurasi.Name = "lblDurasi";
            this.lblDurasi.Size = new System.Drawing.Size(76, 25);
            this.lblDurasi.TabIndex = 13;
            this.lblDurasi.Text = "Durasi : ";
            this.lblDurasi.Click += new System.EventHandler(this.lblDurasi_Click);
            // 
            // lblHargaPerJam
            // 
            this.lblHargaPerJam.AutoSize = true;
            this.lblHargaPerJam.BackColor = System.Drawing.Color.Transparent;
            this.lblHargaPerJam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHargaPerJam.ForeColor = System.Drawing.Color.White;
            this.lblHargaPerJam.Location = new System.Drawing.Point(917, 333);
            this.lblHargaPerJam.Name = "lblHargaPerJam";
            this.lblHargaPerJam.Size = new System.Drawing.Size(139, 25);
            this.lblHargaPerJam.TabIndex = 12;
            this.lblHargaPerJam.Text = "Harga Per Jam : ";
            this.lblHargaPerJam.Click += new System.EventHandler(this.lblHargaPerJam_Click);
            // 
            // lblJamSelesai
            // 
            this.lblJamSelesai.AutoSize = true;
            this.lblJamSelesai.BackColor = System.Drawing.Color.Transparent;
            this.lblJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblJamSelesai.ForeColor = System.Drawing.Color.White;
            this.lblJamSelesai.Location = new System.Drawing.Point(917, 295);
            this.lblJamSelesai.Name = "lblJamSelesai";
            this.lblJamSelesai.Size = new System.Drawing.Size(115, 25);
            this.lblJamSelesai.TabIndex = 11;
            this.lblJamSelesai.Text = "Jam Selesai : ";
            this.lblJamSelesai.Click += new System.EventHandler(this.lblJamSelesai_Click);
            // 
            // lblJamMulai
            // 
            this.lblJamMulai.AutoSize = true;
            this.lblJamMulai.BackColor = System.Drawing.Color.Transparent;
            this.lblJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblJamMulai.ForeColor = System.Drawing.Color.White;
            this.lblJamMulai.Location = new System.Drawing.Point(917, 264);
            this.lblJamMulai.Name = "lblJamMulai";
            this.lblJamMulai.Size = new System.Drawing.Size(105, 25);
            this.lblJamMulai.TabIndex = 10;
            this.lblJamMulai.Text = "Jam Mulai : ";
            this.lblJamMulai.Click += new System.EventHandler(this.lblJamMulai_Click);
            // 
            // cbStudioFilter
            // 
            this.cbStudioFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStudioFilter.FormattingEnabled = true;
            this.cbStudioFilter.Location = new System.Drawing.Point(12, 168);
            this.cbStudioFilter.Name = "cbStudioFilter";
            this.cbStudioFilter.Size = new System.Drawing.Size(147, 33);
            this.cbStudioFilter.TabIndex = 20;
            // 
            // dtpTanggalFilter
            // 
            this.dtpTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTanggalFilter.Location = new System.Drawing.Point(187, 168);
            this.dtpTanggalFilter.Name = "dtpTanggalFilter";
            this.dtpTanggalFilter.Size = new System.Drawing.Size(159, 31);
            this.dtpTanggalFilter.TabIndex = 21;
            // 
            // txtCatatan
            // 
            this.txtCatatan.Location = new System.Drawing.Point(1341, 303);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(133, 26);
            this.txtCatatan.TabIndex = 22;
            this.txtCatatan.TextChanged += new System.EventHandler(this.txtCatatan_TextChanged);
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Location = new System.Drawing.Point(1341, 197);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(133, 26);
            this.txtNoTelp.TabIndex = 23;
            this.txtNoTelp.TextChanged += new System.EventHandler(this.txtNoTelp_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1341, 232);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(133, 26);
            this.txtEmail.TabIndex = 24;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(1341, 267);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(133, 26);
            this.txtNama.TabIndex = 25;
            this.txtNama.TextChanged += new System.EventHandler(this.txtNama_TextChanged);
            // 
            // btnCariJadwal
            // 
            this.btnCariJadwal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariJadwal.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCariJadwal.Location = new System.Drawing.Point(376, 165);
            this.btnCariJadwal.Name = "btnCariJadwal";
            this.btnCariJadwal.Size = new System.Drawing.Size(126, 41);
            this.btnCariJadwal.TabIndex = 26;
            this.btnCariJadwal.Text = "🔍 Cari Jadwal";
            this.btnCariJadwal.UseVisualStyleBackColor = true;
            this.btnCariJadwal.Click += new System.EventHandler(this.btnCariJadwal_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.BackColor = System.Drawing.Color.Transparent;
            this.btnBooking.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBooking.Location = new System.Drawing.Point(1222, 358);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(126, 41);
            this.btnBooking.TabIndex = 27;
            this.btnBooking.Text = "✅ Booking";
            this.btnBooking.UseVisualStyleBackColor = false;
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnBatalBooking
            // 
            this.btnBatalBooking.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBatalBooking.Location = new System.Drawing.Point(1222, 405);
            this.btnBatalBooking.Name = "btnBatalBooking";
            this.btnBatalBooking.Size = new System.Drawing.Size(126, 41);
            this.btnBatalBooking.TabIndex = 28;
            this.btnBatalBooking.Text = "❌ Batal";
            this.btnBatalBooking.UseVisualStyleBackColor = true;
            this.btnBatalBooking.Click += new System.EventHandler(this.btnBatalBooking_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRefresh.Location = new System.Drawing.Point(376, 222);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(126, 41);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(1460, 23);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 41);
            this.btnTutup.TabIndex = 31;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // dgvJadwalTersedia
            // 
            this.dgvJadwalTersedia.AllowUserToAddRows = false;
            this.dgvJadwalTersedia.AllowUserToDeleteRows = false;
            this.dgvJadwalTersedia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJadwalTersedia.BackgroundColor = System.Drawing.Color.White;
            this.dgvJadwalTersedia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJadwalTersedia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwalTersedia.Location = new System.Drawing.Point(34, 295);
            this.dgvJadwalTersedia.Name = "dgvJadwalTersedia";
            this.dgvJadwalTersedia.ReadOnly = true;
            this.dgvJadwalTersedia.RowHeadersVisible = false;
            this.dgvJadwalTersedia.RowHeadersWidth = 62;
            this.dgvJadwalTersedia.RowTemplate.Height = 28;
            this.dgvJadwalTersedia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwalTersedia.Size = new System.Drawing.Size(776, 164);
            this.dgvJadwalTersedia.TabIndex = 32;
            this.dgvJadwalTersedia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwalTersedia_CellClick);
            // 
            // dgvRiwayatBooking
            // 
            this.dgvRiwayatBooking.AllowUserToAddRows = false;
            this.dgvRiwayatBooking.AllowUserToDeleteRows = false;
            this.dgvRiwayatBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRiwayatBooking.BackgroundColor = System.Drawing.Color.White;
            this.dgvRiwayatBooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRiwayatBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayatBooking.Location = new System.Drawing.Point(34, 493);
            this.dgvRiwayatBooking.Name = "dgvRiwayatBooking";
            this.dgvRiwayatBooking.ReadOnly = true;
            this.dgvRiwayatBooking.RowHeadersVisible = false;
            this.dgvRiwayatBooking.RowHeadersWidth = 62;
            this.dgvRiwayatBooking.RowTemplate.Height = 28;
            this.dgvRiwayatBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRiwayatBooking.Size = new System.Drawing.Size(776, 201);
            this.dgvRiwayatBooking.TabIndex = 33;
            this.dgvRiwayatBooking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRiwayatBooking_CellClick);
            // 
            // cbStudio
            // 
            this.cbStudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudio.Location = new System.Drawing.Point(1089, 198);
            this.cbStudio.Name = "cbStudio";
            this.cbStudio.Size = new System.Drawing.Size(110, 28);
            this.cbStudio.TabIndex = 34;
            this.cbStudio.SelectedIndexChanged += new System.EventHandler(this.cbStudio_SelectedIndexChanged);
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggal.Location = new System.Drawing.Point(1089, 232);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(110, 26);
            this.dtpTanggal.TabIndex = 35;
            this.dtpTanggal.ValueChanged += new System.EventHandler(this.dtpTanggal_ValueChanged);
            // 
            // dtpJamSelesai
            // 
            this.dtpJamSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamSelesai.Location = new System.Drawing.Point(1089, 295);
            this.dtpJamSelesai.Name = "dtpJamSelesai";
            this.dtpJamSelesai.Size = new System.Drawing.Size(110, 26);
            this.dtpJamSelesai.TabIndex = 36;
            this.dtpJamSelesai.Value = new System.DateTime(2026, 5, 12, 15, 53, 0, 0);
            this.dtpJamSelesai.ValueChanged += new System.EventHandler(this.dtpJamSelesai_ValueChanged);
            // 
            // dtpJamMulai
            // 
            this.dtpJamMulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamMulai.Location = new System.Drawing.Point(1089, 265);
            this.dtpJamMulai.Name = "dtpJamMulai";
            this.dtpJamMulai.Size = new System.Drawing.Size(110, 26);
            this.dtpJamMulai.TabIndex = 37;
            this.dtpJamMulai.ValueChanged += new System.EventHandler(this.dtpJamMulai_ValueChanged);
            // 
            // txtDurasi
            // 
            this.txtDurasi.ForeColor = System.Drawing.Color.Black;
            this.txtDurasi.Location = new System.Drawing.Point(1087, 359);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.Size = new System.Drawing.Size(112, 26);
            this.txtDurasi.TabIndex = 38;
            this.txtDurasi.TextChanged += new System.EventHandler(this.txtDurasi_TextChanged);
            // 
            // txtHargaPerJam
            // 
            this.txtHargaPerJam.Location = new System.Drawing.Point(1087, 332);
            this.txtHargaPerJam.Name = "txtHargaPerJam";
            this.txtHargaPerJam.ReadOnly = true;
            this.txtHargaPerJam.Size = new System.Drawing.Size(112, 26);
            this.txtHargaPerJam.TabIndex = 39;
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Location = new System.Drawing.Point(1087, 393);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.ReadOnly = true;
            this.txtTotalHarga.Size = new System.Drawing.Size(112, 26);
            this.txtTotalHarga.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-11, -17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1631, 76);
            this.panel1.TabIndex = 41;
            // 
            // FormBookingStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1587, 732);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.txtHargaPerJam);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.dtpJamMulai);
            this.Controls.Add(this.dtpJamSelesai);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.cbStudio);
            this.Controls.Add(this.dgvRiwayatBooking);
            this.Controls.Add(this.dgvJadwalTersedia);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnBatalBooking);
            this.Controls.Add(this.btnBooking);
            this.Controls.Add(this.btnCariJadwal);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.dtpTanggalFilter);
            this.Controls.Add(this.cbStudioFilter);
            this.Controls.Add(this.lblRiwayatBooking);
            this.Controls.Add(this.lblNoTelpPelanggan);
            this.Controls.Add(this.lblEmailPelanggan);
            this.Controls.Add(this.lblNamaPelanggan);
            this.Controls.Add(this.lblCatatan);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.lblDurasi);
            this.Controls.Add(this.lblHargaPerJam);
            this.Controls.Add(this.lblJamSelesai);
            this.Controls.Add(this.lblJamMulai);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.lblStudio);
            this.Controls.Add(this.lblDataPelanggan);
            this.Controls.Add(this.lblDetailJadwal);
            this.Controls.Add(this.lblFormBooking);
            this.Controls.Add(this.lblDaftarJadwal);
            this.Controls.Add(this.lblTanggalFilter);
            this.Controls.Add(this.lblStudioFilter);
            this.Controls.Add(this.lblFilter);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormBookingStudio";
            this.Text = "FormBookingStudio";
            this.Load += new System.EventHandler(this.FormBookingStudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwalTersedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatBooking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblStudioFilter;
        private System.Windows.Forms.Label lblTanggalFilter;
        private System.Windows.Forms.Label lblDaftarJadwal;
        private System.Windows.Forms.Label lblFormBooking;
        private System.Windows.Forms.Label lblDetailJadwal;
        private System.Windows.Forms.Label lblDataPelanggan;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblRiwayatBooking;
        private System.Windows.Forms.Label lblNoTelpPelanggan;
        private System.Windows.Forms.Label lblEmailPelanggan;
        private System.Windows.Forms.Label lblNamaPelanggan;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblDurasi;
        private System.Windows.Forms.Label lblHargaPerJam;
        private System.Windows.Forms.Label lblJamSelesai;
        private System.Windows.Forms.Label lblJamMulai;
        private System.Windows.Forms.ComboBox cbStudioFilter;
        private System.Windows.Forms.DateTimePicker dtpTanggalFilter;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Button btnCariJadwal;
        private System.Windows.Forms.Button btnBooking;
        private System.Windows.Forms.Button btnBatalBooking;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.DataGridView dgvJadwalTersedia;
        private System.Windows.Forms.DataGridView dgvRiwayatBooking;
        private System.Windows.Forms.ComboBox cbStudio;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.DateTimePicker dtpJamSelesai;
        private System.Windows.Forms.DateTimePicker dtpJamMulai;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.TextBox txtHargaPerJam;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Panel panel1;
    }
}