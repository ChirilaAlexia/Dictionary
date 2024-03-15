using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace myDictionary
{
    public partial class ExistingCategory : Window
    {
        private List<string> categories;
        private string photo; // Adăugarea unei variabile pentru a reține calea către imaginea selectată
       
        public ExistingCategory()
        {
            InitializeComponent();
            InitializeCategories();
        }

        private void InitializeCategories()
        {
            try
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
                categories = uniqueCategories.ToList();

                categoryBox.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }
      
        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            string name = nameBox.Text;
            string category = categoryBox.SelectedItem as string;
            string description = descriptionBox.Text;
            if(Validation.IsValidName(name)==false)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            if (Validation.IsValidDescription(description)==false)
            {
                MessageBox.Show("Invalid description");
                return;
            }
            if (Validation.WordExists(name)==true)
            {
                MessageBox.Show("Word already exists!");
                return;
            }
            if (string.IsNullOrEmpty(photo))
            {
                photo = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\photos\\NotFound.png";
            }
            try
            {
                string filePath = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt";

                string lineToAdd = category + " " + name + " " + description + " " + photo; // Folosirea variabilei 'photo'

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
