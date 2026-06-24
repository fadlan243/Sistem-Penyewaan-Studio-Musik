namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormReportViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblGraph = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.lblPilihLaporan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbJenisLaporan = new System.Windows.Forms.ComboBox();
            this.cmbTipeChart = new System.Windows.Forms.ComboBox();
            this.dtpMulai = new System.Windows.Forms.DateTimePicker();
            this.dtpSelesai = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLihatReport = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.BackColor = System.Drawing.Color.Transparent;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(20, 28);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(484, 39);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📊 LAPORAN - BLACK ROCK STUDIO";
            // 
            // lblGraph
            // 
            this.lblGraph.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraph.Location = new System.Drawing.Point(25, 131);
            this.lblGraph.Name = "lblGraph";
            this.lblGraph.Size = new System.Drawing.Size(110, 38);
            this.lblGraph.TabIndex = 1;
            this.lblGraph.Text = "Tampilkan :";
            // 
            // lblPeriode
            // 
            this.lblPeriode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriode.Location = new System.Drawing.Point(395, 91);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(101, 38);
            this.lblPeriode.TabIndex = 2;
            this.lblPeriode.Text = "Periode : ";
            // 
            // lblPilihLaporan
            // 
            this.lblPilihLaporan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPilihLaporan.Location = new System.Drawing.Point(25, 90);
            this.lblPilihLaporan.Name = "lblPilihLaporan";
            this.lblPilihLaporan.Size = new System.Drawing.Size(153, 38);
            this.lblPilihLaporan.TabIndex = 3;
            this.lblPilihLaporan.Text = "Pilih Laporan :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Location = new System.Drawing.Point(-8, -19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 84);
            this.panel1.TabIndex = 4;
            // 
            // cmbJenisLaporan
            // 
            this.cmbJenisLaporan.FormattingEnabled = true;
            this.cmbJenisLaporan.Items.AddRange(new object[] {
            "📊 Laporan Booking",
            "💰 Laporan Pendapatan",
            "👤 Laporan Pelanggan"});
            this.cmbJenisLaporan.Location = new System.Drawing.Point(165, 91);
            this.cmbJenisLaporan.Name = "cmbJenisLaporan";
            this.cmbJenisLaporan.Size = new System.Drawing.Size(121, 28);
            this.cmbJenisLaporan.TabIndex = 5;
            this.cmbJenisLaporan.SelectedIndexChanged += new System.EventHandler(this.cmbJenisLaporan_SelectedIndexChanged);
            // 
            // cmbTipeChart
            // 
            this.cmbTipeChart.FormattingEnabled = true;
            this.cmbTipeChart.Items.AddRange(new object[] {
            "📊 Bar Chart",
            "",
            "🥧 Pie Chart"});
            this.cmbTipeChart.Location = new System.Drawing.Point(165, 131);
            this.cmbTipeChart.Name = "cmbTipeChart";
            this.cmbTipeChart.Size = new System.Drawing.Size(121, 28);
            this.cmbTipeChart.TabIndex = 6;
            this.cmbTipeChart.SelectedIndexChanged += new System.EventHandler(this.cmbTipeChart_SelectedIndexChanged);
            // 
            // dtpMulai
            // 
            this.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMulai.Location = new System.Drawing.Point(483, 90);
            this.dtpMulai.Name = "dtpMulai";
            this.dtpMulai.Size = new System.Drawing.Size(126, 26);
            this.dtpMulai.TabIndex = 7;
            // 
            // dtpSelesai
            // 
            this.dtpSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSelesai.Location = new System.Drawing.Point(648, 89);
            this.dtpSelesai.Name = "dtpSelesai";
            this.dtpSelesai.Size = new System.Drawing.Size(126, 26);
            this.dtpSelesai.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(612, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(30, 284);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(820, 330);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Location = new System.Drawing.Point(30, 208);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(129, 43);
            this.btnTampilkan.TabIndex = 11;
            this.btnTampilkan.Text = "🔍 Tampilkan";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(165, 208);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 43);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "📥 Export PNG";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLihatReport
            // 
            this.btnLihatReport.Location = new System.Drawing.Point(294, 208);
            this.btnLihatReport.Name = "btnLihatReport";
            this.btnLihatReport.Size = new System.Drawing.Size(97, 43);
            this.btnLihatReport.TabIndex = 13;
            this.btnLihatReport.Text = "📄 Report";
            this.btnLihatReport.UseVisualStyleBackColor = true;
            this.btnLihatReport.Click += new System.EventHandler(this.btnLihatReport_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Black;
            this.btnTutup.ForeColor = System.Drawing.Color.Firebrick;
            this.btnTutup.Location = new System.Drawing.Point(753, 28);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(105, 43);
            this.btnTutup.TabIndex = 14;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // FormReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 641);
            this.Controls.Add(this.btnLihatReport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpSelesai);
            this.Controls.Add(this.dtpMulai);
            this.Controls.Add(this.cmbTipeChart);
            this.Controls.Add(this.cmbJenisLaporan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPilihLaporan);
            this.Controls.Add(this.lblPeriode);
            this.Controls.Add(this.lblGraph);
            this.Name = "FormReportViewer";
            this.Text = "FormReportViewer";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblGraph;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Label lblPilihLaporan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbJenisLaporan;
        private System.Windows.Forms.ComboBox cmbTipeChart;
        private System.Windows.Forms.DateTimePicker dtpMulai;
        private System.Windows.Forms.DateTimePicker dtpSelesai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnLihatReport;
        private System.Windows.Forms.Button btnTutup;
    }
}