using Hotel_Management.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
            uC_Employee1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            customerDetails1.Visible = false;

        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerCheckOut1.Visible = false;
            customerDetails1.Visible = false;
            uC_Employee1.Visible = false;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CustomerCheckOut1.Visible = true;
            customerDetails1.Visible = false;
            uC_Employee1.Visible = false;
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CustomerCheckOut1.Visible = false;
            customerDetails1.Visible = true;
            uC_Employee1.Visible = false;

        }

        private void btnEmloyee_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            uC_CustomerCheckOut1.Visible = false;
            customerDetails1.Visible = false;
            uC_Employee1.Visible = true;
        }

        private void uC_AddRoom1_Load(object sender, EventArgs e)
        {
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible=false;
            uC_CustomerCheckOut1.Visible=false;
            uC_CustomerRegistration1.Visible = false;
            customerDetails1.Visible=false;
            uC_Employee1.Visible=false;

            btnAddRoom.PerformClick();
        }
    }
}
