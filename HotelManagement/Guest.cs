using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    class Guest
    {
        MYDB mydb =new MYDB();
        public bool insertCus(int  id, string fname, string lname, string phone, string address,string email)
        {
         
            if (checkExist(id))
            {
                MessageBox.Show("Guest with this ID already exists!", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SqlCommand sqlCommand = new SqlCommand("Insert into customer(id,lname,fname,phone,address,email)" + "Values (@id, @lname,@fname,@phone,@address,@email)", mydb.getConnection);
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            sqlCommand.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            sqlCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            sqlCommand.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            mydb.openConnection();

            if ((sqlCommand.ExecuteNonQuery() == 1))
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
        public DataTable getCus(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool checkExist(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from customer where id= @id",mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value=id;
   
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
        public bool deleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM customer WHERE Id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            { mydb.closeConnection(); return true; }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        public bool updateCus(int id , string fname, string lname, string phone, string address, string email)
        {
            SqlCommand sqlCommand = new SqlCommand("Update customer SET address = @address, fname=@fname, lname=@lname, phone=@phone, email =@email where Id = @id", mydb.getConnection);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.Parameters.AddWithValue ("@lname", lname);
            sqlCommand.Parameters.AddWithValue("@fname", fname);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            sqlCommand.Parameters.AddWithValue("@address", address);
            sqlCommand.Parameters.AddWithValue("@email", email);
            mydb.openConnection();
            if ((sqlCommand.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Error", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool isEmployeeIdExists(int id)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM customer WHERE Id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0;
        }
    }
}
