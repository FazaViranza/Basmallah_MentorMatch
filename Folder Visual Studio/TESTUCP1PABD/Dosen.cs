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

namespace TESTUCP1PABD
{
    public partial class Dosen: Form
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
        public Dosen()
        {
            InitializeComponent();

            comboBoxStatus.Items.Clear();

            comboBoxStatus.Items.Add("Approved");
            comboBoxStatus.Items.Add("Rejected");
            comboBoxStatus.Items.Add("Pending");

            comboBoxStatus.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtNIDN.Text =
                    row.Cells["NIDN"].Value.ToString();

                comboBoxStatus.Text =
                    row.Cells["Status"].Value.ToString();
            }
        }


        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT * FROM PengajuanLomba";

                cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "UPDATE PengajuanLomba " +
                "SET Status=@Status " +
                "WHERE NIDN=@NIDN";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Status",
                    comboBoxStatus.Text);

                cmd.Parameters.AddWithValue("@NIDN",
                    txtNIDN.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Status berhasil diupdate");

                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 login = new Form1();
            login.Show();
        }

        private void txtNIDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}