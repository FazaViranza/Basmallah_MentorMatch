using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESTUCP1PABD
{
    public partial class MenuMahasiswa: Form
    {
        public MenuMahasiswa()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Mahasiswa frm = new Mahasiswa();

            this.Hide();

            frm.Show();
        }

        private void btnUpdateHasil_Click(object sender, EventArgs e)
        {
            UpdateHasilLomba frm =
                new UpdateHasilLomba();

            this.Hide();

            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 login = new Form1();
            login.Show();
        }
    }
}
