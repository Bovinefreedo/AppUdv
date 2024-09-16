using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class AvrageRollStrategy : RollStrategy
    {
        Random _random = new Random();
        public AvrageRollStrategy() { }
        public int rollDie(int sides)
        {
            int numberOfRolls = _random.Next(100) + 1;
            int total = 0;
            for (int i = 0; i < numberOfRolls; i++) { 
                total += _random.Next(sides)+1;
            }
            return total/numberOfRolls;
        }
    }
}
