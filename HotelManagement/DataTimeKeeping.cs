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
    public partial class DataTimeKeeping : Form
    {
        public DataTimeKeeping()
        {
            InitializeComponent();
        }
        MYDB mydb= new MYDB();
        public DataTable getdata(SqlCommand cmd)
        {
            //mydb.openConnection();
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        private void DataTimeKeeping_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet15.timekeeping' table. You can move, or remove it, as needed.
            //this.timekeepingTableAdapter.Fill(this.quanLyKhachSanDataSet15.timekeeping);
           SqlCommand sqlCommand = new SqlCommand("Select * from timekeeping");
            roomTable.ReadOnly = true;
            //DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            roomTable.RowTemplate.Height = 80;
            roomTable.DataSource = getdata(sqlCommand);
        }

        private void roomTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
