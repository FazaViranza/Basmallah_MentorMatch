using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;
using System.Data.SqlClient;

namespace TESTUCP1PABD
{

    public partial class FormImportExcel: Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }

        DataTable dtExcel = new DataTable();

        public FormImportExcel()
        {
            InitializeComponent();
            this.Paint += Form_Paint;

            cmbJenisImport.Items.Add("Mahasiswa");
            cmbJenisImport.Items.Add("Dosen");

            cmbJenisImport.SelectedIndex = -1;
            cmbJenisImport.Text = "-- Pilih Jenis Import --";
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(180, 15, 23, 42)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            Admin1 admin = new Admin1();
            admin.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFile.Clear();

            dataGridView1.DataSource = null;

            dtExcel.Clear();

            cmbJenisImport.SelectedIndex = -1;

            cmbJenisImport.Text = "-- Pilih Jenis Import --";
        }

        private void ImportDosen()
        {
            Koneksi();
            conn.Open();

            foreach (DataRow row in dtExcel.Rows)
            {
                cmd = new SqlCommand(
                    "INSERT INTO Dosen " +
                    "(NIDN, NamaDosen, Jenis, Status) " +
                    "VALUES (@NIDN,@NamaDosen,@Jenis,@Status)",
                    conn);

                cmd.Parameters.AddWithValue(
                    "@NIDN",
                    row["NIDN"].ToString());

                cmd.Parameters.AddWithValue(
                    "@NamaDosen",
                    row["NamaDosen"].ToString());

                cmd.Parameters.AddWithValue(
                    "@Jenis",
                    row["Jenis"].ToString());

                cmd.Parameters.AddWithValue(
                    "@Status",
                    row["Status"].ToString());

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Import dosen berhasil!");
        }

        

        private void ImportMahasiswa()
        {
            Koneksi();
            conn.Open();


            foreach (DataRow row in dtExcel.Rows)
            {
                cmd = new SqlCommand(
                    "INSERT INTO Mahasiswa " +
                    "(NIM,NamaMahasiswa,Prodi,Email,VerificationCode,Status) " +
                    "VALUES (@NIM,@Nama,@Prodi,@Email,@Code,@Status)",
                    conn);

                cmd.Parameters.AddWithValue(
                    "@NIM",
                    row["NIM"].ToString());

                cmd.Parameters.AddWithValue(
                    "@Nama",
                    row["NamaMahasiswa"].ToString());

                cmd.Parameters.AddWithValue(
                    "@Prodi",
                    row["Prodi"].ToString());

                cmd.Parameters.AddWithValue(
                    "@Email",
                    row["Email"].ToString());

                // Generate kode verifikasi acak 6 digit
                Random rnd = new Random();

                cmd.Parameters.AddWithValue(
                    "@Code",
                    rnd.Next(100000, 999999));

                // Status default
                cmd.Parameters.AddWithValue(
                    "@Status",
                    "Pending");

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show(
                "Import mahasiswa berhasil!");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (cmbJenisImport.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih jenis import terlebih dahulu!");
                return;
            }

            if (dtExcel.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Belum ada data yang diimport!");
                return;
            }

            if (!ValidasiHeader())
            {
                MessageBox.Show(
                    "Format file Excel tidak sesuai dengan jenis import yang dipilih!");
                return;
            }

      
            if (!ValidasiData())
                return;

        
            if (cmbJenisImport.Text == "Dosen")
            {
                ImportDosen();
            }
            else
            {
                ImportMahasiswa();
            }

        }

        private bool ValidasiHeader()
        {
            if (cmbJenisImport.Text == "Mahasiswa")
            {
                return
                    dtExcel.Columns.Contains("NIM") &&
                    dtExcel.Columns.Contains("NamaMahasiswa") &&
                    dtExcel.Columns.Contains("Prodi") &&
                    dtExcel.Columns.Contains("Email");
            }

            if (cmbJenisImport.Text == "Dosen")
            {
                return
                    dtExcel.Columns.Contains("NIDN") &&
                    dtExcel.Columns.Contains("NamaDosen") &&
                    dtExcel.Columns.Contains("Jenis") &&
                    dtExcel.Columns.Contains("Status");
            }

            return false;
        }
        private bool ValidasiData()
        {
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                foreach (object item in dtExcel.Rows[i].ItemArray)
                {
                    if (item == DBNull.Value ||
                        string.IsNullOrWhiteSpace(item.ToString()))
                    {
                        MessageBox.Show(
                            "Data kosong ditemukan pada baris " +
                            (i + 2));

                        return false;
                    }
                }
            }

            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormImportExcel_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (cmbJenisImport.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih jenis import terlebih dahulu!");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter =
                "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;


                using (var stream = File.Open(
                    ofd.FileName,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    using (var reader =
                        ExcelReaderFactory.CreateReader(stream))
                    {
                        var result =
                            reader.AsDataSet(
                            new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable =
                                (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                        dtExcel =
                            result.Tables[0];

                        dataGridView1.DataSource =
                            dtExcel;
                    }
                }
            }
        }
    }
}
