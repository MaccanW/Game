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
        Admin ad;

        public AdminQuestions(Admin a)
        {
            InitializeComponent();
            ad = a;
            List<Category> catList = con.GetCategories();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            foreach (Category c in catList)
            {
                CatComboBox.Items.Add(c.Categoryy);
            }
        }

        private void showQBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Question> qList = con.GetAllQuestions();
            //dataGrid.Items.Add(qList);
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            //dataGrid.Items.Clear();
            this.dataGrid.ItemsSource = qList;
            textBox.Text = null;
            raTxt.Text = null;
            wa1Txt.Text = null;
            wa2Txt.Text = null;
            wa3Txt.Text = null;
            //qIdTxt.Text = null;
            CatComboBox.Text = null;
            lvlTxt.Text = null;

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
                //qIdTxt.Text = q.QuestionID.ToString();
                lvlTxt.Text = q.Level.ToString();
                CatComboBox.Text = q.Category.Categoryy;

            }
            catch
            {
                try
                {
                    LegacyQuestion lq = (LegacyQuestion)dataGrid.SelectedItem;
                    textBox.Text = lq.QuestionString;
                    raTxt.Text = lq.RightAnswer;
                    wa1Txt.Text = lq.WrongAnswer1;
                    wa2Txt.Text = lq.WrongAnswer2;
                    wa3Txt.Text = lq.WrongAnswer3;
                    //qIdTxt.Text = q.QuestionID.ToString();
                    lvlTxt.Text = lq.Level.ToString();
                    CatComboBox.Text = lq.Category.Categoryy;
                }
                catch
                {

                }

            }
        }

        private void CatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Question q = (Question)dataGrid.SelectedItem;
                con.UpdateQuestion(q.QuestionID, textBox.Text, raTxt.Text, Convert.ToInt32(lvlTxt.Text), q.Category, q.Creator, wa1Txt.Text, wa2Txt.Text, wa3Txt.Text, "EXECUTE usp_updateQuestion");
                
            }
            catch (Exception ex)
            {
            
                      
            }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            Question q = new Question();
            Category c = new Category((String)CatComboBox.SelectedItem);
            try
            {
                con.CreateQuestion(textBox.Text, raTxt.Text, Convert.ToInt32(lvlTxt.Text), c, ad, wa1Txt.Text, wa2Txt.Text, wa3Txt.Text, "EXECUTE usp_createQuestion ");
            }
            catch{
                
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Question q = (Question)dataGrid.SelectedItem;
            con.DeleteQuestion(q.QuestionID);
            List<Question> qList = con.GetAllQuestions();
            //dataGrid.Items.Add(qList);
            dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
            //dataGrid.Items.Clear();
            this.dataGrid.ItemsSource = qList;
            textBox.Text = null;
            raTxt.Text = null;
            wa1Txt.Text = null;
            wa2Txt.Text = null;
            wa3Txt.Text = null;
            //qIdTxt.Text = null;
            CatComboBox.Text = null;
            lvlTxt.Text = null;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = null;
            raTxt.Text = null;
            wa1Txt.Text = null;
            wa2Txt.Text = null;
            wa3Txt.Text = null;
            //qIdTxt.Text = null;
            CatComboBox.Text = null;
            lvlTxt.Text = null;
        }

        private void showPlayers_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlayers();         

        }

        private void datagridUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Player p = (Player)datagridUser.SelectedItem;
                playernameTxt.Text = p.UserName;
            }
            catch
            {

            }
        }

        private void deleteuserbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.DeleteUser(playernameTxt.Text);
                UpdatePlayers();
            }
            catch
            {

            }
        }

        private void AddAdminBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.CreateOrUpdateUser(adminun.Text, adminpw.Text, "EXECUTE usp_CreateAdmin");
            }catch
            {
                errorMessageLbl.Content = "asdasd";
            }
        }

        private void ShowDeletedBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<LegacyQuestion> lqList = con.GetAllLegacyQuestions();
                dataGrid.ClearValue(ItemsControl.ItemsSourceProperty);
                this.dataGrid.ItemsSource = lqList;
            }
            catch
            {

            }
        }

        private void UpdatePlayers()
        {
            List<Player> pList = con.GetPlayers();
            datagridUser.ClearValue(ItemsControl.ItemsSourceProperty);
            this.datagridUser.ItemsSource = pList;
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
