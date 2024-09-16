using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class RandomRandomRollStrategy : RollStrategy
    {
        private List<RollStrategy> _rollStrategies = new List<RollStrategy>();
        private Random _random = new Random();

        public RandomRandomRollStrategy() { 
            _rollStrategies.Add(new AvrageRollStrategy());
            _rollStrategies.Add(new MafiaRollStrategy());
            _rollStrategies.Add(new NormalRollStrategy());
            _rollStrategies.Add(new PercentageRollStrategy(_random.Next(100)));
            _rollStrategies.Add(new AllOrNothingRollStrategy());
            _rollStrategies.Add(new PredictibleDie());
        }

        public int rollDie(int sides)
        {
            return _rollStrategies[_random.Next(_rollStrategies.Count)].rollDie(sides);
        }
    }
}
