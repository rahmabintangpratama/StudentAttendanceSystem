using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace StudentAttendanceSystem
{
    internal class UserProcess : IDisposable
    {
        private Connect connect;

        public UserProcess()
        {
            connect = new Connect();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public void InputUser(string userID, string nama, string email, string password, int Role)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty.");
                return;
            }

            string hashedPassword = HashPassword(password);

            string query = $"INSERT INTO user (UserID, Nama, Email, Password, Role) VALUES ('{userID}','{nama}', '{email}', '{hashedPassword}', '{Role}')";
            connect.RunCommand(query);

            MessageBox.Show("Account successfully added.");
        }

        public void UpdateUser(long UserID, string newNama, string newEmail, string newPassword, int newRole)
        {
            if (string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("New email and password cannot be empty.");
                return;
            }

            string hashedPassword = HashPassword(newPassword);

            try
            {
                int currentUserRole = GetUserRole(LoginPage.currentLoginSession.Email);
                long currentUserID = LoginPage.currentLoginSession.UserID;

                if (currentUserID == UserID)
                {
                    if (currentUserRole == 1 && newRole != 1)
                    {
                        MessageBox.Show("Cannot edit the role of the currently logged-in administrator.");
                        return;
                    }
                }

                if (!CheckEmailAvailabilityForEdit(UserID, newEmail))
                {
                    MessageBox.Show("Email already used by another user. Please use another email.");
                    return;
                }

                if (newRole != 2 && IsUserInMatKulTable(UserID))
                {
                    MessageBox.Show("Cannot edit the role of this user. The user is still listed in the \"Mata Kuliah\" table.");
                    return;
                }

                if (newRole != 3 && IsUserInAttendanceTable(UserID))
                {
                    MessageBox.Show("Cannot edit the role of this user. The user is still listed in the \"Presensi\" table.");
                    return;
                }

                string query = $"UPDATE user SET Nama = '{newNama}', Email = '{newEmail}', Password = '{hashedPassword}', Role = '{newRole}' WHERE UserID = {UserID}";
                connect.RunCommand(query);
                MessageBox.Show("User successfully edited.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An error occurred while editing the user.");
            }
        }

        private bool CheckEmailAvailabilityForEdit(long userID, string email)
        {
            // Check if the email is available for edit, excluding the current user
            string query = $"SELECT COUNT(*) FROM user WHERE email = '{email}' AND UserID != {userID}";
            int userCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return userCount == 0;
        }

        public void RemoveUser(long UserID)
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;

            try
            {
                if (currentUserID != UserID)
                {
                    if (IsUserInAttendanceTable(UserID))
                    {
                        MessageBox.Show("Cannot delete this user. The user is still listed in the \"Presensi\" table.");
                        return;
                    }

                    if (IsUserInMatKulTable(UserID))
                    {
                        MessageBox.Show("Cannot delete this user. The user is still listed in the \"Mata Kuliah\" table.");
                        return;
                    }

                    string query = $"DELETE FROM user WHERE UserID = {UserID}";
                    connect.RunCommand(query);
                    MessageBox.Show("Account successfully deleted.");
                }
                else
                {
                    MessageBox.Show("Cannot delete your own account!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An error occurred while deleting the user.");
            }
        }

        private bool IsUserInAttendanceTable(long UserID)
        {
            string query = $"SELECT COUNT(*) FROM presensi WHERE UserID = {UserID}";
            int userCountInAttendance = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return userCountInAttendance > 0;
        }

        private bool IsUserInMatKulTable(long UserID)
        {
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE UserID = {UserID}";
            int userCountInCourse = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return userCountInCourse > 0;
        }

        public int GetUserRole(string email)
        {
            string query = $"SELECT role FROM user WHERE email = '{email}'";
            DataTable result = connect.RetrieveData(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["role"]);
            }

            return 0;
        }

        public bool CheckEmailAvailability(string email)
        {
            string query = $"SELECT COUNT(*) FROM user WHERE email = '{email}'";
            int userCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return userCount == 0;
        }

        public long GetUserID(string email)
        {
            string query = $"SELECT UserID FROM user WHERE email = '{email}'";
            DataTable result = connect.RetrieveData(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt64(result.Rows[0]["UserID"]);
            }

            return 0;
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}