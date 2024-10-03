using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public interface ISalaryStrategy
    {
        public int baseSalary();

        public int lunchPayment();
    }
}
