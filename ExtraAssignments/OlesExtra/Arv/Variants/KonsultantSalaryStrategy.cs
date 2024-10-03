using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv.Variants
{
    public   class KonsultantSalaryStrategy : ISalaryStrategy
    {
        private List<Project> projects;

        public KonsultantSalaryStrategy(List<Project> projects)
        {
            this.projects = projects;
        }

        public int baseSalary()
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            int salary = 0;
            foreach (Project p in projects)
            {
                if (now > p._start && now < p._end)
                {
                    int duration = ((p._end.Year - p._start.Year) * 12) + p._end.Month - p._start.Month;
                    salary += p._payment / duration;
                }
            }
            return salary;
        }

        public int lunchPayment()
        {
            return 350;
        }
    }
}
