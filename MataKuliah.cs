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

        private void MataKuliahPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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
            string query = "SELECT m.KodeMataKuliah AS Course_ID, m.NamaMataKuliah AS Course, u.Nama AS Lecturer FROM matakuliah m JOIN user u ON (m.UserID = u.UserID) ORDER BY Course_ID ASC";
            DataTable matkulData = connect.RetrieveData(query);

            dataGridViewMatKul.DataSource = matkulData;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MatKul = textBoxMatKul.Text;
            string MatKulName = textBoxMatKulName.Text;
            DataRowView selectedDosen = (DataRowView)comboBoxDosenPengampu.SelectedItem;
            string userID = Convert.ToString(selectedDosen["UserID"]);

            if (string.IsNullOrWhiteSpace(MatKul) || string.IsNullOrWhiteSpace(MatKulName))
            {
                MessageBox.Show("Course ID and Name must not be blank.");
                return;
            }

            if (AddMatKul(MatKul, MatKulName, userID))
            {
                textBoxMatKul.Clear();
                textBoxMatKulName.Clear();
            }
            else
            {
                MessageBox.Show("Course failed to be added.");
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
                    MessageBox.Show("Course ID already exist.");
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

            if (string.IsNullOrWhiteSpace(MatKul) || string.IsNullOrWhiteSpace(MatKulName))
            {
                MessageBox.Show("Course ID and Name must not be blank.");
                return;
            }

            // Check if the mata kuliah exists in the database before updating
            if (IsMatKulExists(MatKul))
            {
                if (UpdateMatKul(MatKul, MatKulName, userID))
                {
                    textBoxMatKul.Clear();
                    textBoxMatKulName.Clear();
                }
                else
                {
                    MessageBox.Show("Course failed to be edited.");
                }
            }
            else
            {
                MessageBox.Show("Course does not found.");
            }

            refreshData();
        }

        private bool IsMatKulExists(string MatKul)
        {
            // Implement logic to check whether MatKul exists in the database
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE KodeMataKuliah = '{MatKul}'";
            int count = Convert.ToInt32(connect.ExecuteScalar(query));

            return count > 0;
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

            if (IsMatKulExists(MatKul))
            {
                if (RemoveMatKul(MatKul))
                {
                    textBoxMatKul.Clear();
                }
                else
                {
                    MessageBox.Show("Course failed to be deleted.");
                }
            }
            else
            {
                MessageBox.Show("Course does not found.");
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
