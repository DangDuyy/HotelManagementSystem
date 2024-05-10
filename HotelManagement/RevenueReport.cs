using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class RevenueReport : Form
    {
        public RevenueReport()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        private void txt_Total_Click(object sender, EventArgs e)
        {

        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void RevenueReport_Load(object sender, EventArgs e)
        {
            day.Text = "TPHCM , Day " + (DateTime.Now.Date.Day - 1).ToString() + " Month  " + DateTime.Now.Month.ToString() + " Year " + DateTime.Now.Year.ToString();
            // Lấy tổng số tiền của khách sạn hôm qua và định dạng nó thành chuỗi tiền tệ
            int totalHotelAmount = totalHotelYesterday();
            string totalHotelFormatted = totalHotelAmount.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
            lb_TotalHotel.Text = totalHotelFormatted;

            // Lấy số lượng phòng đã đặt và hiển thị
            lb_datphong.Text = CheckInRoomCount().ToString() + " Room";
            lb_booked.Text = CheckOutRoomCount().ToString() + " Room";

            // Gọi các phương thức khác
            lb_TotalService.Text = ServiceCount().ToString() + " Service";
            int tienluong = TienLuongLauBor();
            string luong = tienluong.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
            lb_tienluong.Text = luong;
            // Lấy chi phí từ quản lý cửa hàng và định dạng nó thành chuỗi tiền tệ
            StoreManagent storeManagement = new StoreManagent();
            int storeCost = storeManagement.cost();
            string storeCostFormatted = storeCost.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
            lb_costother.Text = storeCostFormatted;

            // Tính toán và hiển thị sự chênh lệch
            int difference = totalHotelAmount - storeCost;
            string differenceFormatted = difference.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
            //MessageBox.Show(differenceFormatted);
            lb_rong.Text = differenceFormatted;

            /*try
            {
                
                // Tạo đối tượng SqlCommand và thiết lập các tham số
SqlCommand sqlCommand = new SqlCommand("insert into report (id,tongdoanhthu,booking,booked,service,salary,feeother,doanhthurong) VALUES (@id,@tongdoanhthu,@booking,@booked,@service,@salary,@feeother,@doanhthurong)", mydb.getConnection);
                sqlCommand.Parameters.AddWithValue("@id", 55);
                sqlCommand.Parameters.AddWithValue("@tongdoanhthu", totalHotelAmount);
                sqlCommand.Parameters.AddWithValue("@booking", CheckInRoomCount());
                sqlCommand.Parameters.AddWithValue("@booked", CheckOutRoomCount());
                sqlCommand.Parameters.AddWithValue("@service", ServiceCount());
                sqlCommand.Parameters.AddWithValue("@salary", TienLuongLauBor());
                sqlCommand.Parameters.AddWithValue("@feeother", storeCost);
                sqlCommand.Parameters.AddWithValue("@doanhthurong", difference);
                sqlCommand.Parameters.AddWithValue("@date", DateTime.Now.Date);
                mydb.openConnection();
                // Thực thi câu lệnh
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
               MessageBox.Show("Lỗi tại: " + ex.StackTrace);
                // Xử lý thêm hoặc ghi log lỗi ở đây
            }
            finally
            {
                mydb.closeConnection();
            }
*/




        }
        public int CheckInRoomCount()
        {
            DateTime time = DateTime.Now.Date;
            int count = 0;

            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM bookroom WHERE checkindate = @checkin", mydb.getConnection);

            sqlCommand.Parameters.AddWithValue("@checkin", time);
            DataTable dt = getData(sqlCommand);


            return dt.Rows.Count;
        }
        public int CheckOutRoomCount()
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            int count = 0;
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM bookroom WHERE checkoutdate >= @yesterday AND checkoutdate < @today", mydb.getConnection);

            sqlCommand.Parameters.AddWithValue("@yesterday", yesterday);
            sqlCommand.Parameters.AddWithValue("@today", DateTime.Now.Date);
            mydb.openConnection();
            DataTable dt = getData(sqlCommand);
            mydb.closeConnection();

            return dt.Rows.Count;
        }
        public int ServiceCount()
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            DateTime today = DateTime.Now.Date;

            // Mở kết nối
            mydb.openConnection();

            // Câu lệnh SQL để lấy tất cả các dịch vụ đã chọn trong ngày hôm qua
            SqlCommand sqlCommand = new SqlCommand("SELECT selectedsevice FROM BookRoom WHERE checkoutdate >= @yesterday AND checkoutdate < @today", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("@yesterday", yesterday);
            sqlCommand.Parameters.AddWithValue("@today", today);

            // Thực thi câu lệnh và lấy dữ liệu
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int serviceCount = 0;
            while (reader.Read())
            {
                // Tách chuỗi dịch vụ bằng dấu phẩy và đếm
                string[] services = reader["selectedsevice"].ToString().Split(',');
                serviceCount += services.Length; // Đếm số lượng dịch vụ
            }

            // Đóng kết nối và trả về số lượng dịch vụ
            mydb.closeConnection();
            return serviceCount;
        }

        public int TienLuongLauBor()
        {
            // Thiết lập thời gian bắt đầu là 8 giờ sáng hôm qua
            DateTime startTime = DateTime.Now.Date.AddDays(-1).AddHours(8);
            // Thiết lập thời gian kết thúc là 6 giờ sáng hôm nay
            DateTime endTime = DateTime.Now.Date.AddHours(7);


            SqlCommand sqlCommand = new SqlCommand("SELECT SUM(salary) FROM timekeeping WHERE checkintime >= @startTime AND checkouttime < @endTime", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("@startTime", startTime);
            sqlCommand.Parameters.AddWithValue("@endTime", endTime);

            mydb.openConnection();
            object result = sqlCommand.ExecuteScalar();

            mydb.closeConnection(); // Khối using sẽ tự đóng, nhưng đây là cách đóng thủ công

            if (result != DBNull.Value)
            {
                int totalSalary = Convert.ToInt32(result);
                return totalSalary;
            }
            else
            {
                return 0; // Trả về 0 nếu không có dữ liệu
            }

        }

        public int totalHotelYesterday()
        {
            // Lấy ngày hôm qua
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);

            SqlCommand sqlCommand = new SqlCommand("SELECT SUM(total) FROM BookRoom WHERE checkoutdate >= @yesterday AND checkoutdate < @today", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("@yesterday", yesterday);
            sqlCommand.Parameters.AddWithValue("@today", DateTime.Now.Date);
            mydb.openConnection();

            // Sử dụng ExecuteScalar để lấy giá trị tổng
            object result = sqlCommand.ExecuteScalar();
            mydb.closeConnection();

            if (result != null && result != DBNull.Value)
            {
                // Chuyển đổi kết quả thành int
                int total = Convert.ToInt32(result);
                return total;
            }
            else
            {
                // Trả về 0 nếu không có dữ liệu
                return 0;
            }
        }



        public DataTable getDiscount(SqlCommand cmd)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }





        private void lb_hantra_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void day_Click(object sender, EventArgs e)
        {

        }

        private void lb_rong_Click(object sender, EventArgs e)
        {

        }
        public int getid()
        {
            int id;
            Random random = new Random();
            while (true)
            {
                string numberString = "";
                for (int i = 0; i < 4; i++)
                {
                    numberString += random.Next(10).ToString();
                }
                id = int.Parse(numberString); // Convert string to integer and return
                if (!checkExistID(id))
                {
                    return id; // Unique ID found, return it
                }
            }
        }
        public bool checkExistID(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from report where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true; // Course with the given name and ID exists
            }
            else
            {
                return false; // Course with the given name and ID does not exist
            }
        }
        private void btt_checkintime_Click(object sender, EventArgs e)
        {
            int totalHotelAmount = totalHotelYesterday();
            StoreManagent storeManagement = new StoreManagent();
            int storeCost = storeManagement.cost();
            int difference = totalHotelAmount - storeCost;
            // Thực hiện các thao tác với cơ sở dữ liệu ở đây
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);

            // Tạo đối tượng SqlCommand và thiết lập các tham số
            SqlCommand sqlCommand = new SqlCommand("insert into report (id,tongdoanhthu,booking,booked,service,salary,feeother,doanhthurong,date) VALUES (@id,@tongdoanhthu,@booking,@booked,@service,@salary,@feeother,@doanhthurong,@date)", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("@id", getid());
            sqlCommand.Parameters.AddWithValue("@tongdoanhthu", totalHotelYesterday());
            sqlCommand.Parameters.AddWithValue("@booking", CheckInRoomCount());
            sqlCommand.Parameters.AddWithValue("@booked", CheckOutRoomCount());
            sqlCommand.Parameters.AddWithValue("@service", ServiceCount());
            sqlCommand.Parameters.AddWithValue("@salary", TienLuongLauBor());
            sqlCommand.Parameters.AddWithValue("@feeother", storeCost);
            sqlCommand.Parameters.AddWithValue("@doanhthurong", difference);
            sqlCommand.Parameters.AddWithValue("@date", yesterday);
            mydb.openConnection();
            // Thực thi câu lệnh
            sqlCommand.ExecuteNonQuery();


            mydb.closeConnection();




        }


    }
}