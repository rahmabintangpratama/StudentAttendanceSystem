using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace StudentAttendanceSystem
{
    public partial class LoginPage : Form
    {
        private Connect connect;
        private UserProcess userProcess;
        public static LoginSession currentLoginSession;


        public LoginPage()
        {
            InitializeComponent();
            connect = new Connect();
            userProcess = new UserProcess();

            this.FormClosing += LoginPage_FormClosing;
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (LoginUser(email, password))
            {
                long userID = userProcess.GetUserID(email);
                int role = GetUserRole(email);

                currentLoginSession = new LoginSession(email, userProcess.GetUserRole(email), userID);
                OpenHomePage(role);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed. Check your email and password.");
            }
        }

        private bool LoginUser(string email, string password)
        {
            bool isValid = userProcess.ValidateUser(email, password);

            return isValid;
        }

        private int GetUserRole(string email)
        {
            string query = $"SELECT Role FROM user WHERE email = '{email}'";
            DataTable result = connect.RetrieveData(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Role"]);
            }

            return 0;
        }

        private void OpenHomePage(int Role)
        {
            switch (Role)
            {
                case 1: // Administrator
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
                    MessageBox.Show("Role does not valid.");
                    break;
            }

            this.Hide();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.ForeColor = Color.Black;
            textBoxPassword.PasswordChar = '●';
        }
    }

    public class LoginSession
    {
        public long UserID { get; private set; }
        public string Email { get; private set; }
        public int UserRole { get; private set; }

        public LoginSession(string email, int userRole, long userID)
        {
            Email = email;
            UserRole = userRole;
            UserID = userID;
        }

        public void ClearLoginSession()
        {
            Email = null;
            UserRole = 0;
            UserID = 0;
        }
    }
}