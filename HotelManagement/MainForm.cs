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
        
      
    }
}
