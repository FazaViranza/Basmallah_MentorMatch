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
using System.IO;

namespace TESTUCP1PABD
{
    public partial class UpdateHasilLomba: Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        BindingSource bs = new BindingSource();

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=LAPTOP-QL2H17RM;Initial Catalog=MentorMatchMabarDB;Integrated Security=True");
        }

        public UpdateHasilLomba()
        {
            InitializeComponent();

            cmbJuara.Items.Add("Juara 1");
            cmbJuara.Items.Add("Juara 2");
            cmbJuara.Items.Add("Juara 3");
            cmbJuara.Items.Add("Harapan");
            cmbJuara.Items.Add("Tidak Menang");

            cmbHasilLomba.Items.Add("Menang");
            cmbHasilLomba.Items.Add("Finalis");
            cmbHasilLomba.Items.Add("Tidak Menang");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHasilLomba_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbJuara_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSertifikat_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter =
                "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSertifikat.Text = ofd.FileName;

                if (pictureBoxSertifikat.Image != null)
                {
                    pictureBoxSertifikat.Image.Dispose();
                }

                using (FileStream fs =
                    new FileStream(
                        ofd.FileName,
                        FileMode.Open,
                        FileAccess.Read))
                {
                    pictureBoxSertifikat.Image =
                        Image.FromStream(fs);
                }

                pictureBoxSertifikat.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query =
                "SELECT * FROM vw_PengajuanLomba WHERE Status='Approved'";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;

                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

                txtID.DataBindings.Clear();
                cmbHasilLomba.DataBindings.Clear();
                cmbJuara.DataBindings.Clear();
                txtSertifikat.DataBindings.Clear();

                txtID.DataBindings.Add(
                    "Text",
                    bs,
                    "PengajuanID");

                cmbHasilLomba.DataBindings.Add(
                    "Text",
                    bs,
                    "HasilLomba");

                cmbJuara.DataBindings.Add(
                    "Text",
                    bs,
                    "Juara");

                txtSertifikat.DataBindings.Add(
                    "Text",
                    bs,
                    "SertifikatFile");

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
                if (txtSertifikat.Text == "")
                {
                    MessageBox.Show(
                        "Sertifikat wajib diupload!");
                    return;
                }

                string ext =
                    Path.GetExtension(txtSertifikat.Text)
                    .ToLower();

                if (ext != ".pdf" &&
                    ext != ".jpg" &&
                    ext != ".jpeg" &&
                    ext != ".png")
                {
                    MessageBox.Show(
                        "File harus PDF, JPG, JPEG, atau PNG!");
                    return;
                }


                Koneksi();
                conn.Open();

                cmd = new SqlCommand(
                    "sp_UpdateHasilLomba",
                    conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@ID",
                    txtID.Text);

                cmd.Parameters.AddWithValue(
                    "@HasilLomba",
                    cmbHasilLomba.Text);

                cmd.Parameters.AddWithValue(
                    "@Juara",
                    cmbJuara.Text);

                cmd.Parameters.AddWithValue(
                    "@SertifikatFile",
                    txtSertifikat.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Hasil lomba berhasil diupdate");

                conn.Close();

                btnRead_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            MenuMahasiswa menu =
                new MenuMahasiswa();

            menu.Show();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void cmbHasilLomba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
