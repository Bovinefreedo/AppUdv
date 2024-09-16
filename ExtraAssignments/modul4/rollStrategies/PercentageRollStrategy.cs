using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class PercentageRollStrategy : RollStrategy
    {
        int _percentage;
        Random _random = new Random();
        public PercentageRollStrategy(int percent) { 
            _percentage = percent;
        }
        public int rollDie(int sides)
        {
            if (_percentage > _random.Next(100))
            {
                return sides;
            }
            else
            {
                return _random.Next(sides-1)+1;
            }
        }
    }
}
