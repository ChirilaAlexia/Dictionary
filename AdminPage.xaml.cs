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

namespace myDictionary
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        private Administrator admin;
        public AdminPage()
        {
            InitializeComponent();
            admin = new Administrator();
        }

        private void verifyButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            if (admin.Authenticate(username, password))
            {
                AdminInterface userPage = new AdminInterface();
                this.Close();
                userPage.Show();
            }
            else
            {
                MessageBox.Show("Try again");
            }

        }
    }
   }
