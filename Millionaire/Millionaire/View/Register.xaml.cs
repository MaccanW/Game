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
using Millionaire.View;

namespace Millionaire.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        Controller controller = new Controller();
       
        public Register()
        {
         
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
             if (controller.CreateOrUpdateUser(userNameTxt.Text, passwordBox.Password, "EXECUTE usp_CreatePlayer"))
            {
                try {
                    this.Hide();
                } catch(Exception s)
                {
                    Console.WriteLine(s.ToString());
                }
            }

           }

    }
}
