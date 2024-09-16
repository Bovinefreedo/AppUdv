using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExtraAssignments.solutions
{
    public class SolutionDups
    {
        public SolutionDups()
        {
            
        }

        public bool SolutionArray(int[] numbers) {
            int[] seen = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++) {
                for (int j = 0; j < seen.Length; j++) {
                    if (seen[j] == numbers[i]) return true;
                    seen[j] = numbers[i];
                }
            }
            return false;
        }

        public bool SolutionArray2(int[]numbers) {
            Array.Sort(numbers);
            for(int i = 0; i < numbers.Length - 1; i++) {
                if (numbers[i] == numbers[i+1]) return true;
            }
            return false;
        }

        public bool SolutionList(int[] numbers)
        {
            List<int> seen = new List<int>();
            foreach (int n in numbers) {
                if (seen.Contains(n)) return true;
                seen.Add(n);
            }
            return false;
        }

        public bool SolutionHashMap(int[] numbers) {
            HashSet<int> seen = new HashSet<int>();
            foreach (int num in numbers)
            {
                if (seen.Contains(num)) { return true; }
                else { seen.Add(num); }
            }
            return false;
        }
    }
}
