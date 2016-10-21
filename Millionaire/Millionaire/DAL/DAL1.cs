﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.DAL
{
    class DAL1
    {

        //DB connection
        private SqlConnection Connect()
        {

            String ConnectionString = "Server=localhost;Database=Millionaire;Password=sa;User id=sa;Trusted_connection=yes";
            SqlConnection conn = new SqlConnection(ConnectionString);

            conn.Open();

            return conn;
        }

        //Create and update user
        public bool CreateOrUpdateUser(string userName, string password, string userType, string sqlcommand)
        {
            string sql = @sqlcommand + " '" + @userName + "', '" + @password + "', '" + @userType + "'";

            SqlCommand cmd = new SqlCommand(sql, Connect());

            cmd.Parameters.Add(new SqlParameter("sqlcommand", sqlcommand));
            cmd.Parameters.Add(new SqlParameter("userName", userName));
            cmd.Parameters.Add(new SqlParameter("password", password));
            cmd.Parameters.Add(new SqlParameter("userType", userType));

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

        //Create 





 






    }
}
