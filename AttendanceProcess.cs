using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem
{
    internal class AttendanceProcess : IDisposable
    {
        private Connect connect;

        public AttendanceProcess()
        {
            connect = new Connect();
        }

        public void InputAttendance(long UserID, int EventID, int Status)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"INSERT INTO presensi (UserID, EventID, Kehadiran, waktu) VALUES ('{UserID}', '{EventID}', '{Status}', '{currentTime}')";
            connect.ExecuteNonQuery(query);
        }

        public void UpdateAttendance(int PresensiID, long UserID, int EventID, int Status)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $"UPDATE presensi SET UserID = '{UserID}', EventID = '{EventID}', Kehadiran = '{Status}', waktu = '{currentTime}' WHERE PresensiID = '{PresensiID}'";
            connect.ExecuteNonQuery(query);
        }

        public void RemoveAttendance(int PresensiID)
        {
            string query = $"DELETE FROM presensi WHERE PresensiID = '{PresensiID}'";
            connect.ExecuteNonQuery(query);
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}