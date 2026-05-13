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
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
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
            try
            {
                if (txtNIM.Text == "")
                {
                    MessageBox.Show("Pilih mahasiswa dulu!");
                    return;
                }

                Koneksi();
                conn.Open();

                string nim = txtNIM.Text.Trim();

                // 🔥 DEBUG DATABASE & SERVER
                SqlCommand dbCheck = new SqlCommand("SELECT @@SERVERNAME + ' | ' + DB_NAME()", conn);
                MessageBox.Show("Connected to:\n" + dbCheck.ExecuteScalar().ToString());

                MessageBox.Show("NIM = [" + nim + "]");

                // 🔥 UPDATE
                string update = "UPDATE Mahasiswa SET Status='Active' WHERE NIM=@NIM";

                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@NIM", nim);

                int affected = cmd.ExecuteNonQuery();

                MessageBox.Show("Rows affected: " + affected);

                if (affected == 0)
                {
                    MessageBox.Show("❌ Update gagal!\nKemungkinan:\n- NIM tidak cocok\n- atau beda database");
                    conn.Close();
                    return;
                }

                // 🔥 CEK STATUS LANGSUNG DI DB
                SqlCommand cek = new SqlCommand(
                    "SELECT Status FROM Mahasiswa WHERE NIM=@NIM", conn);
                cek.Parameters.AddWithValue("@NIM", nim);

                var status = cek.ExecuteScalar();
                MessageBox.Show("Status di DB sekarang: " + status);

                // 🔥 INSERT KE USERS (ANTI DUPLIKAT)
                string checkUser = "SELECT COUNT(*) FROM Users WHERE Username=@Username";
                SqlCommand checkCmd = new SqlCommand(checkUser, conn);
                checkCmd.Parameters.AddWithValue("@Username", nim);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    string insertUser =
                    "INSERT INTO Users (Username, Password, Role) VALUES (@Username,'123','Mahasiswa')";

                    SqlCommand userCmd = new SqlCommand(insertUser, conn);
                    userCmd.Parameters.AddWithValue("@Username", nim);
                    userCmd.ExecuteNonQuery();
                }

                MessageBox.Show("✔ Mahasiswa berhasil di-approve!");

                conn.Close();

                btnRead_Click(sender, e); // refresh grid
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

        private void txtNIM_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }
    }
}
