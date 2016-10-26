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
        Admin activeAdmin;
        Player activePlayer;

        public Admin ActiveAdmin { get; set; }

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



        public User ValidateUser(string username, string password, string sqlCommand)
        {
            return dal.ValidateUser(username, password, sqlCommand);
        }
        /*private bool CreateOrUpdateScoreboard(int entryId, User user, int points)
        {
           return dal.CreateOrUpdateScoreboard(entryId, user, points);
        }*/

        public List<Question> GetAllQuestions()
        {
            return dal.GetAllQuestions();
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

            /*
        public void DeleteScoreboardEntry(int entryId)
        {
            dal.DeleteScoreboardEntry(entryId); 
        }*/

        public void DeleteQuestion(int questionID)
        {
            dal.DeleteQuestion(questionID);
        }
    }
}
