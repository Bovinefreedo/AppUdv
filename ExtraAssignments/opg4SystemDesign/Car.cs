using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.opg4SystemDesign
{
    public class Car
    {
        public string numberPlate {  get; set; }
        public Category category { get; set; }
        public int year { get; set; }
        public string make {  get; set; }
        public HashSet<DateOnly> bookingCalender { get; set; }

        public Car(string numberPlate, Category category, int year, string make) { 
            this.numberPlate = numberPlate;
            this.category = category;
            this.year = year;
            this.make = make;
            this.bookingCalender = new HashSet<DateOnly>();
        }

        public void bookDate(DateOnly date) { 
            bookingCalender.Add(date);
        }

        public bool isBooked(DateOnly date) { 
            return bookingCalender.Contains(date);
        }

    }
}
