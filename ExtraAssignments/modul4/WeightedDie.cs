using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    internal class WeightedDie : IDice
    {
        private Random _random = new Random();
        private int _eyes;
        private int _sides;
        private int _successRate = 40;
        public WeightedDie(int sides =6) {
            _sides = sides;
            rollDice();
        }
        public int getEyes()
        {
            return _eyes;
        }

        public int getSides()
        {
            return _sides;
        }
        public void setSuccessRate(int successRate){
            _successRate = successRate;
        }
        public int rollDice()
        {
            if (_successRate > _random.Next(100) + 1) {
                _eyes = _sides;
            }
            else{
                _eyes =_random.Next(_sides - 1) + 1;
            }
            return _eyes;
        }
    }
}
