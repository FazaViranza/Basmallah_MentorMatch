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
    public partial class Admin2 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }
        public Admin2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtNIDN.Text =
                    row.Cells["NIDN"].Value.ToString();

                txtNama.Text =
                    row.Cells["NamaDosen"].Value.ToString();

                comboBoxJenis.Text =
                    row.Cells["Jenis"].Value.ToString();

                comboBoxStatus.Text =
                    row.Cells["Status"].Value.ToString();
            }
        }

        private void txtNIDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxJenis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Admin2_Load(object sender, EventArgs e)
        {
            LoadJenis();
            LoadJenisSearch();

            comboBoxStatus.Items.Clear();
            comboBoxStatus.Items.Add("Available");
            comboBoxStatus.Items.Add("Unavailable");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "DELETE FROM Dosen " +
                "WHERE NIDN=@NIDN";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@NIDN",
                    txtNIDN.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil dihapus");

                conn.Close();

                btnRead_Click(sender, e);
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
                "UPDATE Dosen SET " +
                "NamaDosen=@Nama, " +
                "Jenis=@Jenis, " +
                "Status=@Status " +
                "WHERE NIDN=@NIDN";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@NIDN",
                    txtNIDN.Text);

                cmd.Parameters.AddWithValue(
                    "@Nama",
                    txtNama.Text);

                cmd.Parameters.AddWithValue(
                    "@Jenis",
                    comboBoxJenis.Text);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    comboBoxStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil diupdate");

                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "INSERT INTO Dosen (NIDN, NamaDosen, Jenis, Status) VALUES " +
                "(@NIDN,@Nama,@Jenis,@Status)";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@NIDN",
                    txtNIDN.Text);

                cmd.Parameters.AddWithValue(
                    "@Nama",
                    txtNama.Text);

                cmd.Parameters.AddWithValue(
                    "@Jenis",
                    comboBoxJenis.Text);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    comboBoxStatus.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambahkan");

                conn.Close();

                btnRead_Click(sender, e);
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
                "SELECT * FROM Dosen";

                cmd = new SqlCommand(query, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin1 admin = new Admin1();
            admin.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtNIDN.Text =
                    row.Cells["NIDN"].Value.ToString();

                txtNama.Text =
                    row.Cells["NamaDosen"].Value.ToString();

                comboBoxJenis.Text =
                    row.Cells["Jenis"].Value.ToString();

                comboBoxStatus.Text =
                    row.Cells["Status"].Value.ToString();
            }
        }

        void LoadJenis()
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT NamaJenis FROM JenisLomba";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxJenis.DataSource = dt;
                comboBoxJenis.DisplayMember = "NamaJenis";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadJenisSearch()
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT DISTINCT Jenis FROM Dosen";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxSearch.DataSource = dt;
                comboBoxSearch.DisplayMember = "Jenis";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT * FROM Dosen WHERE Jenis=@jenis";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@jenis",
                    comboBoxSearch.Text);

                SqlDataReader reader =
                    cmd.ExecuteReader();

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
    }
}