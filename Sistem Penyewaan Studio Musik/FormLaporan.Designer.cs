namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormLaporan
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
            this.lblPeriode = new System.Windows.Forms.Label();
            this.lblTglMulai = new System.Windows.Forms.Label();
            this.lblTglSelesai = new System.Windows.Forms.Label();
            this.lblRingkasan = new System.Windows.Forms.Label();
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblPendapatan = new System.Windows.Forms.Label();
            this.lblTotalBooking = new System.Windows.Forms.Label();
            this.lblValueTotalDisetujui = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.lblNamaFile = new System.Windows.Forms.Label();
            this.lblDetailPeriode = new System.Windows.Forms.Label();
            this.lblRataRata = new System.Windows.Forms.Label();
            this.lblTotalPendapatan = new System.Windows.Forms.Label();
            this.lblPelangganTeraktif = new System.Windows.Forms.Label();
            this.lblStudioTerpopuler = new System.Windows.Forms.Label();
            this.lblValueTotalDibatalkan = new System.Windows.Forms.Label();
            this.lblTotalSelesai = new System.Windows.Forms.Label();
            this.dtpTglMulai = new System.Windows.Forms.DateTimePicker();
            this.dtpTglSelesai = new System.Windows.Forms.DateTimePicker();
            this.txtNamaFile = new System.Windows.Forms.TextBox();
            this.btnHitung = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSimpanLaporan = new System.Windows.Forms.Button();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalBooking = new System.Windows.Forms.TextBox();
            this.txtDisetujui = new System.Windows.Forms.TextBox();
            this.txtSelesai = new System.Windows.Forms.TextBox();
            this.txtTerpopuler = new System.Windows.Forms.TextBox();
            this.txtTeraktif = new System.Windows.Forms.TextBox();
            this.txtDitolak = new System.Windows.Forms.TextBox();
            this.txtPendapatan = new System.Windows.Forms.TextBox();
            this.txtRataRata = new System.Windows.Forms.TextBox();
            this.txtPeriode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.BackColor = System.Drawing.Color.Transparent;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(23, 27);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(473, 32);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📊 BUAT LAPORAN - BLACK ROCK STUDIO";
            // 
            // lblPeriode
            // 
            this.lblPeriode.BackColor = System.Drawing.Color.Transparent;
            this.lblPeriode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriode.ForeColor = System.Drawing.Color.White;
            this.lblPeriode.Location = new System.Drawing.Point(21, 77);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(224, 44);
            this.lblPeriode.TabIndex = 1;
            this.lblPeriode.Text = "PERIODE LAPORAN";
            this.lblPeriode.Click += new System.EventHandler(this.lblPeriode_Click);
            // 
            // lblTglMulai
            // 
            this.lblTglMulai.AutoSize = true;
            this.lblTglMulai.BackColor = System.Drawing.Color.Transparent;
            this.lblTglMulai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTglMulai.ForeColor = System.Drawing.Color.White;
            this.lblTglMulai.Location = new System.Drawing.Point(21, 134);
            this.lblTglMulai.Name = "lblTglMulai";
            this.lblTglMulai.Size = new System.Drawing.Size(130, 25);
            this.lblTglMulai.TabIndex = 2;
            this.lblTglMulai.Text = "Tanggal Mulai :";
            this.lblTglMulai.Click += new System.EventHandler(this.lblTglMulai_Click);
            // 
            // lblTglSelesai
            // 
            this.lblTglSelesai.AutoSize = true;
            this.lblTglSelesai.BackColor = System.Drawing.Color.Transparent;
            this.lblTglSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTglSelesai.ForeColor = System.Drawing.Color.White;
            this.lblTglSelesai.Location = new System.Drawing.Point(21, 186);
            this.lblTglSelesai.Name = "lblTglSelesai";
            this.lblTglSelesai.Size = new System.Drawing.Size(140, 25);
            this.lblTglSelesai.TabIndex = 3;
            this.lblTglSelesai.Text = "Tanggal Selesai :";
            this.lblTglSelesai.Click += new System.EventHandler(this.lblTglSelesai_Click);
            // 
            // lblRingkasan
            // 
            this.lblRingkasan.BackColor = System.Drawing.Color.Transparent;
            this.lblRingkasan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRingkasan.ForeColor = System.Drawing.Color.White;
            this.lblRingkasan.Location = new System.Drawing.Point(561, 77);
            this.lblRingkasan.Name = "lblRingkasan";
            this.lblRingkasan.Size = new System.Drawing.Size(349, 35);
            this.lblRingkasan.TabIndex = 4;
            this.lblRingkasan.Text = "📋 RINGKASAN LAPORAN";
            this.lblRingkasan.Click += new System.EventHandler(this.lblRingkasan_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.BackColor = System.Drawing.Color.Transparent;
            this.lblStatistik.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatistik.ForeColor = System.Drawing.Color.White;
            this.lblStatistik.Location = new System.Drawing.Point(507, 120);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(128, 39);
            this.lblStatistik.TabIndex = 5;
            this.lblStatistik.Text = "\tSTATISTIK";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblPendapatan
            // 
            this.lblPendapatan.BackColor = System.Drawing.Color.Transparent;
            this.lblPendapatan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblPendapatan.Location = new System.Drawing.Point(840, 120);
            this.lblPendapatan.Name = "lblPendapatan";
            this.lblPendapatan.Size = new System.Drawing.Size(147, 39);
            this.lblPendapatan.TabIndex = 6;
            this.lblPendapatan.Text = "PENDAPATAN";
            this.lblPendapatan.Click += new System.EventHandler(this.lblPendapatan_Click);
            // 
            // lblTotalBooking
            // 
            this.lblTotalBooking.AutoSize = true;
            this.lblTotalBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooking.ForeColor = System.Drawing.Color.White;
            this.lblTotalBooking.Location = new System.Drawing.Point(404, 161);
            this.lblTotalBooking.Name = "lblTotalBooking";
            this.lblTotalBooking.Size = new System.Drawing.Size(129, 25);
            this.lblTotalBooking.TabIndex = 7;
            this.lblTotalBooking.Text = "\tTotal Booking :";
            this.lblTotalBooking.Click += new System.EventHandler(this.lblTotalBooking_Click);
            // 
            // lblValueTotalDisetujui
            // 
            this.lblValueTotalDisetujui.AutoSize = true;
            this.lblValueTotalDisetujui.BackColor = System.Drawing.Color.Transparent;
            this.lblValueTotalDisetujui.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTotalDisetujui.ForeColor = System.Drawing.Color.White;
            this.lblValueTotalDisetujui.Location = new System.Drawing.Point(404, 192);
            this.lblValueTotalDisetujui.Name = "lblValueTotalDisetujui";
            this.lblValueTotalDisetujui.Size = new System.Drawing.Size(160, 25);
            this.lblValueTotalDisetujui.TabIndex = 8;
            this.lblValueTotalDisetujui.Text = "Booking Disetujui :";
            this.lblValueTotalDisetujui.Click += new System.EventHandler(this.lblTotalDiSetujui_Click);
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.BackColor = System.Drawing.Color.Transparent;
            this.lblPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.ForeColor = System.Drawing.Color.White;
            this.lblPreview.Location = new System.Drawing.Point(21, 437);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(163, 25);
            this.lblPreview.TabIndex = 17;
            this.lblPreview.Text = "\t🔍 PREVIEW DATA";
            this.lblPreview.Click += new System.EventHandler(this.lblPreview_Click);
            // 
            // lblNamaFile
            // 
            this.lblNamaFile.AutoSize = true;
            this.lblNamaFile.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaFile.ForeColor = System.Drawing.Color.White;
            this.lblNamaFile.Location = new System.Drawing.Point(21, 400);
            this.lblNamaFile.Name = "lblNamaFile";
            this.lblNamaFile.Size = new System.Drawing.Size(193, 25);
            this.lblNamaFile.TabIndex = 16;
            this.lblNamaFile.Text = "💾 SIMPAN LAPORAN";
            this.lblNamaFile.Click += new System.EventHandler(this.lblNamaFile_Click);
            // 
            // lblDetailPeriode
            // 
            this.lblDetailPeriode.BackColor = System.Drawing.Color.Transparent;
            this.lblDetailPeriode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailPeriode.ForeColor = System.Drawing.Color.White;
            this.lblDetailPeriode.Location = new System.Drawing.Point(402, 383);
            this.lblDetailPeriode.Name = "lblDetailPeriode";
            this.lblDetailPeriode.Size = new System.Drawing.Size(162, 26);
            this.lblDetailPeriode.TabIndex = 15;
            this.lblDetailPeriode.Text = "\tDetail Periode :";
            this.lblDetailPeriode.Click += new System.EventHandler(this.lblDetailPeriode_Click);
            // 
            // lblRataRata
            // 
            this.lblRataRata.AutoSize = true;
            this.lblRataRata.BackColor = System.Drawing.Color.Transparent;
            this.lblRataRata.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRataRata.ForeColor = System.Drawing.Color.White;
            this.lblRataRata.Location = new System.Drawing.Point(715, 195);
            this.lblRataRata.Name = "lblRataRata";
            this.lblRataRata.Size = new System.Drawing.Size(195, 25);
            this.lblRataRata.TabIndex = 14;
            this.lblRataRata.Text = "\tRata-rata per Booking :";
            this.lblRataRata.Click += new System.EventHandler(this.lblRataRata_Click);
            // 
            // lblTotalPendapatan
            // 
            this.lblTotalPendapatan.AutoSize = true;
            this.lblTotalPendapatan.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPendapatan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblTotalPendapatan.Location = new System.Drawing.Point(715, 157);
            this.lblTotalPendapatan.Name = "lblTotalPendapatan";
            this.lblTotalPendapatan.Size = new System.Drawing.Size(156, 25);
            this.lblTotalPendapatan.TabIndex = 13;
            this.lblTotalPendapatan.Text = "\tTotal Pendapatan :";
            this.lblTotalPendapatan.Click += new System.EventHandler(this.lblTotalPendapatan_Click);
            // 
            // lblPelangganTeraktif
            // 
            this.lblPelangganTeraktif.AutoSize = true;
            this.lblPelangganTeraktif.BackColor = System.Drawing.Color.Transparent;
            this.lblPelangganTeraktif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelangganTeraktif.ForeColor = System.Drawing.Color.White;
            this.lblPelangganTeraktif.Location = new System.Drawing.Point(404, 319);
            this.lblPelangganTeraktif.Name = "lblPelangganTeraktif";
            this.lblPelangganTeraktif.Size = new System.Drawing.Size(164, 25);
            this.lblPelangganTeraktif.TabIndex = 12;
            this.lblPelangganTeraktif.Text = "Pelanggan Teraktif :";
            this.lblPelangganTeraktif.Click += new System.EventHandler(this.lblPelangganTeraktif_Click);
            // 
            // lblStudioTerpopuler
            // 
            this.lblStudioTerpopuler.AutoSize = true;
            this.lblStudioTerpopuler.BackColor = System.Drawing.Color.Transparent;
            this.lblStudioTerpopuler.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudioTerpopuler.ForeColor = System.Drawing.Color.White;
            this.lblStudioTerpopuler.Location = new System.Drawing.Point(404, 285);
            this.lblStudioTerpopuler.Name = "lblStudioTerpopuler";
            this.lblStudioTerpopuler.Size = new System.Drawing.Size(161, 25);
            this.lblStudioTerpopuler.TabIndex = 11;
            this.lblStudioTerpopuler.Text = "Studio Terpopuler :";
            this.lblStudioTerpopuler.Click += new System.EventHandler(this.lblStudioTerpopuler_Click);
            // 
            // lblValueTotalDibatalkan
            // 
            this.lblValueTotalDibatalkan.AutoSize = true;
            this.lblValueTotalDibatalkan.BackColor = System.Drawing.Color.Transparent;
            this.lblValueTotalDibatalkan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueTotalDibatalkan.ForeColor = System.Drawing.Color.White;
            this.lblValueTotalDibatalkan.Location = new System.Drawing.Point(404, 256);
            this.lblValueTotalDibatalkan.Name = "lblValueTotalDibatalkan";
            this.lblValueTotalDibatalkan.Size = new System.Drawing.Size(148, 25);
            this.lblValueTotalDibatalkan.TabIndex = 10;
            this.lblValueTotalDibatalkan.Text = "Booking Ditolak :";
            this.lblValueTotalDibatalkan.Click += new System.EventHandler(this.lblTotalDibatalkan_Click);
            // 
            // lblTotalSelesai
            // 
            this.lblTotalSelesai.AutoSize = true;
            this.lblTotalSelesai.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSelesai.ForeColor = System.Drawing.Color.White;
            this.lblTotalSelesai.Location = new System.Drawing.Point(404, 224);
            this.lblTotalSelesai.Name = "lblTotalSelesai";
            this.lblTotalSelesai.Size = new System.Drawing.Size(145, 25);
            this.lblTotalSelesai.TabIndex = 9;
            this.lblTotalSelesai.Text = "Booking Selesai :";
            this.lblTotalSelesai.Click += new System.EventHandler(this.lblTotalSelesai_Click);
            // 
            // dtpTglMulai
            // 
            this.dtpTglMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTglMulai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTglMulai.Location = new System.Drawing.Point(25, 157);
            this.dtpTglMulai.Name = "dtpTglMulai";
            this.dtpTglMulai.Size = new System.Drawing.Size(174, 31);
            this.dtpTglMulai.TabIndex = 18;
            this.dtpTglMulai.ValueChanged += new System.EventHandler(this.dtpTglMulai_ValueChanged);
            // 
            // dtpTglSelesai
            // 
            this.dtpTglSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTglSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTglSelesai.Location = new System.Drawing.Point(25, 210);
            this.dtpTglSelesai.Name = "dtpTglSelesai";
            this.dtpTglSelesai.Size = new System.Drawing.Size(174, 31);
            this.dtpTglSelesai.TabIndex = 19;
            this.dtpTglSelesai.ValueChanged += new System.EventHandler(this.dtpTglSelesai_ValueChanged);
            // 
            // txtNamaFile
            // 
            this.txtNamaFile.Location = new System.Drawing.Point(407, 442);
            this.txtNamaFile.Name = "txtNamaFile";
            this.txtNamaFile.Size = new System.Drawing.Size(161, 26);
            this.txtNamaFile.TabIndex = 20;
            this.txtNamaFile.Text = "laporan_[tanggal].xlsx";
            this.txtNamaFile.TextChanged += new System.EventHandler(this.txtNamaFile_TextChanged);
            // 
            // btnHitung
            // 
            this.btnHitung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHitung.Location = new System.Drawing.Point(25, 242);
            this.btnHitung.Name = "btnHitung";
            this.btnHitung.Size = new System.Drawing.Size(126, 33);
            this.btnHitung.TabIndex = 21;
            this.btnHitung.Text = "🔍 Hitung & Preview";
            this.btnHitung.UseVisualStyleBackColor = true;
            this.btnHitung.Click += new System.EventHandler(this.btnHitung_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Red;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(987, 25);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(126, 44);
            this.btnTutup.TabIndex = 26;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(211, 433);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(126, 33);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "\t🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSimpanLaporan
            // 
            this.btnSimpanLaporan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpanLaporan.Location = new System.Drawing.Point(211, 394);
            this.btnSimpanLaporan.Name = "btnSimpanLaporan";
            this.btnSimpanLaporan.Size = new System.Drawing.Size(126, 33);
            this.btnSimpanLaporan.TabIndex = 24;
            this.btnSimpanLaporan.Text = "💾 Simpan Laporan ke Database\t";
            this.btnSimpanLaporan.UseVisualStyleBackColor = true;
            this.btnSimpanLaporan.Click += new System.EventHandler(this.btnSimpanLaporan_Click);
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(12, 474);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowHeadersWidth = 62;
            this.dgvPreview.RowTemplate.Height = 28;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(1022, 277);
            this.dgvPreview.TabIndex = 27;
            this.dgvPreview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreview_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Location = new System.Drawing.Point(-17, -16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 77);
            this.panel1.TabIndex = 28;
            // 
            // txtTotalBooking
            // 
            this.txtTotalBooking.Location = new System.Drawing.Point(570, 162);
            this.txtTotalBooking.Name = "txtTotalBooking";
            this.txtTotalBooking.ReadOnly = true;
            this.txtTotalBooking.Size = new System.Drawing.Size(137, 26);
            this.txtTotalBooking.TabIndex = 29;
            
            // 
            // txtDisetujui
            // 
            this.txtDisetujui.Location = new System.Drawing.Point(570, 194);
            this.txtDisetujui.Name = "txtDisetujui";
            this.txtDisetujui.ReadOnly = true;
            this.txtDisetujui.Size = new System.Drawing.Size(137, 26);
            this.txtDisetujui.TabIndex = 30;
            // 
            // txtSelesai
            // 
            this.txtSelesai.Location = new System.Drawing.Point(570, 226);
            this.txtSelesai.Name = "txtSelesai";
            this.txtSelesai.ReadOnly = true;
            this.txtSelesai.Size = new System.Drawing.Size(137, 26);
            this.txtSelesai.TabIndex = 31;
            // 
            // txtTerpopuler
            // 
            this.txtTerpopuler.Location = new System.Drawing.Point(571, 284);
            this.txtTerpopuler.Name = "txtTerpopuler";
            this.txtTerpopuler.ReadOnly = true;
            this.txtTerpopuler.Size = new System.Drawing.Size(137, 26);
            this.txtTerpopuler.TabIndex = 32;
            // 
            // txtTeraktif
            // 
            this.txtTeraktif.Location = new System.Drawing.Point(570, 322);
            this.txtTeraktif.Name = "txtTeraktif";
            this.txtTeraktif.ReadOnly = true;
            this.txtTeraktif.Size = new System.Drawing.Size(137, 26);
            this.txtTeraktif.TabIndex = 33;
            // 
            // txtDitolak
            // 
            this.txtDitolak.Location = new System.Drawing.Point(571, 255);
            this.txtDitolak.Name = "txtDitolak";
            this.txtDitolak.ReadOnly = true;
            this.txtDitolak.Size = new System.Drawing.Size(137, 26);
            this.txtDitolak.TabIndex = 34;
            // 
            // txtPendapatan
            // 
            this.txtPendapatan.Location = new System.Drawing.Point(916, 162);
            this.txtPendapatan.Name = "txtPendapatan";
            this.txtPendapatan.ReadOnly = true;
            this.txtPendapatan.Size = new System.Drawing.Size(137, 26);
            this.txtPendapatan.TabIndex = 36;
            // 
            // txtRataRata
            // 
            this.txtRataRata.Location = new System.Drawing.Point(916, 194);
            this.txtRataRata.Name = "txtRataRata";
            this.txtRataRata.ReadOnly = true;
            this.txtRataRata.Size = new System.Drawing.Size(137, 26);
            this.txtRataRata.TabIndex = 37;
            // 
            // txtPeriode
            // 
            this.txtPeriode.Location = new System.Drawing.Point(571, 386);
            this.txtPeriode.Name = "txtPeriode";
            this.txtPeriode.ReadOnly = true;
            this.txtPeriode.Size = new System.Drawing.Size(137, 26);
            this.txtPeriode.TabIndex = 38;
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1117, 763);
            this.Controls.Add(this.txtPeriode);
            this.Controls.Add(this.txtRataRata);
            this.Controls.Add(this.txtPendapatan);
            this.Controls.Add(this.txtDitolak);
            this.Controls.Add(this.txtTeraktif);
            this.Controls.Add(this.txtTerpopuler);
            this.Controls.Add(this.txtSelesai);
            this.Controls.Add(this.txtDisetujui);
            this.Controls.Add(this.txtTotalBooking);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSimpanLaporan);
            this.Controls.Add(this.btnHitung);
            this.Controls.Add(this.txtNamaFile);
            this.Controls.Add(this.dtpTglSelesai);
            this.Controls.Add(this.dtpTglMulai);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.lblNamaFile);
            this.Controls.Add(this.lblDetailPeriode);
            this.Controls.Add(this.lblRataRata);
            this.Controls.Add(this.lblTotalPendapatan);
            this.Controls.Add(this.lblPelangganTeraktif);
            this.Controls.Add(this.lblStudioTerpopuler);
            this.Controls.Add(this.lblValueTotalDibatalkan);
            this.Controls.Add(this.lblTotalSelesai);
            this.Controls.Add(this.lblValueTotalDisetujui);
            this.Controls.Add(this.lblTotalBooking);
            this.Controls.Add(this.lblPendapatan);
            this.Controls.Add(this.lblStatistik);
            this.Controls.Add(this.lblRingkasan);
            this.Controls.Add(this.lblTglSelesai);
            this.Controls.Add(this.lblTglMulai);
            this.Controls.Add(this.lblPeriode);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Label lblTglMulai;
        private System.Windows.Forms.Label lblTglSelesai;
        private System.Windows.Forms.Label lblRingkasan;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblPendapatan;
        private System.Windows.Forms.Label lblTotalBooking;
        private System.Windows.Forms.Label lblValueTotalDisetujui;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Label lblNamaFile;
        private System.Windows.Forms.Label lblDetailPeriode;
        private System.Windows.Forms.Label lblRataRata;
        private System.Windows.Forms.Label lblTotalPendapatan;
        private System.Windows.Forms.Label lblPelangganTeraktif;
        private System.Windows.Forms.Label lblStudioTerpopuler;
        private System.Windows.Forms.Label lblValueTotalDibatalkan;
        private System.Windows.Forms.Label lblTotalSelesai;
        private System.Windows.Forms.DateTimePicker dtpTglMulai;
        private System.Windows.Forms.DateTimePicker dtpTglSelesai;
        private System.Windows.Forms.TextBox txtNamaFile;
        private System.Windows.Forms.Button btnHitung;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSimpanLaporan;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalBooking;
        private System.Windows.Forms.TextBox txtDisetujui;
        private System.Windows.Forms.TextBox txtSelesai;
        private System.Windows.Forms.TextBox txtTerpopuler;
        private System.Windows.Forms.TextBox txtTeraktif;
        private System.Windows.Forms.TextBox txtDitolak;
        private System.Windows.Forms.TextBox txtPendapatan;
        private System.Windows.Forms.TextBox txtRataRata;
        private System.Windows.Forms.TextBox txtPeriode;
    }
}