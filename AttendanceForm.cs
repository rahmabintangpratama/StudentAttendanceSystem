using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentAttendanceSystem
{
    public partial class AttendanceForm : Form
    {
        private Connect connect;
        public static LoginSession loginSession;
        private AttendanceProcess attendanceProcess;
        public AttendanceForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(AttendanceForm_FormClosing);

            connect = new Connect();
            attendanceProcess = new AttendanceProcess();
            textBoxPresensiID.KeyPress += new KeyPressEventHandler(textBoxPresensiID_KeyPress);
            ComboBoxStudentData();
            ComboBoxEventData();
            ComboBoxStatusData();
            refreshData();
        }

        private void AttendanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPresensiID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Hanya izinkan input angka dan kontrol khusus (seperti Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ComboBoxStudentData()
        {
            DataTable studentTable = GetStudent();

            comboBoxStudent.DisplayMember = "Nama";
            comboBoxStudent.ValueMember = "UserID";

            comboBoxStudent.DataSource = studentTable;
        }

        private DataTable GetStudent()
        {
            string queryStudent = "SELECT UserID, Nama FROM user WHERE Role = 3";
            return connect.RetrieveData(queryStudent);
        }

        private void ComboBoxEventData()
        {
            DataTable eventTable = GetEvent();

            comboBoxEvent.DisplayMember = "EventName";
            comboBoxEvent.ValueMember = "EventID";

            comboBoxEvent.DataSource = eventTable;
        }

        private DataTable GetEvent()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            String queryEvent = $"SELECT e.EventID, e.EventName FROM matakuliah m JOIN event e ON (m.KodeMataKuliah = e.KodeMataKuliah) JOIN user u ON (m.UserID = u.UserID) WHERE m.UserID = {currentUserID}";
            return connect.RetrieveData(queryEvent);
        }

        private void ComboBoxStatusData()
        {
            DataTable statusTable = GetStatus();

            comboBoxKehadiran.DisplayMember = "keterangan";
            comboBoxKehadiran.ValueMember = "Kehadiran";

            comboBoxKehadiran.DataSource = statusTable;
        }

        private DataTable GetStatus()
        {
            string queryStatus = "SELECT Kehadiran, keterangan FROM status";
            return connect.RetrieveData(queryStatus);
        }

        private void refreshData()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;

            string query = $"SELECT p.PresensiID AS Attendance_ID, p.waktu AS Time, e.EventName AS Event_Name, u.Nama AS Student, s.keterangan AS Status " +
                           $"FROM presensi p " +
                           $"JOIN event e ON (p.EventID = e.EventID) " +
                           $"JOIN user u ON (p.UserID = u.UserID) " +
                           $"JOIN status s ON (p.Kehadiran = s.Kehadiran) " +
                           $"JOIN matakuliah mk ON (e.KodeMataKuliah = mk.KodeMataKuliah) " +
                           $"WHERE mk.UserID = {currentUserID} " + 
                           $"ORDER BY Time DESC, e.EventID DESC, Event_Name ASC, Student ASC";

            DataTable attendanceData = connect.RetrieveData(query);

            dataGridViewAttendance.DataSource = attendanceData;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LecturerPage lecturerPage = new LecturerPage();
                lecturerPage.Show();
                this.Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRowView selectedStudent = (DataRowView)comboBoxStudent.SelectedItem;
            long UserID = Convert.ToInt64(selectedStudent["UserID"]);
            DataRowView selectedEvent = (DataRowView)comboBoxEvent.SelectedItem;
            int EventID = Convert.ToInt32(selectedEvent["EventID"]);
            DataRowView selectedStatus = (DataRowView)comboBoxKehadiran.SelectedItem;
            int Status = Convert.ToInt32(selectedStatus["Kehadiran"]);

            if (AddAttendance(UserID, EventID, Status))
            {
            }
            else
            {
                MessageBox.Show("Attendance failed to be added.");
            }

            refreshData();
        }

        private bool AddAttendance(long UserID, int EventID, int Status)
        {
            try
            {
                attendanceProcess.InputAttendance(UserID, EventID, Status);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPresensiID.Text))
            {
                MessageBox.Show("Attendance ID cannot be empty for update.");
                return;
            }

            int PresensiID = Convert.ToInt32(textBoxPresensiID.Text);

            // Memeriksa apakah data presensi dengan PresensiID tertentu ada di database
            if (!IsPresensiIDExists(PresensiID))
            {
                MessageBox.Show("Attendance ID does not found.");
                return;
            }

            DataRowView selectedStudent = (DataRowView)comboBoxStudent.SelectedItem;
            long UserID = Convert.ToInt64(selectedStudent["UserID"]);
            DataRowView selectedEvent = (DataRowView)comboBoxEvent.SelectedItem;
            int EventID = Convert.ToInt32(selectedEvent["EventID"]);
            DataRowView selectedStatus = (DataRowView)comboBoxKehadiran.SelectedItem;
            int Status = Convert.ToInt32(selectedStatus["Kehadiran"]);

            if (EditAttendance(PresensiID, UserID, EventID, Status))
            {
                textBoxPresensiID.Clear();
            }
            else
            {
                MessageBox.Show("Attendance failed to be edited.");
            }

            refreshData();
        }

        private bool IsPresensiIDExists(int PresensiID)
        {
            // Pengecekan apakah PresensiID ada di database
            string query = $"SELECT COUNT(*) FROM presensi WHERE PresensiID = {PresensiID}";
            int count = Convert.ToInt32(connect.ExecuteScalar(query));

            return count > 0;
        }

        private bool EditAttendance(int PresensiID, long UserID, int EventID, int Status)
        {
            try
            {
                attendanceProcess.EditAttendance(PresensiID, UserID, EventID, Status);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int PresensiID = Convert.ToInt32(textBoxPresensiID.Text);

            if (IsPresensiIDExists(PresensiID))
            {
                if (RemoveAttendance(PresensiID))
                {
                    textBoxPresensiID.Clear();
                }
                else
                {
                    MessageBox.Show("Attendance failed to be deleted.");
                }
            }
            else
            {
                MessageBox.Show("Attendance ID does not found.");
                return;
            }

            refreshData();
        }

        private bool RemoveAttendance(int PresensiID)
        {
            try
            {
                long currentUserID = LoginPage.currentLoginSession.UserID;
                attendanceProcess.RemoveAttendance(PresensiID, currentUserID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
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

                    csvContent.AppendLine("Attendance_ID,Time,Event_Name,Student,Status");

                    foreach (DataRow row in dt.Rows)
                    {
                        csvContent.AppendLine($"{row["Attendance_ID"]},{row["Time"]},{row["Event_Name"]},{row["Student"]},{row["Status"]}");
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
