using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public abstract class Employee
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } =string.Empty;
        public string address { get; set; } = string.Empty;
        public int zipCode { get; set; }
        public string city { get; set; } = string.Empty;
        public int tax { get; set; }
        public int deduction { get; set; }
        public bool lunch {  get; set; }
        public bool gifts { get; set; }
        public int lunchPrice { get; set; } = 350;

        public int calculateSalary()
        {
            int baseSalary = brutoSalary();
            if (baseSalary == 0) return 0;
            int afterDeduction = baseSalary - deduction;
            int afterTax = baseSalary - (baseSalary * tax) / 100;
            if (gifts) afterTax -= 30;
            if (lunch) afterTax -= lunchPayment() ;
            return afterTax;
        }
        public abstract int brutoSalary();
        public abstract int lunchPayment();
    }
}
