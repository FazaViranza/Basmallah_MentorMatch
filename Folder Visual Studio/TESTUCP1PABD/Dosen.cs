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
using System.Diagnostics;
using System.IO;

namespace TESTUCP1PABD
{
    public partial class Dosen: Form
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
                "SELECT * FROM vw_PengajuanLomba";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;

                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

                txtID.DataBindings.Clear();
                txtNIDN.DataBindings.Clear();
                comboBoxStatus.DataBindings.Clear();

                txtReview.DataBindings.Clear();
                dtpJadwal.DataBindings.Clear();

                txtDraftFile.DataBindings.Clear();


                txtID.DataBindings.Add(
                    "Text",
                    bs,
                    "PengajuanID");

                txtNIDN.DataBindings.Add(
                    "Text",
                    bs,
                    "NIDN");

                comboBoxStatus.DataBindings.Add(
                    "Text",
                    bs,
                    "Status");

                txtReview.DataBindings.Add(
                    "Text",
                    bs,
                    "ReviewDosen");

                dtpJadwal.DataBindings.Add(
                    "Value",
                    bs,
                    "JadwalBimbingan",
                    true,
                    DataSourceUpdateMode.OnPropertyChanged);

                txtDraftFile.DataBindings.Add(
                    "Text",
                    bs,
                    "DraftFile");

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

                cmd = new SqlCommand(
                    "sp_UpdateReviewDosen",
                    conn);  

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@ID",
                    txtID.Text);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    comboBoxStatus.Text);

                cmd.Parameters.AddWithValue(
                    "@ReviewDosen",
                    txtReview.Text);

                cmd.Parameters.AddWithValue(
                    "@JadwalBimbingan",
                    dtpJadwal.Value);

                DateTime tanggalLomba =
                    Convert.ToDateTime(
                        ((DataRowView)bs.Current)["TanggalPelaksanaan"]);

                if (dtpJadwal.Value >= tanggalLomba)
                {
                    MessageBox.Show(
                        "Jadwal bimbingan harus sebelum tanggal pelaksanaan lomba!");

                    return;
                }

                if (dtpJadwal.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show(
                        "Jadwal bimbingan tidak boleh sebelum hari ini!");
                    return;
                }

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Status berhasil diupdate");

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

        private void Dosen_Load(object sender, EventArgs e)
        {

        }

        private void txtReview_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpJadwal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLihatDraft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDraftFile.Text))
            {
                if (string.IsNullOrWhiteSpace(
                    txtDraftFile.Text))
                {
                    MessageBox.Show(
                        "Draft tidak ditemukan!");
                    return;
                }

                if (!File.Exists(txtDraftFile.Text))
                {
                    MessageBox.Show(
                        "File tidak ditemukan!");
                    return;
                }

                Process.Start(txtDraftFile.Text);
            }

            Process.Start(txtDraftFile.Text);
        }
    }
}