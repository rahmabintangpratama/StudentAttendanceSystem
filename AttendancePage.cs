using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentAttendanceSystem
{
    public partial class AttendancePage : Form
    {
        private Connect connect;
        private AttendanceProcess attendanceProcess;
        public AttendancePage()
        {
            InitializeComponent(); ;
            this.FormClosing += new FormClosingEventHandler(AttendancePage_FormClosing);

            connect = new Connect();
            attendanceProcess = new AttendanceProcess();
            FillComboBoxStudent();
            FillComboBoxEvent();
            FillComboBoxStatus();
            displayData();
        }

        // Tambahkan event handler untuk FormClosing
        private void AttendancePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FillComboBoxStudent()
        {
            DataTable studentTable = GetStudent();

            comboBoxStudent.DisplayMember = "Nama";
            comboBoxStudent.ValueMember = "UserID";

            comboBoxStudent.DataSource = studentTable;
        }

        private DataTable GetStudent()
        {
            string queryStudent = "SELECT UserID, Nama FROM user WHERE Role = 3";
            return connect.ExecuteQuery(queryStudent);
        }

        private void FillComboBoxEvent()
        {
            DataTable eventTable = GetEvent();

            comboBoxEvent.DisplayMember = "EventName";
            comboBoxEvent.ValueMember = "EventID";

            comboBoxEvent.DataSource = eventTable;
        }

        private DataTable GetEvent()
        {
            string queryEvent = "SELECT EventID, EventName FROM event";
            return connect.ExecuteQuery(queryEvent);
        }

        private void FillComboBoxStatus()
        {
            DataTable statusTable = GetStatus();

            comboBoxKehadiran.DisplayMember = "keterangan";
            comboBoxKehadiran.ValueMember = "Kehadiran";

            comboBoxKehadiran.DataSource = statusTable;
        }

        private DataTable GetStatus()
        {
            string queryStatus = "SELECT Kehadiran, keterangan FROM status";
            return connect.ExecuteQuery(queryStatus);
        }

        private void displayData()
        {
            string query = "SELECT p.PresensiID AS Attendance_ID, p.waktu AS Time, e.EventName AS Nama_Event, u.Nama AS Student, s.keterangan AS Status FROM presensi p JOIN event e ON (p.EventID = e.EventID) JOIN user u ON (p.UserID = u.UserID) JOIN status s ON (p.Kehadiran = s.Kehadiran) ORDER BY Time DESC, e.EventID DESC, Nama_Event ASC, Student ASC";
            DataTable attendanceData = connect.ExecuteQuery(query);

            dataGridViewAttendance.DataSource = attendanceData;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            // Tampilkan dialog konfirmasi sebelum menutup form
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna mengklik Yes, kembali ke halaman login
                AdministratorPage adminPage = new AdministratorPage();
                adminPage.Show();
                this.Hide();
            }
            else
            {
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
                MessageBox.Show("Attendance succesfuly added.");
            }
            else
            {
                MessageBox.Show("Attendance failed to be added.");
            }

            displayData();
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
            int PresensiID = Convert.ToInt32(textBoxPresensiID.Text);
            DataRowView selectedStudent = (DataRowView)comboBoxStudent.SelectedItem;
            long UserID = Convert.ToInt64(selectedStudent["UserID"]);
            DataRowView selectedEvent = (DataRowView)comboBoxEvent.SelectedItem;
            int EventID = Convert.ToInt32(selectedEvent["EventID"]);
            DataRowView selectedStatus = (DataRowView)comboBoxKehadiran.SelectedItem;
            int Status = Convert.ToInt32(selectedStatus["Kehadiran"]);

            if (EditAttendance(PresensiID, UserID, EventID, Status))
            {
                MessageBox.Show("Attendance succesfuly edited.");
            }
            else
            {
                MessageBox.Show("Attendance failed to be edited.");
            }

            displayData();
        }

        private bool EditAttendance(int PresensiID, long UserID, int EventID, int Status)
        {
            try
            {
                attendanceProcess.UpdateAttendance(PresensiID, UserID, EventID, Status);
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

            if (DeleteAttendance(PresensiID))
            {
                MessageBox.Show("Attendance succesfuly deleted.");
                textBoxPresensiID.Clear();
            }
            else
            {
                MessageBox.Show("Attendance failed to be deleted.");
            }

            displayData();
        }

        private bool DeleteAttendance(int PresensiID)
        {
            try
            {
                attendanceProcess.RemoveAttendance(PresensiID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
    }
}
