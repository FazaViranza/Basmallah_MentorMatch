namespace TESTUCP1PABD
{
    partial class Mahasiswa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.txtNamaLomba = new System.Windows.Forms.TextBox();
            this.txtPenyelenggara = new System.Windows.Forms.TextBox();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.comboBoxJenisMabar = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.comboBoxDosen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNIDN = new System.Windows.Forms.TextBox();
            this.dtpTanggalSelesai = new System.Windows.Forms.DateTimePicker();
            this.txtDraftFile = new System.Windows.Forms.TextBox();
            this.btnBrowseDraft = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jenis Perlombaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nama Lomba";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Penyelenggara";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tanggal Lomba Dimulai";
            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(214, 164);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(121, 20);
            this.txtNIM.TabIndex = 7;
            this.txtNIM.TextChanged += new System.EventHandler(this.txtNIM_TextChanged);
            // 
            // txtNamaLomba
            // 
            this.txtNamaLomba.Location = new System.Drawing.Point(214, 234);
            this.txtNamaLomba.Name = "txtNamaLomba";
            this.txtNamaLomba.Size = new System.Drawing.Size(121, 20);
            this.txtNamaLomba.TabIndex = 9;
            this.txtNamaLomba.TextChanged += new System.EventHandler(this.txtNamaLomba_TextChanged);
            // 
            // txtPenyelenggara
            // 
            this.txtPenyelenggara.Location = new System.Drawing.Point(214, 267);
            this.txtPenyelenggara.Name = "txtPenyelenggara";
            this.txtPenyelenggara.Size = new System.Drawing.Size(121, 20);
            this.txtPenyelenggara.TabIndex = 10;
            this.txtPenyelenggara.TextChanged += new System.EventHandler(this.txtPenyelenggara_TextChanged);
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(501, 167);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTanggal.TabIndex = 11;
            this.dateTimePickerTanggal.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxJenisMabar
            // 
            this.comboBoxJenisMabar.FormattingEnabled = true;
            this.comboBoxJenisMabar.Location = new System.Drawing.Point(214, 201);
            this.comboBoxJenisMabar.Name = "comboBoxJenisMabar";
            this.comboBoxJenisMabar.Size = new System.Drawing.Size(121, 21);
            this.comboBoxJenisMabar.TabIndex = 12;
            this.comboBoxJenisMabar.SelectedIndexChanged += new System.EventHandler(this.comboBoxJenisMabar_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(713, 406);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 406);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Back";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // comboBoxDosen
            // 
            this.comboBoxDosen.FormattingEnabled = true;
            this.comboBoxDosen.Location = new System.Drawing.Point(416, 231);
            this.comboBoxDosen.Name = "comboBoxDosen";
            this.comboBoxDosen.Size = new System.Drawing.Size(208, 21);
            this.comboBoxDosen.TabIndex = 17;
            this.comboBoxDosen.SelectedIndexChanged += new System.EventHandler(this.comboBoxDosen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dosen";
            // 
            // txtNIDN
            // 
            this.txtNIDN.Location = new System.Drawing.Point(630, 231);
            this.txtNIDN.Name = "txtNIDN";
            this.txtNIDN.Size = new System.Drawing.Size(71, 20);
            this.txtNIDN.TabIndex = 19;
            // 
            // dtpTanggalSelesai
            // 
            this.dtpTanggalSelesai.Location = new System.Drawing.Point(501, 195);
            this.dtpTanggalSelesai.Name = "dtpTanggalSelesai";
            this.dtpTanggalSelesai.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalSelesai.TabIndex = 21;
            this.dtpTanggalSelesai.ValueChanged += new System.EventHandler(this.dtpTanggalSelesai_ValueChanged);
            // 
            // txtDraftFile
            // 
            this.txtDraftFile.Location = new System.Drawing.Point(427, 267);
            this.txtDraftFile.Name = "txtDraftFile";
            this.txtDraftFile.Size = new System.Drawing.Size(193, 20);
            this.txtDraftFile.TabIndex = 22;
            this.txtDraftFile.TextChanged += new System.EventHandler(this.txtDraftFile_TextChanged);
            // 
            // btnBrowseDraft
            // 
            this.btnBrowseDraft.Location = new System.Drawing.Point(626, 267);
            this.btnBrowseDraft.Name = "btnBrowseDraft";
            this.btnBrowseDraft.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDraft.TabIndex = 23;
            this.btnBrowseDraft.Text = "Browse";
            this.btnBrowseDraft.UseVisualStyleBackColor = true;
            this.btnBrowseDraft.Click += new System.EventHandler(this.btnBrowseDraft_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Tanggal Lomba Berakhir";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Draft File";
            // 
            // Mahasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBrowseDraft);
            this.Controls.Add(this.txtDraftFile);
            this.Controls.Add(this.dtpTanggalSelesai);
            this.Controls.Add(this.txtNIDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDosen);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.comboBoxJenisMabar);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.txtPenyelenggara);
            this.Controls.Add(this.txtNamaLomba);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Mahasiswa";
            this.Text = "Mahasiswa";
            this.Load += new System.EventHandler(this.Mahasiswa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.TextBox txtNamaLomba;
        private System.Windows.Forms.TextBox txtPenyelenggara;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.ComboBox comboBoxJenisMabar;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox comboBoxDosen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNIDN;
        private System.Windows.Forms.DateTimePicker dtpTanggalSelesai;
        private System.Windows.Forms.TextBox txtDraftFile;
        private System.Windows.Forms.Button btnBrowseDraft;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}