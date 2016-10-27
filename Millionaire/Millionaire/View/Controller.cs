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
        public bool CreateOrUpdateUser(string userName, string password, string userType, string sqlcommand)
        {
            return dal.CreateOrUpdateUser(userName, password, userType, sqlcommand);
        }
        public void DeleteUser(string userName)
        {
            dal.DeleteUser(userName);
        }
        public bool CreateQuestion(string question, string rightAnswer, int level, Category category, Admin creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
           return dal.CreateQuestion(question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
        }

        public bool UpdateQuestion(int id, string question, string rightAnswer, int level, Category category, Admin creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            return dal.UpdateQuestion(id, question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
        }

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException()
            {

            }
            public UserNotFoundException(string message)
            : base(message)
            {

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
            return dal.GetAllQuestions();
        }

        public List<LegacyQuestion> GetAllLegacyQuestions()
        {
            return dal.GetAllLegacyQuestions();
        }

        public void CreateScoreboardEntry(Player player, int points)
        {
            dal.CreateScoreboardEntry(player, points);
        }

        public Question GetQuestion(string category, int level)
        {
            return dal.GetQuestion(category, level);
        }
        public List<ScoreboardEntry> GetScoreboardEntry()
        {
            return dal.GetScoreboardEntry();
        }

        public List<Category> GetCategories()
        {
            return dal.GetCategories();
        }

        public void DeleteQuestion(int questionID)
        {
            dal.DeleteQuestion(questionID);
        }

        public List<Player> GetPlayers()
        {
            return dal.GetPlayers();
        }
    }
}
