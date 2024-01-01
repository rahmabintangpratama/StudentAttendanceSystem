namespace StudentAttendanceSystem
{
    partial class EventPage
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
            this.comboBoxMatKulName = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.textBoxEvent = new System.Windows.Forms.TextBox();
            this.lblEventName = new System.Windows.Forms.Label();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblMatKulName = new System.Windows.Forms.Label();
            this.textBoxRuang = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePickerTanggal = new System.Windows.Forms.DateTimePicker();
            this.textBoxEventID = new System.Windows.Forms.TextBox();
            this.lblEventID = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMatKulName
            // 
            this.comboBoxMatKulName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMatKulName.FormattingEnabled = true;
            this.comboBoxMatKulName.Location = new System.Drawing.Point(198, 82);
            this.comboBoxMatKulName.Name = "comboBoxMatKulName";
            this.comboBoxMatKulName.Size = new System.Drawing.Size(235, 28);
            this.comboBoxMatKulName.TabIndex = 63;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(670, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 48);
            this.btnBack.TabIndex = 62;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBoxEvent
            // 
            this.textBoxEvent.Location = new System.Drawing.Point(198, 48);
            this.textBoxEvent.Name = "textBoxEvent";
            this.textBoxEvent.Size = new System.Drawing.Size(235, 26);
            this.textBoxEvent.TabIndex = 61;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(18, 54);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(96, 20);
            this.lblEventName.TabIndex = 60;
            this.lblEventName.Text = "Nama Event";
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.Location = new System.Drawing.Point(16, 208);
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersWidth = 62;
            this.dataGridViewEvent.RowTemplate.Height = 28;
            this.dataGridViewEvent.Size = new System.Drawing.Size(768, 230);
            this.dataGridViewEvent.TabIndex = 59;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(476, 147);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 48);
            this.btnDelete.TabIndex = 57;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(670, 78);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 48);
            this.btnUpdate.TabIndex = 56;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(476, 78);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 48);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(18, 122);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(57, 20);
            this.lblVenue.TabIndex = 54;
            this.lblVenue.Text = "Ruang";
            // 
            // lblMatKulName
            // 
            this.lblMatKulName.AutoSize = true;
            this.lblMatKulName.Location = new System.Drawing.Point(18, 85);
            this.lblMatKulName.Name = "lblMatKulName";
            this.lblMatKulName.Size = new System.Drawing.Size(138, 20);
            this.lblMatKulName.TabIndex = 53;
            this.lblMatKulName.Text = "Nama Mata Kuliah";
            // 
            // textBoxRuang
            // 
            this.textBoxRuang.Location = new System.Drawing.Point(198, 119);
            this.textBoxRuang.Name = "textBoxRuang";
            this.textBoxRuang.Size = new System.Drawing.Size(235, 26);
            this.textBoxRuang.TabIndex = 52;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 162);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(66, 20);
            this.lblDate.TabIndex = 64;
            this.lblDate.Text = "Tanggal";
            // 
            // dateTimePickerTanggal
            // 
            this.dateTimePickerTanggal.Location = new System.Drawing.Point(198, 156);
            this.dateTimePickerTanggal.Name = "dateTimePickerTanggal";
            this.dateTimePickerTanggal.Size = new System.Drawing.Size(235, 26);
            this.dateTimePickerTanggal.TabIndex = 65;
            // 
            // textBoxEventID
            // 
            this.textBoxEventID.Location = new System.Drawing.Point(198, 12);
            this.textBoxEventID.Name = "textBoxEventID";
            this.textBoxEventID.Size = new System.Drawing.Size(235, 26);
            this.textBoxEventID.TabIndex = 67;
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.Location = new System.Drawing.Point(18, 18);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(71, 20);
            this.lblEventID.TabIndex = 66;
            this.lblEventID.Text = "Event ID";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(670, 148);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(114, 48);
            this.btnDisplay.TabIndex = 68;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // EventPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.textBoxEventID);
            this.Controls.Add(this.lblEventID);
            this.Controls.Add(this.dateTimePickerTanggal);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.comboBoxMatKulName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBoxEvent);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.dataGridViewEvent);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.lblMatKulName);
            this.Controls.Add(this.textBoxRuang);
            this.Name = "EventPage";
            this.Text = "EventPage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMatKulName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBoxEvent;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.DataGridView dataGridViewEvent;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblMatKulName;
        private System.Windows.Forms.TextBox textBoxRuang;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggal;
        private System.Windows.Forms.TextBox textBoxEventID;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Button btnDisplay;
    }
}