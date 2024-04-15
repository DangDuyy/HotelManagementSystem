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

namespace HotelManagement
{
    public partial class AddRoomForm : Form
    {
        public AddRoomForm()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        
        Room room = new Room();

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet2.room' table. You can move, or remove it, as needed.
           // this.roomTableAdapter.Fill(this.quanLyKhachSanDataSet2.room);
            DataTable table = new DataTable();
            table = room.getAllRoom(); // Fetch the data only once
            roomTable.DataSource = table;
        }
        void refresh()
        {
            roomTable.ReadOnly = true;
            //DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            roomTable.RowTemplate.Height = 80;
            roomTable.DataSource = room.getAllRoom();
            //picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            roomTable.AllowUserToAddRows = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void departmentId_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_roomid.Text);
            string room_type = txt_RoomType.Text;
            string beb_type = txt_BebType.Text;
            int price = Convert.ToInt32(txt_price.Text);
            if (room.checkExistRomm(id)==false )
            {
                room.insert(id, room_type, beb_type, price);
                MessageBox.Show("ADD ROOM SUCESSFUL", "ADDROOM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
            else
                MessageBox.Show("ADD ROOM FAILED", "ADDROOM", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_roomid);
            string roomtype = txt_RoomType.Text;
            string beb = txt_BebType.Text;
            int price = Convert.ToInt32(txt_price.Text);
            if (room.updateRoom(id, roomtype, beb, price))
            {
                MessageBox.Show("Update successful");
            }
            else
                MessageBox.Show("Error");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txt_roomid.Text = roomTable.CurrentRow.Cells[0].Value.ToString();
            txt_RoomType.Text = roomTable.CurrentRow.Cells[2].Value.ToString();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            string numberString = "";
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_roomid.Text = numberString;
        }
    }
}
