using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement
{
    public partial class CreateAccount : Form
    {
        MYDB myDB = new MYDB();
        int time = 60;
        string randomCode;
        public static string to;
        public static string username;
        public CreateAccount()
        {
            InitializeComponent();
        }
        public static string pos;
        private void CreateAccount_Load(object sender, EventArgs e)
        {
            cbb_pos.Items.Add("Manager");
            cbb_pos.Items.Add("Admin");
            cbb_pos.Items.Add("Labourer");
            cbb_pos.Items.Add("Receptionist");
            cbb_pos.Items.Add("Guest");
        }
        private bool CheckUserExist(string usn)
        {
            MYDB db = new MYDB();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from std where username = @username", db.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }
        private bool checkCode()
        {
            if (txt_emailcode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (randomCode == txt_emailcode.Text.ToString())
            {
                to = txt_email.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Code");
                return false;
            }
        }
        private void btt_send_Click(object sender, EventArgs e)
        {
            if (txt_email.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (existEmail())
            {
                MessageBox.Show("Email already used", "Please enter another email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = txt_email.Text.Trim();
            from = "conlocmuahe2004@gmail.com"; // Enter your Gmail address here
            pass = "yhaf zcmu alsl bzwo"; // Enter your Gmail password here
            messageBody = "Code: " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Account creation code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code sent successfully", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //timerSendCode.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkInfor()
        {
            if (txt_user.Text.Trim() == "" || txt_pass.Text.Trim() == "" || txt_emailcode.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private bool existEmail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from std where email = @email", myDB.getConnection);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_email.Text.Trim();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btt_create_Click(object sender, EventArgs e)
        {
            username = txt_user.Text;
            pos = cbb_pos.Text;
            SqlCommand cmd = new SqlCommand("Insert into std (username,password,email,position) values (@us, @pass, @email,@pos)", myDB.getConnection);
            cmd.Parameters.Add("@us", SqlDbType.Char).Value = txt_user.Text;
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = txt_pass.Text;
            cmd.Parameters.Add("@email", SqlDbType.Char).Value = txt_email.Text;
            cmd.Parameters.Add("@pos", SqlDbType.Char).Value = cbb_pos.Text;
            if (checkInfor())
            {
                if (!checkCode())
                    return;
                if (txt_pass.Text != txt_rePass.Text)
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                myDB.openConnection();
                if (!CheckUserExist(txt_user.Text.Trim()))
                {
                    MessageBox.Show("This username has already existed", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account,", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_user.Text = "";
                    txt_pass.Text = "";
                    txt_rePass.Text = "";
                    account account = new account();
                    account.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Registration error", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myDB.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cbb_pos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
