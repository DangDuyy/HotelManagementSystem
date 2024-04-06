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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
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
            panel_Son.Controls.Add(childForm);
            panel_Son.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btt_AddEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddEmployee());
        }

        private void btt_Update_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UpdateEmployeeForm());
        }

        private void btn_Shift_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ShiftForm());
        }
    }
}
