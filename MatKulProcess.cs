using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            try
            {
                if (CheckMataKuliahAvailability(MatKul, MatKulName))
                {
                    string query = $"INSERT INTO matakuliah (KodeMataKuliah, NamaMataKuliah, UserID) VALUES ('{MatKul}','{MatKulName}','{UserID}')";
                    connect.RunCommand(query);
                    MessageBox.Show("\"Mata Kuliah\" successfully added.");
                }
                else
                {
                    MessageBox.Show("\"Mata Kuliah\" Name or Code is already in use. Please use a different Name or Code.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private bool CheckMataKuliahAvailability(string MatKul, string MatKulName)
        {
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE KodeMataKuliah = '{MatKul}' OR NamaMataKuliah = '{MatKulName}'";
            int matkulCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return matkulCount == 0;
        }

        public bool CheckMatKulAvailability(string MatKul)
        {
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE KodeMataKuliah = '{MatKul}'";
            int matkulCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return matkulCount == 0;
        }

        public void UpdateMatKul(string MatKul, string MatKulName, string UserID)
        {
            try
            {
                if (CheckMataKuliahAvailabilityOnUpdate(MatKul, MatKulName))
                {
                    string query = $"UPDATE matakuliah SET NamaMataKuliah = '{MatKulName}', UserID = '{UserID}' WHERE KodeMataKuliah = '{MatKul}'";
                    connect.RunCommand(query);
                    MessageBox.Show("\"Mata Kuliah\" successfully edited.");
                }
                else
                {
                    MessageBox.Show("\"Mata Kuliah\" Name is already in use. Please use a different Name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private bool CheckMataKuliahAvailabilityOnUpdate(string MatKul, string MatKulName)
        {
            string query = $"SELECT COUNT(*) FROM matakuliah WHERE NamaMataKuliah = '{MatKulName}' AND KodeMataKuliah != '{MatKul}'";
            int matkulCount = Convert.ToInt32(connect.RetrieveData(query).Rows[0][0]);

            return matkulCount == 0;
        }

        public bool RemoveMatKul(string MatKul)
        {
            try
            {
                if (!IsMatKulConnectedToEvent(MatKul))
                {
                    string query = $"DELETE FROM matakuliah WHERE KodeMataKuliah = '{MatKul}'";
                    connect.RunCommand(query);
                    MessageBox.Show("\"Mata Kuliah\" successfully deleted.");
                    return true;
                }
                else
                {
                    MessageBox.Show("\"Mata Kuliah\" cannot be deleted as it is still connected to Event data.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private bool IsMatKulConnectedToEvent(string MatKul)
        {
            string presensiQuery = $"SELECT COUNT(*) FROM event WHERE KodeMataKuliah = '{MatKul}'";
            int presensiCount = Convert.ToInt32(connect.RetrieveData(presensiQuery).Rows[0][0]);

            return presensiCount > 0;
        }

        public void Dispose()
        {
            connect.Dispose();
        }
    }
}
