using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Windows.Forms;
using System.Drawing.Imaging;
using static System.Windows.Forms.AxHost;
using System.Net;
using System.Xml.Linq;

namespace HotelManagement
{
    class Room
    {
        MYDB mydb = new MYDB();
        public bool insert(int id, string room_type, string beb_type, int price)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO room (id, roomtype, bebtype, price, status)" +
                " VALUES (@id,@roomtype, @bebtype, @price,@status)", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@roomtype", SqlDbType.VarChar).Value = room_type;
            cmd.Parameters.Add("@bebtype", SqlDbType.VarChar).Value = beb_type;
            cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = 0;

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
        public bool checkExistRomm(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from room where id = @id", mydb.getConnection);
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
        public DataTable getAllRoom()
        {
            SqlCommand cmd = new SqlCommand("Select * from room", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public bool roomDeleted(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE  FROM room where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value=id;
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            { mydb.closeConnection(); return true; }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateRoom(int id, string roomtype, string bebtype, int price)
        {
            SqlCommand command = new SqlCommand("UPDATE room SET roomtype = @roomtype, bebtype = @bebtype, price = @price WHERE id=@ID", mydb.getConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@roomtype", SqlDbType.VarChar).Value = roomtype;
            command.Parameters.Add("@bebtype", SqlDbType.VarChar).Value = bebtype;
            command.Parameters.Add("@price", SqlDbType.Int).Value = price;
          
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                MessageBox.Show("Error", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
  
}
