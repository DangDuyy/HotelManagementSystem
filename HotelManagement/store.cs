using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagement
{
    internal class store
    {
        MYDB mydb   = new MYDB();
        public bool insert(int id, string name, string type, float quantify,DateTime date, int once, int price)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO store (product_id, product_name, type, product_quantify, product_date,product_once, price,date)" +
                " VALUES (@product_id, @product_name, @product_type, @product_quantify, @product_date, @product_once, @price,@date)", mydb.getConnection);
            cmd.Parameters.Add("@product_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@product_name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@product_type", SqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@product_quantify", SqlDbType.Float).Value = quantify;
            cmd.Parameters.Add("@product_date", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@product_once", SqlDbType.Int).Value = once;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now.Date;
            mydb.openConnection();

            if ((cmd.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;

            }
        }
        public bool checkExist(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from store where product_id = @id", mydb.getConnection);
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
        public DataTable getAllProduct()
        {
            SqlCommand cmd = new SqlCommand("Select * from store", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable getDateCmd(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;

        }
        public bool ProductDeleted(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE  FROM store where product_id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            { mydb.closeConnection(); return true; }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateProduct(int id, string name, string type, float quantify, DateTime date, int once)
        {
            SqlCommand cmd = new SqlCommand("UPDATE store SET  product_name = @product_name, type= @product_type, product_quantify= @product_quantify, product_date= @product_date, product_once=@product_once WHERE product_id=@ID", mydb.getConnection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@product_name", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@product_type", SqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@product_quantify", SqlDbType.Float).Value = quantify;
            cmd.Parameters.Add("@product_date", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@product_once", SqlDbType.Int).Value = once;

            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Error", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
