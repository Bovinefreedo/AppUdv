using ExtraAssignments.modul4.rollStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    public class AdaptableDie : IDice
    {
        private Random _random = new Random();
        private int _eyes = 0;
        private int _sides = 0;
        private RollStrategy _rollStrategy;
        public AdaptableDie(RollStrategy roll , int sides = 6)
        {
            _sides = sides;
            _rollStrategy = roll;
            _eyes = rollDice();
        }
        public int getEyes()
        {
            return _eyes;
        }

        public int getSides()
        {
            return _sides;
        }

        public int rollDice()
        {
            _eyes = _rollStrategy.rollDie(_sides);
            return _eyes;
        }
    }
    
}
