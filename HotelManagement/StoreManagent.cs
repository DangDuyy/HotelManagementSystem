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
    public partial class StoreManagent : Form
    {
        public StoreManagent()
        {
            InitializeComponent();
        }
        store store = new store();
        MYDB mydb = new MYDB();
        private void StoreManagent_Load(object sender, EventArgs e)
        {

            


            cbb_type.Items.Add("Costs incurred");
            cbb_type.Items.Add("Costs for HotelService");
            //cbb_type.Items.Add("liter");
            SqlCommand cmd = new SqlCommand("Select * from store");
            storeTable.ReadOnly = true;
            storeTable.RowTemplate.Height = 80;
            storeTable.DataSource = store.getDateCmd(cmd);
        }
        public int cost()
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);

            SqlCommand sql = new SqlCommand("SELECT SUM(price) FROM store WHERE date = @date", mydb.getConnection);
                
                    sql.Parameters.Add("@date", SqlDbType.Date).Value = yesterday;

            mydb.openConnection();
                    object result = sql.ExecuteScalar();
            mydb.closeConnection();
                    if (result != null && result != DBNull.Value)
                    {
                        int sumPrice = Convert.ToInt32(result);
                        // Use sumPrice as neede
                        return sumPrice;
                        
                    }
                    else
                    {
                        // Handle the case where no data was found or the result is null
                         return 0;
                    }
                
            
        }
        void refresh()
        {
            SqlCommand cmd = new SqlCommand("Select * from store");
            storeTable.ReadOnly = true;
            storeTable.RowTemplate.Height = 80;
            storeTable.DataSource = store.getDateCmd(cmd);
        }
        private void fnameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_type.SelectedIndex == 0)
            {
                label1.Visible = false;
                txt_onceUse.Visible = false;
                txt_onceUse.Text = "0";
            }
            else 
            {
                label1.Visible = true;
                txt_onceUse.Visible = true;
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
            txt_productId.Text = numberString;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
                int price = Convert.ToInt32(txt_price.Text);
                int id = Convert.ToInt32(txt_productId.Text);
                string name = txt_productName.Text;
                string type = cbb_type.Text;
                float quantify = (float)Convert.ToDouble(txt_quantify.Text);
                int once = Convert.ToInt32(txt_onceUse.Text);
                DateTime datetime = date.Value;
                if (store.checkExist(id))
                {
                    MessageBox.Show("Product ID availiable");
                    return;
                }
                else
                {
                    if (store.insert(id, name, type, quantify, datetime, once, price))
                    {
                        MessageBox.Show("Add Product Successful");
                        refresh();
                    }
                }
            
        }


        private void storeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_productId.Text = storeTable.CurrentRow.Cells[0].Value.ToString();
            txt_productName.Text = storeTable.CurrentRow.Cells[1].Value.ToString();
            DateTime dateValue;
            if (DateTime.TryParse(storeTable.CurrentRow.Cells[4].Value.ToString(), out dateValue))
            {
                date.Value = dateValue;
            }
            else
            {
                MessageBox.Show("Error converting check-in date.");
            }
            cbb_type.Text = storeTable.CurrentRow.Cells[2].Value.ToString();
            txt_quantify.Text = storeTable.CurrentRow.Cells[3].Value.ToString();
            txt_onceUse.Text  = storeTable.CurrentRow.Cells[5].Value.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txt_productId.Text);
            string name = txt_productName.Text;
            string type = cbb_type.Text;
            float quantify = (float)Convert.ToDouble(txt_quantify.Text);
            int once = Convert.ToInt32(txt_onceUse.Text);
            DateTime datetime = date.Value;
            
            if (store.checkExist(id))
            {
                if (store.updateProduct(id, name, type, quantify, datetime, once))
                {
                    MessageBox.Show("Update successful");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Error");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error");
                return;
            }
        }
    }
}
