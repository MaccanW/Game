﻿using System;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }
        Controller controller = new Controller();
        Game gameWindow = new Game();
          
            

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
           if(controller.ValidateUser(usernameTxt.Text, passwordTxt.Text, "EXECUTE [usp_CheckUsername]"))
            {
                
                gameWindow.Show();
                this.Close();

            }
           else
            {
                
                Console.WriteLine(controller.ValidateUser(usernameTxt.Text, passwordTxt.Text, "EXECUTE usp_CheckUsername"));
                Console.WriteLine("Log in failed");
            }

        }
    }
    }