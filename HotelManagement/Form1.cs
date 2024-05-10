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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm1(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            panel_above1.Controls.Add(childForm);
            panel_above1.Tag = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btt_forLaubour_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new DITMEMAY());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new AssigmentForQLvaNV());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btt_chamcong_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new TimeKeeping());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new DataTimeKeeping());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new RevenueReport());
        }
    }
}
