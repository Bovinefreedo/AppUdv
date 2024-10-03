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
        private List<Roll> rollHistory = new();
        private int[] currentRoll;
        public DiceCup(List<IDice> dice){
            myDice = dice;
            currentRoll = new int[myDice.Count];
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
            return currentRoll;
        }

        public int rollDice()
        {
            int total = 0;
            for (int i= 0; i<myDice.Count; i++)
            {
                total += myDice[i].rollDice();
                currentRoll[i]=myDice[i].getEyes();
            }
            return total;
        }
        public int rollDice(bool[] notRolled) { 
            int total = 0;
            for (int i = 0; i<notRolled.Length && i<myDice.Count ; i++){
                if (!notRolled[i]) {
                    total += myDice[i].rollDice();
                }
            }
            int[] sides = getIndividualSides();
            Roll thing = new Roll
            {
                roll = sides,
                time = DateTime.Now
            };

            rollHistory.Add(thing);
            return total;
        }

        public void clearHistory() { 
            rollHistory.Clear();
        }

        public int[] getIndividualSides(int d1, int d2, int d3, int d4, int d5) { 
            currentRoll = new int[] { d1, d2, d3, d4, d5 };
            return currentRoll;
        }

        public int fjern(List<int> list, int index) {
            int remvoed = list[index];
            list.RemoveAt(index);
            return remvoed;
        }
    }
}
