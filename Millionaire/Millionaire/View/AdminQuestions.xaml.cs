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
    /// Interaction logic for AdminQuestions.xaml
    /// </summary>
    public partial class AdminQuestions : Window
    {

        Controller con = new Controller();

        public AdminQuestions()
        {
            InitializeComponent();
            List<Category> catList = con.GetCategories();

            foreach (Category c in catList)
            {
                CatComboBox.Items.Add(c.Categoryy);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<Question> qList = con.GetAllQuestions();
            //dataGrid.Items.Add(qList);
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            //dataGrid.Items.Clear();
            this.dataGrid.ItemsSource = qList;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Question q = (Question)dataGrid.SelectedItem;
                textBox.Text = q.QuestionString;
                raTxt.Text = q.RightAnswer;
                wa1Txt.Text = q.WrongAnswer1;
                wa2Txt.Text = q.WrongAnswer2;
                wa3Txt.Text = q.WrongAnswer3;
                CatComboBox.Text = q.Category.Categoryy;
                
            }catch
            {
                
            }
        }

        private void CatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
