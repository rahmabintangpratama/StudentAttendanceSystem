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
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(UserPage_FormClosing);
        }

        // Tambahkan event handler untuk FormClosing
        private void UserPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tampilkan dialog konfirmasi sebelum menutup form
            DialogResult result = MessageBox.Show("Are you sure you want to close this page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Jika pengguna mengklik Yes, kembali ke halaman login
                AdministratorPage adminPage = new AdministratorPage();
                adminPage.Show();
            }
            else
            {
                // Jika pengguna mengklik No, batalkan penutupan form
                e.Cancel = true;
            }
        }
    }
}
