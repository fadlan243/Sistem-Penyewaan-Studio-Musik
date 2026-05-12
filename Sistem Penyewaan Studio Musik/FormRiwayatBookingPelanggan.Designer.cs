namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormRiwayatBookingPelanggan
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
            this.lblIdBooking = new System.Windows.Forms.Label();
            this.lblInfoPembayaran = new System.Windows.Forms.Label();
            this.lblInfoBooking = new System.Windows.Forms.Label();
            this.lblDaftarBooking = new System.Windows.Forms.Label();
            this.lblDetailBooking = new System.Windows.Forms.Label();
            this.lblTanggalSewa = new System.Windows.Forms.Label();
            this.lblJamMulai = new System.Windows.Forms.Label();
            this.lblJamSelesai = new System.Windows.Forms.Label();
            this.lblDurasi = new System.Windows.Forms.Label();
            this.lblTotalHarga = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblStatusBooking = new System.Windows.Forms.Label();
            this.lblStatusBayar = new System.Windows.Forms.Label();
            this.lblJumlahBayar = new System.Windows.Forms.Label();
            this.lblMetodeBayar = new System.Windows.Forms.Label();
            this.lblTglBayar = new System.Windows.Forms.Label();
            this.lblCatatan = new System.Windows.Forms.Label();
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblCatatanAdmin = new System.Windows.Forms.Label();
            this.lblInformasiPembayaran = new System.Windows.Forms.Label();
            this.txtIDBooking = new System.Windows.Forms.TextBox();
            this.txtStudio = new System.Windows.Forms.TextBox();
            this.txtTglSewa = new System.Windows.Forms.TextBox();
            this.txtJamMulai = new System.Windows.Forms.TextBox();
            this.txtSelesai = new System.Windows.Forms.TextBox();
            this.txtDurasi = new System.Windows.Forms.TextBox();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtStatusBooking = new System.Windows.Forms.TextBox();
            this.txtCatatanAdmin = new System.Windows.Forms.TextBox();
            this.txtTglBayar = new System.Windows.Forms.TextBox();
            this.txtMetodeBayar = new System.Windows.Forms.TextBox();
            this.txtJumlahBayar = new System.Windows.Forms.TextBox();
            this.txtStatusBayar = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.dgvRiwayatBooking = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBayar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatBooking)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.BackColor = System.Drawing.Color.Transparent;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(18, 19);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(617, 48);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📜 RIWAYAT BOOKING - BLACK ROCK STUDIO";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblIdBooking
            // 
            this.lblIdBooking.AutoSize = true;
            this.lblIdBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdBooking.Location = new System.Drawing.Point(53, 142);
            this.lblIdBooking.Name = "lblIdBooking";
            this.lblIdBooking.Size = new System.Drawing.Size(110, 25);
            this.lblIdBooking.TabIndex = 1;
            this.lblIdBooking.Text = "ID Booking :";
            this.lblIdBooking.Click += new System.EventHandler(this.lblIdBooking_Click);
            // 
            // lblInfoPembayaran
            // 
            this.lblInfoPembayaran.AutoSize = true;
            this.lblInfoPembayaran.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPembayaran.Location = new System.Drawing.Point(53, 179);
            this.lblInfoPembayaran.Name = "lblInfoPembayaran";
            this.lblInfoPembayaran.Size = new System.Drawing.Size(0, 25);
            this.lblInfoPembayaran.TabIndex = 2;
            // 
            // lblInfoBooking
            // 
            this.lblInfoBooking.AutoSize = true;
            this.lblInfoBooking.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfoBooking.Location = new System.Drawing.Point(92, 108);
            this.lblInfoBooking.Name = "lblInfoBooking";
            this.lblInfoBooking.Size = new System.Drawing.Size(208, 28);
            this.lblInfoBooking.TabIndex = 3;
            this.lblInfoBooking.Text = "INFORMASI BOOKING";
            this.lblInfoBooking.Click += new System.EventHandler(this.lblInfoBooking_Click);
            // 
            // lblDaftarBooking
            // 
            this.lblDaftarBooking.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDaftarBooking.Location = new System.Drawing.Point(34, 503);
            this.lblDaftarBooking.Name = "lblDaftarBooking";
            this.lblDaftarBooking.Size = new System.Drawing.Size(219, 30);
            this.lblDaftarBooking.TabIndex = 4;
            this.lblDaftarBooking.Text = "\t📋 DAFTAR BOOKING SAYA";
            this.lblDaftarBooking.Click += new System.EventHandler(this.lblDaftarBooking_Click);
            // 
            // lblDetailBooking
            // 
            this.lblDetailBooking.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetailBooking.Location = new System.Drawing.Point(322, 78);
            this.lblDetailBooking.Name = "lblDetailBooking";
            this.lblDetailBooking.Size = new System.Drawing.Size(209, 30);
            this.lblDetailBooking.TabIndex = 5;
            this.lblDetailBooking.Text = "📝 DETAIL BOOKING";
            this.lblDetailBooking.Click += new System.EventHandler(this.lblDetailBooking_Click);
            // 
            // lblTanggalSewa
            // 
            this.lblTanggalSewa.AutoSize = true;
            this.lblTanggalSewa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalSewa.Location = new System.Drawing.Point(52, 214);
            this.lblTanggalSewa.Name = "lblTanggalSewa";
            this.lblTanggalSewa.Size = new System.Drawing.Size(133, 25);
            this.lblTanggalSewa.TabIndex = 11;
            this.lblTanggalSewa.Text = "Tanggal Sewa : ";
            this.lblTanggalSewa.Click += new System.EventHandler(this.lblTanggalSewa_Click);
            // 
            // lblJamMulai
            // 
            this.lblJamMulai.AutoSize = true;
            this.lblJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJamMulai.Location = new System.Drawing.Point(53, 252);
            this.lblJamMulai.Name = "lblJamMulai";
            this.lblJamMulai.Size = new System.Drawing.Size(105, 25);
            this.lblJamMulai.TabIndex = 10;
            this.lblJamMulai.Text = "Jam Mulai : ";
            this.lblJamMulai.Click += new System.EventHandler(this.lblJamMulai_Click);
            // 
            // lblJamSelesai
            // 
            this.lblJamSelesai.AutoSize = true;
            this.lblJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJamSelesai.Location = new System.Drawing.Point(53, 290);
            this.lblJamSelesai.Name = "lblJamSelesai";
            this.lblJamSelesai.Size = new System.Drawing.Size(115, 25);
            this.lblJamSelesai.TabIndex = 9;
            this.lblJamSelesai.Text = "Jam Selesai : ";
            this.lblJamSelesai.Click += new System.EventHandler(this.lblJamSelesai_Click);
            // 
            // lblDurasi
            // 
            this.lblDurasi.AutoSize = true;
            this.lblDurasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurasi.Location = new System.Drawing.Point(53, 327);
            this.lblDurasi.Name = "lblDurasi";
            this.lblDurasi.Size = new System.Drawing.Size(76, 25);
            this.lblDurasi.TabIndex = 8;
            this.lblDurasi.Text = "Durasi : ";
            this.lblDurasi.Click += new System.EventHandler(this.lblDurasi_Click);
            // 
            // lblTotalHarga
            // 
            this.lblTotalHarga.AutoSize = true;
            this.lblTotalHarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHarga.Location = new System.Drawing.Point(50, 361);
            this.lblTotalHarga.Name = "lblTotalHarga";
            this.lblTotalHarga.Size = new System.Drawing.Size(116, 25);
            this.lblTotalHarga.TabIndex = 7;
            this.lblTotalHarga.Text = "Total Harga : ";
            this.lblTotalHarga.Click += new System.EventHandler(this.lblTotalHarga_Click);
            // 
            // lblStudio
            // 
            this.lblStudio.AutoSize = true;
            this.lblStudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudio.Location = new System.Drawing.Point(53, 176);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(77, 25);
            this.lblStudio.TabIndex = 6;
            this.lblStudio.Text = "Studio : ";
            this.lblStudio.Click += new System.EventHandler(this.lblStudio_Click);
            // 
            // lblStatusBooking
            // 
            this.lblStatusBooking.AutoSize = true;
            this.lblStatusBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBooking.Location = new System.Drawing.Point(53, 443);
            this.lblStatusBooking.Name = "lblStatusBooking";
            this.lblStatusBooking.Size = new System.Drawing.Size(145, 25);
            this.lblStatusBooking.TabIndex = 17;
            this.lblStatusBooking.Text = "Status Booking : ";
            this.lblStatusBooking.Click += new System.EventHandler(this.lblStatusBooking_Click);
            // 
            // lblStatusBayar
            // 
            this.lblStatusBayar.AutoSize = true;
            this.lblStatusBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBayar.Location = new System.Drawing.Point(493, 143);
            this.lblStatusBayar.Name = "lblStatusBayar";
            this.lblStatusBayar.Size = new System.Drawing.Size(122, 25);
            this.lblStatusBayar.TabIndex = 16;
            this.lblStatusBayar.Text = "Status Bayar : ";
            this.lblStatusBayar.Click += new System.EventHandler(this.lblStatusBayar_Click);
            // 
            // lblJumlahBayar
            // 
            this.lblJumlahBayar.AutoSize = true;
            this.lblJumlahBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahBayar.Location = new System.Drawing.Point(493, 179);
            this.lblJumlahBayar.Name = "lblJumlahBayar";
            this.lblJumlahBayar.Size = new System.Drawing.Size(129, 25);
            this.lblJumlahBayar.TabIndex = 15;
            this.lblJumlahBayar.Text = "Jumlah Bayar : ";
            this.lblJumlahBayar.Click += new System.EventHandler(this.lblJumlahBayar_Click);
            // 
            // lblMetodeBayar
            // 
            this.lblMetodeBayar.AutoSize = true;
            this.lblMetodeBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodeBayar.Location = new System.Drawing.Point(493, 212);
            this.lblMetodeBayar.Name = "lblMetodeBayar";
            this.lblMetodeBayar.Size = new System.Drawing.Size(136, 25);
            this.lblMetodeBayar.TabIndex = 14;
            this.lblMetodeBayar.Text = "Metode Bayar : ";
            this.lblMetodeBayar.Click += new System.EventHandler(this.lblMetodeBayar_Click);
            // 
            // lblTglBayar
            // 
            this.lblTglBayar.AutoSize = true;
            this.lblTglBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTglBayar.Location = new System.Drawing.Point(493, 250);
            this.lblTglBayar.Name = "lblTglBayar";
            this.lblTglBayar.Size = new System.Drawing.Size(130, 25);
            this.lblTglBayar.TabIndex = 13;
            this.lblTglBayar.Text = "Tanggal Bayar :";
            this.lblTglBayar.Click += new System.EventHandler(this.lblTglBayar_Click);
            // 
            // lblCatatan
            // 
            this.lblCatatan.AutoSize = true;
            this.lblCatatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatatan.Location = new System.Drawing.Point(53, 401);
            this.lblCatatan.Name = "lblCatatan";
            this.lblCatatan.Size = new System.Drawing.Size(86, 25);
            this.lblCatatan.TabIndex = 12;
            this.lblCatatan.Text = "Catatan : ";
            this.lblCatatan.Click += new System.EventHandler(this.lblCatatan_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatistik.Location = new System.Drawing.Point(349, 506);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(506, 27);
            this.lblStatistik.TabIndex = 23;
            this.lblStatistik.Text = "📊 STATISTIK: ...";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblCatatanAdmin
            // 
            this.lblCatatanAdmin.AutoSize = true;
            this.lblCatatanAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatatanAdmin.Location = new System.Drawing.Point(493, 285);
            this.lblCatatanAdmin.Name = "lblCatatanAdmin";
            this.lblCatatanAdmin.Size = new System.Drawing.Size(139, 25);
            this.lblCatatanAdmin.TabIndex = 18;
            this.lblCatatanAdmin.Text = "Catatan Admin :";
            this.lblCatatanAdmin.Click += new System.EventHandler(this.lblCatatanAdmin_Click);
            // 
            // lblInformasiPembayaran
            // 
            this.lblInformasiPembayaran.AutoSize = true;
            this.lblInformasiPembayaran.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInformasiPembayaran.Location = new System.Drawing.Point(537, 108);
            this.lblInformasiPembayaran.Name = "lblInformasiPembayaran";
            this.lblInformasiPembayaran.Size = new System.Drawing.Size(245, 28);
            this.lblInformasiPembayaran.TabIndex = 24;
            this.lblInformasiPembayaran.Text = "INFORMASI PEMBAYARAN";
            this.lblInformasiPembayaran.Click += new System.EventHandler(this.lblInformasiPembayaran_Click);
            // 
            // txtIDBooking
            // 
            this.txtIDBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDBooking.Location = new System.Drawing.Point(189, 139);
            this.txtIDBooking.Name = "txtIDBooking";
            this.txtIDBooking.ReadOnly = true;
            this.txtIDBooking.Size = new System.Drawing.Size(134, 31);
            this.txtIDBooking.TabIndex = 25;
            // 
            // txtStudio
            // 
            this.txtStudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudio.Location = new System.Drawing.Point(189, 175);
            this.txtStudio.Name = "txtStudio";
            this.txtStudio.ReadOnly = true;
            this.txtStudio.Size = new System.Drawing.Size(134, 31);
            this.txtStudio.TabIndex = 26;
            // 
            // txtTglSewa
            // 
            this.txtTglSewa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTglSewa.Location = new System.Drawing.Point(189, 212);
            this.txtTglSewa.Name = "txtTglSewa";
            this.txtTglSewa.ReadOnly = true;
            this.txtTglSewa.Size = new System.Drawing.Size(134, 31);
            this.txtTglSewa.TabIndex = 27;
            // 
            // txtJamMulai
            // 
            this.txtJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJamMulai.Location = new System.Drawing.Point(189, 251);
            this.txtJamMulai.Name = "txtJamMulai";
            this.txtJamMulai.ReadOnly = true;
            this.txtJamMulai.Size = new System.Drawing.Size(134, 31);
            this.txtJamMulai.TabIndex = 28;
            // 
            // txtSelesai
            // 
            this.txtSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelesai.Location = new System.Drawing.Point(189, 290);
            this.txtSelesai.Name = "txtSelesai";
            this.txtSelesai.ReadOnly = true;
            this.txtSelesai.Size = new System.Drawing.Size(134, 31);
            this.txtSelesai.TabIndex = 29;
            // 
            // txtDurasi
            // 
            this.txtDurasi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDurasi.Location = new System.Drawing.Point(189, 325);
            this.txtDurasi.Name = "txtDurasi";
            this.txtDurasi.ReadOnly = true;
            this.txtDurasi.Size = new System.Drawing.Size(134, 31);
            this.txtDurasi.TabIndex = 30;
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHarga.Location = new System.Drawing.Point(189, 362);
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.ReadOnly = true;
            this.txtTotalHarga.Size = new System.Drawing.Size(134, 31);
            this.txtTotalHarga.TabIndex = 31;
            // 
            // txtCatatan
            // 
            this.txtCatatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatan.Location = new System.Drawing.Point(189, 398);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.ReadOnly = true;
            this.txtCatatan.Size = new System.Drawing.Size(134, 31);
            this.txtCatatan.TabIndex = 32;
            // 
            // txtStatusBooking
            // 
            this.txtStatusBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusBooking.Location = new System.Drawing.Point(189, 440);
            this.txtStatusBooking.Name = "txtStatusBooking";
            this.txtStatusBooking.ReadOnly = true;
            this.txtStatusBooking.Size = new System.Drawing.Size(134, 31);
            this.txtStatusBooking.TabIndex = 33;
            // 
            // txtCatatanAdmin
            // 
            this.txtCatatanAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatatanAdmin.Location = new System.Drawing.Point(641, 287);
            this.txtCatatanAdmin.Name = "txtCatatanAdmin";
            this.txtCatatanAdmin.ReadOnly = true;
            this.txtCatatanAdmin.Size = new System.Drawing.Size(134, 31);
            this.txtCatatanAdmin.TabIndex = 38;
            // 
            // txtTglBayar
            // 
            this.txtTglBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTglBayar.Location = new System.Drawing.Point(641, 250);
            this.txtTglBayar.Name = "txtTglBayar";
            this.txtTglBayar.ReadOnly = true;
            this.txtTglBayar.Size = new System.Drawing.Size(134, 31);
            this.txtTglBayar.TabIndex = 37;
            // 
            // txtMetodeBayar
            // 
            this.txtMetodeBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetodeBayar.Location = new System.Drawing.Point(641, 214);
            this.txtMetodeBayar.Name = "txtMetodeBayar";
            this.txtMetodeBayar.ReadOnly = true;
            this.txtMetodeBayar.Size = new System.Drawing.Size(134, 31);
            this.txtMetodeBayar.TabIndex = 36;
            // 
            // txtJumlahBayar
            // 
            this.txtJumlahBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlahBayar.Location = new System.Drawing.Point(641, 177);
            this.txtJumlahBayar.Name = "txtJumlahBayar";
            this.txtJumlahBayar.ReadOnly = true;
            this.txtJumlahBayar.Size = new System.Drawing.Size(134, 31);
            this.txtJumlahBayar.TabIndex = 35;
            // 
            // txtStatusBayar
            // 
            this.txtStatusBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusBayar.Location = new System.Drawing.Point(641, 142);
            this.txtStatusBayar.Name = "txtStatusBayar";
            this.txtStatusBayar.ReadOnly = true;
            this.txtStatusBayar.Size = new System.Drawing.Size(134, 31);
            this.txtStatusBayar.TabIndex = 34;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(498, 336);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(159, 50);
            this.btnRefresh.TabIndex = 39;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Red;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.Color.Snow;
            this.btnTutup.Location = new System.Drawing.Point(738, 17);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(149, 38);
            this.btnTutup.TabIndex = 40;
            this.btnTutup.Text = "\t✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // dgvRiwayatBooking
            // 
            this.dgvRiwayatBooking.AllowUserToAddRows = false;
            this.dgvRiwayatBooking.AllowUserToDeleteRows = false;
            this.dgvRiwayatBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRiwayatBooking.BackgroundColor = System.Drawing.Color.White;
            this.dgvRiwayatBooking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRiwayatBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiwayatBooking.Location = new System.Drawing.Point(12, 536);
            this.dgvRiwayatBooking.Name = "dgvRiwayatBooking";
            this.dgvRiwayatBooking.ReadOnly = true;
            this.dgvRiwayatBooking.RowHeadersVisible = false;
            this.dgvRiwayatBooking.RowHeadersWidth = 62;
            this.dgvRiwayatBooking.RowTemplate.Height = 28;
            this.dgvRiwayatBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRiwayatBooking.Size = new System.Drawing.Size(862, 221);
            this.dgvRiwayatBooking.TabIndex = 41;
            this.dgvRiwayatBooking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRiwayatBooking_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-13, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 73);
            this.panel1.TabIndex = 42;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnBayar
            // 
            this.btnBayar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBayar.Location = new System.Drawing.Point(498, 392);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(159, 50);
            this.btnBayar.TabIndex = 43;
            this.btnBayar.Text = "💰 Bayar";
            this.btnBayar.UseVisualStyleBackColor = true;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // FormRiwayatBookingPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(886, 760);
            this.Controls.Add(this.btnBayar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvRiwayatBooking);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtCatatanAdmin);
            this.Controls.Add(this.txtTglBayar);
            this.Controls.Add(this.txtMetodeBayar);
            this.Controls.Add(this.txtJumlahBayar);
            this.Controls.Add(this.txtStatusBayar);
            this.Controls.Add(this.txtStatusBooking);
            this.Controls.Add(this.txtCatatan);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.txtDurasi);
            this.Controls.Add(this.txtSelesai);
            this.Controls.Add(this.txtJamMulai);
            this.Controls.Add(this.txtTglSewa);
            this.Controls.Add(this.txtStudio);
            this.Controls.Add(this.txtIDBooking);
            this.Controls.Add(this.lblInformasiPembayaran);
            this.Controls.Add(this.lblStatistik);
            this.Controls.Add(this.lblCatatanAdmin);
            this.Controls.Add(this.lblStatusBooking);
            this.Controls.Add(this.lblStatusBayar);
            this.Controls.Add(this.lblJumlahBayar);
            this.Controls.Add(this.lblMetodeBayar);
            this.Controls.Add(this.lblTglBayar);
            this.Controls.Add(this.lblCatatan);
            this.Controls.Add(this.lblTanggalSewa);
            this.Controls.Add(this.lblJamMulai);
            this.Controls.Add(this.lblJamSelesai);
            this.Controls.Add(this.lblDurasi);
            this.Controls.Add(this.lblTotalHarga);
            this.Controls.Add(this.lblStudio);
            this.Controls.Add(this.lblDetailBooking);
            this.Controls.Add(this.lblDaftarBooking);
            this.Controls.Add(this.lblInfoBooking);
            this.Controls.Add(this.lblInfoPembayaran);
            this.Controls.Add(this.lblIdBooking);
            this.Name = "FormRiwayatBookingPelanggan";
            this.Text = "FormRiwayatBookingPelanggan";
            this.Load += new System.EventHandler(this.FormRiwayatBookingPelanggan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiwayatBooking)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblIdBooking;
        private System.Windows.Forms.Label lblInfoPembayaran;
        private System.Windows.Forms.Label lblInfoBooking;
        private System.Windows.Forms.Label lblDaftarBooking;
        private System.Windows.Forms.Label lblDetailBooking;
        private System.Windows.Forms.Label lblTanggalSewa;
        private System.Windows.Forms.Label lblJamMulai;
        private System.Windows.Forms.Label lblJamSelesai;
        private System.Windows.Forms.Label lblDurasi;
        private System.Windows.Forms.Label lblTotalHarga;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblStatusBooking;
        private System.Windows.Forms.Label lblStatusBayar;
        private System.Windows.Forms.Label lblJumlahBayar;
        private System.Windows.Forms.Label lblMetodeBayar;
        private System.Windows.Forms.Label lblTglBayar;
        private System.Windows.Forms.Label lblCatatan;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblCatatanAdmin;
        private System.Windows.Forms.Label lblInformasiPembayaran;
        private System.Windows.Forms.TextBox txtIDBooking;
        private System.Windows.Forms.TextBox txtStudio;
        private System.Windows.Forms.TextBox txtTglSewa;
        private System.Windows.Forms.TextBox txtJamMulai;
        private System.Windows.Forms.TextBox txtSelesai;
        private System.Windows.Forms.TextBox txtDurasi;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtStatusBooking;
        private System.Windows.Forms.TextBox txtCatatanAdmin;
        private System.Windows.Forms.TextBox txtTglBayar;
        private System.Windows.Forms.TextBox txtMetodeBayar;
        private System.Windows.Forms.TextBox txtJumlahBayar;
        private System.Windows.Forms.TextBox txtStatusBayar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.DataGridView dgvRiwayatBooking;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBayar;
    }
}