using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendanceSystem
{
    internal class EventProcess : IDisposable
    {
        private Connect connect;

        public EventProcess()
        {
            connect = new Connect();
        }

        public void InputEvent(string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Event))
                {
                    if (CheckEventAvailability(Event))
                    {
                        string dateFormat = selectedTanggal.ToString("yyyy-MM-dd");
                        string query = $"INSERT INTO event (EventName, KodeMataKuliah, venue, Tanggal) VALUES ('{Event}', '{kodeMK}', '{Ruang}', '{dateFormat}')";
                        connect.RunCommand(query);
                        MessageBox.Show("Event successfully added.");
                    }
                    else
                    {
                        MessageBox.Show("Event Name is already in use. Please use a different Name.");
                    }
                }
                else
                {
                    MessageBox.Show("Event Name cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private bool CheckEventAvailability(string Event)
        {
            // Check if the given EventName is already in use
            string query = $"SELECT COUNT(*) FROM event WHERE EventName = '{Event}'";
            int eventCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return eventCount == 0;
        }

        public void UpdateEvent(int EventID, string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Event))
                {
                    int currentUserRole = GetUserRole(LoginPage.currentLoginSession.Email);
                    long DosenID = LoginPage.currentLoginSession.UserID;

                    if (currentUserRole == 1 || IsDosenInMataKuliah(DosenID, EventID))
                    {
                        if (CheckEventAvailabilityOnUpdate(EventID, Event))
                        {
                            string dateFormat = selectedTanggal.ToString("yyyy-MM-dd");
                            string query = $"UPDATE event SET EventName = '{Event}', KodeMataKuliah = '{kodeMK}', venue = '{Ruang}', Tanggal = '{dateFormat}' WHERE EventID = '{EventID}'";
                            connect.RunCommand(query);
                            MessageBox.Show("Event successfully edited.");
                        }
                        else
                        {
                            MessageBox.Show("Event Name is already in use. Please use a different Name.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Event ID does not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Event Name cannot be empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Check event availability during update
        private bool CheckEventAvailabilityOnUpdate(int EventID, string Event)
        {
            // Check if the given EventName is already in use by other events (excluding the event being updated)
            string query = $"SELECT COUNT(*) FROM event WHERE EventName = '{Event}' AND EventID != '{EventID}'";
            int eventCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return eventCount == 0;
        }

        public bool RemoveEvent(int EventID, long DosenID)
        {
            try
            {
                int currentUserRole = GetUserRole(LoginPage.currentLoginSession.Email);

                if (currentUserRole == 1 || IsDosenInMataKuliah(DosenID, EventID))
                {
                    if (!IsEventConnectedToPresensi(EventID))
                    {
                        string query = $"DELETE FROM event WHERE EventID = '{EventID}'";
                        connect.RunCommand(query);
                        MessageBox.Show("Event successfully deleted.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Event cannot be deleted as it is still connected to Attendance data.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Event ID does not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
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

        private bool IsDosenInMataKuliah(long DosenID, int EventID)
        {
            // Memeriksa apakah dosen mengampu mata kuliah pada event terkait
            string query = $"SELECT mk.UserID FROM matakuliah mk " +
                           $"INNER JOIN event e ON mk.KodeMataKuliah = e.KodeMataKuliah " +
                           $"WHERE e.EventID = '{EventID}' AND mk.UserID = '{DosenID}'";

            DataTable result = connect.RetrieveData(query);
            return result.Rows.Count > 0;
        }

        private bool IsEventConnectedToPresensi(int EventID)
        {
            string presensiQuery = $"SELECT COUNT(*) FROM presensi WHERE EventID = '{EventID}'";
            int presensiCount = Convert.ToInt32(connect.RetrieveData(presensiQuery).Rows[0][0]);

            return presensiCount > 0;
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}
