using Millionaire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Millionaire.View
{

    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Controller controller = new Controller();
        int counter = 0;
        int levelCounter = 0;
        
        public Game(Player p)
        {
            InitializeComponent();
            AddCategories();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
            private void AddCategories()
        {
            textBlock.Text = "Välj kategori";
            //questionLbl.Content = "Pick a category";
            option_1Btn.Visibility = Visibility.Visible;
            option2Btn.Visibility = Visibility.Visible;
            option3Btn.Visibility = Visibility.Visible;
            option4Btn.Visibility = Visibility.Visible;
            List<Category> randomCategory = NewNumber();

            option_1Btn.Content = randomCategory.ElementAt(1).Categoryy;
            option2Btn.Content = randomCategory.ElementAt(2).Categoryy;
            option3Btn.Content = randomCategory.ElementAt(3).Categoryy;
            option4Btn.Content = randomCategory.ElementAt(4).Categoryy;
        }
        private List<Category> NewNumber()
        {
            List<Category> categories = controller.GetCategories();
            List<Category> randomCategory = new List<Category>();
             Random random = new Random();
            for (int i = 0; i <30; i++)
            {
                int randomNumber = random.Next(0, categories.Count());
                if (!randomCategory.Contains(categories.ElementAt(randomNumber))){
                    randomCategory.Add(categories.ElementAt(randomNumber));
                }
            }
            return randomCategory;
        }
        Question rightQuestion = new Question();
        private void option_1Btn_Click(object sender, RoutedEventArgs e)
        {
            //string categoryName = "Science"; //sender.ToString().Remove(0,32) ;
            Question q = controller.GetQuestion(option_1Btn.Content.ToString(), 1);
            rightQuestion = q;
            AddQuestions(q);
            HideVisible("options");
        }
       

        private void AddQuestions(Question q)
        {
            answer1Btn.Visibility = Visibility.Visible;
            answer2Btn.Visibility = Visibility.Visible;
            answer3Btn.Visibility = Visibility.Visible;
            answer4Btn.Visibility = Visibility.Visible;
            List<string> randomAnswer = RandomAnswer(q);
            
            //questionLbl.Content = q.QuestionString;
            textBlock.Text = q.QuestionString;
            answer1Btn.Content = randomAnswer.ElementAt(0);
            answer2Btn.Content = randomAnswer.ElementAt(1);
            answer3Btn.Content = randomAnswer.ElementAt(2);
            answer4Btn.Content = randomAnswer.ElementAt(3);
            
        }
        private List<string> RandomAnswer(Question q)
        {
            List<string> questionAnswers = new List<string>();
            questionAnswers.Add(q.RightAnswer);
            questionAnswers.Add(q.WrongAnswer1);
            questionAnswers.Add(q.WrongAnswer2);
            questionAnswers.Add(q.WrongAnswer3);
            
            List<string> randomAnswer = new List<string>();
            Random random = new Random();
            for (int i = 0; i < 30; i++)
            {
                int randomNumber = random.Next(0, 4);
                if (!randomAnswer.Contains(questionAnswers.ElementAt(randomNumber)))
                {
                    randomAnswer.Add(questionAnswers.ElementAt(randomNumber));
                }
            }
            return randomAnswer;
        }


        private void answer1Btn_Click(object sender, RoutedEventArgs e)
        {
            
            string answer = sender.ToString().Remove(0, 32);
            if (answer.Equals(rightQuestion.RightAnswer))
            {
                counter++;
              HideVisible("answers");
                AddCategories();
            }
            else
            {
                EndGame();
                Console.WriteLine(counter);
            }
            Console.WriteLine(answer);
        }
        private int CalculateScore(int level)
        {      
              return counter = counter * level;
            
        }

        private void EndGame()
        {
            HideVisible("answers");
            textBlock.Text = "Du förlorade! Dina poänd: " + counter;
            //questionLbl.Content = "You lose! Your score: " + counter; 

        }
        private void HideVisible(string type)
        {
            if (type == "answers")
            {
                answer1Btn.Visibility = Visibility.Collapsed;
                answer2Btn.Visibility = Visibility.Collapsed;
                answer3Btn.Visibility = Visibility.Collapsed;
                answer4Btn.Visibility = Visibility.Collapsed;
            } else if (type == "options")
            {
                option_1Btn.Visibility = Visibility.Collapsed;
                option2Btn.Visibility = Visibility.Collapsed;
                option3Btn.Visibility = Visibility.Collapsed;
                option4Btn.Visibility = Visibility.Collapsed;
            }
        }
    }
}

