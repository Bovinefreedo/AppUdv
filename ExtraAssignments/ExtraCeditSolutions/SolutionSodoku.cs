using ExtraAssignments.ExtraCeditSolutions.FrameWorks;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.solutions
{
    public class SolutionSodoku 
    {
        int[][] puzzel = new int[9][];
        public SolutionSodoku(int[][] puzzel)
        {
            this.puzzel = puzzel;
        }

        public bool containsOnlyLegalNumbers()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (puzzel[j][i] > 9 || puzzel[j][i] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool numberIsInRow(int row, int number) {
            for(int i=0; i<9; i++) {
                if (puzzel[i][row]==number)
                    return true;
            }
            return false;
        }

        public bool legalRow(int row)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < 9; i++)
            {
                if (puzzel[i][row] == 0)
                    continue;
                if (seen.Contains(puzzel[i][row]))
                    return false;
                seen.Add(puzzel[i][row]);
            }
            return true;
        }

        public bool numberIsInColumn(int column, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (puzzel[column][i] == number)
                    return true;
            }
            return false;
        }

        public bool legalColumn(int column)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < 9; i++)
            {
                if (puzzel[column][i] == 0)
                    continue;
                if (seen.Contains(puzzel[column][i]))
                    return false;
                seen.Add(puzzel[column][i]);
            }
            return true;
        }

        public bool numberIsInBox(int column, int row, int number) {
            int boxX = row / 3; //Hel tals division simder alle rester ud så 2/3 runder ned til 0.
            int boxY = column / 3;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j<3; j++){
                    if (puzzel[boxY*3+i][boxX*3+j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool legalBox(int boxX, int boxY){
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (puzzel[boxY * 3 + j][boxX * 3 + i] == 0)
                        continue;
                    if(seen.Contains(puzzel[boxY * 3 + j][boxX * 3 + i]))
                        return false;
                    seen.Add(puzzel[boxY * 3 + j][boxX * 3 + i]);
                }
            }
            return true;
        }

        //Vi skal finde ud af om en plade er legal. Der må ikke være duplikater i rækker, kolloner eller boxe
        //Hvis et felt er tomt vil det være 0,
        public bool legalSodoku()
        {
            for(int i = 0;i < 3; i++)
            {
                for( int j = 0;j < 3; j++)
                {
                    if (!legalBox( j, i)){
                        Console.WriteLine($"Box ({j},{i}) is not legal");
                        return false;
                    }
                }
            }
            for(int i = 0; i < 9; i++)
            {
                if (!legalColumn(i)) {
                    Console.WriteLine($"column {i} is not legal");
                    return false ;
                }
                if(!legalRow(i))
                {
                    Console.WriteLine($"row {i} is not legal");
                    return false;
                }
            }

            if (!containsOnlyLegalNumbers()){
                Console.WriteLine("Contains an illegal number");
                return false;
            }

            return true;
        }
        public bool legalMove2(int y, int x, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (puzzel[i][x] == number || puzzel[y][i] == number) {
                    return false;
                }
            }
            int top = x / 3;
            int left = y / 3;
            for (int i = 0; i< 3; i++){
                for (int j = 0; j < 3; j++) {
                    if (puzzel[left*3 + j][top*3 + i] == number) { return false; }
                }
            }
            return true;
        }
        public bool legalMove(int y, int x, int number)
        {
            if (numberIsInRow(x, number)) return false;
            if (numberIsInColumn(y, number)) return false;
            if (numberIsInBox(y, x, number)) return false;
            return true;
        }

        //Vi skal prøve at lave en algoritme, der kan løse vores Sodoku.
        //Jeg har fundet en youtube short der visualisere dette https://youtube.com/shorts/4c_16yiQBfI?si=uq7RsYpv7ySnkCn0
        //Der er 
        public void findNextLegalMove()
        {
            for (int y = 0; y < 9; y++) {
                for (int x = 0; x < 9; x++) {
                    if (puzzel[y][x] == 0){
                        for (int k = 1; k < 10; k++){
                            if (legalMove(y, x, k)){
                                puzzel[y][x] = k;
                                findNextLegalMove();
                                puzzel[y][x] = 0;
                            } 
                        }
                        return;
                    }
                }
            }
            printSodoku();
            return;
        }

        public void solveSoduko()
        {
            if (!legalSodoku()) return;
            findNextLegalMove();
        }

        public void printSodoku()
        {
            Console.WriteLine("-------------------");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($"|{puzzel[i][j]}");
                }
                Console.WriteLine("|");
                Console.WriteLine("-------------------");
            }

        }

        public void setSodoku(int[][] puzzel)
        {
            this.puzzel=puzzel;
        }
    }
}
