using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    public class TestDice
    {
        public TestDice() { }

        public int[] testADie(IDice die, int numberOfTests) { 
            int sides = die.getSides();
            int[] results = new int[sides +1];
            int[] listOfResults = new int[numberOfTests];
            for (int i = 0; i < numberOfTests; i++)
            {
                int roll = die.rollDice();
                results[roll]++;
                listOfResults[i] = roll;
            }
            for(int i = 1; i< results.Length; i++) {
                if (results[i] != 0){
                    Console.WriteLine($"The die has rolled {i}: {results[i]} times");
                }
            }
            return listOfResults;
        }
    }
}
