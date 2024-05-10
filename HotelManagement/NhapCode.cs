using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class NhapCode : Form
    {
        private string _randomCode;

        public NhapCode(string randomCode)
        {
            InitializeComponent();
            _randomCode = randomCode;
        }

        private void NhapCode_Load(object sender, EventArgs e)
        {
            // Có thể thêm mã khởi tạo nếu cần
        }

        private void btt_verify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Code.Text))
            {
                MessageBox.Show("Please enter your code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_randomCode == txt_Code.Text.Trim())
            {
                ResetPass resetPass = new ResetPass();
                resetPass.typeAccount = 1;
                this.Hide();
                if (resetPass.ShowDialog() == DialogResult.Cancel)
                {
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Wrong code", "Code Verification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
 