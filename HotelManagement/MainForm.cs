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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        MYDB mydb = new MYDB();
        string employID = Login_Form.infoLogin.Trim();
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_above.Controls.Add(childForm);
            panel_above.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void button2_Click(object sender, EventArgs e) => OpenChildForm(new AddRoomForm() );
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from std where username = @userid");
            cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = employID;
            DataTable dt = getData(cmd);
            label3.Text = dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddEmployee());
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_above_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bookingRoom());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CheckIn());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customer());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Discount());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddSevice());
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_Form loginForm = new Login_Form();
            loginForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StoreManagent());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new AssigmentForQLvaNV());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1());
        }
    }
}
