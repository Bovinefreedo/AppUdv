using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul1
{
    public class EasyBegings
    {
        ReadNumberInput input = new ReadNumberInput();
        public EasyBegings() { }

        public int addNumbers() {
            int num1 = input.readNumber();
            int num2 = input.readNumber();
            Console.WriteLine($"The added numbers {num1} and {num2} is {num1+num2}");
             return num1+num2;  
        }

        public int addNumbers2() {
            Console.WriteLine("Write the first number:");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Write the second number:");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"The total of the two added numbers is {num1+num2}");
            return num1+num2;
        }

        public bool isEven()
        {   
            int num = input.readNumber();
            bool result = num%2==0;
            if (result)
                Console.WriteLine($"The {num} is even");
            else
                Console.WriteLine($"The {num} is not even");
            return result;

        }

        public bool isOdd() {
            int num = int.Parse(Console.ReadLine());
            bool result = num%2==1;
            if (result) Console.WriteLine("The number is odd");
            else Console.WriteLine("The number is even");
            return result;
        }

        public int addNumbersUpTo(){
            int num = input.readNumber();
            int total = 0;
            for (int i = 1; i <= num; i++) {
                total += i;
            }
            Console.WriteLine($"The total value of the numbers up to {num} is {total}");
            return total;
        }

        public double addNumbersUpTo2() {
            double num = input.readNumber();
            double total = (num+1)*num/2;
            Console.WriteLine($"The total value of the numbers up to {num} is {total}");
            return total;
        }

        public void printTriangle1(){
            for (int i = 0; i < 10; i++)
            {
                string line = "";
                for (int j = i; j < 10; j++){
                    line += "*";
                }
                Console.WriteLine(line);
            }
        }

        public void printTriangle2()
        {
            for (int i = 1; i <= 10; i++)
            {
                string line = "";
                for (int j = 0; j < i; j++)
                {
                    line += "*";
                }
                Console.WriteLine(line);
            }
        }

        public void printTriangle3()
        {
            for (int i = 1; i <= 10; i++)
            {
                string line = "";
                for (int j = 0; j < 10; j++)
                {
                    if (10 - i > j) line += " ";
                    else line += "*";
                }
                Console.WriteLine(line);
            }
        }

        public void printTriangle4()
        {
            for (int i = 1; i <= 10; i++)
            {
                string line = "";
                for (int j = 0; j < 10; j++)
                {
                    if (i > j) line += " ";
                    else line += "*";
                }
                Console.WriteLine(line);
            }
        }
    }
}
