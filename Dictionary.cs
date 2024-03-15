using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDictionary
{
    internal class Dictionary
    {
        private Dictionary<string, Tuple<string, string, string>> dictionary;
        public Dictionary() { dictionary = new Dictionary<string, Tuple<string, string, string>>(); }
    
    public void LoadDictionaryFromFile(string filePath)
    {
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
                        string category = parts[0];
                        string word = parts[1];
                        string description = string.Join(" ", parts.Skip(2).Take(parts.Length - 3));
                        string imagePath = parts[parts.Length - 1]; 

                        dictionary[word] = new Tuple<string, string, string>(category, description, imagePath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error reading file: " + ex.Message);
        }
    }

    public bool WordExists(string word)
    {
        return dictionary.ContainsKey(word);
    }

    public Tuple<string, string, string> GetWordDetails(string word)
    {
        if (dictionary.ContainsKey(word))
            return dictionary[word];
        else
            return null;
    }

    public List<string> GetAllWords()
    {
        return dictionary.Keys.ToList();
    }

    public List<string> GetWordsByCategory(string category)
    {
        return dictionary.Where(entry => entry.Value.Item1 == category)
                          .Select(entry => entry.Key)
                          .ToList();
    }
}
}


