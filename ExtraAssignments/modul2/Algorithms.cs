using ExtraAssignments.modul1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul2
{
    public class Algorithms
    {
        ReadNumberInput input = new ReadNumberInput();
        public Algorithms() { }

        //Cookie cutter standard.
        public void stamps() {
            int submitedNumber = 0;
            while (submitedNumber < 8) 
                { submitedNumber = input.readNumber(); }
            int postage = submitedNumber;
            int fiveCentStamps = 0;
            int threeCentStamps = 0;
            while (postage > 12)
            {
                fiveCentStamps++;
                postage -= 5;
            }
            switch (postage)
            {
                case 12: 
                    threeCentStamps += 4;
                    break;
                case 11:
                    threeCentStamps += 2;
                    fiveCentStamps++;
                    break;
                case 10:
                    fiveCentStamps += 2;
                    break;
                case 9:
                    threeCentStamps += 3;
                    break;
                case 8:
                    threeCentStamps++;
                    fiveCentStamps++;
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
            if (5 * fiveCentStamps + 3 * threeCentStamps == submitedNumber)
            {
                Console.WriteLine($"The postage will be paid with {threeCentStamps} 3 cent stamps and {fiveCentStamps} 5 cent stamps");
            }
            else {
                Console.WriteLine("The code is wrong, the world is ending");
            }
        }

        //With binary search to optimize the number of actions (good when you have large inputs)
        public void stamps2() {
            double submitedNumber = 0;
            while (submitedNumber < 8) {
                submitedNumber = input.readNumber();
            }
            double postage = submitedNumber;
            double fiveCentStamps = 0;
            double threeCentStamps = 0;
            int pow = 0;
            while (postage > 12)
            {
                if (Math.Pow(2, pow) * 5 < postage -12)
                {
                    postage = postage - Math.Pow(2, pow) * 5;
                    fiveCentStamps += Math.Pow(2, pow);
                    pow++;
                }
                else { pow--; }
            }
            fiveCentStamps += remaningFiveStamps((int)postage);
            threeCentStamps += remaningThreeStamps((int)postage);
            if (5 * fiveCentStamps + 3 * threeCentStamps == submitedNumber)
            {
                Console.WriteLine($"The postage will be paid with {threeCentStamps} three cent stamps and {fiveCentStamps} five cent stamps");
            }
            else
            {
                Console.WriteLine("The code is wrong, the world is ending");
            }
        }

        public int remaningThreeStamps(int number) {
            switch (number)
            {
                case 12:
                     return 4;
                case 11:
                    return 2;
                case 10:
                    return 0;
                case 9:
                    return 3;
                case 8:
                    return 1;
                default:
                    Console.WriteLine("Something went wrong with the three cent stamps");
                    return 0;
            }
        }

        public int remaningFiveStamps(int number)
        {
            switch (number)
            {
                case 12:
                    return 0;
                case 11:
                    return 1;
                case 10:
                    return 2;
                case 9:
                    return 0;
                case 8:
                    return 1;
                default:
                    Console.WriteLine("Something went wrong with the five cent stamps");
                    return 0;
            }
        }

        public bool isPalindrome() {
            Console.WriteLine("write a word");
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length/2; i++) {
                if (input[i] != input[input.Length - 1 - i]) {
                    Console.WriteLine("That was not a palindrone");
                    return false;
                }
            }
            Console.WriteLine("This is indeed a palindrome");
            return true;
        }
    }
}
