namespace StudentAttendanceSystem
{
    partial class MataKuliah
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
            this.btnBack = new System.Windows.Forms.Button();
            this.textBoxMatKul = new System.Windows.Forms.TextBox();
            this.lblMatKul = new System.Windows.Forms.Label();
            this.dataGridViewMatKul = new System.Windows.Forms.DataGridView();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDosenPengampu = new System.Windows.Forms.Label();
            this.lblMatKulName = new System.Windows.Forms.Label();
            this.textBoxMatKulName = new System.Windows.Forms.TextBox();
            this.comboBoxDosenPengampu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatKul)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(670, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 48);
            this.btnBack.TabIndex = 50;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // textBoxMatKul
            // 
            this.textBoxMatKul.Location = new System.Drawing.Point(198, 20);
            this.textBoxMatKul.Name = "textBoxMatKul";
            this.textBoxMatKul.Size = new System.Drawing.Size(235, 26);
            this.textBoxMatKul.TabIndex = 49;
            // 
            // lblMatKul
            // 
            this.lblMatKul.AutoSize = true;
            this.lblMatKul.Location = new System.Drawing.Point(18, 26);
            this.lblMatKul.Name = "lblMatKul";
            this.lblMatKul.Size = new System.Drawing.Size(133, 20);
            this.lblMatKul.TabIndex = 48;
            this.lblMatKul.Text = "Kode Mata Kuliah";
            // 
            // dataGridViewMatKul
            // 
            this.dataGridViewMatKul.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMatKul.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatKul.Location = new System.Drawing.Point(16, 208);
            this.dataGridViewMatKul.Name = "dataGridViewMatKul";
            this.dataGridViewMatKul.ReadOnly = true;
            this.dataGridViewMatKul.RowHeadersWidth = 62;
            this.dataGridViewMatKul.RowTemplate.Height = 28;
            this.dataGridViewMatKul.Size = new System.Drawing.Size(768, 230);
            this.dataGridViewMatKul.TabIndex = 45;
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(670, 140);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(114, 48);
            this.btnDisplay.TabIndex = 44;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(463, 140);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(114, 48);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(239, 140);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 48);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(22, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 48);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDosenPengampu
            // 
            this.lblDosenPengampu.AutoSize = true;
            this.lblDosenPengampu.Location = new System.Drawing.Point(18, 106);
            this.lblDosenPengampu.Name = "lblDosenPengampu";
            this.lblDosenPengampu.Size = new System.Drawing.Size(137, 20);
            this.lblDosenPengampu.TabIndex = 37;
            this.lblDosenPengampu.Text = "Dosen Pengampu";
            // 
            // lblMatKulName
            // 
            this.lblMatKulName.AutoSize = true;
            this.lblMatKulName.Location = new System.Drawing.Point(18, 65);
            this.lblMatKulName.Name = "lblMatKulName";
            this.lblMatKulName.Size = new System.Drawing.Size(138, 20);
            this.lblMatKulName.TabIndex = 36;
            this.lblMatKulName.Text = "Nama Mata Kuliah";
            // 
            // textBoxMatKulName
            // 
            this.textBoxMatKulName.Location = new System.Drawing.Point(198, 59);
            this.textBoxMatKulName.Name = "textBoxMatKulName";
            this.textBoxMatKulName.Size = new System.Drawing.Size(235, 26);
            this.textBoxMatKulName.TabIndex = 35;
            // 
            // comboBoxDosenPengampu
            // 
            this.comboBoxDosenPengampu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDosenPengampu.FormattingEnabled = true;
            this.comboBoxDosenPengampu.Location = new System.Drawing.Point(198, 103);
            this.comboBoxDosenPengampu.Name = "comboBoxDosenPengampu";
            this.comboBoxDosenPengampu.Size = new System.Drawing.Size(235, 28);
            this.comboBoxDosenPengampu.TabIndex = 51;
            // 
            // MataKuliah
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxDosenPengampu);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBoxMatKul);
            this.Controls.Add(this.lblMatKul);
            this.Controls.Add(this.dataGridViewMatKul);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDosenPengampu);
            this.Controls.Add(this.lblMatKulName);
            this.Controls.Add(this.textBoxMatKulName);
            this.Name = "MataKuliah";
            this.Text = "MataKuliah";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatKul)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox textBoxMatKul;
        private System.Windows.Forms.Label lblMatKul;
        private System.Windows.Forms.DataGridView dataGridViewMatKul;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblDosenPengampu;
        private System.Windows.Forms.Label lblMatKulName;
        private System.Windows.Forms.TextBox textBoxMatKulName;
        private System.Windows.Forms.ComboBox comboBoxDosenPengampu;
    }
}