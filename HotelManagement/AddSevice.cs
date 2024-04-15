using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace HotelManagement
{
    public partial class AddSevice : Form
    {
        public AddSevice()
        {
            InitializeComponent();
        }
        MYDB mydb= new MYDB();
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        private void AddSevice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet5.sevice' table. You can move, or remove it, as needed.
            //this.seviceTableAdapter.Fill(this.quanLyKhachSanDataSet5.sevice);
            SqlCommand cmd = new SqlCommand("select * from sevice");
            serviceTable.DataSource = getData(cmd);

            
        }

        private void serviceTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = serviceTable.CurrentRow.Cells[0].Value.ToString();
            txt_name.Text = serviceTable.CurrentRow.Cells[1].Value.ToString();
            txt_des.Text = serviceTable.CurrentRow.Cells[2].Value.ToString();
            txt_cost.Text = serviceTable.CurrentRow.Cells[3].Value.ToString();

        }
        private bool checkExist(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from sevice where Id= @id", mydb.getConnection);
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
        void refresh()
        {
            SqlCommand cmd = new SqlCommand("Select * from sevice");
            serviceTable.ReadOnly = true;
            serviceTable.RowTemplate.Height = 80;
            serviceTable.DataSource = getData(cmd);
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            string Name = txt_name.Text;
            string Des = txt_des.Text;
            int cose = Convert.ToInt32(txt_cost.Text);

            if (checkExist(id))
            {
                // Maybe display a message to the user that the discount ID already exists
                MessageBox.Show("ADD DISOUNT FAILED", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Corrected the SQL command string
                SqlCommand cmd = new SqlCommand("INSERT INTO sevice(Id, sevice_name,des, cost)" + "VALUES(@id, @name, @des, @cost)", mydb.getConnection);

                // Fixed the parameter names
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = Name;
                cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = Des;
                cmd.Parameters.Add("@cost", SqlDbType.Int).Value = cose;

                MessageBox.Show("ADD DISOUNT SUCCESSFUL", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Execute the command
                mydb.openConnection();
                cmd.ExecuteNonQuery();
                mydb.closeConnection();
                refresh();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            string Name = txt_name.Text;
            string Des = txt_des.Text;
            int cose = Convert.ToInt32(txt_cost.Text);
            SqlCommand cmd = new SqlCommand("Update sevice SET sevice_name =@name, des =@des, cost =@cost where Id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = Name;
            cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = Des;
            cmd.Parameters.Add("@cost", SqlDbType.Int).Value = cose;
            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                MessageBox.Show("Update succesfull", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();

            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Service has not been added yet", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool deleteService(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM sevice WHERE Id=@id", mydb.getConnection);
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
                MessageBox.Show("Error", "DELETE SERVICE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text)  ;
            if (checkExist(id)){
                deleteService(id);
                MessageBox.Show("DELETE SUCCESSFUL", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            txt_cost.Text = "";
            txt_des.Text = "";
            txt_id.Text = "";
            txt_name.Text = "";
        }
    }
}
