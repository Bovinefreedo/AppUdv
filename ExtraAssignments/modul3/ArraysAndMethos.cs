using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul3
{
    public class ArraysAndMethos
    {
        private ReadMultipleNumbers input = new ReadMultipleNumbers();

        public ArraysAndMethos() { }

        public double findAverage(int[] numbers) {

            double total = 0;

            foreach (var num in numbers)
            {
                total += num; 
            }

            double avg = total/numbers.Length;
            Console.WriteLine($"The average is: {avg}");
            return avg;
        }

        public double varians(int[] numbers) { 
            double avg = findAverage(numbers);
            double varians = 0;
            for (int i = 0; i < numbers.Length; i++) {
                varians += Math.Pow(numbers[i]-avg,2);
            }
            varians = varians/(numbers.Length-1);
            Console.WriteLine($"The varians is: {varians}");
            return varians;
        }
        
        public double standardDiviation(int[] numbers)
        {
            double stDiviation = Math.Sqrt(varians(numbers));
            Console.WriteLine($"The standard diviation is: {stDiviation}");
            return stDiviation;
        }
        //meh
        public double findAverage2(int[] numbers,int i){
            if (i < numbers.Length - 1)
            {
                double soFar = (double) numbers[i] / (double) numbers.Length + findAverage2(numbers, i + 1);
                return soFar;
            }
            else
            {
                double soFar = (double)numbers[i] / (double)numbers.Length;
                return soFar;
            }
        }
        //meh
        public double findVarians2(int[] numbers,int i, double avg){
            if (i < numbers.Length-1)
                return Math.Pow(numbers[i] - avg, 2) / (numbers.Length - 1) + findVarians2(numbers, i + 1, avg);
            else
                return Math.Pow(numbers[i] - avg, 2) / (numbers.Length - 1);
        }
        //mehh
        public double standardDiviation2(int[] numbers)
        {
            return Math.Sqrt(findVarians2(numbers, 0, findAverage2(numbers, 0)));
        }
        //not quite tail recursive
        public double findAverage3(int[] numbers, int i, double avgSoFar)
        {
            if (i == numbers.Length - 1){
                return (double)numbers[i] / (double)numbers.Length + avgSoFar; 
            }
            else{
                return findAverage3(numbers, i + 1, (double)numbers[i] / (double)numbers.Length + avgSoFar);
            }
        }

        //not quite tail recursive
        public double findVarians3(int[] numbers, int i, double avg, double varSoFar)
        {
            if (i == numbers.Length - 1) {
                return Math.Pow(numbers[i] - avg, 2) / (numbers.Length - 1) + varSoFar;
            }
            else{
                return findVarians3(numbers, i+1, avg, Math.Pow(numbers[i] - avg, 2) / (numbers.Length - 1) + varSoFar);
            }
                
        }

        // not quite tail recursive
        public double standardDiviation3(int[] numbers)
        {
            return Math.Sqrt(findVarians3(numbers, 0, findAverage3(numbers, 0, 0),0));
        }
    }
}
