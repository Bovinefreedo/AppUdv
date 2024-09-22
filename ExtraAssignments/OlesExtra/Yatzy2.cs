using ExtraAssignments.modul1;
using ExtraAssignments.modul4;
using ExtraAssignments.modul4.rollStrategies;

namespace ExtraAssignments.OlesExtra
{
    public class Yatzy2
    {
        public string[] _rules { get; } = { "Aces", "Twos", "Threes", "Fours", "Fives", "Sixes", "Pair", "Two Pair", "Three of a Kind", "Four of a Kind", "Full House", "Small Straight", "Large Straight", "Yatzy", "Chance" };
        public bool[,] _used { get; set; } = new bool[15,6];
        public int[,] _score { get; set; } = new int[15,6];
        public bool[] _lockedDice { get; set; } = new bool[5];
        public bool _roundFinished { get; set; } = false;
        public DiceCup _diceCup { get; set; }
        public int _playerInTurn { get; set; } =  0;
        public int _activePlayers { get; set; } = 1;
        public string[] _playerNames { get; set; } = new string[6];
        public int _rollsThisRound { get; set; } = 0;
        public int _round { get; set; } = 1;
        public ReadNumberInput _readNumberInput { get; set; } = new ReadNumberInput();
        public Yatzy2()
        {
            List<IDice> myDice = new List<IDice>();
            for (int i = 0; i < 5; i++)
            {
                myDice.Add(new AdaptableDie(new NormalRollStrategy()));
            }
            _diceCup = new DiceCup(myDice);
        }

        ////////////////////////////////////////////////////////////////
        ////GAME LOGIC//////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
        public void playGame()
        {
            displayTitle();
            _diceCup.rollDice();
            displayDice();
            displayOptions();
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            Console.ReadLine();
            setUpGame();

            while (_round <= 15)
            {
                Console.WriteLine($"Round: {_round} Player: {_playerNames[_playerInTurn]}, {_playerInTurn}");
                displayBoard();
                beginRound();
                playRound();
            }
            displayTitle();
            displayBoard();
            Console.WriteLine("The game is finished");
        }

        public void playRound()
        {
            while (!_roundFinished)
            {
                Console.WriteLine("Please write your command, 'o' will show you the options");
                getInput();
            }
            endRound();
        }

        public void setUpGame()
        {
            int numberOfPlayers = 0;
            while (numberOfPlayers < 1 || numberOfPlayers > 6) {
                numberOfPlayers = _readNumberInput.readNumber();
            }
            _activePlayers = numberOfPlayers;
            for(int i = 0; i < _activePlayers; i++)
            {
                Console.WriteLine($"What is the name of player {i + 1}");
                _playerNames[i] = Console.ReadLine() ?? string.Empty;
            }
        }
        public void endRound() {
            if (_playerInTurn < _activePlayers-1)
                _playerInTurn++;
            else { 
                _playerInTurn = 0;
                _round++;
            }

        }

        public void beginRound()
        {
            _diceCup.rollDice();
            displayDice();
            _roundFinished = false;
            _rollsThisRound = 1;
            for (int i = 0; i < _lockedDice.Length; i++)
            {
                _lockedDice[i] = false;
            }
        }

        public void getInput()
        {
            string input = Console.ReadLine();
            string[] commands = new string[1];
            try { commands = input.Split(" "); }
            catch
            {
                return;
            }
            executeInput(commands);
        }

        public void executeInput(string[] input)
        {
            foreach (string i in input)
            {
                string command = i.Substring(0, 1);
                int num = -1;
                bool hasNum = int.TryParse(i.Remove(0, 1), out num);
                switch (command)
                {
                    case "r": //roll
                        _rollsThisRound++;
                        _diceCup.rollDice(_lockedDice);
                        if (_rollsThisRound == 3)
                        {
                            lockInPoints();
                            _roundFinished = true;
                            return;
                        }
                        displayDieLockName();
                        displayDice();
                        break;
                    case "s": //score
                        displayBoard();
                        break;
                    case "k": //keep
                        _roundFinished = true;
                        if (hasNum) lockInPoints(num);
                        else lockInPoints();
                        return;
                    case "d": //dice
                        displayDieLockName();
                        displayDice();
                        break;
                    case "o": //options
                        displayOptions();
                        break;
                    case "l": //lock dice and unlock dies
                        if (hasNum) lockDie(num);
                        else lockDie();
                        break;
                    case "p": //show points for current roll
                        displayScoreOptions();
                        break;
                    case "u": //rules of the game
                        displayRules();
                        break;
                    default:
                        break;
                }
            }
        }
        public void lockInPoints()
        {
            displayScoreOptions();
            displayDice();
            Console.WriteLine("Pick one not already picked by you");
            int rule = getLegalRule();
            awardPoints(rule);
        }

        public void lockInPoints(int rule)
        {
            if (!_used[rule-1, _playerInTurn] && rule > 0 && rule <= 15)
            {
                awardPoints(rule);
            }
            else lockInPoints();
        }

        //reversing a lock status on a die
        public void lockDie()
        {
            int dieNumber = _readNumberInput.readNumber();
            if (dieNumber > 0 && dieNumber <= 5)
            {
                _lockedDice[dieNumber - 1] = !_lockedDice[dieNumber - 1];
            }
            else { lockDie(); }
        }

        //reversing a lock status on a specific die
        public void lockDie(int num)
        {
            if (num > 0 && num <= 5) _lockedDice[num - 1] = !_lockedDice[num - 1];
            else { lockDie(); }
        }

        public int getLegalRule()
        {
            int rule = _readNumberInput.readNumber();
            if (_used[rule-1, _playerInTurn] || rule < 1 || rule > 15)
            {
                Console.WriteLine("The rule was not legal, The rule has been used or you used an unavailable number, more than 15 or less than 0");
                return getLegalRule();
            }
            else return rule;
        }


        ///////////////////////////////////////////////////////////////////////
        /// AWARDING AND CALCULATIMG POINTS /////////////////////////////////// 
        ///////////////////////////////////////////////////////////////////////

        //Scoreing numbers for the first 6 rules Aces-sixes
        public int scoreNumbers(int num)
        {
            int total = 0;
            int[] rolls = _diceCup.getIndividualSides();
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == num) { total = total + num; }
            }
            return total;
        }

        // scoring multiple of a kind (pair, three or four of a kind)
        public int scoreMultiple(int num)
        {
            int total = 0;
            int[] appearances = appearancesOfEyes();
            for (int i = 0; i < appearances.Length; i++)
            {
                if (appearances[i] >= num) total = num * i;
            }
            return total;
        }

        //Helping method that gives an array with the number of appearances a roll has
        // if the roll is {3,3,3,5,5} it will return {0,0,0,3,0,2,0}
        // the index 0 will always be 0 and can be skipped.
        public int[] appearancesOfEyes()
        {
            int[] rolls = _diceCup.getIndividualSides();
            int[] appearances = new int[7];
            for (int i = 0; i < rolls.Length; i++)
            {
                appearances[rolls[i]]++;
            }
            return appearances;
        }

        //scoring two pair and full house, it is important to put the bigger of the two
        //input integers first, if you don't the input {3,3,3,5,5} will fail.  
        public int scoreMultiplePairs(int bigMult, int smallMult)
        {
            int firstMult = 0;
            int secondMult = 0;
            int[] appearances = appearancesOfEyes();
            for (int i = 1; i < appearances.Length; i++)
            {
                if (appearances[i] >= bigMult)
                {
                    firstMult = i * bigMult;
                    appearances[i] -= bigMult;
                    break;
                }
            }
            for (int i = 1; i < appearances.Length; i++)
            {
                if (appearances[i] >= smallMult)
                {
                    secondMult = i * smallMult;
                    appearances[i] -= smallMult;
                    break;
                }
            }

            if (firstMult == 0 || secondMult == 0) return 0;
            return firstMult + secondMult;
        }

        //scoring a straights
        public int scoreStraight(int start)
        {
            int[] roll = _diceCup.getIndividualSides();
            bool legalStraight = true;
            Array.Sort(roll);
            for (int i = 0; i < 5; i++)
            {
                if (roll[i] != start + i) legalStraight = false;
            }
            if (!legalStraight) return 0;
            else if (start == 1) return 15;
            else return 20;
        }

        //Scoring Yatzy
        public int scoreYatzy()
        {
            int[] appearances = appearancesOfEyes();
            foreach (int i in appearances)
            {
                if (i == 5)
                {
                    displayTitleGPT();
                    displayTitle();
                    return 50;
                }
            }
            return 0;
        }

        //Responsible for awarding points when a turn has been finalized by choosing
        //a rule
        public void awardPoints(int rule)
        {
            _score[rule - 1, _playerInTurn] = scoreCup(rule);
            _used[rule - 1, _playerInTurn] = true;
        }

        //This is where each rule is scored, this only tells you how many points
        //choosing a rule will score you.
        public int scoreCup(int rule)
        {
            switch (rule)
            {
                case 1: //1'ere
                    return scoreNumbers(1);
                case 2: //2'ere
                    return scoreNumbers(2);
                case 3: //3'ere
                    return scoreNumbers(3);

                case 4://4'ere
                    return scoreNumbers(4);

                case 5://5'ere
                    return scoreNumbers(5);

                case 6://6'ere
                    return scoreNumbers(6);

                case 7://par
                    return scoreMultiple(2);

                case 8: //to par
                    return scoreMultiplePairs(2, 2);

                case 9://tre ens 
                    return scoreMultiple(3);

                case 10: //fire ens
                    return scoreMultiple(4);
                case 11: //fuldt hus 
                    return scoreMultiplePairs(3, 2);
                case 12: //lav straight
                    return scoreStraight(1);
                case 13: //høj straight
                    return scoreStraight(2);
                case 14: //Yatzy
                    return scoreYatzy();
                case 15: //chance
                    return _diceCup.getEyes();
                default:
                    throw new Exception();
            }
        }

        ////////////////////////////////////////////////////////////////////
        /// DISPLAY SECTION ////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////

        //This displays the values you score each rule could net you with
        //Your current dice roll, this can be used to evaluate if you want to stop
        //or you want to continue
        public void displayScoreOptions()
        {
            Console.WriteLine("-------------------------");
            int longestWord = 15;
            for (int j = 0; j < _rules.Length; j++)
            {
                Console.Write($"| {j + 1} {_rules[j]}");
                for (int i = _rules[j].Length; i <= longestWord; i++) { Console.Write(" "); }
                if (j < 9) Console.Write(" ");
                Console.Write(" |");
                int score = scoreCup(j + 1);
                if (!_used[j, _playerInTurn] && score < 10) Console.Write($" {score}  |");
                else if (!_used[j, _playerInTurn] && score < 100) Console.Write($" {score} |");
                else Console.Write($" X  |");
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
        }

        //This is the current state of the game, it shows all players and how many
        //points they have locked in so far.
        public void displayBoard()
        {
            int longestWord = 15;
            int[] sum = new int[6];
            int[] total = new int[6];
            for (int j = 0; j < _activePlayers; j++)
            {
                for (int i = 0; i < 6; i++) { sum[j] += _score[i,j]; }
                total[j] = sum[j];
                if (sum[j] >= 63)
                {
                    total[j] += 50;
                }
                for (int i = 6; i < 15; i++) { total[j] += _score[i,j]; }
            }
            drawStraightLine();
            Console.Write("|                  |");
            for (int i = 0; i < _activePlayers; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_playerNames[i].Length >= j + 1) Console.Write(_playerNames[i][j]);
                    else Console.Write(" ");
                }
                Console.Write(" |");
            }
            Console.WriteLine(" ");
            drawStraightLine();
            for (int j = 0; j < 6; j++)
            {
                Console.Write($"| {_rules[j]}");
                for (int i = _rules[j].Length; i <= longestWord; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(" |");
                for (int i = 0; i < _activePlayers; i++)
                {
                    if (!_used[j,i]) Console.Write("    |");
                    else if (_used[j, i] && _score[j, i] < 1) Console.Write(" X  |");
                    else if (_used[j, i] && _score[j, i] < 10) Console.Write($" {_score[j, i]}  |");
                    else Console.Write($" {_score[j, i]} |");
                }
                Console.WriteLine();
            }
            drawStraightLine();
            Console.Write($"| Sum              |");
            for (int i = 0; i < _activePlayers; i++)
            {
                if (sum[i] < 10) Console.Write($" {sum[i]}  |");
                else { Console.WriteLine($" {sum[i]} |"); }
            }
            Console.WriteLine("");
            Console.Write($"| Bonus            |");
            for (int i = 0; i < _activePlayers; i++)
            {
                if (sum[i] > 63) Console.Write($" 50 |");
                else Console.Write($" 0  |");
            }
            Console.WriteLine("");
            drawStraightLine();
            for (int j = 6; j < 15; j++)
            {
                Console.Write($"| {_rules[j]}");
                for (int i = _rules[j].Length; i <= longestWord; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(" |");
                for (int i = 0; i < _activePlayers; i++) { 
                    if (!_used[j,i]) Console.Write("    |");
                    else if (_used[j,i] && _score[j,i] < 1) Console.Write(" X  |");
                    else if (_used[j,i] && _score[j,i] < 10) Console.Write($" {_score[j, i]}  |");
                    else Console.Write($" {_score[j,i]} |");
                }
                Console.WriteLine();
            }
            drawStraightLine();
            Console.Write($"| Total            |");
            for (int i = 0; i < _activePlayers; i++)
            {
                if (total[i] < 10) Console.Write($" {total[i]}  |");
                else if (total[i] < 100) Console.Write($" {total[i]} |");
                else Console.Write($" {total[i]}|");
            }
            Console.WriteLine("");
            drawStraightLine();
        }

        public void drawStraightLine() {

            Console.Write("-------------------");
            for(int i=0; i < _activePlayers; i++)
            {
                Console.Write("-----");
            }
            Console.WriteLine("");
        }

        public void displayDieLockName()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"  Die {i}   ");
            }
            Console.WriteLine("");
            for (int i = 1; i <= 5; i++)
            {
                if (_lockedDice[i - 1]) Console.Write($" Locked   ");
                else Console.Write($"Unlocked  ");
            }
            Console.WriteLine();

        }

        //This prints out the dice roll, so it looks like dice
        public void displayDice()
        {
            int[] diceEyes = _diceCup.getIndividualSides();

            //row 1 top of the dice
            foreach (int i in diceEyes)
            {
                Console.Write(" -------  ");
            }
            //row 2 top of the eyes row
            Console.WriteLine(" ");
            foreach (int i in diceEyes)
            {
                if (i != 1) Console.Write("| * ");
                else Console.Write("|   ");
                if (i > 3) Console.Write("  * | ");
                else Console.Write("    | ");
            }
            //row 3 middle row of the dice, used by uneven and 6
            Console.WriteLine(" ");
            foreach (int i in diceEyes)
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
            foreach (int i in diceEyes)
            {
                if (i > 3) Console.Write("| *  ");
                else Console.Write("|    ");
                if (i != 1) Console.Write(" * | ");
                else Console.Write("   | ");
            }
            Console.WriteLine("");
            //row 5 the lower edge of the dice
            foreach (int i in diceEyes)
            {
                Console.Write(" -------  ");
            }
            Console.WriteLine();
        }
        public void displayRules()
        {
            Console.WriteLine("please implement me");
        }

        public void displayOptions()
        {
            Console.WriteLine("Here are the controls for the game. When prompted for an input, type one of these letters.");
            Console.WriteLine("When you have entered your command press enter.");
            Console.WriteLine("You can enter a number after some commands to speed up the process, id you don't you will be asked for that number later so don't sweat it.");
            Console.WriteLine("One input can hold several commands");
            Console.WriteLine("'l3 l2 d': will switch the lock status for die 2 and 3 and show the dice");
            Console.WriteLine("but beware about the order if you 'r l1 l2' the roll will happen first and the locks will be discarded");
            Console.WriteLine("r: to roll");
            Console.WriteLine("l: to lock/unlock dice, you can provide number 1-5 to choose die");
            Console.WriteLine("k: to keep the dice and lock in scoring, you can optional provide number 1-15 to select rule");
            Console.WriteLine("d: to display dice");
            Console.WriteLine("s: to display the current score board");
            Console.WriteLine("p: to see what point you can lock in with your current roll");
            Console.WriteLine("u: to see the rules of the game");
            Console.WriteLine("o: to see this message again");
        }

        //Title
        public void displayTitle()
        {
            Console.WriteLine(@"\\    //   //\\   ==========   =======   \\    //");
            Console.WriteLine(@" \\  //   //  \\      ||           //     \\  //");
            Console.WriteLine(@"  \\//   //    \\     ||          //       \\//");
            Console.WriteLine(@"   ||    ||====||     ||         //         ||");
            Console.WriteLine(@"   ||    ||    ||     ||        //          ||");
            Console.WriteLine(@"   ||    ||    ||     ||       =======      ||");
        }

        public void displayTitleGPT()
        {
            Console.WriteLine(@"\   /    / \   _ | _   ZZZZZ  \   /");
            Console.WriteLine(@" \ /    /   \    |      /     \ /");
            Console.WriteLine(@"  |    /_____\   |     /       |");
            Console.WriteLine(@"  |   /       \  |    /        |");
            Console.WriteLine(@"  |  /         \ |   ZZZZZ     |");

        }

    }
}


