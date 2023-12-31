﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

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
            textBoxUserId.KeyPress += new KeyPressEventHandler(textBoxUserID_KeyPress);
            ComboBoxRoleData();
            refreshData();
        }

        private void UserPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan input angka dan kontrol khusus (seperti Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxUserId_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxUserId.Text) && !long.TryParse(textBoxUserId.Text, out _))
            {
                MessageBox.Show("Please enter a valid User ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Text = string.Empty;
            }

            if (textBoxUserId.Text.Length > 18)
            {
                MessageBox.Show("User ID should be limited to 18 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUserId.Text = textBoxUserId.Text.Substring(0, 18);
                textBoxUserId.SelectionStart = textBoxUserId.Text.Length;
            }
        }

        private void ComboBoxRoleData()
        {
            DataTable roleTable = GetRole();

            comboBoxRole.DisplayMember = "job";
            comboBoxRole.ValueMember = "Role";

            comboBoxRole.DataSource = roleTable;
        }

        private DataTable GetRole()
        {
            string queryRole = "SELECT Role, job FROM role_value";
            return connect.RetrieveData(queryRole);
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
            string query = "SELECT u.UserID AS User_ID, u.Nama AS Name, u.Email AS Email, r.job AS Role FROM user u JOIN role_value r ON (u.Role = r.Role) ORDER BY Role ASC, User_ID ASC";
            DataTable userData = connect.RetrieveData(query);

            dataGridViewUser.DataSource = userData;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserId.Text))
            {
                MessageBox.Show("User ID cannot be empty.");
                return;
            }

            string userID = textBoxUserId.Text;
            string nama = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            DataRowView selectedRole = (DataRowView)comboBoxRole.SelectedItem;
            int Role = Convert.ToInt32(selectedRole["Role"]);

            if (AddUser(userID, nama, email, password, Role))
            {
                textBoxUserId.Clear();
                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();
            }
            else
            {
                MessageBox.Show("Account failed to be added.");
            }

            refreshData();
        }

        private bool AddUser(string userID, string nama, string email, string password, int Role)
        {
            try
            {
                if (CheckEmailAvailability(email))
                {
                    userProcess.InputUser(userID, nama, email, password, Role);
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

        private bool CheckEmailAvailability(string email)
        {
            UserProcess userProcess = new UserProcess();
            return userProcess.CheckEmailAvailability(email);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserId.Text))
            {
                MessageBox.Show("User ID cannot be empty.");
                return;
            }

            long UserID = Convert.ToInt64(textBoxUserId.Text);
            string nama = textBoxName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            DataRowView selectedRole = (DataRowView)comboBoxRole.SelectedItem;
            int Role = Convert.ToInt32(selectedRole["Role"]);

            // Check if the user exists in the database before updating
            if (IsUserExists(UserID))
            {
                if (UpdateUser(UserID, nama, email, password, Role))
                {
                    textBoxUserId.Clear();
                    textBoxName.Clear();
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Account failed to be edited.");
                }
            }
            else
            {
                MessageBox.Show("User not found in the database.");
            }

            refreshData();
        }

        private bool IsUserExists(long UserID)
        {
            // Implement logic to check whether UserID exists in the database
            string query = $"SELECT COUNT(*) FROM user WHERE UserID = {UserID}";
            int count = Convert.ToInt32(connect.ExecuteScalar(query));

            return count > 0;
        }

        private bool UpdateUser(long UserID, string nama, string email, string password, int Role)
        {
            try
            {
                userProcess.UpdateUser(UserID, nama, email, password, Role);
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
            long UserID = Convert.ToInt64(textBoxUserId.Text);

            if (IsUserExists(UserID))
            {
                if (DeleteUser(UserID))
                {
                    textBoxUserId.Clear();
                    textBoxName.Clear();
                    textBoxEmail.Clear();
                    textBoxPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Account failed to be deleted.");

                }
            }
            else
            {
                MessageBox.Show("User not found in the database.");
            }

            refreshData();
        }

        private bool DeleteUser(long UserID)
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
