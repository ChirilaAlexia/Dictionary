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
    public partial class AdminInterface : Window
    {
        public AdminInterface()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
           AddWord addWord = new AddWord();
            this.Close();
            addWord.Show();

        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            ModifyWord modifyWord = new ModifyWord();
            this.Close();
            modifyWord.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteWord deleteWord = new DeleteWord();
            this.Close();
            deleteWord.Show();
        }

        
    }
}
