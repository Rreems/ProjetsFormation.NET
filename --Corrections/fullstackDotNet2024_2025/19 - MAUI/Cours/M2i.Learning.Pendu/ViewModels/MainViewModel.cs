using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M2i.LEarning.Pendu.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int errorCount;
        private string answer;
        private string mask;
        private string errorMessage;
        private string pictureName;
        private HashSet<char> guessedChars = new();

        public string Letters { get; set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public List<string> Words { get; set; }

        public string ErrorMessage 
        { 
            get => errorMessage; 
            set 
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string PictureName 
        { 
            get => pictureName; 
            set 
            {
                pictureName = value;
                OnPropertyChanged();
            } 
        }

        public string Mask
        {
            get => mask;
            set
            {
                mask = value;
                OnPropertyChanged();
            }
        }

        public int ErrorCount { get => errorCount; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool TestWin()
        {
            return mask.Replace(" ", "").Equals(answer);
        }

        public void NewGame()
        {
            var rnd = new Random();
            var rndIndex = rnd.Next(Words.Count);
            var rndWord = Words[rndIndex];

            answer = rndWord;
            Debug.WriteLine($"Reponse: {answer}");
            guessedChars.Clear();
            GenerateMask();
            errorCount = 0;
            ErrorMessage = $"Errors: {errorCount}/7";
            PictureName = $"hangman_0{errorCount + 1}.png";
        }

        public void GenerateMask()
        {
            var strTemp = "";
            answer
                .Select(c => guessedChars.Contains(c) ? c : '_')
                .ToList()
                .ForEach(c => strTemp += c);

            Mask = string.Join(" ", strTemp.ToCharArray());
        }

        internal void TestChar(char letter)
        {
            guessedChars.Add(letter);

            if (!answer.Contains(letter)) 
            {
                errorCount++;
                // Si pas bonne lettre
            }
            else
            {
                GenerateMask();
               // Si bonne lettre
            }

            ErrorMessage = $"Errors: {errorCount}/7";
            PictureName = $"hangman_0{errorCount + 1}.png";
        }
    }
}
