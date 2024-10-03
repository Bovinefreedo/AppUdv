using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul5
{
    public class Person
    {
        public string _name { get; set; } = "No name";
        public string _address { get; set; } = "No address";
        public string _city { get; set; } = "No-city";
        public int _postcode { get; set; } = 0;
        public double _height { get; set; }
        public double _weight { get; set; }
        public DateOnly _birthday { get; }
        public string _gender { get; set; }

        public Person (DateOnly birthday, double weight, double height, string name, string address, int postcode) { 
            _birthday = birthday;
            _weight = weight;
            _height = height;
            _name = name;
            _address = address;
            _postcode = postcode;
        }

        public override string ToString()
        {
            return $"name: {_name}, birthday: {_birthday}, address: {_address}, {_postcode}, {_city}, height: {_height} cm, weight: {_weight} kg";
        }

        public double calculateBMI() {
            return _weight / (Math.Pow(_height/100,2));
        }

        public bool isTeenager()
        {
            DateOnly twentyYearOld = DateOnly.FromDateTime(DateTime.Now).AddYears(-20);
            DateOnly thirteenYearOld = DateOnly.FromDateTime(DateTime.Now).AddYears(-13);
            if (_birthday >= thirteenYearOld && _birthday < twentyYearOld) 
                return true;
            else 
                return false;
        }

        public bool isBoomer()
        {
            DateOnly fortySix = new DateOnly(1946, 1, 1);
            DateOnly sixtyFour = new DateOnly(1964, 12, 31);
            if (_birthday >= fortySix && _birthday <= sixtyFour)
                return true;
            else
                return false;
            
        }
    }
}
