using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TESTUCP1PABD
{
    public partial class AdminMahasiswa : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        BindingSource bs = new BindingSource();

        void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=192.168.100.124,1433;\r\nInitial Catalog=MentorMatchMabarDB;\r\nUser ID=AdminUser;\r\nPassword=Admin123!;\r\nTrustServerCertificate=True"
            );
        }

        public AdminMahasiswa()
        {
            InitializeComponent();
        }

        // ================= READ DATA =================
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT * FROM vw_Mahasiswa";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;

                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

                txtNIM.DataBindings.Clear();

                txtNIM.DataBindings.Add(
                    "Text",
                    bs,
                    "NIM");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= AMBIL NIM =================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtNIM.Text = row.Cells["NIM"].Value.ToString();

            string status = row.Cells["Status"].Value.ToString();

            // disable approve kalau sudah active
            btnApprove.Enabled = status != "Active";
        }

        // ================= APPROVE =================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            SqlTransaction trans = null;

            try
            {
                if (txtNIM.Text == "")
                {
                    MessageBox.Show("Pilih mahasiswa dulu!");
                    return;
                }

                Koneksi();
                conn.Open();
                trans = conn.BeginTransaction();

                string nim = txtNIM.Text.Trim();

                // 🔥 STORED PROCEDURE
                cmd = new SqlCommand("sp_ApproveMahasiswa", conn, trans);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NIM", nim);

                int affected = cmd.ExecuteNonQuery();

                if (affected == 0)
                {
                    MessageBox.Show("Approve gagal!");
                    conn.Close();
                    return;
                }

                // 🔥 CEK USER
                string checkUser =
                "SELECT COUNT(*) FROM Users WHERE Username=@Username";

                SqlCommand checkCmd = new SqlCommand(checkUser, conn, trans);

                checkCmd.Parameters.AddWithValue("@Username", nim);

                int count = (int)checkCmd.ExecuteScalar();

                // 🔥 INSERT USER
                if (count == 0)
                {
                    string insertUser =
                    "INSERT INTO Users (Username, Password, Role) " +
                    "VALUES (@Username,'123','Mahasiswa')";

                    SqlCommand userCmd =
                        new SqlCommand(insertUser, conn, trans);

                    userCmd.Transaction = trans;

                    userCmd.Parameters.AddWithValue("@Username", nim);

                    userCmd.ExecuteNonQuery();
                }
                trans.Commit();

                MessageBox.Show("Mahasiswa berhasil di-approve!");

                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin1 admin = new Admin1();
            admin.Show();
        }   

        private void txtNIM_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
