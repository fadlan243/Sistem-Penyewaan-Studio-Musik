namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormPelanggan
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
            this.lblSelamatDatang = new System.Windows.Forms.Label();
            this.lblHalo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBookingStudio = new System.Windows.Forms.Button();
            this.btnProfil = new System.Windows.Forms.Button();
            this.btnPembayaran = new System.Windows.Forms.Button();
            this.btnRiwayatBooking = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(22, 12);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(578, 27);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "BLACK ROCK STUDIO - PELANGGAN DASHBOARD";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblSelamatDatang
            // 
            this.lblSelamatDatang.AutoSize = true;
            this.lblSelamatDatang.BackColor = System.Drawing.Color.Transparent;
            this.lblSelamatDatang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelamatDatang.ForeColor = System.Drawing.Color.Snow;
            this.lblSelamatDatang.Location = new System.Drawing.Point(12, 101);
            this.lblSelamatDatang.Name = "lblSelamatDatang";
            this.lblSelamatDatang.Size = new System.Drawing.Size(374, 30);
            this.lblSelamatDatang.TabIndex = 1;
            this.lblSelamatDatang.Text = " Selamat datang di Black Rock Studio ";
            this.lblSelamatDatang.Click += new System.EventHandler(this.lblSelamatDatang_Click);
            // 
            // lblHalo
            // 
            this.lblHalo.AutoSize = true;
            this.lblHalo.BackColor = System.Drawing.Color.Transparent;
            this.lblHalo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalo.ForeColor = System.Drawing.Color.Snow;
            this.lblHalo.Location = new System.Drawing.Point(12, 71);
            this.lblHalo.Name = "lblHalo";
            this.lblHalo.Size = new System.Drawing.Size(200, 30);
            this.lblHalo.TabIndex = 2;
            this.lblHalo.Text = "👋 HALO, [NAMA]!";
            this.lblHalo.Click += new System.EventHandler(this.lblHalo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Firebrick;
            this.panel1.Location = new System.Drawing.Point(-10, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 59);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Black;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Firebrick;
            this.btnLogout.Location = new System.Drawing.Point(728, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(126, 38);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "LOG OUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBookingStudio
            // 
            this.btnBookingStudio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookingStudio.ForeColor = System.Drawing.Color.Firebrick;
            this.btnBookingStudio.Location = new System.Drawing.Point(62, 518);
            this.btnBookingStudio.Name = "btnBookingStudio";
            this.btnBookingStudio.Size = new System.Drawing.Size(213, 50);
            this.btnBookingStudio.TabIndex = 4;
            this.btnBookingStudio.Text = "\t📅 BOOKING STUDIO";
            this.btnBookingStudio.UseVisualStyleBackColor = true;
            this.btnBookingStudio.Click += new System.EventHandler(this.btnBookingStudio_Click);
            // 
            // btnProfil
            // 
            this.btnProfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfil.ForeColor = System.Drawing.Color.Firebrick;
            this.btnProfil.Location = new System.Drawing.Point(718, 62);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(126, 50);
            this.btnProfil.TabIndex = 5;
            this.btnProfil.Text = "\t👤 PROFIL SAYA";
            this.btnProfil.UseVisualStyleBackColor = true;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // btnPembayaran
            // 
            this.btnPembayaran.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPembayaran.ForeColor = System.Drawing.Color.Firebrick;
            this.btnPembayaran.Location = new System.Drawing.Point(582, 518);
            this.btnPembayaran.Name = "btnPembayaran";
            this.btnPembayaran.Size = new System.Drawing.Size(213, 50);
            this.btnPembayaran.TabIndex = 7;
            this.btnPembayaran.Text = "\t💰 PEMBAYARAN";
            this.btnPembayaran.UseVisualStyleBackColor = true;
            this.btnPembayaran.Click += new System.EventHandler(this.btnPembayaran_Click);
            // 
            // btnRiwayatBooking
            // 
            this.btnRiwayatBooking.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiwayatBooking.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRiwayatBooking.Location = new System.Drawing.Point(322, 518);
            this.btnRiwayatBooking.Name = "btnRiwayatBooking";
            this.btnRiwayatBooking.Size = new System.Drawing.Size(213, 50);
            this.btnRiwayatBooking.TabIndex = 8;
            this.btnRiwayatBooking.Text = "📜 RIWAYAT BOOKING";
            this.btnRiwayatBooking.UseVisualStyleBackColor = true;
            this.btnRiwayatBooking.Click += new System.EventHandler(this.btnRiwayatBooking_Click);
            // 
            // FormPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(856, 651);
            this.Controls.Add(this.btnRiwayatBooking);
            this.Controls.Add(this.btnPembayaran);
            this.Controls.Add(this.btnProfil);
            this.Controls.Add(this.btnBookingStudio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHalo);
            this.Controls.Add(this.lblSelamatDatang);
            this.Name = "FormPelanggan";
            this.Text = "FormPelanggan";
            this.Load += new System.EventHandler(this.FormPelanggan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblSelamatDatang;
        private System.Windows.Forms.Label lblHalo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBookingStudio;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Button btnPembayaran;
        private System.Windows.Forms.Button btnRiwayatBooking;
        private System.Windows.Forms.Button btnLogout;
    }
}