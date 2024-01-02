using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAttendanceSystem
{
    public partial class EventForm : Form
    {
        private Connect connect;
        public static LoginSession loginSession;
        private EventProcess eventProcess;
        public EventForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(EventPage_FormClosing);

            connect = new Connect();
            eventProcess = new EventProcess();
            FillComboBoxMatKulName();
            displayData();
        }

        // Tambahkan event handler untuk FormClosing
        private void EventPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FillComboBoxMatKulName()
        {
            DataTable matkulTable = GetMatKul();

            comboBoxMatKulName.DisplayMember = "NamaMataKuliah";
            comboBoxMatKulName.ValueMember = "KodeMataKuliah";

            comboBoxMatKulName.DataSource = matkulTable;
        }

        private DataTable GetMatKul()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            string query = $"SELECT m.KodeMataKuliah, m.NamaMataKuliah FROM matakuliah m JOIN user u ON (m.UserID = u.UserID) WHERE m.UserID = {currentUserID}";
            return connect.ExecuteQuery(query);
        }

        private void displayData()
        {
            long currentUserID = LoginPage.currentLoginSession.UserID;
            string query = $"SELECT e.EventID AS Event_ID, e.EventName AS Nama_Event, m.NamaMataKuliah AS Mata_Kuliah, e.venue AS Ruang, e.Tanggal AS Tanggal FROM matakuliah m JOIN event e ON (m.KodeMataKuliah = e.KodeMataKuliah) JOIN user u ON (m.UserID = u.UserID) WHERE m.UserID = {currentUserID} ORDER BY Tanggal DESC, Nama_Event ASC, Mata_Kuliah ASC";
            DataTable eventData = connect.ExecuteQuery(query);

            dataGridViewEvent.DataSource = eventData;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            // Tampilkan dialog konfirmasi sebelum menutup form
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna mengklik Yes, kembali ke halaman login
                LecturerPage lecturerPage = new LecturerPage();
                lecturerPage.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Event = textBoxEvent.Text;
            DataRowView selectedMatKul = (DataRowView)comboBoxMatKulName.SelectedItem;
            string kodeMK = Convert.ToString(selectedMatKul["KodeMataKuliah"]);
            string Ruang = textBoxRuang.Text;
            DateTime selectedTanggal = dateTimePickerTanggal.Value;

            if (AddEvent(Event, kodeMK, Ruang, selectedTanggal))
            {
                MessageBox.Show("Event successfuly added.");
                textBoxEvent.Clear();
                textBoxRuang.Clear();
            }
            else
            {
                MessageBox.Show("Event failed to be added.");
            }

            displayData();
        }

        private bool AddEvent(string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                eventProcess.InputEvent(Event, kodeMK, Ruang, selectedTanggal);
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
            int EventID = Convert.ToInt32(textBoxEventID.Text);
            string Event = textBoxEvent.Text;
            DataRowView selectedMatKul = (DataRowView)comboBoxMatKulName.SelectedItem;
            string kodeMK = Convert.ToString(selectedMatKul["KodeMataKuliah"]);
            string Ruang = textBoxRuang.Text;
            DateTime selectedTanggal = dateTimePickerTanggal.Value;

            if (EditEvent(EventID, Event, kodeMK, Ruang, selectedTanggal))
            {
                MessageBox.Show("Event successfuly edited.");
                textBoxEvent.Clear();
                textBoxRuang.Clear();
            }
            else
            {
                MessageBox.Show("Event failed to be edited.");
            }

            displayData();
        }

        private bool EditEvent(int EventID, string Event, string kodeMK, string Ruang, DateTime selectedTanggal)
        {
            try
            {
                eventProcess.UpdateEvent(EventID, Event, kodeMK, Ruang, selectedTanggal);
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
            int EventID = Convert.ToInt32(textBoxEventID.Text);

            if (DeleteEvent(EventID))
            {
                MessageBox.Show("Event successfuly deleted.");
                textBoxEventID.Clear();
            }
            else
            {
                MessageBox.Show("Event failed to be deleted.");
            }
        }

        private bool DeleteEvent(int EventID)
        {
            try
            {
                eventProcess.RemoveEvent(EventID);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            displayData();
        }
    }
}