using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TESTUCP1PABD
{
    public partial class FormRekapPrestasi : Form
    {
        private string connectionString = "Data Source=192.168.100.124,1433;\r\nInitial Catalog=MentorMatchMabarDB;\r\nUser ID=AdminUser;\r\nPassword=Admin123!;\r\nTrustServerCertificate=True";
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataTable dtProdi;
        private DataTable dtPrestasi;

        public FormRekapPrestasi()
        {
            InitializeComponent();
        }

        private void FormRekapPrestasi_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                // 1. Load data Prodi ke ComboBox
                string queryProdi = "SELECT DISTINCT Prodi FROM Mahasiswa";
                SqlCommand cmdProdi = new SqlCommand(queryProdi, conn);
                da = new SqlDataAdapter(cmdProdi);
                dtProdi = new DataTable();
                da.Fill(dtProdi);

                // Tambahkan opsi "Semua Prodi"
                DataRow newRow = dtProdi.NewRow();
                newRow["Prodi"] = "Semua Prodi";
                dtProdi.Rows.InsertAt(newRow, 0);

                cmbProdi.DataSource = dtProdi;
                cmbProdi.DisplayMember = "Prodi";
                cmbProdi.ValueMember = "Prodi";

                // 2. Setup ComboBox Status
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("Semua Status");
                cmbStatus.Items.Add("Pending");
                cmbStatus.Items.Add("Approved");
                cmbStatus.Items.Add("Rejected");
                cmbStatus.Items.Add("Completed");
                cmbStatus.SelectedIndex = 0;

                btnCetak.Enabled = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data filter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedProdi = cmbProdi.SelectedValue.ToString();
                string selectedStatus = cmbStatus.SelectedItem.ToString();

                // Ubah pilihan "Semua" menjadi string kosong untuk query
                string filterProdi = selectedProdi == "Semua Prodi" ? "" : selectedProdi;
                string filterStatus = selectedStatus == "Semua Status" ? "" : selectedStatus;

                conn = new SqlConnection(connectionString);
                conn.Open();

                // Menggunakan query JOIN yang disesuaikan dengan database MentorMatch
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =   "SELECT p.PengajuanID, " +
                                    "m.NIM, " +
                                    "m.NamaMahasiswa, " +
                                    "m.Prodi, " +
                                    "d.NamaDosen, " +
                                    "j.NamaJenis, " +
                                    "p.NamaLomba, " +
                                    "p.Penyelenggara, " +
                                    "p.TanggalPelaksanaan, " +
                                    "p.Status, " +
                                    "p.HasilLomba, " +
                                    "p.Juara " +
                                    "FROM PengajuanLomba p " +
                                    "JOIN Mahasiswa m ON p.NIM = m.NIM " +
                                    "JOIN Dosen d ON p.NIDN = d.NIDN " +
                                    "JOIN JenisLomba j ON p.JenisID = j.JenisID " +
                                    "WHERE (@inProdi = '' OR m.Prodi = @inProdi) " +
                                    "AND (@inStatus = '' OR p.Status = @inStatus)";

                cmd.Parameters.AddWithValue("@inProdi", filterProdi);
                cmd.Parameters.AddWithValue("@inStatus", filterStatus);

                da = new SqlDataAdapter(cmd);
                dtPrestasi = new DataTable();
                da.Fill(dtPrestasi);

                dataGridView1.DataSource = dtPrestasi;
                dataGridView1.Columns["PengajuanID"].Visible = false;

                if (dtPrestasi.Rows.Count > 0)
                {
                    btnCetak.Enabled = true;
                }
                else
                {
                    btnCetak.Enabled = false;
                    MessageBox.Show("Data tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data rekap: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            string selectedProdi = cmbProdi.SelectedValue.ToString();
            string selectedStatus = cmbStatus.SelectedItem.ToString();

            string filterProdi = selectedProdi == "Semua Prodi" ? "" : selectedProdi;
            string filterStatus = selectedStatus == "Semua Status" ? "" : selectedStatus;

            // Buka form Cetak Laporan
            FormCetakPrestasi frmCetak = new FormCetakPrestasi(filterProdi, filterStatus);
            frmCetak.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Kembali ke dashboard Admin1
            Admin1 frmAdmin = new Admin1();
            frmAdmin.Show();
        }

        private void btnCetakTerpilih_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Pilih data terlebih dahulu!");
                return;
            }

            int id =
                Convert.ToInt32(
                    dataGridView1.CurrentRow
                    .Cells["PengajuanID"].Value);

            FormCetakPrestasi frm =
                new FormCetakPrestasi(id);

            frm.Show();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
