using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul5
{
    public class CPRNumber
    {
        public static Dictionary<string,CPRNumber> personDatabase = new Dictionary<string, CPRNumber>();
        private DateOnly _birthDay;
        private string _finalFour;

        public CPRNumber(string CPRstring) { 
            checkValidity(CPRstring);
            _birthDay = getBirthDay();
            _finalFour = CPRstring.Substring(6,4);
            personDatabase.Add(CPRstring, this);
        }

        public CPRNumber(DateOnly birthday, string lastFour) { 
        
        }
        public void checkValidity(string CPRstring)
        {
            string cpr = CPRstring;
            int fourLast = -1;
            bool isANumber = int.TryParse(_finalFour, out fourLast);
            if (cpr.Length != 10 && !isANumber && fourLast < 0 && fourLast > 9999)
            {
                throw new Exception();
            }
            else
            {
                return;
            }
        }

        public DateOnly getBirthDay() {
            return new DateOnly();
        }

        public string getCPRString()
        {
            int day = _birthDay.Day;
            string d = day.ToString();
            if (d.Length < 2)
                d = "0" + d;

            int month = _birthDay.Month;
            string m = month.ToString();
            if (m.Length < 2)
                m = "0" + m;

            int year = _birthDay.Year % 100;
            string y = year.ToString();

            string cpr = d + m + y + _finalFour;

            return cpr;
        }
    }
}
