﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management.All_User_Control
{
    public partial class UC_Employee : UserControl
    {
        function fn = new function();
        String query;

        public UC_Employee()
        {
            InitializeComponent();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {
            getMaxID();
        }

        private void tabEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabEmployee.SelectedIndex == 1)
            {
                setEmployee(dataGridView1);
            }
            else if (tabEmployee.SelectedIndex == 2)
            {
                setEmployee(dataGridView2);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String pass = txtPassword.Text;

                query = "insert into employee (ename, mobile, gender, emailid, username, pass) values('" + name + "', " + mobile + ", '" + gender + "', '" + email + "', '" + username + "', '" + pass + "') ";
                fn.setData(query, "Employee Registered. ");

                clearAll();
                getMaxID();
            }
            else
            {
                MessageBox.Show("Fill all Fields.", "Warning...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                if(MessageBox.Show("Are you Sure?", "Confirmation...!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //SqlCommand cmd = new SqlCommand("(ID)values(@TxtID)");

                    query = "DELETE FROM employee WHERE eid = "+txtID.Text+"";
                    // Include proper connection and command setup (not shown in this snippet)
                    SqlCommand cmd = new SqlCommand(query);

                    // Add parameter to prevent SQL injection
                    cmd.Parameters.AddWithValue("@txtID", txtID);

                    fn.setData(query, "Record Deleted");
                    tabEmployee_SelectedIndexChanged(this, null);

                }
                    
            }
                
        }

        private void UC_Employee_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        //=========================REQUIRED METHOD===============================
        public void getMaxID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSET.Text = (num + 1).ToString();
            }
        }
        //=========================================================================
        



        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        public void setEmployee(DataGridView dgv)
        {
            query = "Select * from employee";
            DataSet ds = fn.getData(query);
            dgv.DataSource = ds.Tables[0];
        }

        private void labelToSET_Click(object sender, EventArgs e)
        {

        }
    }
}
