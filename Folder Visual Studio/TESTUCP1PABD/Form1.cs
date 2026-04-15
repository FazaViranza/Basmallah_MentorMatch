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
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        bool isConnected = false;

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True"
            );
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (!isConnected)
                {
                    MessageBox.Show("Silakan koneksikan database terlebih dahulu!");
                    return;
                }

               
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

                string query =
                "SELECT Role FROM Users " +
                "WHERE Username=@Username AND Password=@Password";

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                object role = cmd.ExecuteScalar();

                if (role != null)
                {
                    string userRole = role.ToString();

                    MessageBox.Show("Login Berhasil sebagai " + userRole);

                    this.Hide();

                    if (userRole == "Mahasiswa")
                    {
                        new Mahasiswa().Show();
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
                    MessageBox.Show("Username atau Password salah");
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi(); 

                conn.Open();

                MessageBox.Show("Koneksi ke database berhasil!");

                lblStatus.Text = "Connected";

                isConnected = true; 

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal: " + ex.Message);
                lblStatus.Text = "Failed";
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}