using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                // Memeriksa apakah sudah ada presensi untuk student dan event tertentu
                if (!IsAttendanceExists(UserID, EventID))
                {
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string query = $"INSERT INTO presensi (UserID, EventID, Kehadiran, waktu) VALUES ('{UserID}', '{EventID}', '{Status}', '{currentTime}')";
                    connect.RunCommand(query);
                    MessageBox.Show("Attendance successfully added.");
                }
                else
                {
                    MessageBox.Show("Attendance for this student and event already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void EditAttendance(int PresensiID, long UserID, int EventID, int Status)
        {
            try
            {
                // Memeriksa apakah sudah ada presensi untuk student dan event tertentu
                if (!IsAttendanceExists(UserID, EventID, PresensiID))
                {
                    int currentUserRole = GetUserRole(LoginPage.currentLoginSession.Email);
                    long DosenID = LoginPage.currentLoginSession.UserID;

                    // Memeriksa apakah pengguna adalah admin atau dosen yang mengampu mata kuliah pada event terkait
                    if (currentUserRole == 1 || IsDosenInMataKuliah(DosenID, EventID))
                    {
                        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string query = $"UPDATE presensi SET UserID = '{UserID}', EventID = '{EventID}', Kehadiran = '{Status}', waktu = '{currentTime}' WHERE PresensiID = '{PresensiID}'";
                        connect.RunCommand(query);
                        MessageBox.Show("Attendance successfully edited.");
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to edit attendance for this event.");
                    }
                }
                else
                {
                    MessageBox.Show("Attendance for this student and event already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private bool IsDosenInMataKuliah(long DosenID, int EventID)
        {
            // Memeriksa apakah dosen mengampu mata kuliah pada event terkait
            string query = $"SELECT mk.UserID FROM matakuliah mk " +
                           $"INNER JOIN event e ON mk.KodeMataKuliah = e.KodeMataKuliah " +
                           $"WHERE e.EventID = '{EventID}' AND mk.UserID = '{DosenID}'";

            DataTable result = connect.RetrieveData(query);
            return result.Rows.Count > 0;
        }

        private bool IsAttendanceExists(long UserID, int EventID, int excludePresensiID = -1)
        {
            // Memeriksa apakah sudah ada presensi untuk student dan event tertentu (dengan mengabaikan presensi tertentu jika sedang dilakukan edit)
            string query = $"SELECT COUNT(*) FROM presensi WHERE UserID = '{UserID}' AND EventID = '{EventID}'";

            if (excludePresensiID != -1)
            {
                query += $" AND PresensiID != '{excludePresensiID}'";
            }

            int attendanceCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);
            return attendanceCount > 0;
        }

        public void RemoveAttendance(int PresensiID, long UserID)
        {
            try
            {
                int currentUserRole = GetUserRole(LoginPage.currentLoginSession.Email);
                if (currentUserRole == 1)
                {
                    string query = $"DELETE FROM presensi WHERE PresensiID = '{PresensiID}'";
                    connect.RunCommand(query);
                    MessageBox.Show("Attendance successfully deleted.");
                }
                else
                {
                    // Memeriksa apakah event yang terkait dengan presensi memiliki mata kuliah yang diampu oleh dosen
                    if (IsEventInDosenMataKuliah(PresensiID, UserID))
                    {
                        string query = $"DELETE FROM presensi WHERE PresensiID = '{PresensiID}'";
                        connect.RunCommand(query);
                        MessageBox.Show("Attendance successfully deleted.");
                    }
                    else
                    {
                        MessageBox.Show("You are not authorized to delete attendance for this event.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
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

        private bool IsEventInDosenMataKuliah(int PresensiID, long UserID)
        {
            // Memeriksa apakah event yang terkait dengan presensi memiliki mata kuliah yang diampu oleh dosen
            string query = $"SELECT e.EventID FROM presensi p " +
                           $"INNER JOIN event e ON p.EventID = e.EventID " +
                           $"INNER JOIN matakuliah mk ON e.KodeMataKuliah = mk.KodeMataKuliah " +
                           $"WHERE p.PresensiID = '{PresensiID}' AND mk.UserID = '{UserID}'";

            DataTable result = connect.RetrieveData(query);
            return result.Rows.Count > 0;
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}