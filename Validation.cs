using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace myDictionary
{
    internal class Validation
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 2 && name.Length <= 50 && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
        public static bool IsValidDescription(string description)
        {
            return !string.IsNullOrEmpty(description) && description.Length >= 10 && description.Length <= 500;
        }
        public static bool WordExists( string name)
        {
            try
            {
                string filePath = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt";
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 2 && parts[1] == name)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }

            return false;
        }
        public static bool CategoryExists(string category)
        {
            try
            {
                string filePath = "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt";
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 1 && parts[0] == category)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }

            return false;
        }

    }
}
