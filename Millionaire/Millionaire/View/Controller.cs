using Millionaire.DAL;
using Millionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Millionaire.View;

namespace Millionaire.View
{
   public class Controller
    {
        DAL1 dal = new DAL1();

        public bool CreateOrUpdateUser(string userName, string password, string userType, string sqlcommand)
        {
            return dal.CreateOrUpdateUser(userName, password, userType, sqlcommand);
        }
        public void DeleteUser(string userName)
        {
            dal.DeleteUser(userName);
        }
        public bool ValidateUser(string userName, string password, string sqlCommand)
        {
            
            return dal.ValidateUser(userName, password, sqlCommand);
        }
       /* public bool CreateOrUpdateQuestion( int id, string question, string rightAnswer, int level, string category, string creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
           return dal.CreateOrUpdateQuestion(id, question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
        }
        public bool CreateOrUpdateScoreboard(int entryId, User user, string userType)
        {
           return dal.CreateOrUpdateScoreboard(entryId, user, userType);
        }
        public ScoreboardEntry GetScoreBoardEntry(int entryId)
        {
            return dal.GetScoreboardEntry(entryId);
        }
        public void DeleteScoreboardEntry(int entryId)
        {
            dal.DeleteScoreboardEntry(entryId); 
        }*/
    }
}
