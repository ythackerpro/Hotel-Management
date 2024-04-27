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

namespace Hotel_Management
{
    public partial class Login : Form
    {
        MyConnection db = new MyConnection();   //function == connect
                                                //
        function fn = new function();
        String query;

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            query = "select username, pass from employee where username = '" + txtUsername.Text + "' and pass = '" + txtPassword.Text + "'";
            DataSet data_set = fn.getData(query);
            
            try
            {
                using (db.con_login)
                {
                    SqlCommand cmd_login = new SqlCommand("sp_role_login", db.con_login);
                    cmd_login.CommandType = CommandType.StoredProcedure;
                    db.con_login.Open();
                    cmd_login.Parameters.AddWithValue("@uname",txtUsername.Text);
                    cmd_login.Parameters.AddWithValue("@upass", txtPassword.Text);
                    SqlDataReader rd = cmd_login.ExecuteReader();
                    if(rd.HasRows)
                    {
                        rd.Read();

                        if (rd[4].ToString() == "OP_ADMIN")
                        {
                            //function.type = "A";
                            labelError.Visible = false;
 
                            Dashboard ds = new Dashboard();
                            this.Hide();
                            ds.Show();

                        }

                        else if (rd[4].ToString() == "OP_NV")
                        {
                            labelError.Visible = false;
                            //function.type = "NV";
                            NV nv = new NV();
                            this.Hide();
                            nv.Show();
                        }

                        
                    }
                    else if (data_set.Tables[0].Rows.Count != 0)
                    {
                        labelError.Visible = false;
                        //function.type = "NV";
                        NV nv = new NV();
                        this.Hide();
                        nv.Show();
                    }

                    else
                    {
                        labelError.Visible = true;
                        txtUsername.Clear();
                        txtPassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

            
            /*
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                labelError.Visible = false;
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();

            }
            else
            {
                labelError.Visible = true;
                txtUsername.Clear();
                txtPassword.Clear();

            }
            */
        }
    }   
    }

