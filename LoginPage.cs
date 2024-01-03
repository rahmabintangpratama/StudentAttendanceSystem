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
        private UserProcess userProcess;
        public static LoginSession currentLoginSession;
        private const string connectionString = "server=127.0.0.1; database=db_studentattendancesystem; user=root; password=";


        public LoginPage()
        {
            InitializeComponent(); 
            userProcess = new UserProcess();

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
                long userID = userProcess.GetUserID(email);
                currentLoginSession = new LoginSession(email, userProcess.GetUserRole(email), userID);
                int userRole = GetUserRole(email);

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

                // Perbarui perintah SQL untuk menggunakan parameter dengan benar
                string query = "SELECT Password, Role FROM user WHERE Email = @Email";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Pastikan parameter @Email ditambahkan
                    command.Parameters.AddWithValue("@Email", email);

                    // Pastikan parameter @Password ditambahkan
                    command.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = reader["Password"].ToString();

                            // Verifikasi password dengan membandingkan hash
                            return VerifyPassword(password, hashedPassword);
                        }
                    }
                }
            }

            return false;
        }

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                string inipassword = builder.ToString();
                Console.WriteLine($"Hashed Password: {inipassword}");

                // Bandingkan hash input password dengan hash yang ada di database
                return string.Equals(builder.ToString(), hashedPassword, StringComparison.OrdinalIgnoreCase);
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