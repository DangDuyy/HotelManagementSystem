
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HotelManagement
{
    internal class MYDB
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //get the connection 
        public SqlConnection getConnection
        {
            get
            {
                return con;
            }
        }

        //open the connection
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }

        //close the connection
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
                con.Close();
        }
    }
}