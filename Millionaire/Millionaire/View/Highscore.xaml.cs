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
            


            InitializeComponent();
            var playerCol = new DataGridTextColumn();
            playerCol.Header = "Player";
            var pointsCol = new DataGridTextColumn();
            pointsCol.Header = "Points";

            highscoreGrid.Columns.Add(playerCol);
            highscoreGrid.Columns.Add(pointsCol);

            foreach ( ScoreboardEntry se in controller.GetScoreboardEntry())
            {
                DataGridRow row = (DataGridRow)highscoreGrid[0].Clone();
                highscoreGrid.Rows[1].Cells[1].Value = value;
            };
           
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
