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
    public partial class AdministratorPage : Form
    {
        public AdministratorPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(AdministratorPage_FormClosing);
        }

        // Tambahkan event handler untuk FormClosing
        private void AdministratorPage_FormClosing(object sender, FormClosingEventArgs e)
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
                LoginPage loginPage = new LoginPage();
                loginPage.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserPage userPage = new UserPage();
            userPage.Show();
            this.Hide();
        }

        private void btnMatkul_Click(object sender, EventArgs e)
        {

        }

        private void btnPresensi_Click(object sender, EventArgs e)
        {

        }
    }
}
