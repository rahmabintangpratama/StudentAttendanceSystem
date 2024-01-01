namespace StudentAttendanceSystem
{
    partial class AttendancePage
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
            this.lblPresensiID = new System.Windows.Forms.Label();
            this.textBoxPresensiID = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewAttendance = new System.Windows.Forms.DataGridView();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxKehadiran = new System.Windows.Forms.ComboBox();
            this.lblKehadiran = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPresensiID
            // 
            this.lblPresensiID.AutoSize = true;
            this.lblPresensiID.Location = new System.Drawing.Point(51, 34);
            this.lblPresensiID.Name = "lblPresensiID";
            this.lblPresensiID.Size = new System.Drawing.Size(113, 20);
            this.lblPresensiID.TabIndex = 38;
            this.lblPresensiID.Text = "Attendance ID";
            // 
            // textBoxPresensiID
            // 
            this.textBoxPresensiID.Location = new System.Drawing.Point(186, 31);
            this.textBoxPresensiID.Name = "textBoxPresensiID";
            this.textBoxPresensiID.Size = new System.Drawing.Size(306, 26);
            this.textBoxPresensiID.TabIndex = 37;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(782, 200);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(114, 48);
            this.btnDisplay.TabIndex = 36;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(627, 200);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 48);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(782, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 48);
            this.btnUpdate.TabIndex = 34;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(627, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 48);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewAttendance
            // 
            this.dataGridViewAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttendance.Location = new System.Drawing.Point(50, 267);
            this.dataGridViewAttendance.Name = "dataGridViewAttendance";
            this.dataGridViewAttendance.ReadOnly = true;
            this.dataGridViewAttendance.RowHeadersWidth = 62;
            this.dataGridViewAttendance.RowTemplate.Height = 28;
            this.dataGridViewAttendance.Size = new System.Drawing.Size(846, 302);
            this.dataGridViewAttendance.TabIndex = 32;
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Location = new System.Drawing.Point(186, 146);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(306, 28);
            this.comboBoxEvent.TabIndex = 27;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(51, 87);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(66, 20);
            this.lblStudent.TabIndex = 26;
            this.lblStudent.Text = "Student";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(51, 149);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(50, 20);
            this.lblEvent.TabIndex = 25;
            this.lblEvent.Text = "Event";
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(186, 87);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(306, 28);
            this.comboBoxStudent.TabIndex = 24;
            // 
            // comboBoxKehadiran
            // 
            this.comboBoxKehadiran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKehadiran.FormattingEnabled = true;
            this.comboBoxKehadiran.Location = new System.Drawing.Point(186, 203);
            this.comboBoxKehadiran.Name = "comboBoxKehadiran";
            this.comboBoxKehadiran.Size = new System.Drawing.Size(306, 28);
            this.comboBoxKehadiran.TabIndex = 40;
            // 
            // lblKehadiran
            // 
            this.lblKehadiran.AutoSize = true;
            this.lblKehadiran.Location = new System.Drawing.Point(51, 206);
            this.lblKehadiran.Name = "lblKehadiran";
            this.lblKehadiran.Size = new System.Drawing.Size(56, 20);
            this.lblKehadiran.TabIndex = 39;
            this.lblKehadiran.Text = "Status";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(782, 17);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 48);
            this.btnBack.TabIndex = 51;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // AttendancePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 616);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.comboBoxKehadiran);
            this.Controls.Add(this.lblKehadiran);
            this.Controls.Add(this.lblPresensiID);
            this.Controls.Add(this.textBoxPresensiID);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewAttendance);
            this.Controls.Add(this.comboBoxEvent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.comboBoxStudent);
            this.Name = "AttendancePage";
            this.Text = "AttendancePage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPresensiID;
        private System.Windows.Forms.TextBox textBoxPresensiID;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridViewAttendance;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxKehadiran;
        private System.Windows.Forms.Label lblKehadiran;
        private System.Windows.Forms.Button btnBack;
    }
}