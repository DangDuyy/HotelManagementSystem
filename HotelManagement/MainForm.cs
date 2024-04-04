using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private void aDDEMPLOYEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show(this);
        }

        private void dELETEEMPLOYEEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateEmployeeForm updateEmployeeForm = new UpdateEmployeeForm();
            updateEmployeeForm.Show(this);
        }

     
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeForm());
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_above_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
