using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv.Variants
{
    public class PartTimeSalaryStrategy : ISalaryStrategy
    {
        private int hours;
        private int rateHour;

        public PartTimeSalaryStrategy(int hours, int rateHour)
        {
            this.hours = hours;
            this.rateHour = rateHour;
        }
        public int baseSalary()
        {
            return hours * rateHour;
        }

        public int lunchPayment()
        {
            return 275;
        }
    }
}
