using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.opg4SystemDesign
{
    public class Payment
    {
        public Booking booking { get; set; }
        public string paymentMethod { get; set; }
        public double price { get; set; }

        public Payment(Booking booking, string paymentMethod) { 
            this.booking = booking;
            this.paymentMethod = paymentMethod;
            this.price = booking.price();
            this.booking.paid = true; 
        }
    }
}
