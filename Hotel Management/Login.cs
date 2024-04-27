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
using System.Xml.Linq;

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
            try
            {
                query = "SELECT * FROM employee";
                //query_ad  = "SELECT * FROM tb_loginRole";
                DataSet ds_set = fn.getData(query);

                string username = txtUsername.Text;
                string password = txtPassword.Text;
                //string dbType = row["adminlv"].toString();
                bool foundMatch = false;

                // Check if the DataSet has at least one table
                if (ds_set.Tables.Count > 0 && ds_set.Tables[0].Rows.Count > 0)
                {
                    // Loop through rows in the first table (assuming only one table)
                    foreach (DataRow row in ds_set.Tables[0].Rows)
                    {
                        string dbUsername = row["username"].ToString();
                        string dbPassword = row["pass"].ToString();
                        string dbType = row["type"].ToString();

                        if (username == dbUsername && password == dbPassword)
                        {
                            
                            if (dbType == "OP_ADMIN")
                            {
                                MessageBox.Show("Admin");
                                Dashboard ds = new Dashboard();
                                this.Hide();
                                ds.Show();

                            }
                            else if (dbType == "OP_NV")
                            {
                                MessageBox.Show(row["ename"].ToString());
                                NV nv = new NV();
                                this.Hide();
                                nv.Show();
                            }
                            
                            foundMatch = true;
                            break; // Stop iterating if a match is found (optional)
                        }

                    }
                }

                //using (db.con_login)
                //{
                //    SqlCommand cmd_login = new SqlCommand("sp_role_login", db.con_login);
                //    cmd_login.CommandType = CommandType.StoredProcedure;
                //    db.con_login.Open();
                //    cmd_login.Parameters.AddWithValue("@uname", txtUsername.Text);
                //    cmd_login.Parameters.AddWithValue("@upass", txtPassword.Text);
                //    SqlDataReader rd = cmd_login.ExecuteReader();
                //    if (rd.HasRows)
                //    {
                //        rd.Read();

                //        if (rd[4].ToString() == "OP_ADMIN")
                //        {
                //            function.type = "A";
                //            labelError.Visible = false;

                //            Dashboard ds = new Dashboard();
                //            this.Hide();
                //            ds.Show();

                //        }

                //else if (rd[4].ToString() == "OP_NV")
                //{
                //    labelError.Visible = false;
                //    //function.type = "NV";
                //    NV nv = new NV();
                //    this.Hide();
                //    nv.Show();
                //}


                //     }
                //     else if (data_set.Tables[0].Rows.Count != 0)
                //     {
                //         labelError.Visible = false;
                //         //function.type = "NV";
                //         NV nv = new NV();
                //         this.Hide();
                //         nv.Show();
                //     }

                else
                {
                    labelError.Visible = true;
                    txtUsername.Clear();
                    txtPassword.Clear();
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

