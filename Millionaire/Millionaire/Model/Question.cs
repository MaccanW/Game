﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire.Model
{
   public class Question
    {
        private int questionID;
        private String questionString;
        private String rightAnswer;
        private String wrongAnswer1;
        private String wrongAnswer2;
        private String wrongAnswer3;
        
        private Category category;
        private int level;
        private Admin creator;

       /* public Question(string questionID, string questionString, string rightAnswer, List<string> wrongAnswers, string category, int level, Admin creator)
        {
            this.questionID = questionID;
            this.questionString = questionString;
            this.rightAnswer = rightAnswer;
            this.wrongAnswers = wrongAnswers;
            this.category = category;
            this.level = level;
            this.creator = creator;
        }*/

        public int QuestionID
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

        public Category Category
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

        public Admin Creator
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

        public string WrongAnswer1
        {
            get
            {
                return wrongAnswer1;
            }

            set
            {
                wrongAnswer1 = value;
            }
        }

        public string WrongAnswer2
        {
            get
            {
                return wrongAnswer2;
            }

            set
            {
                wrongAnswer2 = value;
            }
        }

        public string WrongAnswer3
        {
            get
            {
                return wrongAnswer3;
            }

            set
            {
                wrongAnswer3 = value;
            }
        }


    }
}

