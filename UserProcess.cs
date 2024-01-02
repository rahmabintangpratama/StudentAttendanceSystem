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

        public void InputUser(string userID, string nama, string email, string password, int Role)
        {
            string query = $"INSERT INTO user (UserID, Nama, Email, Password, Role) VALUES ('{userID}','{nama}', '{email}', '{password}', '{Role}')";
            connect.RunCommand(query);
        }

        public void UpdateUser(int UserID, string newNama, string newEmail, string newPassword, int newRole)
        {
            string query = $"UPDATE user SET Nama = '{newNama}', Email = '{newEmail}', Password = '{newPassword}', Role = '{newRole}' WHERE UserID = {UserID}";
            connect.RunCommand(query);
        }

        public void RemoveUser(int UserID)
        {
            string query = $"DELETE FROM user WHERE UserId = {UserID}";
            connect.RunCommand(query);
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