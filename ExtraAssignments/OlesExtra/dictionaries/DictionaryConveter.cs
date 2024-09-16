using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.dictionaries
{
    public class DictionaryConveter
    {
        public DictionaryConveter(){}

        public void convertDictionary(string pathOriginal, string pathCopy) { 
            List<string> words = new List<string>();
            File.ReadAllLines(pathOriginal);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            File.WriteAllLines(pathCopy, words);
        }

    }
}
