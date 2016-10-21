using Millionaire.DAL;
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

        private bool CreateUser(string userName, string password, string userType, string sqlCommand)
        {
            return dal.CreateOrUpdateUser(userName, password, userType, sqlCommand);
        }

        private void DeleteUser(string userName)
        {
            dal.DeleteUser(userName);
        }
        private bool CreateOrQuestion(int id, string question, string rightAnswer, int questionLevel, string category, string creator, string wrongAnswer1, string wrongAnswer2, string wrongAnswer3, string sqlCommand)
        {
            return dal.CreateOrUpdateQuestion(id, question, rightAnswer, questionLevel, category, creator, wrongAnswer1, wrongAnswer2, wrongAnswer3, sqlCommand);
        }
        private void DeleteQuestion(int id)
        {
            dal.DeleteQuestion(id);
        }


    }
}
