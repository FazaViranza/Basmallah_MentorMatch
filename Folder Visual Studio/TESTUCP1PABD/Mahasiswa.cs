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
    public partial class Mahasiswa : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        BindingSource bs = new BindingSource();

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

        }

        private void txtNIM_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBoxJenisMabar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDosen.DataSource = null;
            txtNIDN.Clear();

            if (comboBoxJenisMabar.Text != "")
            {
                LoadDosenByJenis(comboBoxJenisMabar.Text);
            }
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
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT * FROM vw_PengajuanLomba";

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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIM.Text == "")
                {
                    MessageBox.Show("NIM tidak boleh kosong!");
                    return;
                }

                if (txtNamaLomba.Text == "")
                {
                    MessageBox.Show("Nama lomba tidak boleh kosong!");
                    return;
                }

                if (txtPenyelenggara.Text == "")
                {
                    MessageBox.Show("Penyelenggara tidak boleh kosong!");
                    return;
                }

                if (txtNIDN.Text == "")
                {
                    MessageBox.Show("Pilih dosen terlebih dahulu!");
                    return;
                }

                if (comboBoxDosen.SelectedValue == null)
                {
                    MessageBox.Show("Tidak ada dosen tersedia untuk jenis ini!");
                    return;
                }

                // 🔥 TAMBAH DI SINI
                if (dateTimePickerTanggal.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Tanggal pelaksanaan tidak boleh di masa lalu!");
                    return;
                }

                // =====================
                // BARU MASUK DATABASE
                // =====================
                Koneksi();
                conn.Open();

                cmd = new SqlCommand("sp_SubmitPengajuan", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
                cmd.Parameters.AddWithValue("@NIDN", txtNIDN.Text);
                cmd.Parameters.AddWithValue("@JenisID", comboBoxJenisMabar.SelectedValue);
                cmd.Parameters.AddWithValue("@NamaLomba", txtNamaLomba.Text);
                cmd.Parameters.AddWithValue("@Penyelenggara", txtPenyelenggara.Text);
                cmd.Parameters.AddWithValue("@TanggalPelaksanaan", dateTimePickerTanggal.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil disimpan");

                conn.Close();

                btnView_Click(sender, e);
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dataGridView1.Rows[e.RowIndex];

                txtNIM.Text =
                    row.Cells["NIM"].Value.ToString();

                comboBoxJenisMabar.SelectedValue =
                    row.Cells["JenisID"].Value;

                txtNamaLomba.Text =
                    row.Cells["NamaLomba"].Value.ToString();

                txtPenyelenggara.Text =
                    row.Cells["Penyelenggara"].Value.ToString();

                dateTimePickerTanggal.Value =
                    Convert.ToDateTime(
                        row.Cells["TanggalPelaksanaan"].Value);
            }

        }

        private void comboBoxDosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDosen.SelectedValue != null)
            {
                txtNIDN.Text =
                    comboBoxDosen.SelectedValue.ToString();
            }
        }

        void LoadDosen()
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT NIDN, NamaDosen FROM Dosen WHERE Status='Available'";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxDosen.DataSource = dt;
                comboBoxDosen.DisplayMember = "NamaDosen";
                comboBoxDosen.ValueMember = "NIDN";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadJenis()
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT * FROM JenisLomba";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxJenisMabar.DataSource = dt;
                comboBoxJenisMabar.DisplayMember = "NamaJenis";
                comboBoxJenisMabar.ValueMember = "JenisID";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadDosenByJenis(string jenis)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT NIDN, NamaDosen FROM Dosen " +
                "WHERE Status='Available' AND Jenis=@jenis";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                da.SelectCommand.Parameters.AddWithValue("@jenis", jenis);

                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxDosen.DataSource = dt;
                comboBoxDosen.DisplayMember = "NamaDosen";
                comboBoxDosen.ValueMember = "NIDN";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }
    }
}