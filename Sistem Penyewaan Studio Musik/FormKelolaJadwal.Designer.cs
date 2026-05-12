namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormKelolaJadwal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKelolaJadwal));
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblKeterangan = new System.Windows.Forms.Label();
            this.lblStatistik = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblTanggalFilter = new System.Windows.Forms.Label();
            this.lblStudioFilter = new System.Windows.Forms.Label();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblJamSelesai = new System.Windows.Forms.Label();
            this.lblJamMulai = new System.Windows.Forms.Label();
            this.cbStudioFilter = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbStudio = new System.Windows.Forms.ComboBox();
            this.dtpTanggalFilter = new System.Windows.Forms.DateTimePicker();
            this.dtpJamSelesai = new System.Windows.Forms.DateTimePicker();
            this.dtpJamMulai = new System.Windows.Forms.DateTimePicker();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnStatusTersedia = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnStatusDitutup = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.lblDaftarJadwal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigatorJadwal = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.bindingSourceJadwal = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorJadwal)).BeginInit();
            this.bindingNavigatorJadwal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJadwal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFormTitle.Location = new System.Drawing.Point(575, 128);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(164, 25);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "📝 FORM JADWAL";
            this.lblFormTitle.Click += new System.EventHandler(this.lblFormTitle_Click);
            // 
            // lblKeterangan
            // 
            this.lblKeterangan.AutoSize = true;
            this.lblKeterangan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKeterangan.Location = new System.Drawing.Point(573, 366);
            this.lblKeterangan.Name = "lblKeterangan";
            this.lblKeterangan.Size = new System.Drawing.Size(115, 25);
            this.lblKeterangan.TabIndex = 1;
            this.lblKeterangan.Text = "Keterangan : ";
            this.lblKeterangan.Click += new System.EventHandler(this.lblKeterangan_Click);
            // 
            // lblStatistik
            // 
            this.lblStatistik.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatistik.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStatistik.Location = new System.Drawing.Point(14, 435);
            this.lblStatistik.Name = "lblStatistik";
            this.lblStatistik.Size = new System.Drawing.Size(129, 38);
            this.lblStatistik.TabIndex = 2;
            this.lblStatistik.Text = "Statistik :";
            this.lblStatistik.Click += new System.EventHandler(this.lblStatistik_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(575, 327);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status :";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTanggal.Location = new System.Drawing.Point(575, 219);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(82, 25);
            this.lblTanggal.TabIndex = 4;
            this.lblTanggal.Text = "\tTanggal :";
            this.lblTanggal.Click += new System.EventHandler(this.lblTanggal_Click);
            // 
            // lblStudio
            // 
            this.lblStudio.AutoSize = true;
            this.lblStudio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudio.Location = new System.Drawing.Point(579, 179);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(109, 25);
            this.lblStudio.TabIndex = 5;
            this.lblStudio.Text = "Pilih Studio :";
            this.lblStudio.Click += new System.EventHandler(this.lblStudio_Click);
            // 
            // lblTanggalFilter
            // 
            this.lblTanggalFilter.AutoSize = true;
            this.lblTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTanggalFilter.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTanggalFilter.Location = new System.Drawing.Point(34, 199);
            this.lblTanggalFilter.Name = "lblTanggalFilter";
            this.lblTanggalFilter.Size = new System.Drawing.Size(82, 25);
            this.lblTanggalFilter.TabIndex = 6;
            this.lblTanggalFilter.Text = "Tanggal :";
            this.lblTanggalFilter.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblStudioFilter
            // 
            this.lblStudioFilter.AutoSize = true;
            this.lblStudioFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudioFilter.ForeColor = System.Drawing.Color.Firebrick;
            this.lblStudioFilter.Location = new System.Drawing.Point(34, 142);
            this.lblStudioFilter.Name = "lblStudioFilter";
            this.lblStudioFilter.Size = new System.Drawing.Size(72, 25);
            this.lblStudioFilter.TabIndex = 7;
            this.lblStudioFilter.Text = "Studio :";
            this.lblStudioFilter.Click += new System.EventHandler(this.lblStudioFilter_Click);
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(19, 19);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(320, 48);
            this.lblJudul.TabIndex = 8;
            this.lblJudul.Text = "📅 KELOLA JADWAL";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblJamSelesai
            // 
            this.lblJamSelesai.AutoSize = true;
            this.lblJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblJamSelesai.Location = new System.Drawing.Point(573, 293);
            this.lblJamSelesai.Name = "lblJamSelesai";
            this.lblJamSelesai.Size = new System.Drawing.Size(110, 25);
            this.lblJamSelesai.TabIndex = 9;
            this.lblJamSelesai.Text = "Jam Selesai :";
            this.lblJamSelesai.Click += new System.EventHandler(this.lblJamSelesai_Click);
            // 
            // lblJamMulai
            // 
            this.lblJamMulai.AutoSize = true;
            this.lblJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblJamMulai.Location = new System.Drawing.Point(575, 257);
            this.lblJamMulai.Name = "lblJamMulai";
            this.lblJamMulai.Size = new System.Drawing.Size(105, 25);
            this.lblJamMulai.TabIndex = 10;
            this.lblJamMulai.Text = "Jam Mulai : ";
            this.lblJamMulai.Click += new System.EventHandler(this.lblJamMulai_Click);
            // 
            // cbStudioFilter
            // 
            this.cbStudioFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudioFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbStudioFilter.FormattingEnabled = true;
            this.cbStudioFilter.Location = new System.Drawing.Point(114, 139);
            this.cbStudioFilter.Name = "cbStudioFilter";
            this.cbStudioFilter.Size = new System.Drawing.Size(125, 33);
            this.cbStudioFilter.TabIndex = 11;
            this.cbStudioFilter.SelectedIndexChanged += new System.EventHandler(this.cbStudioFilter_SelectedIndexChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Tersedia",
            "Dipesan",
            "Ditutup"});
            this.cbStatus.Location = new System.Drawing.Point(712, 327);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(155, 33);
            this.cbStatus.TabIndex = 12;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // cbStudio
            // 
            this.cbStudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbStudio.FormattingEnabled = true;
            this.cbStudio.Location = new System.Drawing.Point(712, 176);
            this.cbStudio.Name = "cbStudio";
            this.cbStudio.Size = new System.Drawing.Size(155, 33);
            this.cbStudio.TabIndex = 13;
            this.cbStudio.SelectedIndexChanged += new System.EventHandler(this.cbStudio_SelectedIndexChanged);
            // 
            // dtpTanggalFilter
            // 
            this.dtpTanggalFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTanggalFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalFilter.Location = new System.Drawing.Point(114, 194);
            this.dtpTanggalFilter.Name = "dtpTanggalFilter";
            this.dtpTanggalFilter.Size = new System.Drawing.Size(98, 31);
            this.dtpTanggalFilter.TabIndex = 14;
            this.dtpTanggalFilter.ValueChanged += new System.EventHandler(this.dtpTanggalFilter_ValueChanged);
            // 
            // dtpJamSelesai
            // 
            this.dtpJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJamSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamSelesai.Location = new System.Drawing.Point(712, 293);
            this.dtpJamSelesai.Name = "dtpJamSelesai";
            this.dtpJamSelesai.Size = new System.Drawing.Size(155, 31);
            this.dtpJamSelesai.TabIndex = 15;
            this.dtpJamSelesai.ValueChanged += new System.EventHandler(this.dtpJamSelesai_ValueChanged);
            // 
            // dtpJamMulai
            // 
            this.dtpJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJamMulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpJamMulai.Location = new System.Drawing.Point(712, 252);
            this.dtpJamMulai.Name = "dtpJamMulai";
            this.dtpJamMulai.Size = new System.Drawing.Size(155, 31);
            this.dtpJamMulai.TabIndex = 16;
            this.dtpJamMulai.ValueChanged += new System.EventHandler(this.dtpJamMulai_ValueChanged);
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggal.Location = new System.Drawing.Point(712, 219);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(155, 31);
            this.dtpTanggal.TabIndex = 17;
            this.dtpTanggal.ValueChanged += new System.EventHandler(this.dtpTanggal_ValueChanged);
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeterangan.Location = new System.Drawing.Point(712, 366);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(173, 31);
            this.txtKeterangan.TabIndex = 18;
            this.txtKeterangan.Text = "Catatan Tambahan...";
            this.txtKeterangan.TextChanged += new System.EventHandler(this.txtKeterangan_TextChanged);
            // 
            // btnCari
            // 
            this.btnCari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCari.Location = new System.Drawing.Point(14, 252);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(201, 43);
            this.btnCari.TabIndex = 19;
            this.btnCari.Text = "\t🔍 Cari Jadwal";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnStatusTersedia
            // 
            this.btnStatusTersedia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStatusTersedia.Location = new System.Drawing.Point(8, 379);
            this.btnStatusTersedia.Name = "btnStatusTersedia";
            this.btnStatusTersedia.Size = new System.Drawing.Size(149, 43);
            this.btnStatusTersedia.TabIndex = 20;
            this.btnStatusTersedia.Text = "📋 Set Tersedia";
            this.btnStatusTersedia.UseVisualStyleBackColor = true;
            this.btnStatusTersedia.Click += new System.EventHandler(this.btnStatusTersedia_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTutup.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTutup.Location = new System.Drawing.Point(779, 19);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(112, 43);
            this.btnTutup.TabIndex = 21;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.Location = new System.Drawing.Point(691, 410);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 43);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "🔄 Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSimpan.Location = new System.Drawing.Point(562, 410);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(115, 43);
            this.btnSimpan.TabIndex = 23;
            this.btnSimpan.Text = "\t💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnStatusDitutup
            // 
            this.btnStatusDitutup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStatusDitutup.Location = new System.Drawing.Point(163, 379);
            this.btnStatusDitutup.Name = "btnStatusDitutup";
            this.btnStatusDitutup.Size = new System.Drawing.Size(155, 43);
            this.btnStatusDitutup.TabIndex = 24;
            this.btnStatusDitutup.Text = "🚫 Set Ditutup";
            this.btnStatusDitutup.UseVisualStyleBackColor = true;
            this.btnStatusDitutup.Click += new System.EventHandler(this.btnStatusDitutup_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHapus.Location = new System.Drawing.Point(215, 317);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(103, 43);
            this.btnHapus.TabIndex = 25;
            this.btnHapus.Text = "🗑️ Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(128, 317);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 43);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "\t✏️ Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTambah.Location = new System.Drawing.Point(12, 317);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(113, 43);
            this.btnTambah.TabIndex = 27;
            this.btnTambah.Text = "\t➕ Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // lblDaftarJadwal
            // 
            this.lblDaftarJadwal.AutoSize = true;
            this.lblDaftarJadwal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDaftarJadwal.ForeColor = System.Drawing.Color.Firebrick;
            this.lblDaftarJadwal.Location = new System.Drawing.Point(34, 101);
            this.lblDaftarJadwal.Name = "lblDaftarJadwal";
            this.lblDaftarJadwal.Size = new System.Drawing.Size(149, 25);
            this.lblDaftarJadwal.TabIndex = 28;
            this.lblDaftarJadwal.Text = "DAFTAR JADWAL";
            this.lblDaftarJadwal.Click += new System.EventHandler(this.lblDaftarJadwal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.bindingNavigatorJadwal);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Location = new System.Drawing.Point(-7, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 77);
            this.panel1.TabIndex = 29;
            // 
            // bindingNavigatorJadwal
            // 
            this.bindingNavigatorJadwal.AddNewItem = this.bindingNavigatorSeparator1;
            this.bindingNavigatorJadwal.BindingSource = this.bindingSourceJadwal;
            this.bindingNavigatorJadwal.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorJadwal.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorJadwal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigatorJadwal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorJadwal.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorJadwal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorJadwal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorJadwal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorJadwal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorJadwal.Name = "bindingNavigatorJadwal";
            this.bindingNavigatorJadwal.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorJadwal.Size = new System.Drawing.Size(932, 33);
            this.bindingNavigatorJadwal.TabIndex = 22;
            this.bindingNavigatorJadwal.Text = "bindingNavigator1";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(54, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.AllowUserToAddRows = false;
            this.dgvJadwal.AllowUserToDeleteRows = false;
            this.dgvJadwal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJadwal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvJadwal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Location = new System.Drawing.Point(14, 483);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.ReadOnly = true;
            this.dgvJadwal.RowHeadersVisible = false;
            this.dgvJadwal.RowHeadersWidth = 62;
            this.dgvJadwal.RowTemplate.Height = 28;
            this.dgvJadwal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJadwal.Size = new System.Drawing.Size(854, 218);
            this.dgvJadwal.TabIndex = 30;
            this.dgvJadwal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwal_CellClick);
            // 
            // FormKelolaJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(889, 706);
            this.Controls.Add(this.dgvJadwal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDaftarJadwal);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnStatusDitutup);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStatusTersedia);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.dtpJamMulai);
            this.Controls.Add(this.dtpJamSelesai);
            this.Controls.Add(this.dtpTanggalFilter);
            this.Controls.Add(this.cbStudio);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbStudioFilter);
            this.Controls.Add(this.lblJamMulai);
            this.Controls.Add(this.lblJamSelesai);
            this.Controls.Add(this.lblStudioFilter);
            this.Controls.Add(this.lblTanggalFilter);
            this.Controls.Add(this.lblStudio);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStatistik);
            this.Controls.Add(this.lblKeterangan);
            this.Controls.Add(this.lblFormTitle);
            this.Name = "FormKelolaJadwal";
            this.Text = "FormKelolaJadwal";
            this.Load += new System.EventHandler(this.FormKelolaJadwal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorJadwal)).EndInit();
            this.bindingNavigatorJadwal.ResumeLayout(false);
            this.bindingNavigatorJadwal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJadwal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblKeterangan;
        private System.Windows.Forms.Label lblStatistik;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblTanggalFilter;
        private System.Windows.Forms.Label lblStudioFilter;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblJamSelesai;
        private System.Windows.Forms.Label lblJamMulai;
        private System.Windows.Forms.ComboBox cbStudioFilter;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbStudio;
        private System.Windows.Forms.DateTimePicker dtpTanggalFilter;
        private System.Windows.Forms.DateTimePicker dtpJamSelesai;
        private System.Windows.Forms.DateTimePicker dtpJamMulai;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnStatusTersedia;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnStatusDitutup;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Label lblDaftarJadwal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.BindingNavigator bindingNavigatorJadwal;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.BindingSource bindingSourceJadwal;
    }
}