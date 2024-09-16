using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul1
{
    public class ReadNumberInput
    {
        public ReadNumberInput() { }
        public int readNumber() {
            Console.WriteLine("Write a number:");
            int num = 0;
            bool passed = false;
            while (!passed) {
                passed = int.TryParse(Console.ReadLine(), out num);
                if (!passed) 
                    Console.WriteLine("That was not a number");
            }
            return num;
        }
    }
}
