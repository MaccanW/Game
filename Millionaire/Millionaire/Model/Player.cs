using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    public class Player : User
    {
        public Player(String userName, String password)
        {
            this.UserName = userName;
            this.Password = password;
        }


        //perhaps implement this method in the Question class instead?
        public bool AnswerQuestion(Question q, String answer)
        {
            return false;
        }

        //we should probably run this as a stored procedure in the RDBMS and not in the .NET program (to make Erdogan happy :) )
        public ScoreboardEntry GetHighScore()
        {
            return null;
        }
    }
}
