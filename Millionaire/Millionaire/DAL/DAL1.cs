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
    public class DAL1
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
        public bool CreateOrUpdateQuestion(int id, string question, string rightAnswer, int level, Category category, Admin creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            string sql = @sqlCommand + " "+ @id + ", '" + @question + "', '" + @rightAnswer + "', " + @level + ", '" + @category.Categoryy + "', '" + @creator.UserName + "', '" + @wrongAnswer1 + "', '" + @wrongAnswer2 + "', '" + @wrongAnswer3 + "'";

            SqlCommand cmd = new SqlCommand(sql, Connect());

           /* cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("question", question));
            cmd.Parameters.Add(new SqlParameter("rightAnswer", rightAnswer));
            cmd.Parameters.Add(new SqlParameter("level", level));
            cmd.Parameters.Add(new SqlParameter("category", category.Categoryy));
            Category c = new Category(category.Categoryy);
            String hej = c.Categoryy;
            cmd.Parameters.Add(new SqlParameter(creator.ToString(), hej));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer1", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer2", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("wrongAnswer3", wrongAnswer1));
            cmd.Parameters.Add(new SqlParameter("sqlCommand", sqlCommand));*/

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
        private bool CreateOrUpdateScoreboard(int entryId, User user, int points)
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




        /*public Admin getAdmin(string userName)
        {
            string sql = "EXECUTE usp_getUser " + @userName;

            SqlCommand cmd = new SqlCommand(sql, Connect());
            cmd.Parameters.Add(new SqlParameter("userName", userName));

            try
            {
                cmd.ExecuteNonQuery();
                Connect().Close();
                return u;
            }
            catch
            {
                Connect().Close();
                return null;
            }



        }*/

        public List<Question> GetAllQuestions()
        {
            string sql = "EXECUTE usp_getAllQuestions";

            SqlCommand cmd = new SqlCommand(sql, Connect());

            SqlDataReader reader = cmd.ExecuteReader();

            List<Question> qList = new List<Question>();
            try
            {
                while (reader.Read())
                {
                    Question q = new Question();

                    q.QuestionID = reader.GetInt32(0);
                    q.QuestionString = reader.GetString(1);
                    q.RightAnswer = reader.GetString(2);
                    q.Level = reader.GetInt32(3);
                    q.Category = new Category(reader.GetString(4));
                    q.Creator = new Admin(reader.GetString(5), "passWord");
                    q.WrongAnswer1 = reader.GetString(6);
                    q.WrongAnswer2 = reader.GetString(7);
                    q.WrongAnswer3 = reader.GetString(8);

                    qList.Add(q);

                }
                return qList;
            }
            catch
            {
                return null;
            }
        }

        public List<Category> GetCategories()
        {
            string sql = "EXECUTE usp_getCategories";
            SqlCommand cmd = new SqlCommand(sql, Connect());
            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> catList = new List<Category>();
            try
            {
                while (reader.Read())
                {
                    Category c = new Category(reader.GetString(0));
                    catList.Add(c);
                }
                return catList;
            }
            catch
            {
                return null;
            }
        }


    }
}
