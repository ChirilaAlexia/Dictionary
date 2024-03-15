using Microsoft.Win32;
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
    /// Interaction logic for NewCategory.xaml
    /// </summary>
    public partial class NewCategory : Window
    {
        private string photo;
        public NewCategory()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameBox.Text;
            string category = categoryBox.Text;
            string description = descriptionBox.Text;

            if(Validation.WordExists(name))
            {
                MessageBox.Show("Word already exists!");
                return;
            }
            if (Validation.CategoryExists(category))
            {
                MessageBox.Show("Category already exists!");
                return;
            }
            if(Validation.IsValidName(name)==false)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            if(Validation.IsValidDescription(description)==false)
            {
                MessageBox.Show("Invalid description");
                return;
            }
            if (string.IsNullOrEmpty(photo))
            {
                photo = "D:\\facultate\\anul2\\sem2\\\\MAP\\GasesteCuvinteInatorul\\myDictionary\\photos\\NotFound.png";
            }

            try
            {
                string filePath = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt";

                string lineToAdd = " "+category + " " + name + " " + description + " " + photo;

               
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    writer.WriteLine(lineToAdd);
                }

                MessageBox.Show("Word added to the dictionary!");
            }
            catch
            {
                MessageBox.Show("Something went wrong! Try again!");

            }

        }
        

        private void Photo_Click(object sender, RoutedEventArgs e)
        {

            photo = WordsOperations.openPhoto();
            
        }
    }
    }

