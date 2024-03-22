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

namespace HotelManagement
{
    public partial class UpdateEmployeeForm : Form
    {
        public UpdateEmployeeForm()
        {
            InitializeComponent();
        }
        Employee em = new Employee();
        private void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Receptionist");
            listBox1.Items.Add("Labourer");
            listBox1.Items.Add("Manager");
            //listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) // Kiểm tra xem có mục nào được chọn không
            {
                string selectedValue = listBox1.SelectedItem.ToString(); // Lấy giá trị của mục được chọn
                                                                         // Sử dụng giá trị selectedValue ở đây hoặc gán cho biến khác
                MessageBox.Show("Bạn đã chọn: " + selectedValue); // Hiển thị giá trị đã chọn
            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = TextBoxFname.Text;
            string lname = TextBoxLname.Text;
            string position = listBox1.Text;
            DateTime bdate = DateTimePicker1.Value;
            string phone = TextBoxPhone.Text;
            string adrs = TexBoxAddress.Text;
            string gender = "Male";
            //int phone2= Convert.ToInt32(TextBoxPhone.Text);

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            //allow only 10-100
            if ((this_year - born_year) < 10 || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Employee Age must be between 18 and 100 years", "Birth date error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((ContainsDigit(phone) == false))
            {
                MessageBox.Show("The phone number must be INT", "Phone number error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ContainsDigit(fname) == true || ContainsDigit(lname) == true)
            {
                MessageBox.Show("The Name must be STRING", " THE NAME error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (verif())
            {
                try
                {
                    id = Convert.ToInt32(textBoxID.Text);

                    pic_Face.Image.Save(pic, pic_Face.Image.RawFormat);
                    if (em.updateEmployee(id, fname, lname,position, gender, bdate, phone, adrs, pic))
                    {
                        MessageBox.Show("Employee Information Updated", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        bool verif()
        {
            if ((textBoxID.Text.Trim() == "")
                || (TextBoxFname.Text.Trim() == "")
                || (TextBoxLname.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (TexBoxAddress.Text.Trim() == "")
                || (pic_Face.Image == null))
            {
                return false;
            }
            else
            { return true; }
        }
        public bool ContainsDigit(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            //delete student
            try
            {
                int studentId = Convert.ToInt32(textBoxID.Text);
                //display a confirmation message before the delete
                if ((MessageBox.Show("Are you sure want to delete this Employee ", "Delete Employee ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (em.deleteEmployee(studentId))
                    {
                        MessageBox.Show("Employee  deleted", "Delete Employee ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //clear fiedls after delete
                        textBoxID.Text = "";
                        TextBoxFname.Text = "";
                        TextBoxLname.Text = "";
                        TexBoxAddress.Text = "";
                        listBox1.Text = "";
                        TextBoxPhone.Text = "";
                        DateTimePicker1.Value = DateTime.Now;
                        pic_Face.Image = null;

                    }
                    else
                    {
                        MessageBox.Show("Employee not deleted", "Delete Employee ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Employee ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

 

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBoxID.Text);
                SqlCommand command = new SqlCommand("SELECT id, fname, lname, position, bdate, gender, phone, address, picture FROM std WHERE id = @id");
                command.Parameters.AddWithValue("@id", id);

                DataTable table = em.getEmployee(command);

                if (table.Rows.Count > 0)
                {
                    TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                    TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                    string position = table.Rows[0]["position"].ToString();

                    // Tìm vị trí của mục trong listBox1 mà có giá trị bằng với 'position'
                    int index = listBox1.FindStringExact(position);
                    listBox1.SelectedIndex = index;
                  
                    DateTimePicker1.Value = (DateTime)table.Rows[0]["bdate"];

                    if (table.Rows[0]["gender"].ToString().Trim() == "Female")
                    {
                        RadioButtonFemale.Checked = true;
                    }
                    else
                    {
                        RadioButtonMale.Checked = true;
                    }
                    TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
                    TexBoxAddress.Text = table.Rows[0]["address"].ToString();

                    byte[] pic;
                    pic = (byte[])table.Rows[0]["picture"];
                    MemoryStream picture = new MemoryStream(pic);
                    pic_Face.Image = Image.FromStream(picture);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy", "Tìm kiếm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Tìm kiếm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

   
}
