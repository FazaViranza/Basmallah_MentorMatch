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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.btnView = new System.Windows.Forms.Button();
            this.comboBoxDosen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNIDN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jenis Perlombaan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nama Lomba";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Penyelenggara";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tanggal";
            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(111, 182);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(100, 20);
            this.txtNIM.TabIndex = 7;
            this.txtNIM.TextChanged += new System.EventHandler(this.txtNIM_TextChanged);
            // 
            // txtNamaLomba
            // 
            this.txtNamaLomba.Location = new System.Drawing.Point(111, 252);
            this.txtNamaLomba.Name = "txtNamaLomba";
            this.txtNamaLomba.Size = new System.Drawing.Size(100, 20);
            this.txtNamaLomba.TabIndex = 9;
            this.txtNamaLomba.TextChanged += new System.EventHandler(this.txtNamaLomba_TextChanged);
            // 
            // txtPenyelenggara
            // 
            this.txtPenyelenggara.Location = new System.Drawing.Point(111, 285);
            this.txtPenyelenggara.Name = "txtPenyelenggara";
            this.txtPenyelenggara.Size = new System.Drawing.Size(100, 20);
            this.txtPenyelenggara.TabIndex = 10;
            this.txtPenyelenggara.TextChanged += new System.EventHandler(this.txtPenyelenggara_TextChanged);
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(111, 319);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerTanggal.TabIndex = 11;
            this.dateTimePickerTanggal.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxJenisMabar
            // 
            this.comboBoxJenisMabar.FormattingEnabled = true;
            this.comboBoxJenisMabar.Location = new System.Drawing.Point(111, 219);
            this.comboBoxJenisMabar.Name = "comboBoxJenisMabar";
            this.comboBoxJenisMabar.Size = new System.Drawing.Size(121, 21);
            this.comboBoxJenisMabar.TabIndex = 12;
            this.comboBoxJenisMabar.SelectedIndexChanged += new System.EventHandler(this.comboBoxJenisMabar_SelectedIndexChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(617, 267);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(617, 296);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(617, 238);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 16;
            this.btnView.Text = "Show";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // comboBoxDosen
            // 
            this.comboBoxDosen.FormattingEnabled = true;
            this.comboBoxDosen.Location = new System.Drawing.Point(111, 359);
            this.comboBoxDosen.Name = "comboBoxDosen";
            this.comboBoxDosen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDosen.TabIndex = 17;
            this.comboBoxDosen.SelectedIndexChanged += new System.EventHandler(this.comboBoxDosen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dosen";
            // 
            // txtNIDN
            // 
            this.txtNIDN.Location = new System.Drawing.Point(111, 399);
            this.txtNIDN.Name = "txtNIDN";
            this.txtNIDN.Size = new System.Drawing.Size(100, 20);
            this.txtNIDN.TabIndex = 19;
            // 
            // Mahasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNIDN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDosen);
            this.Controls.Add(this.btnView);
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
            this.Controls.Add(this.dataGridView1);
            this.Name = "Mahasiswa";
            this.Text = "Mahasiswa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox comboBoxDosen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNIDN;
    }
}