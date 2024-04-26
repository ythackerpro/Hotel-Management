using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Hotel_Management.All_User_Control
{
    public partial class UC_CustomerCheckOut : UserControl
    {
        function fn = new function();
        String query;

        public UC_CustomerCheckOut()
        {
            InitializeComponent();

        }

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
            query = "SELECT c.*, r.* FROM customer c INNER JOIN rooms r ON c.roomid = r.roomid WHERE c.chekout = 'NO'";
            //query = "SELECT * from customer";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    query = "SELECT cust.*, r.* FROM customer cust INNER JOIN rooms r ON cust.roomid = r.roomid WHERE cust.cname LIKE " + txtName.Text; //+ " AND cust.chekout = 'NO'";
            //    //query = "SELECT * from customer where cname like '\" + txtName.Text + \"%' ";
            //    DataSet ds = fn.getData(query);
            //    dataGridView1.DataSource = ds.Tables[0];
            //}
            //catch(Exception ex)
            //{
            //    debugBox.Text = ex.Message;
            //}
            string searchText = txtName.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                //if (string.IsNullOrEmpty(searchText))

                if (row != null) // Check if the row itself is not null
                {
                    try
                    {
                        if (row.Cells["cname"] != null) // Check if the specific cell exists
                        {
                            string customerName = "test";
                            customerName = row.Cells["cname"].Value.ToString().ToLower();
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                            currencyManager.SuspendBinding();
                            if (customerName.Contains(searchText))
                            {
                                if (!row.Visible) // Check if the row is currently visible
                                {
                                    row.Visible = true;
                                }
                            }
                            else
                            {
                                if (row.Visible == true) // Check if the row is currently visible
                                {
                                    row.Visible = false; // Hide the row only if it's currently visible
                                }
                            }
                            currencyManager.ResumeBinding();
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        // Handle the case where the "cname" cell is null (optional)
                        // You can log the error or display a message to the user
                        Console.WriteLine("Error: Null reference encountered for cell 'cname' in a row.");
                        Console.WriteLine(ex.Message); // Provides more details about the exception
                    }

                }
            }
        }

        int id;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    debugText2.Text = id.ToString();
            //    txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    txtRoomNo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //}
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckOutDate.Text;
                    query = "update customer set chekout = 'YES', checkout = ' " + cdate + " ' where cid =" + id + " update rooms set booked = 'NO' where roomNo ='" + txtRoomNo.Text + "'";
                    fn.setData(query, "Check Out Successfully. ");
                    UC_CustomerCheckOut_Load(this, null);
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoomNo.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row was clicked
            {
                dataGridView1.Rows[e.RowIndex].Selected = true; // Select the entire row based on the clicked row index
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // User has selected at least one row

                    // Option 1: Accessing the first selected row (assuming single row selection)
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Access data from the selected row
                    string selectedCustomerName = selectedRow.Cells["cname"].Value.ToString();
                    int selectedCustomerID = int.Parse(selectedRow.Cells["cid"].Value.ToString()); // Assuming "customerID" is an integer column
                    //debugText2.Text = selectedCustomerID.ToString();
                    txtCName.Text = selectedCustomerName.ToString();
                    txtRoomNo.Text = selectedRow.Cells["roomid"].Value.ToString();
                }
                else
                {
                    // No row is selected (optional: inform the user)
                    MessageBox.Show("Please select a row to extract data.");
                }
            }
        }
    }
}
