using Millionaire.DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Millionaire.View;

namespace Millionaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();
        Register registerWindow = new Register();
        AdminQuestions adminquestionWindow = new AdminQuestions();
        login loginWindow = new login();
        Highscore highscoreWindow = new Highscore();
        
        public MainWindow()
        {
           
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            registerWindow.Show();
      
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            loginWindow.Show();
            this.Close();
        }

        private void highscoreBtn_Click(object sender, RoutedEventArgs e)
        {
            highscoreWindow.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            adminquestionWindow.Show();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            adminquestionWindow.Show();
        }
    }
}
