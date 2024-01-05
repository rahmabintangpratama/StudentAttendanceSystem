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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPresensi
            // 
            this.btnPresensi.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPresensi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresensi.ForeColor = System.Drawing.Color.White;
            this.btnPresensi.Location = new System.Drawing.Point(198, 110);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(182, 49);
            this.btnPresensi.TabIndex = 4;
            this.btnPresensi.Text = "Attendance";
            this.btnPresensi.UseVisualStyleBackColor = false;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // btnMatkul
            // 
            this.btnMatkul.BackColor = System.Drawing.Color.Sienna;
            this.btnMatkul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatkul.ForeColor = System.Drawing.Color.White;
            this.btnMatkul.Location = new System.Drawing.Point(12, 110);
            this.btnMatkul.Name = "btnMatkul";
            this.btnMatkul.Size = new System.Drawing.Size(130, 49);
            this.btnMatkul.TabIndex = 2;
            this.btnMatkul.Text = "Course";
            this.btnMatkul.UseVisualStyleBackColor = false;
            this.btnMatkul.Click += new System.EventHandler(this.btnMatkul_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(12, 29);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(130, 49);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "User";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Red;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(436, 29);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(130, 49);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.Color.White;
            this.btnEvent.Location = new System.Drawing.Point(198, 29);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(182, 49);
            this.btnEvent.TabIndex = 3;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = false;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // AdministratorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(578, 185);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnPresensi);
            this.Controls.Add(this.btnMatkul);
            this.Controls.Add(this.btnUser);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 241);
            this.MinimumSize = new System.Drawing.Size(600, 241);
            this.Name = "AdministratorPage";
            this.Text = "Administrator Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPresensi;
        private System.Windows.Forms.Button btnMatkul;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnEvent;
    }
}