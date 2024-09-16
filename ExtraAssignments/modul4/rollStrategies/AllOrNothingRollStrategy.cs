using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    internal class AllOrNothingRollStrategy : RollStrategy
    {
        private Random _random = new Random();
        public AllOrNothingRollStrategy() { }
        public int rollDie(int sides)
        {
            if (_random.Next(2) == 1)
                return sides;
            else
                return 1;
        }
    }
}
