using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        public DataTable getBookingRoom( SqlCommand cmd)
        {   
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();  
            adapter.Fill(table);
            
            return table;
        }
        private void BookingRoom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet9.BookRoom' table. You can move, or remove it, as needed.
           // this.bookRoomTableAdapter4.Fill(this.quanLyKhachSanDataSet9.BookRoom);

            SqlCommand data = new SqlCommand("Select * from bookroom");
            bookingTable.ReadOnly = true;
            bookingTable.DataSource = getBookingRoom(data);

            SqlCommand cmd = new SqlCommand("select * from customer");
            cbb_guestId.DataSource = guest.getCus(cmd);
            cbb_guestId.DisplayMember = "Id";
            cbb_guestId.ValueMember = "Id";
           
            
            SqlCommand service = new SqlCommand("Select * from sevice");
            checkListBox.DataSource = getBookingRoom(service);
            checkListBox.DisplayMember = "sevice_name";
            checkListBox.ValueMember = "sevice_name";
           
            SqlCommand dis = new SqlCommand("Select * from discount");
            cbb_promo.DataSource = getBookingRoom(dis);
            cbb_promo.DisplayMember = "discount_name";
            cbb_promo.ValueMember = "discount_name";
            cbb_promo.SelectedItem = null;  
            
                    
          




        }

        


        private void ccb_roomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typeroom = ccb_roomType.Text;
            SqlCommand cmd = new SqlCommand("Select * from room where roomtype = @roomtype ");
            cmd.Parameters.Add("@roomtype", SqlDbType.NVarChar).Value = typeroom;
            cbb_bedType.DataSource = getBookingRoom(cmd);
            cbb_bedType.DisplayMember = "bebtype";
            cbb_bedType.ValueMember = "bebtype";
            cbb_bedType.SelectedItem = null;
        }
        //listService.ItemCheck += new ItemCheckEventHandler(listService_ItemCheck);
        private void cbb_roomId_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void cbb_bedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Room room = new Room();
            string typeroom = ccb_roomType.Text;
            string bedtype = cbb_bedType.Text;
            SqlCommand cmd = new SqlCommand("Select * from room where roomtype = @roomtype and bebtype = @bed and status = @status");
            cmd.Parameters.Add("@roomtype", SqlDbType.NVarChar).Value = typeroom;
            cmd.Parameters.Add("@bed", SqlDbType.NVarChar).Value = bedtype;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = 0;  
            cbb_roomId.DataSource = getBookingRoom(cmd);
            cbb_roomId.DisplayMember = "id";
            cbb_roomId .ValueMember = "id";
            cbb_roomId .SelectedItem = null;
            
        }
        private bool updateRoom(int id, int status)
        {
            SqlCommand command = new SqlCommand("UPDATE room SET status=@status WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@status", SqlDbType.Int).Value = 1;


            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
               
                return false;
            }
        }
        void refresh()
        {
            SqlCommand data = new SqlCommand("Select * from bookroom");
            bookingTable.DataSource = getBookingRoom(data);
        }

        private void checkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        int totalSevice = 0;
        public int tinhtien(int cost)
        {
            totalSevice += cost;
            //MessageBox.Show(Convert.ToString(totalSevice));
            return totalSevice;
        }
        // Danh sách để theo dõi các dịch vụ đã chọn
        List<string> selectedServices = new List<string>();
        string selectedServicesString;
        public void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DataTable services = (DataTable)checkListBox.DataSource;
            string serviceName = services.Rows[e.Index]["sevice_name"].ToString(); // Giả sử cột tên dịch vụ là 'name'
            int serviceCost = (int)services.Rows[e.Index]["cost"];

            if (e.NewValue == CheckState.Checked)
            {
                // Thêm dịch vụ vào danh sách nếu được chọn
                selectedServices.Add(serviceName);
                tinhtien(serviceCost);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                // Xóa dịch vụ khỏi danh sách nếu bị bỏ chọn
                selectedServices.Remove(serviceName);
                tinhtien(-serviceCost);
            }

            // Cập nhật chuỗi các dịch vụ đã chọn
             selectedServicesString = String.Join(", ", selectedServices);
            MessageBox.Show(selectedServicesString);
            // Cập nhật label hoặc textbox với chuỗi mới
            lb_totalSevice.Text = "Total Service: " + Convert.ToString(totalSevice);
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }
        
        

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {

                int booking_id = Convert.ToInt32(txt_bookingId.Text);
                int guest_id = Convert.ToInt32(cbb_guestId.Text);
                DateTime checkin_date = checkIn.Value;
                DateTime checkout_date = checkOut.Value;

                string roomtype = ccb_roomType.Text;
                string bedtype = cbb_bedType.Text;
                int room_id = Convert.ToInt32(cbb_roomId.Text);
                string promo = cbb_promo.Text;
                int total = Convert.ToInt32(txt_total_Amount.Text);
                string selectedService = selectedServicesString;
                //MessageBox.Show(selected_service);
                if (isBookIdExists(booking_id) == true)
                {
                    MessageBox.Show("Booking ID availible");
                    return;
                }
                // Corrected the SQL command string and parameter name
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO bookroom(bookingId, cus_Id, room_Id, roomtype, bedtype, checkindate, checkoutdate, selectedsevice, promo, total) VALUES(@bookingId, @cus_Id, @room_Id, @roomtype, @bedtype, @checkindate, @checkoutdate, @selectedservice, @promo, @total)", mydb.getConnection);
                sqlCommand.Parameters.AddWithValue("@bookingId", booking_id);
                sqlCommand.Parameters.AddWithValue("@cus_Id", guest_id);
                sqlCommand.Parameters.AddWithValue("@room_Id", room_id);
                sqlCommand.Parameters.AddWithValue("@roomtype", roomtype);
                sqlCommand.Parameters.AddWithValue("@bedtype", bedtype);
                sqlCommand.Parameters.AddWithValue("@checkindate", checkin_date);
                sqlCommand.Parameters.AddWithValue("@checkoutdate", checkout_date);
                sqlCommand.Parameters.AddWithValue("@selectedservice", selectedServicesString); // Corrected parameter name
                sqlCommand.Parameters.AddWithValue("@promo", promo);
                sqlCommand.Parameters.AddWithValue("@total", total);

                // Don't forget to open the connection and execute the command
                mydb.getConnection.Open();
                sqlCommand.ExecuteNonQuery();
                updateRoom(room_id, 1);
                refresh();
                mydb.getConnection.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool isBookIdExists(int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM bookroom WHERE bookingId = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }
        void dislayTotal()
        {
            
        }
        private int getDateDifference()
        {
            DateTime checkIn_time = checkIn.Value;
            DateTime checkOut_time = checkOut.Value;
            TimeSpan ts = checkOut_time - checkIn_time;
            return ts.Days;
        }
        private int getCost()
        {
            SqlConnection con = mydb.getConnection;
            con.Open();
            string query = "SELECT price FROM room WHERE id=@id  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", cbb_roomId.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            
            int cost = 0;
            while (dr.Read())
            {
                cost = dr.GetInt32(0);
            }
            con.Close();
            return cost;
        }
        private int getDiscountRate()
        {
            int rate = 0;
            if (cbb_promo.SelectedIndex != -1 && cbb_promo.Text != "")
            {
                SqlConnection con = mydb.getConnection;
                con.Open();
                string query = "SELECT rate FROM discount WHERE discount_name = @discount_name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@discount_name", cbb_promo.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rate = dr.GetInt32(0);
                }
                con.Close();
                rate = 100 - rate;
            }
            else
            {
                rate = 0;
            }
            return rate;

        }
        private void checkOut_ValueChanged(object sender, EventArgs e)
        {
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }
        private int getAmount()
        {
            int i = 0;
            int diff = getDateDifference() + 1;
            int cost = getCost();
            float rate = getDiscountRate();
            if (rate != 0)
            {
                rate = (float)getDiscountRate() / 100;
                int serviceTotalPrice = totalSevice;
                i = (int)(((diff * cost) + serviceTotalPrice) * rate);
            }
            else
            {
                int serviceTotalPrice = totalSevice;
                i = (int)((diff * cost) + serviceTotalPrice);
            }
            return i;
        }

        private void cbb_promo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            string numberString = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_bookingId.Text = numberString;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {

                int booking_id = Convert.ToInt32(txt_bookingId.Text);
                int guest_id = Convert.ToInt32(cbb_guestId.Text);
                DateTime checkin_date = checkIn.Value;
                DateTime checkout_date = checkOut.Value;

                string roomtype = ccb_roomType.Text;
                string bedtype = cbb_bedType.Text;
                int room_id = Convert.ToInt32(cbb_roomId.Text);
                string promo = cbb_promo.Text;
                int total = Convert.ToInt32(txt_total_Amount.Text);
                string selectedService = selectedServicesString;
                //MessageBox.Show(selected_service);
                if (isBookIdExists(booking_id) == false)
                {
                    MessageBox.Show("Booking ID unavailiable");
                    return;
                }
                // Corrected the SQL command string and parameter name
                SqlCommand sqlCommand = new SqlCommand("UPDATE bookroom SET cus_Id = @cus_Id, room_Id = @room_Id, roomtype = @roomtype, bedtype = @bedtype, checkindate = @checkindate, checkoutdate = @checkoutdate, selectedsevice = @selectedservice, promo = @promo, total = @total WHERE bookingId = @bookingId ", mydb.getConnection);
   
                sqlCommand.Parameters.AddWithValue("@bookingId", booking_id);
                sqlCommand.Parameters.AddWithValue("@cus_Id", guest_id);
                sqlCommand.Parameters.AddWithValue("@room_Id", room_id);
                sqlCommand.Parameters.AddWithValue("@roomtype", roomtype);
                sqlCommand.Parameters.AddWithValue("@bedtype", bedtype);
                sqlCommand.Parameters.AddWithValue("@checkindate", checkin_date);
                sqlCommand.Parameters.AddWithValue("@checkoutdate", checkout_date);
                sqlCommand.Parameters.AddWithValue("@selectedservice", selectedServicesString); // Corrected parameter name
                sqlCommand.Parameters.AddWithValue("@promo", promo);
                sqlCommand.Parameters.AddWithValue("@total", total);

                // Don't forget to open the connection and execute the command
                mydb.getConnection.Open();
                sqlCommand.ExecuteNonQuery();
                refresh();
                mydb.getConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbb_guestId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("select * from room where status = 0");
            ccb_roomType.DataSource = getBookingRoom(sqlCommand);
            ccb_roomType.DisplayMember = "roomtype";
            ccb_roomType.ValueMember = "roomtype";
            ccb_roomType.SelectedItem = null;
        }

        private void filterCMBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        

      
        private void bookingTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_bookingId.Text = bookingTable.CurrentRow.Cells[0].Value.ToString();
                cbb_guestId.Text = bookingTable.CurrentRow.Cells[1].Value.ToString().Trim();
                cbb_roomId.Text = bookingTable.CurrentRow.Cells[2].Value.ToString();
                ccb_roomType.Text = bookingTable.CurrentRow.Cells[3].Value.ToString();
                cbb_bedType.Text = bookingTable.CurrentRow.Cells[4].Value.ToString();
                cbb_promo.Text = bookingTable.CurrentRow.Cells[8].Value.ToString();
                txt_total_Amount.Text = bookingTable.CurrentRow.Cells[9].Value.ToString();
                //cbb_roomId.Text = bookingTable.CurrentRow.Cells[2].Value.ToString();
                DateTime dateValue;
                if (DateTime.TryParse(bookingTable.CurrentRow.Cells[5].Value.ToString(), out dateValue))
                {
                    checkIn.Value = dateValue;
                }
                else
                {
                    MessageBox.Show("Error converting check-in date.");
                }

                DateTime dateValue2;
                if (DateTime.TryParse(bookingTable.CurrentRow.Cells[6].Value.ToString(), out dateValue2))
                {
                    checkOut.Value = dateValue2;
                }
                else
                {
                    MessageBox.Show("Error converting check-out date.");
                }

                /*string selected_Services = bookingTable.CurrentRow.Cells[7].Value.ToString();
                string[] selectedServicesArray = selected_Services.Split(',');
                for (int i = 0; i < checkListBox.Items.Count; i++)
                {
                    checkListBox.SetItemChecked(i, false);
                    for (int j = 0; j < selectedServicesArray.Length; j++)
                    {
                        if (checkListBox.Items[i].ToString() == selectedServicesArray[j].Trim())
                        {
                            checkListBox.SetItemChecked(i, true);
                            break;
                        }
                    }
                }*/
            }
            catch
            {
                MessageBox.Show("ss");
            }
        }
    }
}
