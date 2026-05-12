namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormProfilPelanggan
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
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblNamaLengkapi = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSubJudul = new System.Windows.Forms.Label();
            this.lblNoTelp = new System.Windows.Forms.Label();
            this.lblPasswordBaru = new System.Windows.Forms.Label();
            this.lblKonfirmasiPassword = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelp = new System.Windows.Forms.TextBox();
            this.txtKonfirmasiPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordBaru = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(234, 218);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(159, 26);
            this.txtNama.TabIndex = 0;
            this.txtNama.TextChanged += new System.EventHandler(this.txtNama_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(234, 131);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(159, 26);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(24, 45);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(439, 32);
            this.lblJudul.TabIndex = 2;
            this.lblJudul.Text = "\t👤 PROFIL SAYA - BLACK ROCK STUDIO";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblNamaLengkapi
            // 
            this.lblNamaLengkapi.AutoSize = true;
            this.lblNamaLengkapi.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaLengkapi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaLengkapi.ForeColor = System.Drawing.Color.White;
            this.lblNamaLengkapi.Location = new System.Drawing.Point(50, 217);
            this.lblNamaLengkapi.Name = "lblNamaLengkapi";
            this.lblNamaLengkapi.Size = new System.Drawing.Size(140, 25);
            this.lblNamaLengkapi.TabIndex = 3;
            this.lblNamaLengkapi.Text = "NamaLengkap : ";
            this.lblNamaLengkapi.Click += new System.EventHandler(this.lblNamaLengkapi_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(50, 172);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(68, 25);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email : ";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(48, 132);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(105, 25);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username : ";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblSubJudul
            // 
            this.lblSubJudul.BackColor = System.Drawing.Color.Transparent;
            this.lblSubJudul.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubJudul.ForeColor = System.Drawing.Color.White;
            this.lblSubJudul.Location = new System.Drawing.Point(48, 92);
            this.lblSubJudul.Name = "lblSubJudul";
            this.lblSubJudul.Size = new System.Drawing.Size(196, 36);
            this.lblSubJudul.TabIndex = 6;
            this.lblSubJudul.Text = "Informasi Profil";
            this.lblSubJudul.Click += new System.EventHandler(this.lblSubJudul_Click);
            // 
            // lblNoTelp
            // 
            this.lblNoTelp.AutoSize = true;
            this.lblNoTelp.BackColor = System.Drawing.Color.Transparent;
            this.lblNoTelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTelp.ForeColor = System.Drawing.Color.White;
            this.lblNoTelp.Location = new System.Drawing.Point(48, 263);
            this.lblNoTelp.Name = "lblNoTelp";
            this.lblNoTelp.Size = new System.Drawing.Size(116, 25);
            this.lblNoTelp.TabIndex = 7;
            this.lblNoTelp.Text = "No Telepon : ";
            this.lblNoTelp.Click += new System.EventHandler(this.lblNoTelp_Click);
            // 
            // lblPasswordBaru
            // 
            this.lblPasswordBaru.AutoSize = true;
            this.lblPasswordBaru.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordBaru.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordBaru.ForeColor = System.Drawing.Color.White;
            this.lblPasswordBaru.Location = new System.Drawing.Point(50, 358);
            this.lblPasswordBaru.Name = "lblPasswordBaru";
            this.lblPasswordBaru.Size = new System.Drawing.Size(141, 25);
            this.lblPasswordBaru.TabIndex = 12;
            this.lblPasswordBaru.Text = "Password Baru : ";
            this.lblPasswordBaru.Click += new System.EventHandler(this.lblPasswordBaru_Click);
            // 
            // lblKonfirmasiPassword
            // 
            this.lblKonfirmasiPassword.AutoSize = true;
            this.lblKonfirmasiPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblKonfirmasiPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKonfirmasiPassword.ForeColor = System.Drawing.Color.White;
            this.lblKonfirmasiPassword.Location = new System.Drawing.Point(50, 412);
            this.lblKonfirmasiPassword.Name = "lblKonfirmasiPassword";
            this.lblKonfirmasiPassword.Size = new System.Drawing.Size(190, 25);
            this.lblKonfirmasiPassword.TabIndex = 11;
            this.lblKonfirmasiPassword.Text = "Konfirmasi Password : ";
            this.lblKonfirmasiPassword.Click += new System.EventHandler(this.lblKonfirmasiPassword_Click);
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.BackColor = System.Drawing.Color.Transparent;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlamat.ForeColor = System.Drawing.Color.White;
            this.lblAlamat.Location = new System.Drawing.Point(50, 311);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(82, 25);
            this.lblAlamat.TabIndex = 8;
            this.lblAlamat.Text = "Alamat : ";
            this.lblAlamat.Click += new System.EventHandler(this.lblAlamat_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(234, 173);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 26);
            this.txtEmail.TabIndex = 13;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(234, 312);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(159, 26);
            this.txtAlamat.TabIndex = 14;
            this.txtAlamat.TextChanged += new System.EventHandler(this.txtAlamat_TextChanged);
            // 
            // txtNoTelp
            // 
            this.txtNoTelp.Location = new System.Drawing.Point(234, 262);
            this.txtNoTelp.Name = "txtNoTelp";
            this.txtNoTelp.Size = new System.Drawing.Size(159, 26);
            this.txtNoTelp.TabIndex = 15;
            this.txtNoTelp.TextChanged += new System.EventHandler(this.txtNoTelp_TextChanged);
            // 
            // txtKonfirmasiPassword
            // 
            this.txtKonfirmasiPassword.Location = new System.Drawing.Point(234, 413);
            this.txtKonfirmasiPassword.Name = "txtKonfirmasiPassword";
            this.txtKonfirmasiPassword.Size = new System.Drawing.Size(159, 26);
            this.txtKonfirmasiPassword.TabIndex = 16;
            this.txtKonfirmasiPassword.TextChanged += new System.EventHandler(this.txtKonfirmasiPassword_TextChanged);
            // 
            // txtPasswordBaru
            // 
            this.txtPasswordBaru.Location = new System.Drawing.Point(234, 359);
            this.txtPasswordBaru.Name = "txtPasswordBaru";
            this.txtPasswordBaru.Size = new System.Drawing.Size(159, 26);
            this.txtPasswordBaru.TabIndex = 17;
            this.txtPasswordBaru.TextChanged += new System.EventHandler(this.txtPasswordBaru_TextChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(53, 459);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(163, 53);
            this.btnSimpan.TabIndex = 18;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(53, 518);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(163, 53);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "\t🔄 Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(234, 459);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(163, 53);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.BackColor = System.Drawing.Color.Red;
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(697, 39);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(163, 53);
            this.btnTutup.TabIndex = 23;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-12, -36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 101);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FormProfilPelanggan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sistem_Penyewaan_Studio_Musik.Properties.Resources.ChatGPT_Image_6_Mei_2026__22_38_38;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(860, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtPasswordBaru);
            this.Controls.Add(this.txtKonfirmasiPassword);
            this.Controls.Add(this.txtNoTelp);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPasswordBaru);
            this.Controls.Add(this.lblKonfirmasiPassword);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.lblNoTelp);
            this.Controls.Add(this.lblSubJudul);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblNamaLengkapi);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtNama);
            this.Name = "FormProfilPelanggan";
            this.Text = "FormProfilPelanggan";
            this.Load += new System.EventHandler(this.FormProfilPelanggan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblNamaLengkapi;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSubJudul;
        private System.Windows.Forms.Label lblNoTelp;
        private System.Windows.Forms.Label lblPasswordBaru;
        private System.Windows.Forms.Label lblKonfirmasiPassword;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelp;
        private System.Windows.Forms.TextBox txtKonfirmasiPassword;
        private System.Windows.Forms.TextBox txtPasswordBaru;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Panel panel1;
    }
}