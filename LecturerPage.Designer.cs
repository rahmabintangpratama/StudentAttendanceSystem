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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblStudentAttendanceForm = new System.Windows.Forms.Label();
            this.lblNIM = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblKodeMataKuliah = new System.Windows.Forms.Label();
            this.lblKehadiran = new System.Windows.Forms.Label();
            this.NIM_comboBox = new System.Windows.Forms.ComboBox();
            this.Kehadiran_comboBox = new System.Windows.Forms.ComboBox();
            this.KodeMataKuliah_comboBox = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 439);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(954, 254);
            this.dataGridView1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(342, 212);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(362, 35);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // lblStudentAttendanceForm
            // 
            this.lblStudentAttendanceForm.AutoSize = true;
            this.lblStudentAttendanceForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentAttendanceForm.Location = new System.Drawing.Point(336, 9);
            this.lblStudentAttendanceForm.Name = "lblStudentAttendanceForm";
            this.lblStudentAttendanceForm.Size = new System.Drawing.Size(353, 36);
            this.lblStudentAttendanceForm.TabIndex = 2;
            this.lblStudentAttendanceForm.Text = "Student Attendance Form";
            // 
            // lblNIM
            // 
            this.lblNIM.AutoSize = true;
            this.lblNIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIM.Location = new System.Drawing.Point(89, 110);
            this.lblNIM.Name = "lblNIM";
            this.lblNIM.Size = new System.Drawing.Size(63, 29);
            this.lblNIM.TabIndex = 3;
            this.lblNIM.Text = "NIM:";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggal.Location = new System.Drawing.Point(89, 212);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(108, 29);
            this.lblTanggal.TabIndex = 5;
            this.lblTanggal.Text = "Tanggal:";
            // 
            // lblKodeMataKuliah
            // 
            this.lblKodeMataKuliah.AutoSize = true;
            this.lblKodeMataKuliah.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKodeMataKuliah.Location = new System.Drawing.Point(89, 160);
            this.lblKodeMataKuliah.Name = "lblKodeMataKuliah";
            this.lblKodeMataKuliah.Size = new System.Drawing.Size(208, 29);
            this.lblKodeMataKuliah.TabIndex = 6;
            this.lblKodeMataKuliah.Text = "Kode Mata Kuliah:";
            // 
            // lblKehadiran
            // 
            this.lblKehadiran.AutoSize = true;
            this.lblKehadiran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKehadiran.Location = new System.Drawing.Point(89, 269);
            this.lblKehadiran.Name = "lblKehadiran";
            this.lblKehadiran.Size = new System.Drawing.Size(129, 29);
            this.lblKehadiran.TabIndex = 7;
            this.lblKehadiran.Text = "Kehadiran:";
            // 
            // NIM_comboBox
            // 
            this.NIM_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIM_comboBox.FormattingEnabled = true;
            this.NIM_comboBox.Location = new System.Drawing.Point(342, 102);
            this.NIM_comboBox.Name = "NIM_comboBox";
            this.NIM_comboBox.Size = new System.Drawing.Size(362, 37);
            this.NIM_comboBox.TabIndex = 8;
            // 
            // Kehadiran_comboBox
            // 
            this.Kehadiran_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kehadiran_comboBox.FormattingEnabled = true;
            this.Kehadiran_comboBox.Location = new System.Drawing.Point(342, 266);
            this.Kehadiran_comboBox.Name = "Kehadiran_comboBox";
            this.Kehadiran_comboBox.Size = new System.Drawing.Size(362, 37);
            this.Kehadiran_comboBox.TabIndex = 9;
            // 
            // KodeMataKuliah_comboBox
            // 
            this.KodeMataKuliah_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KodeMataKuliah_comboBox.FormattingEnabled = true;
            this.KodeMataKuliah_comboBox.Location = new System.Drawing.Point(342, 157);
            this.KodeMataKuliah_comboBox.Name = "KodeMataKuliah_comboBox";
            this.KodeMataKuliah_comboBox.Size = new System.Drawing.Size(362, 37);
            this.KodeMataKuliah_comboBox.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(107, 359);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 49);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(322, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 49);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(536, 359);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(130, 49);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(749, 359);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(130, 49);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // LecturerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.KodeMataKuliah_comboBox);
            this.Controls.Add(this.Kehadiran_comboBox);
            this.Controls.Add(this.NIM_comboBox);
            this.Controls.Add(this.lblKehadiran);
            this.Controls.Add(this.lblKodeMataKuliah);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.lblNIM);
            this.Controls.Add(this.lblStudentAttendanceForm);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "LecturerPage";
            this.Text = "Lecturer Page";
            this.Load += new System.EventHandler(this.LecturerPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblStudentAttendanceForm;
        private System.Windows.Forms.Label lblNIM;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblKodeMataKuliah;
        private System.Windows.Forms.Label lblKehadiran;
        private System.Windows.Forms.ComboBox NIM_comboBox;
        private System.Windows.Forms.ComboBox Kehadiran_comboBox;
        private System.Windows.Forms.ComboBox KodeMataKuliah_comboBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}