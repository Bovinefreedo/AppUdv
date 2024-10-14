using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.opg4SystemDesign
{
    public class Booking
    {
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
        public bool paid { get; set; }
        public Car car { get; set; }
        public int numberOfDays { get; set; }
        public Customer customer { get; set; }

        public Booking(DateOnly startDate, DateOnly endDate, Car car, Customer customer) { 
            this.startDate = startDate;
            this.endDate = endDate;
            this.car = car;
            this.customer = customer;
            DateOnly day = startDate;
            numberOfDays = 0;
            paid = false;
            while (day <= endDate)
            {
                if (car.isBooked(day))
                {
                    throw new Exception();
                }
                else { 
                    car.bookDate(day);
                }
                day = day.AddDays(1);
                numberOfDays++;
            }
            
        }
        public double price() {
            int pricePrDay = car.category.price;
            
            int price = pricePrDay * numberOfDays;

            return price;
        }
    }
}
