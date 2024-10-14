using ExtraAssignments.modul4;
using ExtraAssignments.modul5;
using ExtraAssignments.modul4.rollStrategies;
using ExtraAssignments.OlesExtra;
using ExtraAssignments.modul3;
using ExtraAssignments.OlesExtra.Arv;
using ExtraAssignments.modul8;
using ExtraAssignments.OlesExtra.Yatzy;
using ExtraAssignments.opg4SystemDesign;

DateOnly s1 = new DateOnly(2022, 5, 30);
DateOnly s2 = new DateOnly(2022, 5, 31);
DateOnly e1 = new DateOnly(2022, 6, 4);
DateOnly e2 = new DateOnly(2022, 7, 7);

Category aPlus = new Category("a+", 40);
Category bPlus = new Category("b+", 45);
Car toyotaCorolla = new Car("abc123", aPlus, 1997, "toyota");
Car MazdaMx = new Car("cba654", bPlus, 2002, "mazda");
Customer Frank = new Customer("Frank", "Frank@Frank.dk", "Franzy");
Customer Ole = new Customer("Ole", "lærer@Ole.net", "OLEOLEOLEOLE");
Booking b1 = new Booking(s1,e1, MazdaMx,Frank);
Console.WriteLine($"{MazdaMx.isBooked(e1)} booked by {b1.customer.name} price = {b1.price()}");