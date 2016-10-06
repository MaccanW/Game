using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    class ScoreboardEntry
    {
        private String entryID;
        private Player player;
        private List<Question> questionList;


        public string EntryID
        {
            get
            {
                return entryID;
            }

            set
            {
                entryID = value;
            }
        }

        public Player Player
        {
            get
            {
                return player;
            }

            set
            {
                player = value;
            }
        }

        public List<Question> QuestionList
        {
            get
            {
                return questionList;
            }

            set
            {
                questionList = value;
            }
        }


        public ScoreboardEntry(string entryID, Player player, List<Question> questionList)
        {
            this.EntryID = entryID;
            this.Player = player;
            this.QuestionList = questionList;
        }

        public int CalculateScore()
        {
            int score = 0;

            foreach (Question q in questionList)
            {
                score += q.Level;
            }

            return score;
        }


    }
}
