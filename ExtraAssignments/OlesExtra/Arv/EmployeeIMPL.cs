using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class EmployeeIMPL : IEmployee
    {
        private string firstName;
        private string lastName;
        private string address;
        private int zipCode;
        private string city;
        private int tax;
        private int deduction;
        private bool lunch;        
        private bool gifts;      
        private ISalaryStrategy salary;
        public EmployeeIMPL(string firstName, string lastName, string address, int zipCode, string city, int tax, int deduction, bool lunch, bool gifts, ISalaryStrategy salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.zipCode = zipCode;
            this.city = city;
            this.tax = tax;
            this.deduction = deduction;
            this.lunch = lunch;
            this.gifts = gifts;
            this.salary = salary;   
        }

        public int calculateSalary()
        {
            int baseSalary = salary.baseSalary();
            int lunchPayment = salary.lunchPayment();
        }
    }
}
