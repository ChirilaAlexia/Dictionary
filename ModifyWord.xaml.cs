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
    /// Interaction logic for ModifyWord.xaml
    /// </summary>
    public partial class ModifyWord : Window
    {
        public ModifyWord()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string word = inBox.Text;
            bool gasit = false;

            if (Validation.WordExists(word))
            {
                List<string> updatedLines = new List<string>();


                try
                {
                    using (StreamReader sr = new StreamReader("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(' ');
                            if (parts.Length >= 4)
                            {
                                string cuv = parts[1];

                                if (cuv != word)
                                {
                                    // Păstrăm doar liniile care nu conțin cuvântul de șters
                                    updatedLines.Add(line);
                                }
                                else
                                {
                                    gasit = true;
                                    nameBox.Text = cuv;
                                    categoryBox.Text = parts[0];
                                    descriptionBox.Text = string.Join(" ", parts.Skip(2).Take(parts.Length - 3));
                                    pathBox.Text = parts[parts.Length - 1];
                                }
                            }
                        }
                        if (gasit == false)
                        {
                            nameBox.Text = "notFound";
                            categoryBox.Text = "notFound";
                            descriptionBox.Text = "notFound";
                            pathBox.Text = "notFound";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading or writing file: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("The word doesn't exist");
            }
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            string initialName = inBox.Text;
            string name = nameBox.Text;
            string description = descriptionBox.Text;
            string img = pathBox.Text;
            string categ = categoryBox.Text;
            if (name == "notFound" || description == "notFound" || img == "notFound" || categ == "notFound")
            {
                MessageBox.Show("U can't do this!!!!!");
                return;
            }
            else
            {

                WordsOperations.ModifyWord("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt",initialName,name,description,img,categ);
            }
        }
    }
    
}
