using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul4
{
    public class NormalDice : IDice
    {
        private Random _random = new Random();
        private int _eyes = 0;
        private int _sides = 0;
        public NormalDice(int sides=6) { 
            _sides = sides;
            _eyes = _random.Next(_sides)+1;
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
            _eyes = _random.Next(_sides) + 1;
            return _eyes;
        }
    }
}
