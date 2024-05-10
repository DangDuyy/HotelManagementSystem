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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelManagement
{
    public partial class ResetPass : Form
    {
        internal int typeAccount;
        public ResetPass()
        {
            InitializeComponent();
        }
        //STUDENT std = new STUDENT();
        MYDB db = new MYDB();
        ForgotAccount f = new ForgotAccount();
        string email;
        private void ResetPass_Load(object sender, EventArgs e)
        {

        }

        private void btt_change_Click(object sender, EventArgs e)
        {
            string pass = txt_newpass.Text;
            email = f.GetMail;
            // Khởi tạo một đối tượng ForgetPassForm


            // Gọi phương thức get_email từ đối tượng ForgetPassForm

            // Kiểm tra xem email có giá trị hợp lệ không
            if (!string.IsNullOrEmpty(email))
            {
                // Mở kết nối đến cơ sở dữ liệu
                db.openConnection();

                // Thực hiện truy vấn cập nhật mật khẩu
                SqlCommand command = new SqlCommand("UPDATE log_in SET  password = @pass WHERE email = @email", db.getConnection);
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                // Kiểm tra kết quả của truy vấn
                if (command.ExecuteNonQuery() == 1)
                {
                    // Nếu thành công, thông báo và đóng kết nối
                    MessageBox.Show("Password reset successfully.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu không thành công, thông báo lỗi
                    MessageBox.Show("Error resetting password.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Đóng kết nối
                db.closeConnection();
            }
            else
            {
                // Nếu không tìm thấy email, hiển thị thông báo lỗi
                MessageBox.Show("Email not found.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
