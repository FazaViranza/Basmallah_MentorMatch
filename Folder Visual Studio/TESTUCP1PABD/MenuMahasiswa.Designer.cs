namespace TESTUCP1PABD
{
    partial class MenuMahasiswa
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnUpdateHasil = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(269, 201);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnUpdateHasil
            // 
            this.btnUpdateHasil.Location = new System.Drawing.Point(409, 201);
            this.btnUpdateHasil.Name = "btnUpdateHasil";
            this.btnUpdateHasil.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateHasil.TabIndex = 1;
            this.btnUpdateHasil.Text = "Afdet";
            this.btnUpdateHasil.UseVisualStyleBackColor = true;
            this.btnUpdateHasil.Click += new System.EventHandler(this.btnUpdateHasil_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(336, 239);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MenuMahasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUpdateHasil);
            this.Controls.Add(this.btnSubmit);
            this.Name = "MenuMahasiswa";
            this.Text = "MahasiswaPilihan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnUpdateHasil;
        private System.Windows.Forms.Button btnLogout;
    }
}