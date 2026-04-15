using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace TESTUCP1PABD
{
    public partial class Mahasiswa: Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        // KONEKSI DATABASE
        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }
        public Mahasiswa()
        {
            InitializeComponent();

            txtNIDN.ReadOnly = true;

            LoadJenis();  
            LoadDosen();   
        }

        private void txtNIM_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBoxJenisMabar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNamaLomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPenyelenggara_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBoxDosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        void LoadDosen()
        {
            
        }

        void LoadJenis()
        {
            
        }
    }
}