using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myDictionary
{
    internal static class WordsOperations
    {
        

        public static List<string> GetCategories(string filePath)
        {

            HashSet<string> uniqueCategories = new HashSet<string>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length >= 4)
                    {
                        string category = parts[0];
                        uniqueCategories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            return uniqueCategories.ToList();
        }
        public static bool DeleteWord(string filePath, string word)
        {
            List<string> updatedLines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
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
                                updatedLines.Add(line);
                            }
                        }
                    }
                }

                File.WriteAllLines(filePath, updatedLines);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading or writing file: " + ex.Message);
                return false;
            }
        }

        public static bool ModifyWord(string filePath, string initialName, string name, string description, string img, string category)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(' ');

                    if (parts.Length >= 4 && parts[1] == initialName)
                    {
                        lines[i] = $"{category} {name} {description} {img}";
                        break;
                    }
                }

                File.WriteAllLines(filePath, lines);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading or writing file: " + ex.Message);
                return false;
            }
        }
        public static string openPhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg,*.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName; // Actualizarea variabilei 'photo' cu calea către imaginea selectată
            }
            return null;
        }
    }
}
