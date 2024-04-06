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
    public partial class ShiftForm : Form
    {
        public ShiftForm()
        {
            InitializeComponent();
        }

        Employee employee = new Employee();

        MYDB db = new MYDB();
        
        private void btn_CheckIn_Click(object sender, EventArgs e)

        {
            DateTime checkInTime = DateTime.Now;

            SqlCommand cmd = new SqlCommand("insert into shift(checkin) value (@cin) where manv = @id", db.getConnection);
            cmd.Parameters.Add("@cin", SqlDbType.DateTime).Value = checkInTime;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(txt_ID.Text);

            MessageBox.Show("Bat dau ca lam viec");

        }



        private void btn_CheckOut_Click(object sender, EventArgs e)
        {
            DateTime checkOutTime = DateTime.Now;
            SqlCommand cmd = new SqlCommand("insert into shift(checkout) value (@cout) where manv = @id", db.getConnection);
            cmd.Parameters.Add("@cout", SqlDbType.DateTime).Value = checkOutTime;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(txt_ID.Text);

            MessageBox.Show("Ket thuc ca lam viec");

        }
    }
}
