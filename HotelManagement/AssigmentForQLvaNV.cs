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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace HotelManagement
{
    public partial class AssigmentForQLvaNV : Form
    {
        public AssigmentForQLvaNV()
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
        private DataTable getRecept()
        {
            SqlCommand cmd = new SqlCommand("Select id,fname,position from std where position = @position ");
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = "Receptionist";
            DataTable table = new DataTable();
            table = getBookingRoom(cmd);
            return table;
        }
        private DataTable getManager()
        {
            SqlCommand cmd = new SqlCommand("Select id,fname,position from std where position = @position ");
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = "Manager";
            DataTable table = new DataTable();
            table = getBookingRoom(cmd);
            return table;
        }
        private DataTable getLaubabor()
        {
            //mydb.openConnection();
            SqlCommand cmd = new SqlCommand("Select id,fname,position from std where position = @position or position = @position1");
            cmd.Parameters.Add("@position", SqlDbType.NVarChar).Value = "Receptionist";
            cmd.Parameters.Add("@position1", SqlDbType.NVarChar).Value = "Manager"; // Changed @position2 to @position1
            DataTable table = new DataTable();
            table = getBookingRoom(cmd);
            return table;

        }

        public void AutoAssigment()
        {


            DataTable table = getLaubabor();
          
            Random random = new Random();
            List<DataRow> tasks = table.Rows.Cast<DataRow>().ToList();

            int[,] shiftCounts = new int[7, 3]; // 7 ngày trong tuần, 3 ca mỗi ngày
            List<string>[,] assignedEmployees = new List<string>[7, 3];
            for (int i = 0; i < 5; i++) // Thứ Hai đến Thứ Sáu
            {
                shiftCounts[i, 0] = 2; // Ca sáng
                assignedEmployees[i, 0] = new List<string>(2);
                shiftCounts[i, 1] = 2; // Ca chiều
                assignedEmployees[i, 1] = new List<string>(2);
                shiftCounts[i, 2] = 1; // Ca tối
                assignedEmployees[i, 2] = new List<string>(1);
            }

            for (int i = 5; i < 7; i++) // Thứ Bảy và Chủ Nhật
            {
                shiftCounts[i, 0] = 1; // Ca sáng
                assignedEmployees[i, 0] = new List<string>(1);

                shiftCounts[i, 1] = 1; // Ca chiều
                assignedEmployees[i, 1] = new List<string>(1);

                shiftCounts[i, 2] = 1; // Ca tối
                assignedEmployees[i, 2] = new List<string>(1);
            }
            HashSet<string> assignedEmployeesPerDay = new HashSet<string>();
           
            for (int day = 0; day < shiftCounts.GetLength(0); day++)
            {
                assignedEmployeesPerDay.Clear(); // Xóa danh sách cho ngày m
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
                        int dem = 0;
                        if (day >= 0 && day < 5 && shift >= 0 && shift < 2 && count == 0)
                        {
                            do
                            {
                                dem++;
                                if (dem == 4)
                                {
                                    if(!check(tasks, "Manager"))
                                    {
                                        dem = 0;
                                        break;
                                    }
                                }
                                randomEmployeeIndex = random.Next(tasks.Count);
                                task = tasks[randomEmployeeIndex];
                                assignedEmployee = $"{task["id"].ToString()} {task["fname"].ToString()}";
                                if (assignedEmployees[day, shift][0] == null)
                                {
                                    assignedEmployees[day, shift][0] = assignedEmployee;
                                    assignedEmployeesForShift.Add(assignedEmployee);
                                    tasks.RemoveAt(randomEmployeeIndex);
                                }
                                else
                                {
                                    break;
                                }                             
                            }
                            while (task["position"].ToString().Trim() == "Manager");
                        }
                        else if (day >= 0 && day < 5 && shift >= 0 && shift < 2 && count == 1)
                        {
                            if(tasks.Count == 0)
                            {
                                break;
                            }
                            do
                            {
                                dem++;
                                if (dem == 4)
                                {
                                    if (!check(tasks, "Receptionist"))
                                    {
                                        dem = 0;
                                        break;
                                    }
                                }                              
                                randomEmployeeIndex = random.Next(tasks.Count);
                                task = tasks[randomEmployeeIndex];
                                assignedEmployee = $"{task["id"].ToString()} {task["fname"].ToString()}";
                                if (assignedEmployees[day, shift][0] == null)
                                {
                                    assignedEmployees[day, shift][0] = assignedEmployee;                        
                                    tasks.RemoveAt(randomEmployeeIndex);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while ( task["position"].ToString().Trim() == "Receptionist");
                        }
                        else
                        {
                            if (tasks.Count == 0)
                            {
                                break;
                            }
                            randomEmployeeIndex = random.Next(tasks.Count);
                            task = tasks[randomEmployeeIndex];
                            assignedEmployee = $"{task["id"].ToString()} {task["fname"].ToString()}";
                            assignedEmployees[day, shift].Add( assignedEmployee);
                            tasks.RemoveAt(randomEmployeeIndex);
                        }         
                    }
                    // Nối chuỗi tất cả nhân viên được gán cho ca này và gán vào DataGridView
                    dataGridView1.Rows[shift].Cells[day + 1].Value = string.Join("\n", assignedEmployeesForShift);
                }
            }
        }
        bool check(List<DataRow> tasks, string tmp)
        {
            for(int i=0; i < tasks.Count; i++)
            {
                if (tasks[i]["position"].ToString().Trim() == tmp.Trim())
                {
                    return true;
                }

            }
            return false;
        }
        public void AutoAssignmentcover()
        {
            DataTable table = getLaubabor();
            Random random = new Random();
            List<DataRow> tasks = table.Rows.Cast<DataRow>().ToList();

            int[,] shiftCounts = new int[7, 3]; // 7 ngày trong tuần, 3 ca mỗi ngày
            List<string>[,] assignedEmployees = new List<string>[7, 3];

            for (int i = 0; i < 5; i++) // Thứ Hai đến Thứ Sáu
            {
                shiftCounts[i, 0] = 2; // Ca sáng
                assignedEmployees[i, 0] = new List<string>(2);
                shiftCounts[i, 1] = 2; // Ca chiều
                assignedEmployees[i, 1] = new List<string>(2);
                shiftCounts[i, 2] = 1; // Ca tối
                assignedEmployees[i, 2] = new List<string>(1);
            }

            for (int i = 5; i < 7; i++) // Thứ Bảy và Chủ Nhật
            {
                shiftCounts[i, 0] = 1; // Ca sáng
                assignedEmployees[i, 0] = new List<string>(1);
                shiftCounts[i, 1] = 1; // Ca chiều
                assignedEmployees[i, 1] = new List<string>(1);
                shiftCounts[i, 2] = 1; // Ca tối
                assignedEmployees[i, 2] = new List<string>(1);
            }
            int n = 0;
            HashSet<string> assignedEmployeesPerDay = new HashSet<string>();
            for (int day = 0; day < shiftCounts.GetLength(0); day++)
            {
                assignedEmployeesPerDay.Clear();
                for (int shift = 0; shift < shiftCounts.GetLength(1); shift++)
                {
                    while (assignedEmployees[day, shift].Count < shiftCounts[day, shift])
                    {
                        if (tasks.Count == 0)
                        {
                            tasks = table.Rows.Cast<DataRow>().ToList();
                        }
                        n++;
                        DataRow task;
                        string assignedEmployee;
                        int randomEmployeeIndex;
                        int dem = 0;
                       
                        do
                        {
                            //MessageBox.Show("Ditmemay");
                            dem++;
                  
                            if (dem == 4)
                            {
                                if (!check(tasks, "Manager") && shiftCounts[day, shift] == 2 && assignedEmployees[day, shift].Count == 0)
                                {
                                    //MessageBox.Show("dem");
                                    List<DataRow> hehe= table.Rows.Cast<DataRow>().ToList();
                                    tasks.AddRange(hehe.ToList());
                                    dem = 0;
                                    break;
                                }
                                if (!check(tasks, "Receptionist") && shiftCounts[day, shift] == 2 && assignedEmployees[day, shift].Count == 1)
                                {
                                    
                                    List<DataRow> hehe = table.Rows.Cast<DataRow>().ToList();
                                    tasks.AddRange(hehe.ToList());
                                    tasks.AddRange(tasks.ToList());
                                    break;
                                }
                            }
                            randomEmployeeIndex = random.Next(tasks.Count);
                            task = tasks[randomEmployeeIndex];
                            assignedEmployee = $"{task["id"].ToString()} {task["fname"].ToString()}";

                            if (!assignedEmployeesPerDay.Contains(assignedEmployee) && ((task["position"].ToString().Trim() == "Manager" && shiftCounts[day, shift] == 2 && assignedEmployees[day, shift].Count == 0) 
                                || (task["position"].ToString().Trim() == "Receptionist" && shiftCounts[day, shift] == 2 && assignedEmployees[day, shift].Count == 1) 
                                || (shiftCounts[day, shift] == 1)))
                            {
                                assignedEmployees[day, shift].Add(assignedEmployee);
                                assignedEmployeesPerDay.Add(assignedEmployee);
                                tasks.RemoveAt(randomEmployeeIndex);
                                break;
                            }
                            //MessageBox.Show(day.ToString() + " " + shift.ToString());
                            //MessageBox.Show(assignedEmployee);
                        } while (true || n == 40);
                    }

                    // Gán danh sách nhân viên được gán cho ca này vào DataGridView
                    dataGridView1.Rows[shift].Cells[day + 1].Value = string.Join("\n", assignedEmployees[day, shift]);
                }
            }
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
                            string updateQuery = $"UPDATE chia_ca_ManagerRecept SET {columnName}=@nhan_vien WHERE shift=@ca";
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
        private void AssigmentForQLvaNV_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SqlCommand cmd = new SqlCommand("Select * from chia_ca_ManagerRecept");
            dataGridView1.DataSource = getBookingRoom(cmd);
            
        }

        private void btt_assigmentWork_Click(object sender, EventArgs e)
        {
            AutoAssignmentcover();
            UpdateShiftScheduleInDatabase();
        }
    }
}
