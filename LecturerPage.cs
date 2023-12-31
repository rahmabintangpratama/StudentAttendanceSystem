using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentAttendanceSystem
{
    public partial class LecturerPage : Form
    {
        public LecturerPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(LecturerPage_FormClosing);
        }

        private void LecturerPage_Load(object sender, EventArgs e)
        {

        }

        // Tambahkan event handler untuk FormClosing
        private void LecturerPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tampilkan dialog konfirmasi sebelum menutup form
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna mengklik Yes, kembali ke halaman login
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
            }
            else
            {
                // Jika pengguna mengklik No, batalkan penutupan form
                e.Cancel = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}