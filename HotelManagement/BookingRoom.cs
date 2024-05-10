using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class bookingRoom : Form
    {
        public bookingRoom()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        Room phong = new Room();
        Guest guest = new Guest();
        public DataTable getBookingRoom(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        private void BookingRoom_Load(object sender, EventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("Select * from bookroom ", mydb.getConnection);
            bookingTable.DataSource = getBookingRoom(cmd);
        }

        private void cbb_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string x = cbb_filter.Text;
            {
                //MessageBox.Show(
                if (x.Trim() == "Checkin")
                {
                    SqlCommand cmd = new SqlCommand("Select * from bookroom where checkoutdate IS NULL", mydb.getConnection);
                    bookingTable.DataSource = getBookingRoom(cmd);

                }
                else if (x.Trim() == "Checkout")
                {
                    SqlCommand cmd = new SqlCommand("Select * from bookroom where checkoutdate is not NULL", mydb.getConnection);
                    bookingTable.DataSource = getBookingRoom(cmd);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Select * from bookroom ", mydb.getConnection);
                    bookingTable.DataSource = getBookingRoom(cmd);
                }

            }
        }
    }
}
