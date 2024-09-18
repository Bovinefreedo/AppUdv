using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.ExtraCredit
{
    public class Queens
    {
        private int numberOfSolutions = 0;
        public Queens() { }

        public bool legalPlacement(string[][] board, int column, int row)
        {
            return true;
        }

        public void getNextSquareInRow(string[][] board, int row)
        {

        }

        public int QueensN(int n)
        {
            numberOfSolutions = 0;
            string[][] board = new string[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new string[n];
            }
            getNextSquareInRow(board, 0);
            return numberOfSolutions;
        }

        public void printBoard(string[][] board)
        {
            for (int k = 0; k < board.Length; k++)
            {
                Console.Write("----");
            }
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[j][i].Equals("Q"))
                        Console.Write("| Q ");
                    else
                        Console.Write("|   ");
                }
                Console.WriteLine("|");
                for (int k = 0; k < board.Length; k++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
    }
}
