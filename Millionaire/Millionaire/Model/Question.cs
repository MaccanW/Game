using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
    class Question
    {
        private String questionID;
        private String questionString;
        private String rightAnswer;
        private List<String> wrongAnswers;
        private String category;
        private int level;
        private Admin creator;

        public Question(string questionID, string questionString, string rightAnswer, List<string> wrongAnswers, string category, int level, Admin creator)
        {
            this.questionID = questionID;
            this.questionString = questionString;
            this.rightAnswer = rightAnswer;
            this.wrongAnswers = wrongAnswers;
            this.category = category;
            this.level = level;
            this.creator = creator;
        }

        public string QuestionID
        {
            get
            {
                return questionID;
            }

            set
            {
                questionID = value;
            }
        }

        public string QuestionString
        {
            get
            {
                return questionString;
            }

            set
            {
                questionString = value;
            }
        }

        public string RightAnswer
        {
            get
            {
                return rightAnswer;
            }

            set
            {
                rightAnswer = value;
            }
        }

        public List<string> WrongAnswers
        {
            get
            {
                return wrongAnswers;
            }

            set
            {
                wrongAnswers = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        internal Admin Creator
        {
            get
            {
                return creator;
            }

            set
            {
                creator = value;
            }
        }
    }
}

