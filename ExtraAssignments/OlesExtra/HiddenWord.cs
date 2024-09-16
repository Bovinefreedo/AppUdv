using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra
{
    public class HiddenWord
    {
        private string word;
        private bool[] guessed;

        public HiddenWord(string word)
        {
            this.word = word;
            guessed = new bool[word.Length];
        }

        public void guessLetter(char guess) {
            for (int i = 0; i < word.Length; i++){
                if (word[i] == guess)
                    guessed[i]=true;
            }
            printGuessedWord();
        }

        public string printGuessedWord() {
            string shownWord = "";
            for (int i = 0; i < guessed.Length; i++)
            {
                if (guessed[i]) shownWord += word[i];
                else shownWord += "*";
            }
            return shownWord;
        }

        public bool guessWord(string guess)
        {
            return guess.ToUpper().Equals(word.ToUpper());
        }
    }
}
