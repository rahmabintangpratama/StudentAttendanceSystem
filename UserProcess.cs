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
        public static LoginSession loginSession;

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
            string hashedPassword = HashPassword(password);

            string query = $"INSERT INTO user (UserID, Nama, Email, Password, Role) VALUES ('{userID}','{nama}', '{email}', '{hashedPassword}', '{Role}')";
            connect.RunCommand(query);
        }

        public void UpdateUser(int UserID, string newNama, string newEmail, string newPassword, int newRole)
        {
            string hashedPassword = HashPassword(newPassword);

            string query = $"UPDATE user SET Nama = '{newNama}', Email = '{newEmail}', Password = '{hashedPassword}', Role = '{newRole}' WHERE UserID = {UserID}";
            connect.RunCommand(query);
        }

        public void RemoveUser(int UserID)
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;

            if (currentUserID != UserID)
            {
                string query = $"DELETE FROM user WHERE UserID = {UserID}";
                connect.RunCommand(query);
                MessageBox.Show("Account Successfuly Deleted.");
            }
            else
            {
                MessageBox.Show("Cannot delete your own account!");
            }
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