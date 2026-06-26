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
using static System.Collections.Specialized.BitVector32;

namespace TESTUCP1PABD
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;


        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=192.168.100.124,1433;\r\nInitial Catalog=MentorMatchMabarDB;\r\nUser ID=AdminUser;\r\nPassword=Admin123!;\r\nTrustServerCertificate=True"
            );
        }

        public Form1()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;

            try
            {
                Koneksi();
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Koneksi database gagal!\n\n" + ex.Message);

                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Username tidak boleh kosong!");
                    return;
                }

                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password tidak boleh kosong!");
                    return;
                }

                Koneksi();
                conn.Open();

                // 🔥 FIX QUERY (TAMBAH SPASI + ALIAS)
                string query =
                "SELECT u.Role " +
                "FROM Users u " +
                "LEFT JOIN Mahasiswa m ON u.Username = m.NIM " +
                "WHERE u.Username=@Username " +
                "AND u.Password=@Password " +
                "AND (m.Status IS NULL OR m.Status='Active')";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                object role = cmd.ExecuteScalar();

                if (role != null)
                {
                    string userRole = role.ToString();

                    // 🔥 SESSION (INI DOANG TAMBAHAN PENTING)
                    Session.Username = txtUsername.Text;
                    Session.Role = userRole;

                    MessageBox.Show("Login Berhasil sebagai " + userRole);

                    this.Hide();

                    if (userRole == "Mahasiswa")
                    {
                        new MenuMahasiswa().Show();
                    }
                    else if (userRole == "Dosen")
                    {
                        new Dosen().Show();
                    }
                    else if (userRole == "Admin")
                    {
                        new Admin1().Show();
                    }
                }
                else
                {
                    MessageBox.Show("Username / Password salah atau akun belum diverifikasi!");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }

        

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterMahasiswa reg = new RegisterMahasiswa();
            reg.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
