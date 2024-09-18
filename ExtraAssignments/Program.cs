using ExtraAssignments.ExtraCredit;
using ExtraAssignments.modul1;
using ExtraAssignments.modul2;
using ExtraAssignments.modul3;
using ExtraAssignments.modul4;
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

DictionaryConverter converter = new DictionaryConverter();

string path = @"C:\Users\hotso\source\repos\ExtraAssignments\ExtraAssignments\OlesExtra\dictionaries\da_DK.dic";
string destination = @"C:\Users\hotso\source\repos\ExtraAssignments\ExtraAssignments\OlesExtra\dictionaries\da_DK.txt";

converter.convertDictionary(path, destination);