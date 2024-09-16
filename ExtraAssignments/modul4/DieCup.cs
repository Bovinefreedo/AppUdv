using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    public class DiceCup : IDice
    {
        List<IDice> myDice;
        public DiceCup(List<IDice> dice){
            myDice = dice;
        }
        public int getEyes()
        {
            int total = 0; 
            foreach(IDice dice in myDice) { 
                total +=dice.getEyes(); 
            }
            return total;
        }

        public int getSides()
        {
            int total = 0;
            foreach (IDice dice in myDice)
            {
                total += dice.getSides();
            }
            return total;
        }

        public int rollDice()
        {
            int total = 0;
            foreach (IDice dice in myDice)
            {
                total += dice.getSides();
            }
            return total;
        }
    }
}
