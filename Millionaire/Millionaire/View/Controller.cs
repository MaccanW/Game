using Millionaire.DAL;
using Millionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.View
{
    class Controller
    {
        DAL1 dal = new DAL1();

        private bool CreateOrUpdateUser(string userName, string password, string userType, string sqlcommand)
        {
            return dal.CreateOrUpdateUser(userName, password, userType, sqlcommand);
        }
        private void DeleteUser(string userName)
        {
            dal.DeleteUser(userName);
        }
        private bool CreateOrUpdateQuestion(int id, string question, string rightAnswer, int level, string category, string creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
           return dal.CreateOrUpdateQuestion(id, question, rightAnswer, level, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
        }
        private bool CreateOrUpdateScoreboard(int entryId, Player player, int points)
        {
           return dal.CreateOrUpdateScoreboard(entryId, player, points);
        }
        private ScoreboardEntry GetScoreBoardEntry(int entryId)
        {
            return dal.GetScoreboardEntry(entryId);
        }
        private void DeleteScoreboardEntry(int entryId)
        {
            dal.DeleteScoreboardEntry(entryId); 
        }
    }
}
