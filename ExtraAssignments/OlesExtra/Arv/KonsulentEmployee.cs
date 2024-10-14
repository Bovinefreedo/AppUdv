using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class KonsulentEmployee : Employee
    {
        List<Project> projects { get; set; }

        public KonsulentEmployee(string firstName, string lastName, string address, int zipCode, string city, int tax, int deduction, bool lunch, bool gifts, List<Project> projects)
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
            this.projects = projects;
        }

    public override int brutoSalary()
        {
            DateOnly now = DateOnly.FromDateTime(DateTime.Now);
            int salary = 0;
            foreach (Project p in projects) {
                if (now > p._start && now < p._end) {
                    int duration = ((p._end.Year - p._start.Year) * 12) + p._end.Month - p._start.Month;
                    salary += p._payment/(duration+1);
                }
            }
            return salary;
        }

        public override int lunchPayment()
        {
            return lunchPrice;
        }
    }
}
