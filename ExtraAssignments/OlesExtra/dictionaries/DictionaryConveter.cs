using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.dictionaries
{
    public class DictionaryConverter
    {
        public DictionaryConverter(){}

        public void convertDictionary(string pathOriginal, string pathCopy) { 
            List<string> words = new List<string>();
            File.ReadAllLines(pathOriginal);

            foreach (string word in words)
            {
                Console.WriteLine(word);
                Console.WriteLine(word);
            }
            Console.WriteLine(words);
            File.WriteAllLines(pathCopy, words);
        }

    }
}
