using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AddWord : Window
    {
        private List<string> categories;
        public AddWord()
        {
            InitializeComponent();
            InitializeCategories();
        }
        private void InitializeCategories()
        {
            categories = WordsOperations.GetCategories("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt");
            categoryList.ItemsSource = categories;
        }

        private void existingButton_Click(object sender, RoutedEventArgs e)
        {
            ExistingCategory existingCategory = new ExistingCategory();
            this.Close();
            existingCategory.Show();
        }

        private void newCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            NewCategory newCategory = new NewCategory();
            this.Close();
            newCategory.Show();
        }
    }
}
