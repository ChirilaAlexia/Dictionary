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
    /// <summary>
    /// Interaction logic for DeleteWord.xaml
    /// </summary>
    public partial class DeleteWord : Window
    {
        public DeleteWord()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            string word = inputBox.Text;
            if(Validation.WordExists(word))
            {
                WordsOperations.DeleteWord("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt", word);
                MessageBox.Show("Succes!");
            }
            else
            {
                MessageBox.Show("Please enter an existent word");
            }
           
        }
    }
   }

