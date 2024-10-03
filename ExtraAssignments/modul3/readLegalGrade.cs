using ExtraAssignments.modul1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul3
{
    public class readLegalGrade
    {
        public readLegalGrade() { }

        public List<int> getGrades() {
            List<int> grades = new List<int>();
            while (true) {
                Console.WriteLine("Write a legal grade or perrish");
                string input =Console.ReadLine();
                int grade = 0;
                bool isNum = int.TryParse(input, out grade);
                if (!isNum) { break; }
                if (!validGrade(grade)) { break; }
                grades.Add(grade);
            }
            return grades;
        }

        public bool validGrade(int grade) {
            switch (grade)
            {
                case -3: case 0: case 2: case 4: case 7: case 10: case 12:
                    return true;
                default:
                    return false;
            }
        }
    }
}
