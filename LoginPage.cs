﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SessionManager.h;

namespace StudentAttendanceSystem
{
    public partial class LoginPage : Form
    {
        private const string connectionString = "server=127.0.0.1; database=db_studentattendancesystem; user=root; password=";


        public LoginPage()
        {
            InitializeComponent(); ;

            // Menambahkan event handler ketika form ditutup
            this.FormClosing += LoginPage_FormClosing;
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Pastikan untuk menghentikan aplikasi jika form utama ditutup
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (LoginUser(email, password))
            {
                long loggedInUserID = GetLoggedInUserID(email);
                int userRole = GetUserRole(email);

                SessionManager.SetLoggedInUser(loggedInUserID, userRole);

                OpenHomePage(userRole);
            }
            else
            {
                MessageBox.Show("Login failed. Check your email and password.");
            }
        }

        private bool LoginUser(string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Role FROM User WHERE Email = @Email AND Password = @Password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();

                    return result != null; // Jika result tidak null, login berhasil
                }
            }
        }

        private int GetUserRole(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Role FROM user WHERE Email = @Email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    object result = command.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0; // Mengembalikan nilai role atau 0 jika tidak ditemukan
                }
            }
        }

        private void OpenHomePage(int Role)
        {
            switch (Role)
            {
                case 1: // Admin
                    AdministratorPage adminPage = new AdministratorPage();
                    adminPage.Show();
                    break;

                case 2: // Dosen
                    LecturerPage lecturerPage = new LecturerPage();
                    lecturerPage.Show();
                    break;

                case 3: // Mahasiswa
                    StudentPage studentPage = new StudentPage();
                    studentPage.Show();
                    break;

                default:
                    MessageBox.Show("Role tidak valid.");
                    break;
            }

            this.Hide(); // Sembunyikan form login setelah login berhasil
        }
    }
}