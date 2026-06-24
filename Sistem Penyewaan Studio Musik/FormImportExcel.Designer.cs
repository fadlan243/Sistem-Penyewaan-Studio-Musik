namespace Sistem_Penyewaan_Studio_Musik
{
    partial class FormImportExcel
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
            this.lblRowCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.Firebrick;
            this.lblJudul.Location = new System.Drawing.Point(18, 41);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(338, 49);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "📥 IMPORT FROM EXCEL";
            this.lblJudul.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRowCount.Location = new System.Drawing.Point(14, 480);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(173, 35);
            this.lblRowCount.TabIndex = 1;
            this.lblRowCount.Text = "📊 Total data: 0";
            this.lblRowCount.Click += new System.EventHandler(this.lblRowCount_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblJudul);
            this.panel1.Controls.Add(this.btnTutup);
            this.panel1.Location = new System.Drawing.Point(-6, -32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 104);
            this.panel1.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(19, 114);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(213, 26);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(255, 110);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 35);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "📂 Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(715, 49);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(119, 41);
            this.btnTutup.TabIndex = 5;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(400, 110);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(119, 35);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "⬆️ Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(809, 326);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FormImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 524);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRowCount);
            this.Name = "FormImportExcel";
            this.Text = "FormImportExcel";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}