using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul5
{
    public class Person
    {
        private string _gender;
        private DateOnly _birthday;
        private string _name;
        private double _height;
        private double _age;
        private double _wheight;

        public Person (string gender, DateOnly birthday, string name, double height, double age, double wheight)
        {
            _gender = gender;
            _birthday = birthday;
            _name = name;
            _height = height;
            _age = age;
            _wheight = wheight;
        }
    }
}
