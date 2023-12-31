namespace StudentAttendanceSystem
{
    partial class AdministratorPage
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
            this.btnPresensi = new System.Windows.Forms.Button();
            this.btnMatkul = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPresensi
            // 
            this.btnPresensi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresensi.Location = new System.Drawing.Point(550, 201);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(130, 49);
            this.btnPresensi.TabIndex = 16;
            this.btnPresensi.Text = "Presensi";
            this.btnPresensi.UseVisualStyleBackColor = true;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // btnMatkul
            // 
            this.btnMatkul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatkul.Location = new System.Drawing.Point(308, 201);
            this.btnMatkul.Name = "btnMatkul";
            this.btnMatkul.Size = new System.Drawing.Size(182, 49);
            this.btnMatkul.TabIndex = 15;
            this.btnMatkul.Text = "Mata Kuliah";
            this.btnMatkul.UseVisualStyleBackColor = true;
            this.btnMatkul.Click += new System.EventHandler(this.btnMatkul_Click);
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Location = new System.Drawing.Point(121, 201);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(130, 49);
            this.btnUser.TabIndex = 14;
            this.btnUser.Text = "User";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(335, 360);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 49);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AdministratorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPresensi);
            this.Controls.Add(this.btnMatkul);
            this.Controls.Add(this.btnUser);
            this.Name = "AdministratorPage";
            this.Text = "Administrator Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPresensi;
        private System.Windows.Forms.Button btnMatkul;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnBack;
    }
}