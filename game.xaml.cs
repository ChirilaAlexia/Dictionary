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
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {

        Dictionary dictionary = new Dictionary();
        private int currentWordIndex = 0;
        private int correctAnswers = 0;
        private List<Tuple<string, int, int>> m_game;


        public game()
        {
            InitializeComponent();
            InitializeGame();
            DisplayWord(currentWordIndex);
        }
        public void LoadDictionaryFromFile(string filePath)
        {
            try
            {
                dictionary.LoadDictionaryFromFile(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading file: " + ex.Message);
            }
        }
        private List<string> GetRandomKeys(Dictionary dictionary, int count)
        {

            // Get all keys from the dictionary
            List<string> allKeys = dictionary.GetAllWords();

            // Shuffle the keys randomly
            Random random = new Random();
            List<string> shuffledKeys = allKeys.OrderBy(x => random.Next()).ToList();

            // Take the first 'count' number of keys
            List<string> randomKeys = shuffledKeys.Take(count).ToList();

            return randomKeys;
        }
        List<string> randomKeys;
        private void InitializeGame()
        {
            LoadDictionaryFromFile("D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\words.txt");

            randomKeys = GetRandomKeys(dictionary, 5);
            m_game = new List<Tuple<string, int, int>>();

            Random random = new Random();

            foreach (var key in randomKeys)
            {
                int photoDescription = random.Next(2);
                m_game.Add(Tuple.Create(key, photoDescription, 0));
            }
        }

        private void DisplayWord(int index)
        {
            if (index < 0)
                return;

            Tuple<string, string, string> currentWord = dictionary.GetWordDetails(randomKeys[index]);


            if (m_game.ElementAt(index).Item2 == 0)
            {
                if (currentWord.Item3 != "D:\\facultate\\anul2\\sem2\\MAP\\GasesteCuvinteInatorul\\myDictionary\\photos\\NotFound.png")
                    DisplayImage(currentWord.Item3);
                else
                    DisplayDescription(currentWord.Item2);
            }
            else
                DisplayDescription(currentWord.Item2);

            if (m_game.ElementAt(index).Item3 == 1)
            {
                inputWord.Text = m_game.ElementAt(index).Item1;
            }
            // Actualizează starea butoanelor Next și Previous
            btnNext.IsEnabled = (index < 4);
            btnPrevious.IsEnabled = (index > 0);
           
            btnNext.Content = (index < 4) ? "Next" : "End Game";

        }

        private void DisplayImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            imageBox.Source = bitmap;
        }

        private void DisplayDescription(string description)
        {
            outputBox.Text = description;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Implementează logica pentru butonul Next
            currentWordIndex++;
            inputWord.Clear();
            //golire outputBox si imageBox

            outputBox.Text = string.Empty;

            // Resetează imaginea din imageBox
            imageBox.Source = null;
            DisplayWord(currentWordIndex);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            // Implementează logica pentru butonul Previous
            currentWordIndex--;
            inputWord.Clear();
            outputBox.Text = string.Empty;

            // Resetează imaginea din imageBox
            imageBox.Source = null;
            //prevoius daca e ghicit sa il completeze
            DisplayWord(currentWordIndex);
        }
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            // Implementează logica pentru butonul Finish
            MessageBox.Show($"Număr de răspunsuri corecte: {correctAnswers}");
            //plus afisare cuvinte in ordine din game


            StringBuilder wordsInOrder = new StringBuilder("Cuvinte in ordine: ");
            foreach (var tuple in m_game)
            {
                wordsInOrder.Append(tuple.Item1).Append(", ");
            }

            // Elimină virgula de la sfârșitul șirului și afișează MessageBox
            MessageBox.Show(wordsInOrder.ToString().TrimEnd(',', ' '));

            InitializeGame();
            inputWord.Clear();
            outputBox.Text = string.Empty;

            // Resetează imaginea din imageBox
            imageBox.Source = null;
            correctAnswers = 0;
            currentWordIndex = 0;
            DisplayWord(currentWordIndex);

        }

        private void checkWord_Click(object sender, RoutedEventArgs e)
        {
            if (inputWord != null)
            {
                Tuple<string, int, int> currentTuple = m_game.ElementAt(currentWordIndex);

                if (inputWord.Text == currentTuple.Item1)
                {
                    if (currentTuple.Item3 == 0)

                    {
                        correctAnswers++;
                        m_game[currentWordIndex] = Tuple.Create(currentTuple.Item1, currentTuple.Item2, 1);
                    }

                }
            }
        }

    }
}
