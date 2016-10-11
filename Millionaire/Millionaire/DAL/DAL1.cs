using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.DAL
{
    class DAL1
    {
        private SqlConnection Connect()
        {

            String ConnectionString = "Server=localhost;Database=Millionaire;Password=sa;User id=sa;Trusted_connection=yes";
            SqlConnection conn = new SqlConnection(ConnectionString);

            conn.Open();

            return conn;
        }

        public bool CreateUser(string userName, string passWord)
        {
            string sql = "EXECUTE usp_createPlayer '" + userName + "', '" + passWord + "'";

            SqlCommand cmd = new SqlCommand(sql, Connect());

            try
            {
                cmd.ExecuteNonQuery();
                Connect().Close();
                return true;
            }
            catch
            {
                Connect().Close();
                return false;
            }
        }


    }
}
