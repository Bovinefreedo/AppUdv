using ExtraAssignments.ExtraCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.solutions
{
    public class TestingClass
    {
        HelpMethods help = new HelpMethods();
        public TestingClass() { }

        public void TestContainsDuplicates()
        {
            ContainsDuplicates dups = new ContainsDuplicates();
            if (!dups.containsDuplicates(help.dups()))
            {
                Console.WriteLine($"containsDups returned false, expected true");
                Console.WriteLine($"The function failed on this input {help.dups()}");
                Console.ReadLine();
                return;
            }

            if (dups.containsDuplicates(help.manyInts(4)))
            {
                Console.WriteLine($"containsDups returned true, when it expected false");
                Console.WriteLine($"the function failed with the input {help.manyInts(4)}");
                return;
            }
            Console.WriteLine($"Your algorithm has passed my tests, congratulations");
        }
        public void TestSodoku()
        {
        }
    }
}
