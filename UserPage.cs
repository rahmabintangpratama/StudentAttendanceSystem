using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentAttendanceSystem
{
    public partial class UserPage : Form
    {
        private Connect connect;
        private UserProcess userProcess;
        public UserPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(UserPage_FormClosing);

            connect = new Connect();
            userProcess = new UserProcess();
            displayData();
        }

        // Tambahkan event handler untuk FormClosing
        private void UserPage_FormClosing(object sender, FormClosingEventArgs e)
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
            else
            {
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void displayData()
        {
            string query = "SELECT UserID, Nama, Email, Role FROM user ORDER BY Role ASC, UserID ASC";
            DataTable userData = connect.ExecuteQuery(query);

            dataGridViewUser.DataSource = userData;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userID = textBoxUserId.Text;
            string nama = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string role = textBoxRole.Text;
            
            if (AddUser(userID, nama, email, password, role))
            {
                MessageBox.Show("Account successfuly added.");
                textBoxUserId.Clear();
                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();
                textBoxRole.Clear();
            }
            else
            {
                MessageBox.Show("Account failed to be added.");
            }

            displayData();
        }

        private bool AddUser(string userID, string nama, string email, string password, string role)
        {
            try
            {
                if (IsEmailAvailable(email))
                {
                    // Tambahkan user baru
                    userProcess.InputUser(userID, nama, email, password, role);
                    return true;
                }
                else
                {
                    MessageBox.Show("Email already used. Please use another email.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private bool IsEmailAvailable(string email)
        {
            UserProcess userProcess = new UserProcess();
            // Cek apakah email ada dalam database
            return userProcess.IsEmailAvailable(email);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(textBoxUserId.Text);
            string nama = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string role = textBoxRole.Text;

            if (UpdateUser(UserID, nama, email, password, role))
            {
                MessageBox.Show("Account successfuly edited.");
                textBoxUserId.Clear();
                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();
                textBoxRole.Clear();
            }
            else
            {
                MessageBox.Show("Account Failed to be edited.");
            }

            displayData();
        }

        private bool UpdateUser(int UserID, string nama, string email, string password, string role)
        {
            try
            {
                userProcess.UpdateUser(UserID, nama, email, password, role);
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
            int UserID = Convert.ToInt32(textBoxUserId.Text);

            if (DeleteUser(UserID))
            {
                MessageBox.Show("Account Successfuly Deleted.");
                textBoxUserId.Clear();
            }
            else
            {
                MessageBox.Show("Account failed to be deleted.");
            }

            displayData();
        }

        private bool DeleteUser(int UserID)
        {
            try
            {
                userProcess.RemoveUser(UserID);
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
