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
    public partial class CheckIn : Form
    {
        public CheckIn()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        private void CheckIn_Load(object sender, EventArgs e)
        {
            refresh();
        }
        void refresh()
        {
            label8.Visible = false;
            txt_total_Amount.Visible = false;
            guna2DateTimePicker1.Value = DateTime.Now;
            checkOut.Value = DateTime.Now;
            // Ngắt sự kiện SelectedIndexChanged tạm thời
            checkListBox.SelectedIndexChanged -= checkListBox_SelectedIndexChanged;

            // Thiết lập nguồn dữ liệu cho CheckListBox
            SqlCommand service = new SqlCommand("Select * from sevice"); // Sửa lại chính tả
            checkListBox.DataSource = getBookingRoom(service);
            checkListBox.DisplayMember = "sevice_name".Trim(); // Sửa lại chính tả
            checkListBox.ValueMember = "sevice_name".Trim(); // Sửa lại chính tả
            
            // Kết nối lại sự kiện sau khi đã thiết lập xong
            checkListBox.SelectedIndexChanged += checkListBox_SelectedIndexChanged;

            // Làm tương tự với ComboBox cho khách hàng
            //cbb_guestId.SelectedIndexChanged -= cbb_guestId_SelectedIndexChanged;
            SqlCommand chello = new SqlCommand("select * from customer");
            cbb_guestId.DataSource = getBookingRoom(chello);
            cbb_guestId.DisplayMember = "Id";
            
            //cbb_guestId.SelectedIndexChanged += cbb_guestId_SelectedIndexChanged;

            // Làm tương tự với ComboBox cho mã giảm giá
            cbb_promo.SelectedIndexChanged -= cbb_promo_SelectedIndexChanged;
            SqlCommand dis = new SqlCommand("Select * from discount");
            cbb_promo.DataSource = getBookingRoom(dis);
            cbb_promo.DisplayMember = "discount_name";
            cbb_promo.ValueMember = "discount_name";
            cbb_promo.SelectedItem = null;
            cbb_promo.SelectedIndexChanged += cbb_promo_SelectedIndexChanged;

            SqlCommand cmd = new SqlCommand("Select * from room", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRow row in data.Rows)
            {
                // Tạo một nút mới.
                Button roomButton = new Button();

                // Thiết lập các thuộc tính cho nút, ví dụ như Text.
                roomButton.Text = "Room " + row["id"].ToString() + "\n RoomType: " + row["roomtype"].ToString() + "\n BedType: " + row["bebtype"].ToString() + "\n Price: " + row["price"].ToString(); // Giả sử có cột 'room_number' trong bảng của bạn.
                roomButton.Size = new Size(180, 180);
                // Cho phép nút tự động điều chỉnh kích thước.

                // Thêm sự kiện click nếu cần.
                roomButton.Click += RoomButton_Click;
                roomButton.Tag = row;
                if (row["status"].ToString() == "1")
                {
                    roomButton.BackColor = Color.Red;
                   // addButton.Visible = false;
                }
                else
                {
                    roomButton.BackColor = Color.Green;
                    //addButton.Visible = true;
                }
                // Thêm nút vào FlowLayoutPanel.
                flowLayoutPanel1.Controls.Add(roomButton);

            }
        }
        public DataTable getBookingRoom(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        private void RoomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // Xử lý sự kiện click tại đây, ví dụ: hiển thị thông tin phòng.
            DataRow roomInfo = (DataRow)clickedButton.Tag;
            SqlCommand cmd = new SqlCommand("Select * from sevice", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            txt_roomtype.Text = roomInfo["roomtype"].ToString();
            txt_roomid.Text = roomInfo["id"].ToString();
            txt_bebtype.Text = roomInfo["bebtype"].ToString();

            SqlCommand sqlCommand = new SqlCommand("Select * from bookroom where room_id = @roomid");
            sqlCommand.Parameters.Add("@roomid", SqlDbType.NChar).Value = roomInfo["id"].ToString();
            DataTable table = getBookingRoom(sqlCommand);

            if (roomInfo["status"].ToString() == "1")
            {
                delete();
                addButton.Visible = false;
                guna2DateTimePicker1.Visible = true;
                checkOut.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label8.Visible = true;
                txt_total_Amount.Visible = true;
                label10.Visible = true;
                cbb_promo.Visible = true;
                if (table.Rows.Count > 0)
                {
                    txt_bookingId.Text = table.Rows[0]["bookingid"].ToString();
                    string customerId = table.Rows[0]["cus_Id"].ToString().Trim();
                    int index = -1; // Default value if not found

                    for (int i = 0; i < cbb_guestId.Items.Count; i++)
                    {
                        DataRowView row = (DataRowView)cbb_guestId.Items[i];
                        if (row["Id"].ToString().Trim() == customerId)
                        {
                            index = i;
                            break;
                        }
                    }

                    cbb_guestId.SelectedIndex = index;
                    txt_deposit.Text = table.Rows[0]["deposit"].ToString();
                    txt_totalGuest.Text = table.Rows[0]["totalcus"].ToString();
                    if (table.Rows.Count > 0)
                    {
                        guna2DateTimePicker1.Value = Convert.ToDateTime(table.Rows[0]["checkindate"]);
                        string selected_Services = table.Rows[0]["selectedsevice"].ToString().Trim();
                        string[] selectedServicesArray = selected_Services.Split(',');
                        HashSet<string> selectedServicesSet = new HashSet<string>(selectedServicesArray);
                        for (int i = 0; i < checkListBox.Items.Count; i++)
                        {
                            checkListBox.SetItemChecked(i, false);
                        }
                        //MessageBox.Show("heelo");
                        for (int i = 0; i < checkListBox.Items.Count; i++)
                        {
                            //MessageBox.Show(data.Rows[i]["sevice_name"].ToString().Trim());
                            for (int j = 0; j < selectedServicesArray.Length; j++)
                            {
                                selectedServicesArray[j] = selectedServicesArray[j].Trim();
                                if (selectedServicesArray[j] == data.Rows[i]["sevice_name"].ToString().Trim())
                                {
                                    //MessageBox.Show("heelo");
                                    checkListBox.SetItemChecked(i, true);
                                    break;
                                }

                            }

                        }
                    }

                }
            }
            else
            {
                delete();
                addButton.Visible = true;
                guna2DateTimePicker1.Visible = true;
                checkOut.Visible = false;
                label6.Visible = false;
                label5.Visible = true;
                label8.Visible = false;
                txt_total_Amount.Visible = false;
                label10.Visible = false;
                cbb_promo.Visible = false;
            }
            
            //txt_bookingId.Text = roomInfo["id"].ToString();
           
            
            

        }
        void delete()
        {
            for (int i = 0; i < checkListBox.Items.Count; i++)
            {
                checkListBox.SetItemChecked(i, false);
            }
            txt_totalGuest.Text = string.Empty;
            txt_bookingId.Text = string.Empty;
            txt_total_Amount.Text = string.Empty;
            txt_deposit.Text = string.Empty;


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
        List<string> selectedServices = new List<string>();
        string selectedServicesString;
        private void checkListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           /* // Kiểm tra xem có mục nào được chọn hay không
            if (checkListBox.SelectedIndex != -1)
            {
                //MessageBox.Show("hello");
                // Lấy thông tin dịch vụ từ mục được chọn
                DataRowView selectedService = (DataRowView)checkListBox.SelectedItem;
                string serviceName = selectedService["sevice_name"].ToString().Trim();
                int serviceCost = Convert.ToInt32(selectedService["cost"]);

                // Kiểm tra xem mục này đã được đánh dấu hay chưa
                bool isChecked = checkListBox.GetItemChecked(checkListBox.SelectedIndex);

                if (!isChecked)
                {
                    // Nếu mục chưa được đánh dấu, đánh dấu và thêm vào danh sách dịch vụ đã chọn
                    checkListBox.SetItemChecked(checkListBox.SelectedIndex, true);
                    selectedServices.Add(serviceName);
                    tinhtien(serviceCost);
                    //MessageBox.Show("hello");
                }
                else
                {
                    
                    // Nếu mục đã được đánh dấu, bỏ đánh dấu và xóa khỏi danh sách dịch vụ đã chọn
                    checkListBox.SetItemChecked(checkListBox.SelectedIndex, false);
                    selectedServices.Remove(serviceName);
                    tinhtien(-serviceCost);
                    MessageBox.Show("hello");
                }

                // Cập nhật chuỗi các dịch vụ đã chọn và hiển thị
                selectedServicesString = String.Join(", ", selectedServices);
                lb_service.Text = "Total Service: " + Convert.ToString(totalSevice);
                txt_total_Amount.Text = Convert.ToString(getAmount());
            }*/
        }

       /* List<string> selectedServices = new List<string>();
        string selectedServicesString;
        private void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
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
            //MessageBox.Show(selectedServicesString);
            // Cập nhật label hoặc textbox với chuỗi mới
            lb_service.Text = "Total Service: " + Convert.ToString(totalSevice);
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }*/

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                int booking_id = Convert.ToInt32(txt_bookingId.Text);
                int guest_id = Convert.ToInt32(cbb_guestId.Text);
                DateTime checkin_date = guna2DateTimePicker1.Value.Date;
                DateTime checkout_date = checkOut.Value.Date;
                int deposit = Convert.ToInt32(txt_deposit.Text);
                string roomtype = txt_roomtype.Text;
                string bedtype = txt_bebtype.Text;
                int room_id = Convert.ToInt32(txt_roomid.Text);
                string promo = cbb_promo.Text;
                int total = Convert.ToInt32(txt_total_Amount.Text);
                string selectedService = selectedServicesString;
                int cus = Convert.ToInt32(txt_totalGuest.Text);
                //MessageBox.Show(selected_service);
                if (isBookIdExists(booking_id) == true)
                {
                    MessageBox.Show("Booking ID availible");
                    return;
                }
                // Corrected the SQL command string and parameter name
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO bookroom(bookingId, cus_Id, room_Id, roomtype, bedtype, checkindate,  selectedsevice,  totalcus,deposit) VALUES(@bookingId, @cus_Id, @room_Id, @roomtype, @bedtype, @checkindate, @selectedservice,@totalcus,@deposit)", mydb.getConnection);
                sqlCommand.Parameters.AddWithValue("@bookingId", booking_id);
                sqlCommand.Parameters.AddWithValue("@cus_Id", guest_id);
                sqlCommand.Parameters.AddWithValue("@room_Id", room_id);
                sqlCommand.Parameters.AddWithValue("@roomtype", roomtype);
                sqlCommand.Parameters.AddWithValue("@bedtype", bedtype);
                sqlCommand.Parameters.AddWithValue("@checkindate", checkin_date);
               
                sqlCommand.Parameters.AddWithValue("@selectedservice", selectedServicesString); // Corrected parameter name
          
                sqlCommand.Parameters.AddWithValue("@totalcus", cus);
                sqlCommand.Parameters.AddWithValue("@deposit",deposit );

                // Don't forget to open the connection and execute the command
                mydb.getConnection.Open();
                sqlCommand.ExecuteNonQuery();
                updateRoom(room_id, 1);
                totalProductUsed();
                refresh();
                mydb.getConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool updateRoom(int id, int status)
        {
            SqlCommand command = new SqlCommand("UPDATE room SET status=@status WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@status", SqlDbType.Int).Value = status;


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
        private bool isBookIdExists(int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM bookroom WHERE bookingId = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }
        private int getDateDifference()
        {
            DateTime checkIn_time = guna2DateTimePicker1.Value;
            DateTime checkOut_time = checkOut.Value;
            TimeSpan ts = checkOut_time - checkIn_time;
            return ts.Days;
        }
        private int getCost()
        {
            SqlConnection con = mydb.getConnection;
            int cost = 0;

            try
            {
                con.Open();
                string query = "SELECT price FROM room WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txt_roomid.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cost = dr.GetInt32(0);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

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
         int totalSevice = 0;
        public int tinhtien(int cost)
        {
            totalSevice += cost;
            //MessageBox.Show(Convert.ToString(totalSevice));
            return totalSevice;
        }
        private int getAmount()
        {
            SqlCommand sqlCommand = new SqlCommand("Select * from bookroom where room_Id = @id");
            sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = txt_roomid.Text;
            DataTable dt = getBookingRoom(sqlCommand);
            if (dt.Rows.Count > 0)
            {
                int deposit = Convert.ToInt32(dt.Rows[0]["deposit"].ToString());

                int i = 0;
                int diff = getDateDifference() + 1;
                int cost = getCost();
                float rate = getDiscountRate();
                if (rate != 0)
                {
                    rate = (float)getDiscountRate() / 100;
                    int serviceTotalPrice = totalSevice;
                    i = (int)(((diff * cost) + serviceTotalPrice) * rate) - deposit;
                }
                else
                {
                    int serviceTotalPrice = totalSevice;
                    i = (int)((diff * cost) + serviceTotalPrice) - deposit;
                }
                return i;
            }
            else return 0;
                
        }

        private void cbb_promo_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }
        void totalProductUsed()
        {
            string x = "Costs for HotelService";
            int guest = Convert.ToInt32(txt_totalGuest.Text);
            SqlCommand sqlCommand = new SqlCommand("UPDATE store SET product_quantify = product_quantify - (product_once * @guest) where type = @type", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("@guest", guest);
            sqlCommand.Parameters.AddWithValue("@type", x);
            mydb.getConnection.Open();
            sqlCommand.ExecuteNonQuery();
            mydb.getConnection.Close();
        }

        private void checkOut_ValueChanged(object sender, EventArgs e)
        {
            if (getDateDifference() < 0)
            {
                MessageBox.Show("Error: Check-In and Check-Out. Please Enter The Date again","Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }
        
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            

                int booking_id = Convert.ToInt32(txt_bookingId.Text);
                int guest_id = Convert.ToInt32(cbb_guestId.Text);
                DateTime checkin_date = guna2DateTimePicker1.Value;
                DateTime checkout_date = checkOut.Value;

                string roomtype = txt_roomtype.Text;
                string bedtype = txt_bebtype.Text;
                string room_id = txt_roomtype.Text;
                string promo = cbb_promo.Text;
                int total = Convert.ToInt32(txt_total_Amount.Text);
                string selectedService = selectedServicesString;
                int cus = Convert.ToInt32(txt_totalGuest.Text);
                //MessageBox.Show(selected_service);
                if (isBookIdExists(booking_id) == false)
                {
                    MessageBox.Show("Booking ID unavailiable");
                    return;
                }
                // Corrected the SQL command string and parameter name
                SqlCommand sqlCommand = new SqlCommand("UPDATE bookroom SET cus_Id = @cus_Id, room_Id = @room_Id, roomtype = @roomtype, bedtype = @bedtype, checkindate = @checkindate, checkoutdate = @checkoutdate, selectedsevice = @selectedservice, promo = @promo, total = @total, totalcus = @cus WHERE bookingId = @bookingId ", mydb.getConnection);

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
                sqlCommand.Parameters.AddWithValue("@cus", cus);

                // Don't forget to open the connection and execute the command
                mydb.getConnection.Open();
                sqlCommand.ExecuteNonQuery();
                
                int roomid = Convert.ToInt32(txt_roomid.Text);
                updateRoom(roomid, 0);
                refresh();
                mydb.getConnection.Close();
            
            
        }

        private void checkListBox_ItemCheck(object sender, ItemCheckEventArgs e)
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
            //MessageBox.Show(selectedServicesString);
            // Cập nhật label hoặc textbox với chuỗi mới
            lb_service.Text = "Total Service: " + Convert.ToString(totalSevice);
            txt_total_Amount.Text = Convert.ToString(getAmount());
        }
    }
    }

