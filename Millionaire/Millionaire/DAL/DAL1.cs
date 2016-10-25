using Millionaire.Model;
using System;
using System.Collections;
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

        //Delete user
        public void DeleteUser(string userName)
        {
            string sql = "execute usp_deleteUser" + " '" + @userName + "' ";

            SqlCommand cmd = new SqlCommand(sql, Connect());

            cmd.Parameters.Add(new SqlParameter("userName", userName));

            try
            {
                cmd.ExecuteNonQuery();
                Connect().Close();

            }
            catch
            {
                Connect().Close();

            }
        }
        //Create or update question
        public bool CreateOrUpdateQuestion(int id, string question, string rightAnswer, int level, string category, string creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            string sql = "execute usp_createQuestion" + @id + ", '" + @question + "', ' " + @rightAnswer + "'" + @level + ", '" + @category + "', " + @creator + "', '" + @wrongAnswer1 + "', '" + @wrongAnswer2 + "', '" + @wrongAnswer3 + "', '" + @sqlCommand + "'";

            SqlCommand cmd = new SqlCommand(sql, Connect());

            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("question", question));
            cmd.Parameters.Add(new SqlParameter("rightAnswer", rightAnswer));
            cmd.Parameters.Add(new SqlParameter("level", level));
            cmd.Parameters.Add(new SqlParameter("category", category));
            cmd.Parameters.Add(new SqlParameter("creator", creator));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer1", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer2", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer3", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("sqlCommand", sqlCommand));

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

        //Validate user
        public bool ValidateUser(string userName, string password, string sqlCommand)
        {
            string sql = @sqlCommand + " '" + @userName + "', '" + @password + "'";

            SqlCommand cmd = new SqlCommand(sql, Connect());
            SqlDataReader reader = cmd.ExecuteReader();

            cmd.Parameters.Add(new SqlParameter("sqlcommand", sqlCommand));
            cmd.Parameters.Add(new SqlParameter("userName", userName));
            cmd.Parameters.Add(new SqlParameter("userPassword", password));

            try
            {
                while (reader.Read())
                {


                    if (reader.GetInt32(0) == 1)
                    {

                        Connect().Close();
                        return true;
                    }
                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
                Connect().Close();
            }
            return false;
        }


        //Create or update scoreboard 
        public bool CreateOrUpdateScoreboard(int entryId, User user, int points)
        {
            string sql = "execute usp_createScoreboardEntry '" + @entryId + "' ," + @user.UserName + "' " + @points;

            SqlCommand cmd = new SqlCommand(sql, Connect());

            cmd.Parameters.Add(new SqlParameter("entryId", entryId));
            cmd.Parameters.Add(new SqlParameter("player", user.UserName));
            cmd.Parameters.Add(new SqlParameter("points", points));

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

        public List<ScoreboardEntry> GetScoreboardEntry()
        {
            string sql = "EXECUTE usp_getScoreboardEntries";

            SqlCommand cmd = new SqlCommand(sql, Connect());
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScoreboardEntry> entryList = new List<ScoreboardEntry>();
            try
            {
                while (reader.Read())
                {
                    ScoreboardEntry entry = new ScoreboardEntry();
                    entry.Player = new Player(reader.GetValue(1).ToString(), "password");
                    entry.Points = Int32.Parse(reader.GetValue(2).ToString());
                    entryList.Add(entry);

                }
                Connect().Close();
                return entryList;
            }
            catch
            {
                Connect().Close();
                return entryList;
            }
        }
    }
}