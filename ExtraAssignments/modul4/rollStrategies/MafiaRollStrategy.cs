using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class MafiaRollStrategy : RollStrategy
    {
        Random _random = new Random();
        public MafiaRollStrategy() { }
        public int rollDie(int sides)
        {
            int num = _random.Next(sides) + 1;
            if (num == sides){
                return num;
            }
            return _random.Next(sides)+1;
        }
    }
}
