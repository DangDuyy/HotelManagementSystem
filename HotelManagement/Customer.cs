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
            //string email = txt_email.Text;
            guest.insertCus(id, fname, lname, phone, address,email);
            refresh();
        }

        private void guestTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_customerID.Text = guestTable.CurrentRow.Cells[0].Value.ToString();
            txt_fName.Text = guestTable.CurrentRow.Cells[1].Value.ToString();
            txt_lName.Text = guestTable.CurrentRow.Cells[2].Value.ToString();
            txt_phone.Text = guestTable.CurrentRow.Cells[3].Value.ToString();
            txt_address.Text = guestTable.CurrentRow.Cells[4].Value.ToString();
            txt_email.Text = guestTable.CurrentRow.Cells[5].Value.ToString();
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            string fname = txt_fName.Text;
            string lname = txt_lName.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
         string email = txt_email.Text;
            int id = Convert.ToInt32(txt_customerID.Text);
            if (guest.checkExist(id))
            {
                guest.updateCus(id, fname, lname, phone, address, email);
                MessageBox.Show("Update successful");
                refresh();
            }
            else
                MessageBox.Show("Customer not availiable");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            txt_customerID.Text = "";
            txt_address.Text = string.Empty;
            txt_fName.Text = string.Empty;
            txt_lName.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_phone.Text = string.Empty;
            txt_email.Text = string.Empty;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(txt_customerID.Text);
            if (txt_customerID.Text == string.Empty)
            {
                MessageBox.Show("No Data to move");
                return;
            }
            int id = Convert.ToInt32(txt_customerID.Text);
            if (guest.checkExist(id))
            {
                if(guest.deleteEmployee(id))
                {
                    MessageBox.Show("Deleted successful");
                    refresh();
                }
            }
        }
    }
}
