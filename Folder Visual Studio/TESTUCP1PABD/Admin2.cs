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
using System.Text.RegularExpressions;

namespace TESTUCP1PABD
{
    public partial class Admin2 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        BindingSource bs = new BindingSource();

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-6UCOLCI3\\RAZFAR;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
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

                cmd = new SqlCommand("sp_DeleteDosen", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NIDN", txtNIDN.Text);

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
           
                if (txtNIDN.Text == "" ||
                    txtNama.Text == "" ||
                    comboBoxJenis.Text == "" ||
                    comboBoxStatus.Text == "")
                {
                    MessageBox.Show("Semua field harus diisi!");
                    return;
                }

               
                if (!Regex.IsMatch(txtNIDN.Text, @"^D\d{3}$"))
                {
                    MessageBox.Show("NIDN harus format D---!");
                    return;
                }

              
                if (Regex.IsMatch(txtNama.Text, @"\d"))
                {
                    MessageBox.Show("Nama tidak boleh mengandung angka!");
                    return;
                }

                Koneksi();
                conn.Open();

                cmd = new SqlCommand(
                    "sp_UpdateDosen",
                    conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

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

                MessageBox.Show(
                    "Data berhasil diupdate");

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
               
                if (txtNIDN.Text == "" ||
                    txtNama.Text == "" ||
                    comboBoxJenis.Text == "" ||
                    comboBoxStatus.Text == "")
                {
                    MessageBox.Show("Semua field harus diisi!");
                    return;
                }

               
                if (!Regex.IsMatch(txtNIDN.Text, @"^D\d{3}$"))
                {
                    MessageBox.Show("NIDN harus format D001!");
                    return;
                }

                
                if (Regex.IsMatch(txtNama.Text, @"\d"))
                {
                    MessageBox.Show("Nama tidak boleh mengandung angka!");
                    return;
                }

                Koneksi();
                conn.Open();

                cmd = new SqlCommand(
                    "sp_InsertDosen",
                    conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

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

                MessageBox.Show(
                    "Data berhasil ditambahkan");

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
                "SELECT * FROM vw_Dosen";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;

                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

                txtNIDN.DataBindings.Clear();
                txtNama.DataBindings.Clear();
                comboBoxJenis.DataBindings.Clear();
                comboBoxStatus.DataBindings.Clear();

                txtNIDN.DataBindings.Add(
                    "Text",
                    bs,
                    "NIDN");

                txtNama.DataBindings.Add(
                    "Text",
                    bs,
                    "NamaDosen");

                comboBoxJenis.DataBindings.Add(
                    "Text",
                    bs,
                    "Jenis");

                comboBoxStatus.DataBindings.Add(
                    "Text",
                    bs,
                    "Status");

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

                cmd = new SqlCommand("sp_SearchDosen", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Jenis",
                    comboBoxSearch.Text);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;

                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string input = txtNIDN.Text.Replace(" ", "").ToLower();
                if (input.Contains("or1=1") || input.Contains("or'1'='1'") || input.Contains("--"))
                {
                    throw new Exception("SQL Error : Unsafe UPDATE operation not allowed");
                }

                string query = "UPDATE Dosen SET NamaDosen='HACKED' WHERE NIDN='" + txtNIDN.Text + "'";
                cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

                MessageBox.Show(result + " data berhasil diubah!");
                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (SqlException ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unsafe UPDATE") || ex.Message.ToLower().Contains("safe"))
                {
                    simpanLog(ex.Message);
                    MessageBox.Show("SQL Error : Unsafe UPDATE operation not allowed");
                }
                else
                {
                    simpanLog(ex.Message);
                    MessageBox.Show("General Error : " + ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = @"
                    UPDATE Dosen SET NamaDosen = 'Dr. Ahmad' WHERE NIDN = 'D001';
                    UPDATE Dosen SET NamaDosen = 'Dr. Siti' WHERE NIDN = 'D002';
                    UPDATE Dosen SET NamaDosen = 'Dr. Budi' WHERE NIDN = 'D003';
                    UPDATE Dosen SET NamaDosen = 'Dr. Hendra' WHERE NIDN = 'D004';
                    UPDATE Dosen SET NamaDosen = 'Dr. Rina' WHERE NIDN = 'D005';
                ";

                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Dosen berhasil di-reset ke data semula!");
                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat reset data: " + ex.Message);
            }
        }

        private void simpanLog(string message)
        {
            try
            {
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan log: " + ex.Message);
            }
        }

    }
}