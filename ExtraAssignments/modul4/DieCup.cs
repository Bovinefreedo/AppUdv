using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    public class DiceCup : IDice
    {
        private List<IDice> myDice;
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

        public int[] getIndividualSides()
        {
            int[] eachDie = new int[myDice.Count];
            for (int i = 0; i < eachDie.Length; i++){
                eachDie[i] = myDice[i].getEyes();
            }
            return eachDie;
        }

        public int rollDice()
        {
            int total = 0;
            foreach (IDice dice in myDice)
            {
                total += dice.rollDice();
            }
            return total;
        }
        public int rollDice(bool[] diceToBeRolled) { 
            int total = 0;
            for (int i = 0; i<diceToBeRolled.Length && i<myDice.Count ; i++){
                if (diceToBeRolled[i]) {
                    total += myDice[i].rollDice();
                }
            }
            return total;
        }
    }
}
