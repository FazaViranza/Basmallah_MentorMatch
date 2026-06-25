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
    public partial class FormStatusPengajuan: Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        void Koneksi()
        {
            conn = new SqlConnection(Session.ConnectionString);
        }
        public FormStatusPengajuan()
        {
            InitializeComponent();
        }

        private void txtNIM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNIM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCari.PerformClick();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIM.Text.Trim() == "")
                {
                    MessageBox.Show("Masukkan NIM terlebih dahulu!");
                    return;
                }

                Koneksi();
                conn.Open();

                string query =
                "SELECT " +
                "NamaLomba, " +
                "TanggalPelaksanaan, " +
                "TanggalSelesai, " +
                "Status, " +
                "ReviewDosen, " +
                "JadwalBimbingan, " +
                "HasilLomba, " +
                "Juara " +
                "FROM vw_PengajuanLomba " +
                "WHERE NIM = @NIM";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@NIM",
                    txtNIM.Text.Trim());

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ditemukan!");
                }

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

            MenuMahasiswa frm =
                new MenuMahasiswa();

            frm.Show();
        }

        private void FormStatusPengajuan_Load(object sender, EventArgs e)
        {

        }
    }
}
