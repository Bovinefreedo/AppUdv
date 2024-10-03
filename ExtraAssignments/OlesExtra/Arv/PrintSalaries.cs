using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class PrintSalaries
    {
        private List<Employee> employees;



        public PrintSalaries() {
            Project p1 = new Project(600000, new DateOnly(1999, 6, 1), new DateOnly(2011, 6, 28));
            Project p2 = new Project(500000, new DateOnly(2024, 8, 1), new DateOnly(2025, 9, 28));
            Project p3 = new Project(6000000, new DateOnly(2023, 6, 1), new DateOnly(2027, 6, 28));
            Project p4 = new Project(800000, new DateOnly(2024, 8, 1), new DateOnly(2025, 12, 28));

            List<Project> l1 = new List<Project> { p1 };
            List<Project> l2 = new List<Project> { p2, p4 };
            List<Project> l3 = new List<Project> { p3 };
            List<Project> l4 = new List<Project> { p4 };
            List<Project> l5 = new List<Project> { p1, p3 };

            employees = new List<Employee>{
            new FullTimeEmployee("John", "Doe", "123 Main St", 12345, "Metropolis", 20, 5, true, false, 45000),
            new FullTimeEmployee("Jane", "Doe", "456 Oak St", 12346, "Gotham", 15, 10, false, true, 50000),
            new FullTimeEmployee("Tom", "Smith", "789 Pine St", 12347, "Star City", 18, 7, true, true, 8000),
            new FullTimeEmployee("Mary", "Johnson", "101 Maple St", 12348, "Central City", 22, 8, false, false, 45730),
            new FullTimeEmployee("Jake", "Brown", "202 Elm St", 12349, "Blüdhaven", 19, 12, true, false, 25000),
            new FullTimeEmployee("Linda", "White", "303 Birch St", 12350, "Ivy Town", 17, 9, false, true, 30210),
            new FullTimeEmployee("Emily", "Clark", "404 Cedar St", 12351, "Coast City", 21, 6, true, true, 55000),
            new FullTimeEmployee("Robert", "Lopez", "505 Willow St", 12352, "Opal City", 16, 4, false, false, 80000),
            new FullTimeEmployee("Alice", "Martinez", "606 Spruce St", 12353, "Fawcett City", 23, 11, true, false, 100000),
            new FullTimeEmployee("Henry", "Lewis", "707 Redwood St", 12354, "Midway City", 20, 5, false, true, 22000),
            new FullTimeEmployee("Paul", "Walker", "808 Cherry St", 12355, "National City", 18, 8, true, true, 27000),
            new FullTimeEmployee("Jessica", "Harris", "909 Chestnut St", 12356, "Smallville", 19, 7, false, false, 42500),
            new KonsulentEmployee("Lucas", "Allen", "100 Oakwood Dr", 12357, "Keystone City", 21, 6, true, false, l1),
            new KonsulentEmployee("Karen", "Wright", "101 Rosewood Dr", 12358, "El Paso", 17, 9, false, true, l2),
            new KonsulentEmployee("Sophia", "King", "102 Silver St", 12359, "Gateway City", 16, 10, true, true, l3),
            new KonsulentEmployee("Oliver", "Scott", "103 River Rd", 12360, "Dakota City", 22, 5, false, false, l4),
            new KonsulentEmployee("Nathan", "Carter", "104 Forest Ln", 12361, "Charlton City", 19, 12, true, false, l5),
            new PartTimeEmployee("Monica", "Rogers", "105 Meadow Dr", 12362, "Hub City", 20, 8, false, true, 200, 180),
            new PartTimeEmployee("Alex", "Gonzalez", "106 Hill St", 12363, "Steel City", 18, 6, true, true, 600, 30),
            new PartTimeEmployee("Julia", "Nelson", "107 Garden St", 12364, "Palmera City", 23, 11, false, false, 300, 190),
            new PartTimeEmployee("Ryan", "Reed", "108 Brookside Dr", 12365, "Skartaris", 21, 7, true, false, 150, 30),
            new PartTimeEmployee("Caroline", "Butler", "109 Park Ave", 12366, "Trophy City", 19, 9, false, true, 280, 140),
            new PartTimeEmployee("Aaron", "Griffin", "110 Canyon Rd", 12367, "Belle Reve", 22, 6, true, true, 143, 250),
            new PartTimeEmployee("Eve", "Patterson", "111 Harbor St", 12368, "St. Roch", 17, 5, false, false, 300, 300),
            new PartTimeEmployee("Zoe", "Mitchell", "112 Pinecone Ct", 12369, "Sunnydale", 16, 8, true, false, 125, 140)
        };

        }
        public void print() {
            foreach (Employee e in employees) {
                Console.WriteLine($"Name: {e.firstName} {e.lastName}: {e.calculateSalary()}");
            }
        }
    }
}
