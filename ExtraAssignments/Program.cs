using ExtraAssignments.ExtraCredit;
using ExtraAssignments.modul1;
using ExtraAssignments.modul2;
using ExtraAssignments.modul3;
using ExtraAssignments.modul4;
using ExtraAssignments.modul4.rollStrategies;
using ExtraAssignments.OlesExtra;
using ExtraAssignments.OlesExtra.dictionaries;
using ExtraAssignments.solutions;

HelpMethods help = new HelpMethods();
ArraysAndMethos arraysAndMethos = new ArraysAndMethos();
int[][] puzzel = help.getSodoku1();
SolutionSodoku solver = new SolutionSodoku(puzzel);

SolutionQueens nQueens = new SolutionQueens();

//Console.WriteLine(nQueens.queensN(7));
//solver.solveSoduko();

//TestDice test = new TestDice();
//List<IDice> dice = new List<IDice>();

//arraysAndMethos.standardDiviation(test.testADie(help.CreateDiceFromId(6),50000));
//HiddenWord word = new HiddenWord("badeand");
//Hangman game = new Hangman(word);

//TestDice t = new TestDice();
//List<IDice> list = new List<IDice>();
//for (int i = 0; i < 5; i++) {
//
//}
//AdaptableDie normal = new AdaptableDie(new NormalRollStrategy());
//
//t.testADie(normal, 100000);

Yatzy y = new Yatzy();

y.playRound();