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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPresensi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEvent
            // 
            this.btnEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.Location = new System.Drawing.Point(286, 268);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(182, 49);
            this.btnEvent.TabIndex = 23;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = true;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(424, 427);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 49);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPresensi
            // 
            this.btnPresensi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresensi.Location = new System.Drawing.Point(520, 268);
            this.btnPresensi.Name = "btnPresensi";
            this.btnPresensi.Size = new System.Drawing.Size(130, 49);
            this.btnPresensi.TabIndex = 21;
            this.btnPresensi.Text = "Presensi";
            this.btnPresensi.UseVisualStyleBackColor = true;
            this.btnPresensi.Click += new System.EventHandler(this.btnPresensi_Click);
            // 
            // LecturerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPresensi);
            this.Name = "LecturerPage";
            this.Text = "Lecturer Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEvent;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPresensi;
    }
}