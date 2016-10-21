using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    class Admin : User
    {
        public Admin(String userID, String password)
        {
            this.UserName = UserName;
            this.Password = password;
            //Hejsan
       

        }

       /* public Question AddQuestion(string questionID, string questionString, string rightAnswer, List<string> wrongAnswers, string category, int level)
        {
            return new Question(questionID, questionString, rightAnswer, wrongAnswers, category, level, this);
        }*/
    }
}
