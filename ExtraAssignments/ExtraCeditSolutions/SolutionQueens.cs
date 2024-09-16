using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.solutions
{
    public class SolutionQueens
    {
        private int numberOfSolutions = 0;
        public SolutionQueens() { }
        public bool legalPlacement(string[][] board, int column, int row)
        {
            for (int i = 1; i <= row; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[column][row-i].Equals("Q"))
                        return false;
                    if (column - i >= 0 && board[column-i][row-i].Equals("Q"))
                        return false;
                    if (column + i < board.Length && board[column+i][row-i].Equals("Q"))
                        return false;
                }
            }
            return true;
        }

        public void getNextSquareInRow(string[][] board, int row)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (row + 1 > board.Length)
                    {                           
                        numberOfSolutions++;
                        Console.WriteLine($"solution: {numberOfSolutions}");
                        printBoard(board);
                        Console.WriteLine("do you want to see more solutions?");
                        Console.ReadLine();
                        return;
                    }
                if (legalPlacement(board, i, row))
                {
                    board[i][row] = "Q";
                    getNextSquareInRow(board, row + 1);
                    board[i][row] = "";

                }
            }
        }

        public int queensN(int n)
        {
            numberOfSolutions = 0;
            string[][] board = new string[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new string[n];
                for (int j = 0; j < n; j++) { board[i][j] = ""; }
            }
            getNextSquareInRow(board, 0);
            return numberOfSolutions;
        }

        public void printBoard(string[][] board) {
            for (int k = 0; k < board.Length; k++)
            {
                Console.Write("----");
            }
                Console.WriteLine();
            for (int i = 0; i < board.Length; i++) { 
                for(int j = 0; j < board[i].Length; j++){
                    if (board[j][i].Equals("Q"))
                        Console.Write("| Q ");
                    else
                        Console.Write("|   ");
                }
                Console.WriteLine("|");
                for (int k = 0; k < board.Length; k++) { 
                    Console.Write("----");
                }
                    Console.WriteLine();
            }
        
        }
    }
}
