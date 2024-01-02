using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

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
            string dateFormat = selectedTanggal.ToString("yyyy-MM-dd");
            string query = $"INSERT INTO event (EventName, KodeMataKuliah, venue, Tanggal) VALUES ('{Event}', '{kodeMK}', '{Ruang}', '{dateFormat}')";
            connect.RunCommand(query);
        }

        public void UpdateEvent(int EventID, string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            string dateFormat = selectedTanggal.ToString("yyyy-MM-dd");
            string query = $"UPDATE event SET EventName = '{Event}', KodeMataKuliah = '{kodeMK}', venue = '{Ruang}', Tanggal = '{dateFormat}' WHERE EventID = '{EventID}'";
            connect.RunCommand(query);
        }

        public void RemoveEvent(int EventID)
        {
            string query = $"DELETE FROM event WHERE EventID = '{EventID}'";
            connect.RunCommand(query);
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}
