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
    public partial class DITMEMAY : Form
    {
        public DITMEMAY()
        {
            InitializeComponent();
        }
        MYDB mydb = new MYDB();
        public DataTable getBookingRoom(SqlCommand cmd)
        {
            //mydb.openConnection();
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        private DataTable getLaubabor()
        {
            //mydb.openConnection();
            SqlCommand cmd = new SqlCommand("Select id,fname,position from std where position = @position");
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = "Labourer";
            DataTable table = new DataTable();
            table = getBookingRoom(cmd);
            return table;

        }
        private void DITMEMAY_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlCommand cmd = new SqlCommand("Select * from chia_ca");
            dataGridView1.DataSource = getBookingRoom(cmd);
            DataTable table = getLaubabor();


        }
        public void AutoAssigment()
        {
           
            SqlCommand cmd = new SqlCommand("Select * from chia_ca");
            // dataGridView1.DataSource = getBookingRoom(cmd);
            DataTable table = getLaubabor();

            Random random = new Random();
            List<DataRow> tasks = table.Rows.Cast<DataRow>().ToList();

            int[,] shiftCounts = new int[7, 3]; // 7 ngày trong tuần, 3 ca mỗi ngày

            for (int i = 0; i < 5; i++) // Thứ Hai đến Thứ Sáu
            {
                shiftCounts[i, 0] = 2; // Ca sáng
                shiftCounts[i, 1] = 2; // Ca chiều
                shiftCounts[i, 2] = 1; // Ca tối
            }

            for (int i = 5; i < 7; i++) // Thứ Bảy và Chủ Nhật
            {
                shiftCounts[i, 0] = 1; // Ca sáng
                shiftCounts[i, 1] = 1; // Ca chiều
                shiftCounts[i, 2] = 1; // Ca tối
            }

            // Theo dõi nhân viên đã được gán trong mỗi ngày
            HashSet<string> assignedEmployeesPerDay = new HashSet<string>();

            // ... phần còn lại của mã ...

            for (int day = 0; day < shiftCounts.GetLength(0); day++)
            {
                assignedEmployeesPerDay.Clear(); // Xóa danh sách cho ngày mới

                for (int shift = 0; shift < shiftCounts.GetLength(1); shift++)
                {
                    List<string> assignedEmployeesForShift = new List<string>(); // Danh sách để lưu trữ nhân viên được gán cho ca này

                    for (int count = 0; count < shiftCounts[day, shift]; count++)
                    {
                        if (tasks.Count == 0)
                        {
                            // Tái cấp dữ liệu nhân viên từ DataTable
                            tasks = table.Rows.Cast<DataRow>().ToList();
                        }

                        DataRow task;
                        string assignedEmployee;
                        int randomEmployeeIndex;

                        do
                        {
                            randomEmployeeIndex = random.Next(tasks.Count);
                            task = tasks[randomEmployeeIndex];
                            assignedEmployee = $"{task["id"].ToString()} {task["fname"].ToString()}";
                        }
                        while (assignedEmployeesPerDay.Contains(assignedEmployee)); // Kiểm tra xem nhân viên đã được gán trong ngày chưa

                        assignedEmployeesForShift.Add(assignedEmployee); // Thêm nhân viên vào danh sách ca này
                        assignedEmployeesPerDay.Add(assignedEmployee); // Thêm nhân viên vào danh sách đã gán
                        tasks.RemoveAt(randomEmployeeIndex);
                    }

                    // Nối chuỗi tất cả nhân viên được gán cho ca này và gán vào DataGridView
                    dataGridView1.Rows[shift].Cells[day + 1].Value = string.Join("\n", assignedEmployeesForShift);
                }
            }

            // ... phần còn lại của mã ...
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateShiftScheduleInDatabase()
        {
            // Lặp qua DataGridView để cập nhật thông tin vào cơ sở dữ liệu
            for (int day = 0; day < dataGridView1.Columns.Count - 1; day++) // Bỏ qua cột đầu tiên vì nó là cột ID
            {
                for (int shift = 0; shift < dataGridView1.Rows.Count; shift++)
                {
                    string assignedEmployees = dataGridView1.Rows[shift].Cells[day + 1].Value?.ToString(); // Lấy thông tin lịch trực từ ô tương ứng

                    if (!string.IsNullOrEmpty(assignedEmployees))
                    {
                        // Tạo câu lệnh SQL để cập nhật thông tin lịch trực vào cơ sở dữ liệu
                        string columnName = "";
                        switch (day)
                        {
                            case 0:
                                columnName = "monday";
                                break;
                            case 1:
                                columnName = "tuesday";
                                break;
                            case 2:
                                columnName = "wednesday";
                                break;
                            case 3:
                                columnName = "thursday";
                                break;
                            case 4:
                                columnName = "friday";
                                break;
                            case 5:
                                columnName = "saturday";
                                break;
                            case 6:
                                columnName = "sunday";
                                break;
                            default:
                                break;
                        }
                        string columnShift = "";
                        switch (shift)
                        {
                            case 0:
                                columnShift = "Sang";
                                break;
                            case 1:
                                columnShift = "Chieu";
                                break;
                            case 2:
                                columnShift = "Toi";
                                break;
                            default:
                                break;
                        }

                        // Thực hiện câu lệnh SQL
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            // Lấy danh sách ID của các nhân viên
                            List<string> employeeIDs = assignedEmployees.Split('\n').Select(item => item.Split(' ')[0]).ToList();

                            // Tạo câu lệnh SQL để cập nhật ID của nhân viên
                            string updateQuery = $"UPDATE chia_ca SET {columnName}=@nhan_vien WHERE shift=@ca";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, mydb.getConnection))
                            {
                                // Ghép danh sách ID thành một chuỗi ngăn cách bằng dấu phẩy
                                string employeeIDsString = string.Join(",", employeeIDs);

                                cmd.Parameters.AddWithValue("@nhan_vien", employeeIDsString);
                                cmd.Parameters.AddWithValue("@ca", columnShift); // Ca bắt đầu từ dòng thứ hai, nên cộng thêm 1

                                mydb.openConnection();
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Update successful");
        }




        private void btt_assigmentWork_Click(object sender, EventArgs e)
        {
            // Gán lịch trực cho nhân viên và hiển thị lên DataGridView
            AutoAssigment();
            // Cập nhật thông tin vào cơ sở dữ liệu
            UpdateShiftScheduleInDatabase();
        }

    }





}
