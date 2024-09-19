using ExtraAssignments.modul1;
using ExtraAssignments.modul4.rollStrategies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

namespace ExtraAssignments.modul4
{
    public class Yatzy
    {
        private string[] _rules = { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes", "Pair", "Two Pair", "Three of a Kind", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yatzy", "Chance" };
        private bool[] _used = new bool[15];
        private int[] _score = new int[15];
        private DiceCup _diceCup;
        private int _rollsThisRound = 0;
        private int round = 0;
        private ReadNumberInput _readNumberInput = new ReadNumberInput();
        public Yatzy() {
            List<IDice> myDice = new List<IDice>();
            for (int i = 0; i < 5; i++) {
                myDice.Add(new AdaptableDie(new NormalRollStrategy()));
            }
            _diceCup = new DiceCup(myDice);
        }

        public void playGame()
        {
            while (round > 15) {
                displayBoard();
                playRound();
            }

        }

        public void playRound()
        {
            displayBoard();
            round++;
            _diceCup.rollDice();
            displayDice();
        }
        public void executeInput(string[] input)
        {
            foreach(string i in input) {
                switch (i) { 
                    case "roll":
                        break;
                    case "board":
                        break;
                    case "keep":
                        break;
                    case "dice":
                        break;
                    default:
                        break;
                }
            }
        }

        public int getLegalRule() { 
            int rule = _readNumberInput.readNumber();
            if (_used[rule] || rule<1 || rule > 13)
            {
                Console.WriteLine("The rule was not legal, The rule has been used or you used an illegal number, more than 13 or less than 0");
                return getLegalRule();
            }
            else return rule;
        }

        public int scoreNumbers(int num) {
            int total = 0;
            int[] rolls = _diceCup.getIndividualSides();
            for (int i = 0; i > rolls.Length; i++)
            {
                if (rolls[i] == num) total += rolls[i];
            }
            return total;
        }
        public int scoreMultiple(int num) {
            int total = 0;
            int[] appearances = apperancesOfEyes();
            for (int i = 0; i < appearances.Length; i++)
            {
                if (appearances[i] >= num) total = num * i;
            } 
            return total;
        }

        public int[] apperancesOfEyes() {
            int[] rolls = _diceCup.getIndividualSides();
            int[] appearances = new int[7];
            for (int i = 0; i < rolls.Length; i++)
            {
                appearances[rolls[i]]++;
            }
            return appearances;
        }

        public int scoreMultiplePairs(int firstPair, int secondPair) {
            int total = 0;
            int[] appearances = apperancesOfEyes();
            for (int i = 0; i < appearances.Length; i++)
            {
                if (appearances[i] == firstPair) total += firstPair * i;
                else if(appearances[i] == secondPair) total += secondPair * i;
            }
            return total;
        }

        public int scoreStraight(int start) {
            int[] roll = _diceCup.getIndividualSides();
            bool legalStaright = true;
            Array.Sort(roll);
            for(int i = 0; i < 5; i++)
            {
                if (roll[i] != start + i) legalStaright = false;
            }
            if (!legalStaright) return 0;
            else if (start == 1) return 15;
            else return 20;
        }

        public int scoreYatzy() {
            int[] apperances = apperancesOfEyes();
            foreach(int i in apperances)
            {
                if (i == 5) return 50;
            }
            return 0;
        }

        public void scoreCup(int rule) {
            switch (rule) {
                case 1: //1'ere
                    _score[0] = scoreNumbers(1);
                    _used[0] = true;
                    return;
                case 2: //2'ere
                    _score[1] = scoreNumbers(2);
                    _used[1] = true;
                    return;

                case 3: //3'ere
                    _score[2] = scoreNumbers(3);
                    _used[2] = true;
                    return;

                case 4://4'ere
                    _score[3] = scoreNumbers(4);
                    _used[3] = true;
                    return;

                case 5://5'ere
                    _score[4] = scoreNumbers(5);
                    _used[4] = true;
                    return;

                case 6://6'ere
                    _score[5] = scoreNumbers(6);
                    _used[5] = true;
                    return;
                case 7://par
                    _score[6] = scoreMultiple(2);
                    _used[6] = true;
                    return;

                case 8: //to par
                    _score[7] = scoreMultiplePairs(2, 2);
                    _used[7] = true;
                    return;

                case 9://tre ens 
                    _score[8] = scoreMultiple(3);
                    _used[8] = true;
                    return;

                case 10: //fire ens
                    _score[9] = scoreMultiple(4);
                    _used[9] = true;
                    return;

                case 11: //lav straight
                    _score[10] = scoreStraight(1);
                    _used[10] = true;
                    return;
                case 12: //høj straight
                    _score[11] = scoreStraight(2);
                    _used[11] = true;
                    return;
                case 13: //fuldt hus
                    _score[12] = scoreMultiplePairs(2, 3);
                    _used[12] = true;
                    return;
                case 14: //chance
                    _score[13] = _diceCup.getEyes();
                    _used[13] = true;
                    return;
                case 15: //Yatzy
                    _score[14] = scoreYatzy();
                    _used[14] = true;
                    return;
                default:
                    throw new Exception();
            }
        }
        public void displayBoard() {
            int longestWord = 0;
            foreach (string word in _rules) { 
                if(word.Length> longestWord) longestWord = word.Length;
            }
            for(int j = 0; j<_rules.Length; j++) {
                Console.Write($"| {_rules[j]}");
                for (int i = _rules[j].Length; i <= longestWord; i++) {
                    Console.Write(" ");
                }
                Console.Write(" |");
                if (!_used[j]) Console.Write("    |");
                else if (_used[j] && _score[j] < 1) Console.Write(" X  |");
                else if (_used[j] && _score[j] < 10) Console.Write($" {_score[j]}  |");
                else Console.Write($" {_score[j]} |");
                Console.WriteLine();
            }

        }
        public void displayDice() { 
            int[] diceEyes = _diceCup.getIndividualSides();

            //row 1 top of the dice
            foreach (int i in diceEyes) {
                Console.Write("--------- ");
            }
            //row 2 top of the eyes row
            Console.WriteLine(" ");
            foreach (int i in diceEyes) {
                if (i != 1) Console.Write("| * ");
                else Console.Write("|   ");
                if (i > 3) Console.Write("  * | ");
                else Console.Write("    | ");
            }
            //row 3 middle row of the dice, used by uneven and 6
            Console.WriteLine(" ");
            foreach (int i in diceEyes) {
                if (i == 6) Console.Write("| * ");
                else Console.Write("|   ");
                if (i % 2 == 1) Console.Write("*");
                else Console.Write(" ");
                if (i == 6) Console.Write(" * | ");
                else Console.Write("   | ");
            }
            //row 4 lowest row with eyers
            Console.WriteLine("");
            foreach (int i in diceEyes) {
                if (i > 3) Console.Write("| *  ");
                else Console.Write("|    ");
                if (i != 1) Console.Write(" * | ");
                else Console.Write("   | ");
            }
            Console.WriteLine("");
            //row 5 the lower edge of the dice
            foreach (int i in diceEyes) {
                Console.Write("--------- ");
            }
            Console.WriteLine();
        
        }
    }
}
