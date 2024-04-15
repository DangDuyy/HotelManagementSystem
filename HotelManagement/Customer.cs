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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        Guest guest = new Guest();  
        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet.customer' table. You can move, or remove it, as needed.
            //this.customerTableAdapter.Fill(this.quanLyKhachSanDataSet.customer);
            SqlCommand command = new SqlCommand("SELECT * FROM customer");
            guestTable.ReadOnly = true;
            guestTable.RowTemplate.Height = 80;
            guestTable.DataSource = guest.getCus(command);

        }

        private void refresh()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM customer");
            guestTable.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            guestTable.RowTemplate.Height = 80;
            guestTable.DataSource = guest.getCus(command);
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_customerID.Text);
            string fname = txt_fName.Text;
            string lname = txt_lName.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
            string email = txt_email.Text;
            guest.insertCus(id, fname, lname, phone, address, email);
            refresh();
        }

        private void guestTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            string numberString = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_customerID.Text = numberString;
        }
    }
}
