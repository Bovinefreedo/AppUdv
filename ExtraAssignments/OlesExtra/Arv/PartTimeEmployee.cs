using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class PartTimeEmployee : Employee
    {
        public int hours { get; set; }
        public int rateHour { get; set; }

        public PartTimeEmployee(string firstName, string lastName, string address, int zipCode, string city, int tax, int deduction, bool lunch, bool gifts, int hours, int rateHour)
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
            this.hours = hours;
            this.rateHour = rateHour;
        }
    public override int brutoSalary()
        {
            return rateHour*hours;
        }

        public override int lunchPayment()
        {
            return lunchPrice-(lunchPrice*30)/100;
        }



    }
}
