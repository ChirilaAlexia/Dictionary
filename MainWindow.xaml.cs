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

namespace myDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void adminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage userPage = new AdminPage();
            this.Close();
            userPage.Show();
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            UserPage userPage = new UserPage();
            this.Close();
            userPage.Show();
        }

        private void GameBtn_Click(object sender, RoutedEventArgs e)
        {
            game game=new game();
            this.Close();
            game.Show();
        }
    }
}
