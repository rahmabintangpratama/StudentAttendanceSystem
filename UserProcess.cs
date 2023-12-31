using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendanceSystem
{
    internal class UserProcess : IDisposable
    {
        private Connect connect;

        public UserProcess()
        {
            connect = new Connect();
        }

        public bool AuthenticateUser(string email, string password)
        {
            string query = $"SELECT * FROM user WHERE email='{email}'";
            DataTable result = connect.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                string PasswordInDatabase = result.Rows[0]["password"].ToString();

                if (password != PasswordInDatabase)
                {
                    MessageBox.Show($"Authentication failed.");
                }
            }

            return false;
        }



        public void InputUser(string userID, string nama, string email, string password, string role)
        {
            string query = $"INSERT INTO user (UserID, Nama, Email, Password, Role) VALUES ('{userID}','{nama}', '{email}', '{password}', '{role}')";
            connect.ExecuteNonQuery(query);
        }

        public void UpdateUser(int UserID, string newNama, string newEmail, string newPassword, string newRole)
        {
            string query = $"UPDATE user SET Nama = '{newNama}', Email = '{newEmail}', Password = '{newPassword}', Role = '{newRole}' WHERE UserID = {UserID}";
            connect.ExecuteNonQuery(query);
        }


        public void RemoveUser(int UserID)
        {
            string query = $"DELETE FROM user WHERE UserId = {UserID}";
            connect.ExecuteNonQuery(query);
        }

        public int GetUserRole(string email)
        {
            string query = $"SELECT role FROM user WHERE email = '{email}'";
            DataTable result = connect.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["role"]);
            }

            return 0;
        }

        public bool IsEmailAvailable(string email)
        {
            string query = $"SELECT COUNT(*) FROM user WHERE email = '{email}'";
            int userCount = Convert.ToInt32(connect.ExecuteQuery(query).Rows[0][0]);

            return userCount == 0;
        }

        public int GetUserId(string email)
        {
            string query = $"SELECT id FROM user WHERE email = '{email}'";
            DataTable result = connect.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["id"]);
            }

            return 0;
        }

        public void Dispose()
        {
            connect.Dispose();
        }


    }
}