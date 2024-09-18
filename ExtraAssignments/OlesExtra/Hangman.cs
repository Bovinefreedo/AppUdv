using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra
{
    public class Hangman
    {
        int _numberOfGuesses = 1;
        HiddenWord _word;
        public Hangman(HiddenWord word) {
            _word = word;
            getInput();
        }

        public void getInput() {
            bool finished = false;
            Console.WriteLine("welcome to the game Hangman, you have 10 guess to figure out the hidden word,");
            Console.WriteLine("if you put in a single letter, we will reveal where that letter is in our word");
            Console.WriteLine("if you write more than one it is a guess on a word. You need to guess the word,");
            Console.WriteLine("so even if you have revealed all the letters you have not won. untill you write it as a guess.");
            while (!finished) { 
                string guess = Console.ReadLine();
                if (guess == null) continue;
                if (guess.Length == 1)
                {
                    _word.guessLetter(guess[0]);
                    Console.Write($"{_word.printGuessedWord()}     you have revealed the letter {guess}, guess {_numberOfGuesses}: ");
                }
                else{
                    if (_word.guessWord(guess))
                    {
                        Console.WriteLine($"Congratualtions, you have guessed it the word was {guess}");
                        finished = true;
                    }
                    else {
                        Console.Write($"{_word.printGuessedWord()}     the word {guess} was wrong, guess {_numberOfGuesses}:");
                    }
                }
                _numberOfGuesses++;
                if (_numberOfGuesses >= 10) {
                    finished = true;
                    Console.WriteLine($"You are out of guesses and have lost you big big snail, the word was {_word.printGuessedWord()}");
                }
            }
        
        }
    }
}
