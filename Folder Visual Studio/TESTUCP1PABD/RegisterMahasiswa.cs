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
    public partial class RegisterMahasiswa : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

    public RegisterMahasiswa()
        {
            InitializeComponent();
            txtCode.Enabled = false;
        }

        void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }

        string GenerateCode()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        // ================= REGISTER =================
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔥 VALIDASI KOSONG
                if (txtNIM.Text == "" ||
                    txtNama.Text == "" ||
                    txtProdi.Text == "" ||
                    txtEmail.Text == "")
                {
                    MessageBox.Show("Semua field harus diisi!");
                    return;
                }

                // 🔥 VALIDASI NIM
                if (!Regex.IsMatch(txtNIM.Text, @"^\d{11}$"))
                {
                    MessageBox.Show("NIM harus 11 digit angka!");
                    return;
                }

                // 🔥 VALIDASI NAMA
                if (Regex.IsMatch(txtNama.Text, @"\d"))
                {
                    MessageBox.Show("Nama tidak boleh mengandung angka!");
                    return;
                }

                // 🔥 VALIDASI EMAIL
                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Format email tidak valid!");
                    return;
                }

                Koneksi();
                conn.Open();

                // 🔥 CEK NIM SUDAH ADA
                string checkNIM =
                "SELECT COUNT(*) FROM Mahasiswa WHERE NIM=@NIM";

                SqlCommand checkCmd =
                    new SqlCommand(checkNIM, conn);

                checkCmd.Parameters.AddWithValue(
                    "@NIM",
                    txtNIM.Text);

                int exists =
                    (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("NIM sudah terdaftar!");
                    conn.Close();
                    return;
                }

                // 🔥 GENERATE CODE
                string code = GenerateCode();

                // 🔥 STORED PROCEDURE
                cmd = new SqlCommand(
                    "sp_RegisterMahasiswa",
                    conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@NIM",
                    txtNIM.Text);

                cmd.Parameters.AddWithValue(
                    "@Nama",
                    txtNama.Text);

                cmd.Parameters.AddWithValue(
                    "@Prodi",
                    txtProdi.Text);

                cmd.Parameters.AddWithValue(
                    "@Email",
                    txtEmail.Text);

                cmd.Parameters.AddWithValue(
                    "@Code",
                    code);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Kode verifikasi: " + code);

                conn.Close();

                txtCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= VERIFY =================
        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIM.Text == "" || txtCode.Text == "")
                {
                    MessageBox.Show("Masukkan NIM dan kode!");
                    return;
                }

                Koneksi();
                conn.Open();

                cmd = new SqlCommand("sp_VerifyMahasiswa", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
                cmd.Parameters.AddWithValue("@Code", txtCode.Text);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Verifikasi berhasil!");

                    // 🔥 CEK USER BIAR GA DOUBLE
                    string checkUser = "SELECT COUNT(*) FROM Users WHERE Username=@Username";
                    SqlCommand checkUserCmd = new SqlCommand(checkUser, conn);
                    checkUserCmd.Parameters.AddWithValue("@Username", txtNIM.Text);

                    int count = (int)checkUserCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertUser =
                        "INSERT INTO Users (Username, Password, Role) VALUES (@Username,'123','Mahasiswa')";

                        SqlCommand userCmd = new SqlCommand(insertUser, conn);
                        userCmd.Parameters.AddWithValue("@Username", txtNIM.Text);

                        userCmd.ExecuteNonQuery();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kode salah!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNIM_TextChanged(object sender, EventArgs e) { }
        private void txtNama_TextChanged(object sender, EventArgs e) { }
        private void txtProdi_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtCode_TextChanged(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
