using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentAttendanceSystem
{
    public partial class StudentPage : Form
    {
        private Connect connect;
        public static LoginSession loginSession;
        public StudentPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(StudentPage_FormClosing);

            connect = new Connect();
            refreshData();
        }

        private void StudentPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void refreshData()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            string query = $"SELECT p.PresensiID AS Attendance_ID, p.waktu AS Time, e.EventName AS Nama_Event, u.Nama AS Student, s.keterangan AS Status FROM presensi p JOIN event e ON (p.EventID = e.EventID) JOIN user u ON (p.UserID = u.UserID) JOIN status s ON (p.Kehadiran = s.Kehadiran) WHERE p.UserID = '{currentUserID}' ORDER BY Time DESC, e.EventID DESC, Nama_Event ASC, Student ASC";
            DataTable attendanceData = connect.RetrieveData(query);

            dataGridViewAttendance.DataSource = attendanceData;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewAttendance.DataSource;

            // Periksa apakah ada data presensi sebelum memulai proses ekspor
            if (dt.Rows.Count > 0)
            {
                ExportToCSV(dt);
            }
            else
            {
                MessageBox.Show("No attendance data available for export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportToCSV(DataTable dt)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    DefaultExt = "csv",
                    Filter = "CSV files (*.csv)|*.csv",
                    Title = "Save CSV File"
                };

                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    StringBuilder csvContent = new StringBuilder();

                    csvContent.AppendLine("Attendance_ID,Time,Nama_Event,Student,Status");

                    foreach (DataRow row in dt.Rows)
                    {
                        csvContent.AppendLine($"{row["Attendance_ID"]},{row["Time"]},{row["Nama_Event"]},{row["Student"]},{row["Status"]}");
                    }

                    File.WriteAllText(filePath, csvContent.ToString());

                    MessageBox.Show($"Data has been exported to {filePath}", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Failed to export data.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
