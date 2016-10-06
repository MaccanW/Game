using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    class Player : User
    {
        public Player(String userID, String password)
        {
            this.UserID = userID;
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
