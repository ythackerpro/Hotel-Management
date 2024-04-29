using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUEPHONG
{
    public partial class frmKetNoiDB : Form
    {
        public frmKetNoiDB()
        {
            InitializeComponent();
        }
        SqlConnection GetCon(string server, string username, string pass, string database)
        {
            return new SqlConnection("Data Source=" + server + "; Initial Catalog=" + database + "; User ID=" + username + "; Password=" + pass + ";");
        }

        private void frmKetNoiDB_Load(object sender, EventArgs e)
        {

        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            SqlConnection con = GetCon(txtServer.Text, txtUsername.Text, txtPassword.Text, cboDatabase.Text);
            try
            {
                con.Open();
                MessageBox.Show("Success!");
            }
            catch (Exception)
            {
                MessageBox.Show("Unsuccess!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            cboDatabase.Items.Clear();
            string conn = "server=" + txtServer.Text + "; User ID=" + txtUsername.Text + "; pwd=" + txtPassword.Text + ";";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string qr = "SELECT * FROM tb_loginRole";
            SqlCommand cmd = new SqlCommand(qr, con);
            IDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cboDatabase.Items.Add(dr[0].ToString());
            }
        }
    }
}
