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
    public partial class Admin1: Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }
        public Admin1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtID.Text =
                    row.Cells["PengajuanID"].Value.ToString();
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin2 dosenPage = new Admin2();
            dosenPage.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(
                    "Yakin ingin menghapus data?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    Koneksi();
                    conn.Open();

                    string query =
                    "DELETE FROM PengajuanLomba WHERE PengajuanID=@ID";

                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ID",
                        txtID.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ID yang dihapus: " + txtID.Text);

                    conn.Close();

                    btnRead_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                SqlDataReader reader =
                    cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;

                conn.Close();
                HitungTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 login = new Form1();
            login.Show();

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtID.Text =
                    row.Cells["PengajuanID"].Value.ToString();
            }
        }

        void HitungTotal()
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT COUNT(*) FROM PengajuanLomba";

                cmd = new SqlCommand(query, conn);

                int total =
                    (int)cmd.ExecuteScalar();

                lblTotal.Text =
                    "Total Pengajuan: " + total;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}