using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    internal class MatKulProcess : IDisposable
    {
        private Connect connect;

        public MatKulProcess()
        {
            connect = new Connect();
        }

        public void InputMatKul(string MatKul, string MatKulName, string UserID)
        {
            string query = $"INSERT INTO matakuliah (KodeMataKuliah, NamaMataKuliah, UserID) VALUES ('{MatKul}','{MatKulName}','{UserID}')";
            connect.ExecuteNonQuery(query);
        }

        public bool IsMatKulAvailable(string MatKul)
        {
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE KodeMataKuliah = '{MatKul}'";
            int matkulCount = Convert.ToInt32(connect.ExecuteQuery(query).Rows[0][0]);

            return matkulCount == 0;
        }

        public void UpdateMatKul(string MatKul, string MatKulName, string UserID)
        {
            string query = $"UPDATE matakuliah SET NamaMataKuliah = '{MatKulName}', UserID = '{UserID}' WHERE KodeMataKuliah = '{MatKul}'";
            connect.ExecuteNonQuery(query);
        }

        public void RemoveMatKul(string MatKul)
        {
            string query = $"DELETE FROM matakuliah WHERE KodeMataKuliah = '{MatKul}'";
            connect.ExecuteNonQuery(query);
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}
