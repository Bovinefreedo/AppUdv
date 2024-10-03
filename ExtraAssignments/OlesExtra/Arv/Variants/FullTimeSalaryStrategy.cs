using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv.Variants
{
    public class FullTimeSalaryStrategy : ISalaryStrategy
    {
        private int salary;
        public FullTimeSalaryStrategy(int salary)
        {
            this.salary = salary;
        }

        public int baseSalary()
        {
            return salary;
        }

        public int lunchPayment()
        {
            return 350;
        }
    }
}
