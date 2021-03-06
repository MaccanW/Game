﻿using Millionaire.Model;
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

namespace Millionaire.View
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        Controller controller = new Controller();
        
        
          
            

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {   

            
            try
            {
                User u = controller.ValidateUser(usernameTxt.Text, passwordBox.Password, "EXECUTE [usp_CheckLogin]");
                if (u.GetType().ToString().Equals("Millionaire.Model.Admin"))
                {

                    AdminQuestions adminQuestionWindow = new AdminQuestions((Admin)u);
                    adminQuestionWindow.Show();
                    this.Close();
                    

                }
                else if (u.GetType().ToString().Equals("Millionaire.Model.Player"))
                {   
                    Game gameWindow = new Game((Player)u);
                    gameWindow.Show();
                    this.Close();
                }
            }
            catch (IndexOutOfRangeException)
            {
                //Skriv något om att det är fel användarnamn/lösenord

                errorMessageLbl.Content = "Error: Wrong username/password";
            }
            catch (Exception exception)
            {

                errorMessageLbl.Content = "Error: Wrong username/password" + exception.Message;
            }

        }
    }
    }
