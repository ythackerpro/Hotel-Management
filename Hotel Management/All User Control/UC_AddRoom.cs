using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;

        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM rooms";  //table rooms
            DataSet ds = fn.getData(query);
            dataGridView_AddRoom.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if(txtRoomNumber.Text != "" && listRoomType.Text != "" && listBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNumber.Text;
                String type = listRoomType.Text;
                String bed = listBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);

                query = "insert into rooms(roomNo, roomType, bed, price) values ('"+roomno+ "','"+type+ "','"+bed+"',"+price+")";
                fn.setData(query, "Room Added.");

                UC_AddRoom_Load(this, null);
                clearAll();

            }
            else
            {
                MessageBox.Show("Fill all Fields", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomNumber.Clear();
            listRoomType.SelectedIndex = -1;
            listBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {

        }

        private void listRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
    }
}
