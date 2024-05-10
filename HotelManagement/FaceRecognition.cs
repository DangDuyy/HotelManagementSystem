using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace HotelManagement
{
    public partial class FaceRecognition : Form
    {

        FaceRec faceRec = new FaceRec();
        MYDB mydb = new MYDB();
        public FaceRecognition(string employID)
        {
            InitializeComponent();
            textBox1.Text = employID;
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
        int id;
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
        private void button1_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
        }
       

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(textBox1.Text);
            MessageBox.Show("Successful");
            faceRec.isTrained = true;
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text + ".jpg";
            string imagePath = Path.Combine(".", "Image", fileName);


            // Chuyển đổi hình ảnh thành mảng byte
            byte[] imageBytes;
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    imageBytes = br.ReadBytes((int)fs.Length);
                }
            }
            // Lấy thông tin nhân viên dựa trên username
            SqlCommand cmd = new SqlCommand("Select * from std where username = @user", mydb.getConnection);
            cmd.Parameters.Add("@user", SqlDbType.NChar).Value = textBox1.Text;
            DataTable dt = getData(cmd);

            // Kiểm tra xem có dữ liệu nhân viên không
            if (dt.Rows.Count > 0)
            {
                // Tạo ID ngẫu nhiên cho bản ghi check-in
                id = int.Parse(getid());

                // Lấy thời gian hiện tại
                DateTime checkintime = DateTime.Now;
                DateTime date = DateTime.Now.Date; // Lấy ngày hiện tại mà không có thời gian

                int salary = 0;
                string employee_id = dt.Rows[0]["id"].ToString().Trim();
                if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                {
                    salary = 320000 / 2;
                }
                else
                {
                    salary = 480000 / 2;
                }

                // Chèn thông tin check-in vào cơ sở dữ liệu
                SqlCommand sql = new SqlCommand("Insert into timekeeping (id,employee_id,fname,lname,checkintime,date,status,salary,picture) values (@id,@employee_id,@fname,@lname, @checkin,@date,@status,@salary,@picture)", mydb.getConnection);
                sql.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sql.Parameters.Add("@checkin", SqlDbType.DateTime).Value = checkintime; // Sử dụng kiểu DateTime để lưu cả ngày và giờ
                sql.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = dt.Rows[0]["id"].ToString().Trim();
                sql.Parameters.Add("@fname", SqlDbType.NVarChar).Value = dt.Rows[0]["fname"].ToString().Trim();
                sql.Parameters.Add("@lname", SqlDbType.NVarChar).Value = dt.Rows[0]["lname"].ToString().Trim();
                sql.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now;
                sql.Parameters.Add("@status", SqlDbType.NVarChar).Value = "No Check Out";
                sql.Parameters.Add("@salary", SqlDbType.Int).Value = salary;
                sql.Parameters.Add("@picture", SqlDbType.Image).Value = imageBytes;


                // Mở kết nối và thực thi câu lệnh SQL
                mydb.openConnection();
                if (dateCheckinExists(date, employee_id) == true)
                {
                    MessageBox.Show("You checked in today.");
                    mydb.closeConnection();
                    return;
                }
                else if (sql.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Check-in suscessfull.");
                }
                else
                {
                    MessageBox.Show("Check-in did't success.");
                }
                mydb.closeConnection();
            }
            else
            {
                MessageBox.Show("Don't Found Employee Infomation.");
            }
        }
    }
}
