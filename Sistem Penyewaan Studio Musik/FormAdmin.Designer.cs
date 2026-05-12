namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormAdmin
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
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.btnKelolaPelanggan = new System.Windows.Forms.Button();
            this.btnKelolaStudio = new System.Windows.Forms.Button();
            this.btnKelolaJadwal = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.PanelAdmin = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.PanelAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLaporan
            // 
            this.btnLaporan.ForeColor = System.Drawing.Color.Firebrick;
            this.btnLaporan.Location = new System.Drawing.Point(614, 537);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(227, 51);
            this.btnLaporan.TabIndex = 0;
            this.btnLaporan.Text = "\t📊 Laporan";
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRiwayat.Location = new System.Drawing.Point(339, 537);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(248, 51);
            this.btnRiwayat.TabIndex = 1;
            this.btnRiwayat.Text = "\t📜 Kelola Booking";
            this.btnRiwayat.UseVisualStyleBackColor = true;
            this.btnRiwayat.Click += new System.EventHandler(this.btnRiwayat_Click);
            // 
            // btnKelolaPelanggan
            // 
            this.btnKelolaPelanggan.ForeColor = System.Drawing.Color.Firebrick;
            this.btnKelolaPelanggan.Location = new System.Drawing.Point(339, 463);
            this.btnKelolaPelanggan.Name = "btnKelolaPelanggan";
            this.btnKelolaPelanggan.Size = new System.Drawing.Size(248, 51);
            this.btnKelolaPelanggan.TabIndex = 2;
            this.btnKelolaPelanggan.Text = "👥 Kelola User";
            this.btnKelolaPelanggan.UseVisualStyleBackColor = true;
            this.btnKelolaPelanggan.Click += new System.EventHandler(this.btnKelolaPelanggan_Click);
            // 
            // btnKelolaStudio
            // 
            this.btnKelolaStudio.ForeColor = System.Drawing.Color.Firebrick;
            this.btnKelolaStudio.Location = new System.Drawing.Point(63, 463);
            this.btnKelolaStudio.Name = "btnKelolaStudio";
            this.btnKelolaStudio.Size = new System.Drawing.Size(253, 51);
            this.btnKelolaStudio.TabIndex = 3;
            this.btnKelolaStudio.Text = "🎸 Kelola Studio";
            this.btnKelolaStudio.UseVisualStyleBackColor = true;
            this.btnKelolaStudio.Click += new System.EventHandler(this.btnKelolaStudio_Click);
            // 
            // btnKelolaJadwal
            // 
            this.btnKelolaJadwal.ForeColor = System.Drawing.Color.Firebrick;
            this.btnKelolaJadwal.Location = new System.Drawing.Point(614, 463);
            this.btnKelolaJadwal.Name = "btnKelolaJadwal";
            this.btnKelolaJadwal.Size = new System.Drawing.Size(227, 51);
            this.btnKelolaJadwal.TabIndex = 4;
            this.btnKelolaJadwal.Text = "📅 Kelola Jadwal";
            this.btnKelolaJadwal.UseVisualStyleBackColor = true;
            this.btnKelolaJadwal.Click += new System.EventHandler(this.btnKelolaJadwal_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.BackColor = System.Drawing.Color.Transparent;
            this.lblAdmin.Font = new System.Drawing.Font("Rockwell", 12F);
            this.lblAdmin.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAdmin.Location = new System.Drawing.Point(-52, 29);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(1003, 47);
            this.lblAdmin.TabIndex = 5;
            this.lblAdmin.Text = "              BLACK ROCK STUDIO - ADMIN DASHBOARD";
            this.lblAdmin.Click += new System.EventHandler(this.lblAdmin_Click);
            // 
            // PanelAdmin
            // 
            this.PanelAdmin.BackColor = System.Drawing.Color.Black;
            this.PanelAdmin.Controls.Add(this.btnLogout);
            this.PanelAdmin.Controls.Add(this.lblAdmin);
            this.PanelAdmin.Location = new System.Drawing.Point(-13, -15);
            this.PanelAdmin.Name = "PanelAdmin";
            this.PanelAdmin.Size = new System.Drawing.Size(937, 71);
            this.PanelAdmin.TabIndex = 6;
            this.PanelAdmin.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelAdmin_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnLogout.FlatAppearance.BorderSize = 3;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnLogout.Location = new System.Drawing.Point(772, 19);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(131, 46);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.ForeColor = System.Drawing.Color.Firebrick;
            this.btnPembayaran.Location = new System.Drawing.Point(70, 538);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(245, 49);
            this.btnPembayaran.TabIndex = 7;
            this.btnPembayaran.Text = "💸 Pembayaran";
            this.btnPembayaran.UseVisualStyleBackColor = true;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 687);
            this.Controls.Add(this.btnPembayaran);
            this.Controls.Add(this.PanelAdmin);
            this.Controls.Add(this.btnKelolaJadwal);
            this.Controls.Add(this.btnKelolaStudio);
            this.Controls.Add(this.btnKelolaPelanggan);
            this.Controls.Add(this.btnRiwayat);
            this.Controls.Add(this.btnLaporan);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.PanelAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.Button btnKelolaPelanggan;
        private System.Windows.Forms.Button btnKelolaStudio;
        private System.Windows.Forms.Button btnKelolaJadwal;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Panel PanelAdmin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPembayaran;
    }
}