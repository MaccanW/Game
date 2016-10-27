using Millionaire.DAL;
using Millionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millionaire.View;
using System.Collections;


namespace Millionaire.View
{
   public class Controller
    {
        DAL1 dal = new DAL1();

        public Admin ActiveAdmin { get; set; }
        public Player GetPlayer(string username) {
            return dal.GetPlayer(username);
        }
        public bool CreateOrUpdateUser(string userName, string password, string sqlcommand)
        {
            try
            {
                return dal.CreateOrUpdateUser(userName, password, sqlcommand);
            }
            catch
            {
                throw;
            }

        }
        public void DeleteUser(string userName)
        {
            try
            {
                dal.DeleteUser(userName);
            }
            catch
            {
                throw;
            }
        }
        public bool CreateQuestion(string question, string rightAnswer, int level, Category category, Admin creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            try
            {
                return dal.CreateQuestion(question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);

            }
            catch
            {
                throw;
            }
        }

        public bool UpdateQuestion(int id, string question, string rightAnswer, int level, Category category, Admin creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            try
            {
                return dal.UpdateQuestion(id, question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
            }
            catch
            {
                throw;
            }
       }


        public User ValidateUser(string username, string password, string sqlCommand)
        {
            try
            {
                return dal.ValidateUser(username, password, sqlCommand);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public bool CreateScoreboardEntry(User user, int points)
        {
           return dal.CreateOrUpdateScoreboard(user, points);
        }

        public List<Question> GetAllQuestions()
        {
            try
            {
                return dal.GetAllQuestions();
            }
            catch
            {
                throw;
            }

        }

        public List<LegacyQuestion> GetAllLegacyQuestions()
        {
            try
            {
                return dal.GetAllLegacyQuestions();
            }
            catch
            {
                throw;
            }

        }

        public void CreateScoreboardEntry(Player player, int points)
        {
            try
            {
                dal.CreateScoreboardEntry(player, points);
            }
            catch
            {

            }

        }

        public Question GetQuestion(string category, int level)
        {
            try
            {
                return dal.GetQuestion(category, level);
            }

            catch
            {
                throw;
            }

        }
        public List<ScoreboardEntry> GetScoreboardEntry()
        {
            try
            {
                return dal.GetScoreboardEntry();
            }
            catch
            {
                throw;
            }

        }

        public List<Category> GetCategories()
        {
            try
            {
                return dal.GetCategories();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteQuestion(int questionID)
        {
            try
            {
                dal.DeleteQuestion(questionID);
            }
            catch
            {
                throw;
            }
        }

        public List<Player> GetPlayers()
        {
            try
            {
                return dal.GetPlayers();
            }
            catch
            {
                throw;
            }

        }
    }
}
