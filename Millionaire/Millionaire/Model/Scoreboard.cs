using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    class Scoreboard
    {
        private String scoreboardID;
        private List<ScoreboardEntry> entryList;

        public string ScoreboardID
        {
            get
            {
                return scoreboardID;
            }

            set
            {
                scoreboardID = value;
            }
        }

        public List<ScoreboardEntry> EntryList
        {
            get
            {
                return entryList;
            }

            set
            {
                entryList = value;
            }
        }

        public Scoreboard(string scoreboardID, List<ScoreboardEntry> entryList)
        {
            this.scoreboardID = scoreboardID;
            this.entryList = entryList;
        }


    }
}
