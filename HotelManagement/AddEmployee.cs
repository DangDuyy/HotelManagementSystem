using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
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
        Employee employy = new Employee();
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Receptionist");
            listBox1.Items.Add("Labourer");
            listBox1.Items.Add("Manager");
        }

        private void btt_Add_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            string id = txt_EmployeeID.Text;
            string fname = txt_Fname.Text;
            string lname = txt_Lname.Text;
            string pos = listBox1.Text;
            DateTime bdate = DateTimePicker1.Value;
            string phone = txt_Phone.Text;
            string adrs = txt_Address.Text;
            string gender = "Male";

            if (RadioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = DateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            //  sv tu 10-100,  co the thay doi
            if (((this_year - born_year) < 18) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Add Employee Age Must Be Between 18 and 100 year", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ContainsDigit(id) == false)
            {
                MessageBox.Show("The ID number must be INT", "ID number error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((ContainsDigit(phone) == false))
            {
                MessageBox.Show("The phone number must be INT", "Phone number error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ContainsDigit(fname) || ContainsDigit(lname))
            {
                MessageBox.Show("The Name must be STRING", " THE NAME error ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (verif())
            {
                pic_Employee.Image.Save(pic, pic_Employee.Image.RawFormat);
                int ID = Convert.ToInt32(txt_EmployeeID.Text);
                if (employee.insertEmployee(ID, fname, lname, pos, gender,bdate, phone, adrs, pic))
                {
                    MessageBox.Show("New Employee Added", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
        bool verif()
        {
            if ((txt_Fname.Text.Trim() == "")
                        || (txt_Lname.Text.Trim() == "")
                        || (txt_Address.Text.Trim() == "")
                        || (txt_Phone.Text.Trim() == "")
                        || (pic_Employee.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_Employee.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
