using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class NormalRollStrategy : RollStrategy
    {
        Random _random = new Random();

        public NormalRollStrategy() { }
        public int rollDie(int sides) {
            return _random.Next(sides) +1; 
        }
    }
}
