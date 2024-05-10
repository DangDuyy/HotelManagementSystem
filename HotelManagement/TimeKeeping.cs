using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Helpers.GraphicsHelper;

namespace HotelManagement
{
    public partial class TimeKeeping : Form
    {
        
        public TimeKeeping()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        string employID = Login_Form.infoLogin.Trim();
        private void TimeKeeping_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet14.timekeeping' table. You can move, or remove it, as needed.
            //this.timekeepingTableAdapter.Fill(this.quanLyKhachSanDataSet14.timekeeping);
            // hehe();
            datetimeCheckOut.Value = DateTime.Now;
            SqlCommand cmd = new SqlCommand("Select * from std where username = @userid");
            cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = employID;
            DataTable dt = getData(cmd);
            //MessageBox.Show(Login_Form.infoLogin);
            DateTime time = DateTime.Now;
            if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
            {
                lb_welcome.Text = "Welcome HR:  " + dt.Rows[0]["position"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
                string ideployy = dt.Rows[0]["id"].ToString().Trim();
                DateTime dateTime = DateTime.Now;

                string dayOfWeekName = dateTime.ToString("dddd");

                SqlCommand sql = new SqlCommand($"SELECT [{dayOfWeekName}], [shift] FROM chia_ca", mydb.getConnection);
                DataTable data = getData(sql);

                bool hasShift = false; // Biến cờ để kiểm tra ca làm việc

                foreach (DataRow row in data.Rows)
                {
                    string[] employeeIds = row[dayOfWeekName].ToString().Trim().Split(',');
                    List<string> employeeIdList = new List<string>(employeeIds);

                    if (employeeIdList.Contains(ideployy))
                    {
                        //MessageBox.Show("Hello");
                        MessageBox.Show(ideployy);

                        string shift = row["shift"].ToString().Trim();
                        //MessageBox.Show(shift);

                        if (CanCheckIn(shift, DateTime.Now))
                        {
                            MessageBox.Show($"Employee ID {ideployy} scheduled to work the {shift} shift today.");
                            btt_checkintime.Visible = true;
                            btt_checkouttime.Visible = true;
                            hasShift = true;
                            break; // Thoát khỏi vòng lặp nếu tìm thấy ID khớp và ca làm việc phù hợp
                        }
                        else
                        {
                            MessageBox.Show($"The employee {ideployy} schedule to work the shift{shift}. Please checkin later");
                            btt_checkintime.Visible = false;
                            btt_checkouttime.Visible = false;
                            hasShift = true;
                            break;
                        }
                    }
                }

                if (!hasShift) // Nếu sau khi duyệt hết mà không có ca làm
                {
                    MessageBox.Show("Hôm nay bạn không có ca làm.");
                    btt_checkintime.Visible = false;
                    btt_checkouttime.Visible = false;
                }
            }
            else
            {
                lb_welcome.Text = "Welcome HR:  " + dt.Rows[0]["position"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
                string ideployy = dt.Rows[0]["id"].ToString().Trim();
                DateTime dateTime = DateTime.Now;

                string dayOfWeekName = dateTime.ToString("dddd");

                SqlCommand sql = new SqlCommand($"SELECT [{dayOfWeekName}], [shift] FROM chia_ca_ManagerRecept", mydb.getConnection);
                DataTable data = getData(sql);

                bool hasShift = false; // Biến cờ để kiểm tra ca làm việc

                foreach (DataRow row in data.Rows)
                {
                    string[] employeeIds = row[dayOfWeekName].ToString().Trim().Split(',');
                    List<string> employeeIdList = new List<string>(employeeIds);

                    if (employeeIdList.Contains(ideployy))
                    {
                        //MessageBox.Show("Hello");
                        MessageBox.Show(ideployy);

                        string shift = row["shift"].ToString().Trim();
                        //MessageBox.Show(shift);

                        if (CanCheckIn(shift, DateTime.Now))
                        {
                            MessageBox.Show($"Employee ID {ideployy} scheduled to work the {shift} shift today.");
                            btt_checkintime.Visible = true;
                            btt_checkouttime.Visible = true;
                            hasShift = true;
                            break; // Thoát khỏi vòng lặp nếu tìm thấy ID khớp và ca làm việc phù hợp
                        }
                        else
                        {
                            MessageBox.Show($"The employee {ideployy} schedule to work the shift{shift}. Please checkin later");
                            btt_checkintime.Visible = false;
                            btt_checkouttime.Visible = false;
                            hasShift = true;
                            break;
                        }
                    }
                }

                if (!hasShift) // Nếu sau khi duyệt hết mà không có ca làm
                {
                    MessageBox.Show("Hôm nay bạn không có ca làm.");
                    btt_checkintime.Visible = false;
                    btt_checkouttime.Visible = false;
                }
            }
        }
       

        private bool CanCheckIn(string shift, DateTime currentTime)
        {
        
            //MessageBox.Show(currentTime.Hour.ToString());
            switch (shift.Trim())
            {
                case "Sang":
                    return currentTime.Hour >= 6 && currentTime.Hour < 14;
                case "Chieu":
                    return currentTime.Hour >= 14 && currentTime.Hour < 22;
                case "Toi":
                    // For the night shift, we need to account for the fact that it spans two days
                    if (currentTime.Hour >= 22 && currentTime.Hour <= 24 || currentTime.Hour > 0 && currentTime.Hour < 6)
                        return true;


                 
                return false;
                default:
                    return false; // Invalid shift name
            }
        }

        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        private bool idIdExists(string id)
        {
            int x = int.Parse(id);
            SqlCommand cmd = new SqlCommand("Select * from timekeeping where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value= id;
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
        int id;

        private bool dateCheckinExists(DateTime day, string id)
        {
            day = day.Date;
            SqlCommand cmd = new SqlCommand("Select * from timekeeping where date = @date and employee_id = @id", mydb.getConnection);
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = day;
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id; 
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
            FaceRecognition faceRecognition = new FaceRecognition(employID);
            faceRecognition.Show(this);
            
        }

        string getid()
        {
            string numberString;
            do
            {
                numberString = "";
                Random random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    numberString += random.Next(10).ToString();
                }

            } 
            while (idIdExists(numberString));
            return numberString;
        }
        private void btt_checkouttime_Click(object sender, EventArgs e)
        {
            //DateTime checkouttime = datetimeCheckOut.Value;
            SqlCommand hehe = new SqlCommand("Select * from std where username = @user", mydb.getConnection);
            hehe.Parameters.Add("@user", SqlDbType.NChar).Value = employID;
            DataTable dt = getData(hehe);
            // Lấy dữ liệu từ bảng 'timekeeping'
            SqlCommand sql = new SqlCommand("select * from timekeeping WHERE employee_id = @id AND date = @date ", mydb.getConnection);
            sql.Parameters.Add("@id", SqlDbType.NVarChar).Value = dt.Rows[0]["id"].ToString().Trim();
            sql.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.Date;
            DataTable table = getData(sql);

            // Kiểm tra xem có dữ liệu không
            DateTime checkintime;
            if (DateTime.TryParse(table.Rows[0]["checkintime"].ToString(), out checkintime))
            {
                MessageBox.Show(checkintime.ToString());
            }
            else
            {
                MessageBox.Show("Checkintime Value did't valid or did't exist .");
            }
            TimeSpan duration = DateTime.Now - checkintime;
            double hours = duration.TotalHours;
            hours = Math.Round(hours, 2);
            double salary = 0;
            MessageBox.Show($"Số giờ là: {hours}");
            
            double tienphat = 8 - hours;
            /*if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
            {
                salary = hours * 40000.0;
            }
            else
            {
                salary = hours * 60000.0;
            }*/
            //double roundedNumber = Math.Round(hours, 2);
            string status;
            
            if (hours >= 7.5)
            {
                status = "Complete";
                if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                {
                    salary = hours * 40000.0 ;
                }
                else
                {
                    salary = 8 * 60000.0 ;
                }
            }
            else
            {
                status = (8 - hours).ToString();
                if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                {
                    salary = hours * 30000.0 - tienphat * 20000;
                }
                else
                {
                    salary = hours * 30000.0 - tienphat * 30000;
                }
            }
            //MessageBox.Show(id.ToString());
            
            SqlCommand cmd = new SqlCommand("UPDATE timekeeping SET checkouttime = @time, status = @status, salary = @salary WHERE employee_id = @id AND date = @date", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = table.Rows[0]["employee_id"].ToString().Trim();
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.Date;
            cmd.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@salary", SqlDbType.Int).Value = salary;
            mydb.openConnection();
            if (dateCheckinExists(DateTime.Now, table.Rows[0]["employee_id"].ToString().Trim() ))
            {

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Check out successful. Thank You");
                    mydb.closeConnection();
                    return;
                }
                else
                {
                    MessageBox.Show("Errorhhh");
                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
