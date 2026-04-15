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
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT " +
                "p.PengajuanID, " +
                "p.NIM, " +
                "m.NamaMahasiswa, " +
                "d.NamaDosen, " +
                "j.NamaJenis, " +
                "p.NamaLomba, " +
                "p.Penyelenggara, " +
                "p.TanggalPelaksanaan, " +
                "p.Status " +
                "FROM PengajuanLomba p " +
                "JOIN Mahasiswa m ON p.NIM = m.NIM " +
                "JOIN Dosen d ON p.NIDN = d.NIDN " +
                "JOIN JenisLomba j ON p.JenisID = j.JenisID";

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

                Koneksi();
                conn.Open();

                cmd.Parameters.AddWithValue("@Jenis",
                    comboBoxJenisMabar.SelectedValue);

                string query =
                "INSERT INTO PengajuanLomba " +
                "(NIM,NIDN,JenisID,NamaLomba,Penyelenggara,TanggalPelaksanaan,Status) " +
                "VALUES (@NIM,@NIDN,@Jenis,@Nama,@Penyelenggara,@Tanggal,'Pending')";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NIM",
                    txtNIM.Text);

                cmd.Parameters.AddWithValue("@NIDN",
                    txtNIDN.Text);

                cmd.Parameters.AddWithValue("@Jenis",
                    comboBoxJenisMabar.SelectedValue);

                cmd.Parameters.AddWithValue("@Nama",
                    txtNamaLomba.Text);

                cmd.Parameters.AddWithValue("@Penyelenggara",
                    txtPenyelenggara.Text);

                cmd.Parameters.AddWithValue("@Tanggal",
                    dateTimePickerTanggal.Value);

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