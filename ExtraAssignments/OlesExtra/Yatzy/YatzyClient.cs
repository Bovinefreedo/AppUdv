using ExtraAssignments.modul4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Yatzy
{
    public class YatzyClient : IClient
    {
        private int[] scoreCup = new int[15];
        private string[] _rules = { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes", "Pair", "Two Pair", "Three of a Kind", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yatzy", "Chance" };
        private bool[] _used = new bool[15];
        private int[] _diceEyes = new int[15];
        public void displayCurrentScore()
        {
            throw new NotImplementedException();
        }

        public void displayDice()
        {
            //row 1 top of the dice
            foreach (int i in _diceEyes)
            {
                Console.Write(" -------  ");
            }
            //row 2 top of the eyes row
            Console.WriteLine(" ");
            foreach (int i in _diceEyes)
            {
                if (i != 1) Console.Write("| * ");
                else Console.Write("|   ");
                if (i > 3) Console.Write("  * | ");
                else Console.Write("    | ");
            }
            //row 3 middle row of the dice, used by uneven and 6
            Console.WriteLine(" ");
            foreach (int i in _diceEyes)
            {
                if (i == 6) Console.Write("| * ");
                else Console.Write("|   ");
                if (i % 2 == 1) Console.Write("*");
                else Console.Write(" ");
                if (i == 6) Console.Write(" * | ");
                else Console.Write("   | ");
            }
            //row 4 lowest row with eyers
            Console.WriteLine("");
            foreach (int i in _diceEyes)
            {
                if (i > 3) Console.Write("| *  ");
                else Console.Write("|    ");
                if (i != 1) Console.Write(" * | ");
                else Console.Write("   | ");
            }
            Console.WriteLine("");
            //row 5 the lower edge of the dice
            foreach (int i in _diceEyes)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
        }

        public void displayDiceLock()
        {
            throw new NotImplementedException();
        }

        public void displayDiceName()
        {
            throw new NotImplementedException();
        }

        public void displayRules()
        {
            throw new NotImplementedException();
        }

        public void displayScoreCup()
        {
            Console.WriteLine("-------------------------");
            int longestWord = 15;
            for (int j = 0; j < _rules.Length; j++)
            {
                Console.Write($"| {j + 1} {_rules[j]}");
                for (int i = _rules[j].Length; i <= longestWord; i++) { Console.Write(" "); }
                if (j < 9) Console.Write(" ");
                Console.Write(" |");
                if (!_used[j] && scoreCup[j] < 10) Console.Write($" {scoreCup[j]}  |");
                else if (!_used[j] && scoreCup[j] < 100) Console.Write($" {scoreCup[j]} |");
                else Console.Write($" X  |");
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
        }

        public void displayTitle()
        {
            throw new NotImplementedException();
        }

        public string lockInPoints()
        {
            throw new NotImplementedException();
        }

        public bool[] rollDice()
        {
            throw new NotImplementedException();
        }
    }
}
