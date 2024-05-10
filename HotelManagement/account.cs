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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
       MYDB db = new MYDB();
        private bool CheckID(int usn)
        {
           
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from std where id= @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }
        private bool CheckUserExist(string usn)
        {
           
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

        private bool checkInfor()
        {
            if (txt_id.Text.Trim() == "" || txt_fname.Text.Trim() == "" || txt_lname.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void btt_create_Click(object sender, EventArgs e)
        {
            MemoryStream pic = new MemoryStream();
            pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
            DateTime bdate = guna2DateTimePicker1.Value.Date;
            string gender = "Male";

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }
            SqlCommand cmd = new SqlCommand("UPDATE std SET id = @id, fname = @fname, lname = @lname, bdate = @bdate,gender = @gender, phone = @phone, address = @address, picture = @picture WHERE username = @username", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.NChar).Value = txt_id.Text;
            cmd.Parameters.Add("@fname", SqlDbType.NChar).Value = txt_fname.Text;
            cmd.Parameters.Add("@lname", SqlDbType.NChar).Value = txt_lname.Text;
            cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = txt_phone.Text;
            cmd.Parameters.Add("@address", SqlDbType.NChar).Value = txt_address.Text;
            cmd.Parameters.Add("@bdate", SqlDbType.Date).Value = bdate;
            cmd.Parameters.Add("@picture", SqlDbType.Image).Value = pic.ToArray();
            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = CreateAccount.username;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            if (checkInfor())
            {
                db.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully updated. Please wait for Admin approval.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear the form fields
                }
                else
                {
                    MessageBox.Show("Update error", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void account_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            string numberString;
            string pos = CreateAccount.pos;
            if(pos.Trim() == "Manager")
            {
                numberString = "QL";
            }
            else if(pos.Trim() == "Labourer")
            {
                numberString = "LC";
            }
            else if (pos.Trim() == "Receptionist")
            {

                numberString = "LT";
            }
            else if ((pos.Trim() == "Admin"))
            {
                numberString = "AD";

            }
            else
            {
                numberString = "Guest";
            }
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_id.Text = numberString;
        }
    }

}
