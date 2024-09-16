using ExtraAssignments.modul1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul3
{
    public class ReadMultipleNumbers
    {
        private ReadNumberInput input = new ReadNumberInput();
        public ReadMultipleNumbers() { }
        public int[] readNumbers() {

            Console.WriteLine("How many numbers should be in your array?");
            int num = 0;
            bool passed = false;
            while (!passed)
            {
              num = input.readNumber();
                if (num <= 0)
                {
                    passed = true;
                }
            }
            int i= 0;
            int[] numbers = new int[num];
            while (i < num)
            {
                Console.WriteLine($"Write number {i + 1} of {num}");
                numbers[i] = input.readNumber();
                i++;
            }
            return numbers;
        }

        public int[] readGrades()
        {

            Console.WriteLine("How many numbers should be in your array?");
            int num = 0;
            bool passed = false;
            while (!passed)
            {
                num = input.readNumber();
                if (num <= 0)
                {
                    passed = true;
                }
            }
            int i = 0;
            int[] numbers = new int[num];
            Console.WriteLine("Legal grades are, 12, 10, 7, 4, 2, 0, -3");
            while (i < num)
            {
                Console.WriteLine($"Write number {i + 1} of {num}");
                numbers[i] = input.readNumber();
                if (numbers[i] == 12 || numbers[i] == 10 || numbers[i] == 7 || numbers[i] == 4 || numbers[i] == 2 || numbers[i] == 0 || numbers[i] == -3)
                { i++; }
                else {
                    Console.WriteLine("Legal grades are, 12, 10, 7, 4, 2, 0, -3, what you wrote was not a legal grade");
                }
            }
            return numbers;
        }
    }
}
    

