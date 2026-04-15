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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

        }
    }
    private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT Role FROM Users " +
                "WHERE Username=@Username AND Password=@Password";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                object role = cmd.ExecuteScalar();

                if (role != null)
                {
                    MessageBox.Show("Login Berhasil");

                    // nanti redirect form di sini
                }
                else
                {
                    MessageBox.Show("Login Gagal");
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

