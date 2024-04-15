using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagement
{
    public partial class Discount : Form
    {
        public Discount()
        {
            InitializeComponent();
        }
        MYDB mydb= new MYDB();
        private void Discount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet1.discount' table. You can move, or remove it, as needed.
            //this.discountTableAdapter.Fill(this.quanLyKhachSanDataSet1.discount);
            SqlCommand cmd = new SqlCommand("Select * from discount");
            discountTable.ReadOnly = true;
            discountTable.RowTemplate.Height = 80;
            discountTable.DataSource = getDiscount(cmd);

        }
        void refresh()
        {
            SqlCommand cmd = new SqlCommand("Select * from discount");
            discountTable.ReadOnly = true;
            discountTable.RowTemplate.Height = 80;
            discountTable.DataSource = getDiscount(cmd);
        }
        public DataTable  getDiscount(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;

        }
        private void discountTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_discountId.Text = discountTable.CurrentRow.Cells[0].Value.ToString();
            txt_discountName.Text = discountTable.CurrentRow.Cells[1].Value.ToString();
            txt_des.Text = discountTable.CurrentRow.Cells[2].Value.ToString();
            txt_Rate.Text = discountTable.CurrentRow.Cells[3].Value.ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            int disId = Convert.ToInt32(txt_discountId.Text);
            string disName = txt_discountName.Text;
            string disDes = txt_des.Text;
            int disRate = Convert.ToInt32(txt_Rate.Text);

            if (checkExist(disId))
            {
                // Maybe display a message to the user that the discount ID already exists
                MessageBox.Show("ADD DISOUNT FAILED", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Corrected the SQL command string
                SqlCommand cmd = new SqlCommand("INSERT INTO discount(discount_id, discount_name, discount_des, rate)" + "VALUES(@id, @name, @des, @rate)", mydb.getConnection);

                // Fixed the parameter names
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = disId;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = disName;
                cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = disDes;
                cmd.Parameters.Add("@rate", SqlDbType.Int).Value = disRate;
         
                MessageBox.Show("ADD DISOUNT SUCCESSFUL", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Execute the command
                    mydb.openConnection();
                 cmd.ExecuteNonQuery();
                 mydb.closeConnection(); 
                refresh();
            }
        }

        private bool checkExist(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from discount where discount_id= @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true; // Course with the given name and ID exists
            }
            else
            {
                return false; // Course with the given name and ID does not exist
            }
        }
        public bool updateDiscount(int id,string name, string des, int rate)
        {
            SqlCommand cmd = new SqlCommand("UPDATE discount SET discount_name = @name,discount_des =@des,rate=@rate WHERE discount_id=@id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = des;
            cmd.Parameters.Add("@rate", SqlDbType.Int).Value = rate;
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Error", "Update Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            int disId = Convert.ToInt32(txt_discountId.Text);
            string disName = txt_discountName.Text;
            string disDes = txt_des.Text;
            int disRate = Convert.ToInt32(txt_Rate.Text);
            if(updateDiscount(disId, disName, disDes, disRate))
            {
                MessageBox.Show("UPDATE DISCOUNT SUCCESSFUL", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            txt_discountName.Text = "";
            txt_discountId.Text = "";
            txt_Rate.Text = "";
            txt_des.Text = "";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
        private bool deleteDiscount(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM discount WHERE discount_id=@id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Error", "DELETE Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_discountId.Text);
            if(deleteDiscount(id))
            {
                MessageBox.Show("DELETE DISCOUNT SUCCESSFUL", "DELETE Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            string numberString = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_discountId.Text = numberString;
        }
    }
}
