using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Yatzy
{
    public interface IClient
    {
        public void displayRules();
        public void displayCurrentScore();
        public void displayDiceName();
        public void displayDiceLock();
        public void displayDice();
        public void displayScoreCup();
        public void displayTitle();
        public string lockInPoints();
        public bool[] rollDice();
    }
}
