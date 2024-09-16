using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class PredictibleDie : RollStrategy
    {
        private int next = 1;
        public int rollDie(int sides)
        {
            if (sides > next) {
                next++;
                return next;
            }
            else
            {
                next = 1;
                return next;
            }
        }
    }
}
