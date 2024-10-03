using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class FullTimeEmployee : Employee
    {
        public int baseSalary {  get; set; }

        public FullTimeEmployee(string firstName, string lastName, string address, int zipCode, string city, int tax, int deduction, bool lunch, bool gifts, int baseSalary)
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
            this.baseSalary = baseSalary;
        }

    public override int brutoSalary()
        {
            return baseSalary;
        }

        public override int lunchPayment()
        {
            return lunchPrice;
        }
    }
}
