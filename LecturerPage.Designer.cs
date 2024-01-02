namespace StudentAttendanceSystem
{
    partial class LecturerPage
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
            this.btnEvent = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPresensi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEvent
            // 
            this.btnEvent.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.Color.White;
            this.btnEvent.Location = new System.Drawing.Point(12, 30);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(182, 49);
            this.btnEvent.TabIndex = 1;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = false;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Red;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(439, 30);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(130, 49);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPresensi
            // 
            this.btnPresensi.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPresensi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresensi.ForeColor = System.Drawing.Color.White;
            this.btnPresensi.Location = new System.Drawing.Point(251, 30);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(130, 49);
            this.btnPresensi.TabIndex = 2;
            this.btnPresensi.Text = "Presensi";
            this.btnPresensi.UseVisualStyleBackColor = false;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // LecturerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 109);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnPresensi);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(603, 165);
            this.MinimumSize = new System.Drawing.Size(603, 165);
            this.Name = "LecturerPage";
            this.Text = "Lecturer Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEvent;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnPresensi;
    }
}