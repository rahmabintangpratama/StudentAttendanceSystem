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

namespace StudentAttendanceSystem
{
    public partial class MataKuliah : Form
    {
        private Connect connect;
        public MataKuliah()
        {
            InitializeComponent(); ;
            this.FormClosing += new FormClosingEventHandler(MataKuliahPage_FormClosing);

            connect = new Connect();
        }

        // Tambahkan event handler untuk FormClosing
        private void MataKuliahPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void displayData()
        {
            string query = "SELECT m.KodeMataKuliah AS Kode_Mata_Kuliah, m.NamaMataKuliah AS Mata_Kuliah, u.Nama AS Dosen_Pengampu FROM matakuliah m JOIN user u ON (m.UserID = u.UserID) ORDER BY Kode_Mata_Kuliah ASC";
            DataTable matkulData = connect.ExecuteQuery(query);

            dataGridViewMatKul.DataSource = matkulData;
        }
    }
}
