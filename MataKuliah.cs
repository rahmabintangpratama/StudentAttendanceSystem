using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentAttendanceSystem
{
    public partial class MataKuliah : Form
    {
        private Connect connect;
        private MatKulProcess matkulProcess;
        public MataKuliah()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MataKuliahPage_FormClosing);

            connect = new Connect();
            matkulProcess = new MatKulProcess();
            ComboBoxDosenPengampuData();
            refreshData();
        }

        private void ComboBoxDosenPengampuData()
        {
            DataTable dosenTable = GetDosen();

            comboBoxDosenPengampu.DisplayMember = "Nama";
            comboBoxDosenPengampu.ValueMember = "UserID";

            comboBoxDosenPengampu.DataSource = dosenTable;
        }

        private DataTable GetDosen()
        {
            string query = "SELECT UserID, Nama FROM user WHERE Role = 2";
            return connect.RetrieveData(query);
        }

        // Tambahkan event handler untuk FormClosing
        private void MataKuliahPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tampilkan dialog konfirmasi sebelum menutup form
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna mengklik Yes, kembali ke halaman login
                AdministratorPage adminPage = new AdministratorPage();
                adminPage.Show();
                this.Hide();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            string query = "SELECT m.KodeMataKuliah AS Kode_Mata_Kuliah, m.NamaMataKuliah AS Mata_Kuliah, u.Nama AS Dosen_Pengampu FROM matakuliah m JOIN user u ON (m.UserID = u.UserID) ORDER BY Kode_Mata_Kuliah ASC";
            DataTable matkulData = connect.RetrieveData(query);

            dataGridViewMatKul.DataSource = matkulData;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MatKul = textBoxMatKul.Text;
            string MatKulName = textBoxMatKulName.Text;
            DataRowView selectedDosen = (DataRowView)comboBoxDosenPengampu.SelectedItem;
            string userID = Convert.ToString(selectedDosen["UserID"]);

            if (AddMatKul(MatKul, MatKulName, userID))
            {
                MessageBox.Show("\"Mata Kuliah\" successfuly added.");
                textBoxMatKul.Clear();
                textBoxMatKulName.Clear();
            }
            else
            {
                MessageBox.Show("\"Mata Kuliah\" failed to be added.");
            }

            refreshData();
        }

        private bool AddMatKul(string MatKul, string MatKulName, string UserID)
        {
            try
            {
                if (CheckMatKulAvailability(MatKul))
                {
                    matkulProcess.InputMatKul(MatKul, MatKulName, UserID);
                    return true;
                }
                else
                {
                    MessageBox.Show("\"Kode Mata Kuliah\" already exist..");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private bool CheckMatKulAvailability(string MatKul)
        {
            MatKulProcess matkulProcess = new MatKulProcess();
            return matkulProcess.CheckMatKulAvailability(MatKul);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string MatKul = textBoxMatKul.Text;
            string MatKulName = textBoxMatKulName.Text;
            DataRowView selectedDosen = (DataRowView)comboBoxDosenPengampu.SelectedItem;
            string userID = Convert.ToString(selectedDosen["UserID"]);

            if (UpdateMatKul(MatKul, MatKulName, userID))
            {
                MessageBox.Show("\"Mata Kuliah\" successfuly edited.");
                textBoxMatKul.Clear();
                textBoxMatKulName.Clear();
            }
            else
            {
                MessageBox.Show("\"Mata Kuliah\" Failed to be edited.");
            }

            refreshData();
        }

        private bool UpdateMatKul(string MatKul, string MatKulName, string UserID)
        {
            try
            {
                matkulProcess.UpdateMatKul(MatKul, MatKulName, UserID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string MatKul = textBoxMatKul.Text;

            if (RemoveMatKul(MatKul))
            {
                MessageBox.Show("\"Mata Kuliah\" Successfuly Deleted.");
                textBoxMatKul.Clear();
            }
            else
            {
                MessageBox.Show("\"Mata Kuliah\" failed to be deleted.");
            }

            refreshData();
        }

        private bool RemoveMatKul(string MatKul)
        {
            try
            {
                matkulProcess.RemoveMatKul(MatKul);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
