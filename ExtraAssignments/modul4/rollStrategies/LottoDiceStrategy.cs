using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4.rollStrategies
{
    public class LottoDiceStrategy : RollStrategy
    {
        private List<int> _numbers;
        private Random _random = new Random();
        private int _sides;

        public LottoDiceStrategy(int sides){
            for (int i = 1; i <= sides; i++){
                _numbers.Add(i);
            }
            _sides = sides;
        }
        public int rollDie(int sides)
        {
            return 1;
        }
    }
}
