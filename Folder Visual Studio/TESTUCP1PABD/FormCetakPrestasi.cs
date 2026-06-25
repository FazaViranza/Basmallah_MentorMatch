using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TESTUCP1PABD
{
    public partial class FormCetakPrestasi : Form
    {
        private string connectionString = Session.ConnectionString;
        private string filterProdi;
        private string filterStatus;
        private int pengajuanID = 0;

        public FormCetakPrestasi(string prodi, string status)
        {
            InitializeComponent();
            this.filterProdi = prodi;
            this.filterStatus = status;
        }

        public FormCetakPrestasi(int id)
        {
            InitializeComponent();
            pengajuanID = id;

            filterProdi = "";
            filterStatus = "";
        }

        private void FormCetakPrestasi_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Eksekusi query data pengajuan lomba mahasiswa
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (pengajuanID > 0)
                {
                    cmd.CommandText =
                    "SELECT m.NIM, m.NamaMahasiswa, m.Prodi, d.NamaDosen, " +
                    "j.NamaJenis, p.NamaLomba, p.Penyelenggara, " +
                    "p.TanggalPelaksanaan, p.Status, p.HasilLomba, p.Juara " +
                    "FROM PengajuanLomba p " +
                    "JOIN Mahasiswa m ON p.NIM = m.NIM " +
                    "JOIN Dosen d ON p.NIDN = d.NIDN " +
                    "JOIN JenisLomba j ON p.JenisID = j.JenisID " +
                    "WHERE p.PengajuanID = @ID";

                    cmd.Parameters.AddWithValue("@ID", pengajuanID);
                }
                else
                {
                    cmd.CommandText =
                    "SELECT m.NIM, m.NamaMahasiswa, m.Prodi, d.NamaDosen, " +
                    "j.NamaJenis, p.NamaLomba, p.Penyelenggara, " +
                    "p.TanggalPelaksanaan, p.Status, p.HasilLomba, p.Juara " +
                    "FROM PengajuanLomba p " +
                    "JOIN Mahasiswa m ON p.NIM = m.NIM " +
                    "JOIN Dosen d ON p.NIDN = d.NIDN " +
                    "JOIN JenisLomba j ON p.JenisID = j.JenisID " +
                    "WHERE (@inProdi = '' OR m.Prodi = @inProdi) " +
                    "AND (@inStatus = '' OR p.Status = @inStatus)";

                    cmd.Parameters.AddWithValue("@inProdi", filterProdi);
                    cmd.Parameters.AddWithValue("@inStatus", filterStatus);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                // 2. Petakan DataTable ke List objek C# PrestasiData
                List<PrestasiData> listData = new List<PrestasiData>();
                foreach (DataRow row in dt.Rows)
                {
                    listData.Add(new PrestasiData
                    {
                        NIM = row["NIM"].ToString(),
                        NamaMahasiswa = row["NamaMahasiswa"].ToString(),
                        Prodi = row["Prodi"].ToString(),
                        NamaDosen = row["NamaDosen"].ToString(),
                        NamaJenis = row["NamaJenis"].ToString(),
                        NamaLomba = row["NamaLomba"].ToString(),
                        Penyelenggara = row["Penyelenggara"].ToString(),
                        TanggalPelaksanaan = Convert.ToDateTime(row["TanggalPelaksanaan"]).ToString("dd/MM/yyyy"),
                        Status = row["Status"].ToString(),
                        HasilLomba = row["HasilLomba"] != DBNull.Value ? row["HasilLomba"].ToString() : "-",
                        Juara = row["Juara"] != DBNull.Value ? row["Juara"].ToString() : "-"
                    });
                }

                // 3. Menggunakan class CrystalReport yang sudah di-generate dari CrystalReport.rpt
                CrystalReport rd = new CrystalReport();
                rd.SetDataSource(listData);

                // 4. Hubungkan ke CrystalReportViewer
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
