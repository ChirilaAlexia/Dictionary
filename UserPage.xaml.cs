using System;
using System.Collections;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
       Dictionary dictionary = new Dictionary();
        public UserPage()
        {
            InitializeComponent();
            LoadDictionaryFromFile("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt");
            InitializeCategories();
         

        }
        private void categoryBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = categoryBox1.SelectedItem as string;

            if (selectedCategory != null && selectedCategory != "All")
            {
                
                var filteredWords = dictionary.GetWordsByCategory(selectedCategory);
                autoCompleteBox.ItemsSource = filteredWords;
            }
            else
            {
                autoCompleteBox.ItemsSource = dictionary.GetAllWords();
            }
        }
        private void LoadDictionaryFromFile(string filePath)
        {
            try
            {
                dictionary.LoadDictionaryFromFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string word = autoCompleteBox.Text.ToLower();
            if (word.Length == 0)
            {
                MessageBox.Show("Please enter a word");
            }

                if (dictionary.WordExists(word))
                {
                    Tuple<string, string, string> data = dictionary.GetWordDetails(word);
                    outputBox.Text = data.Item2;
                    categoryBox.Text = data.Item1;


                    string imagePath = data.Item3;
                    if (File.Exists(imagePath))
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(imagePath);
                        bitmap.EndInit();
                        imageBox.Source = bitmap;
                    }
                    else
                    {

                        MessageBox.Show("Image not found: " + imagePath);
                    }
                }
                else
                {
                    outputBox.Text = "Sorry! Word not found";
                    categoryBox.Text = "None";
                    string notFoundImagePath = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\photos\\NotFound.png";
                    if (File.Exists(notFoundImagePath))
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(notFoundImagePath);
                        bitmap.EndInit();
                        imageBox.Source = bitmap;
                    }
                    else
                    {
                        MessageBox.Show("Image not found: " + notFoundImagePath);
                        imageBox.Source = null;
                    }
                }
            
            
        }
        private void InitializeCategories()
        {
            HashSet<string> uniqueCategories = new HashSet<string>();

            
            string[] lines = File.ReadAllLines("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt");

            
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                if (parts.Length >= 4)
                {
                    string category = parts[0];
                    uniqueCategories.Add(category);
                }
            }
            uniqueCategories.Add("All");

            
            foreach (string category in uniqueCategories)
            {
                categoryBox1.Items.Add(category);
            }

        }
    }
}
