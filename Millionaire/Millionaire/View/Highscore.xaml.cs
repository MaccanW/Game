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
using Millionaire.Model;
using System.Data;

namespace Millionaire.View
{
    /// <summary>
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class Highscore : Window
    {
        public Highscore()
        {
            Controller controller = new Controller();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            InitializeComponent();

            try
            {
                this.highscoreGrid.ItemsSource = controller.GetScoreboardEntry();
                this.highscoreGrid.Items.Refresh();
            }
            catch (Exception ex)
            {
                errorMessageLbl.Content = "Error: " + ex.Message;
            }
        }



        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }
    }
}
