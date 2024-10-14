using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul8
{
     public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }

        public Item(string name, double price, int stock, string color)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Color = color;
        }
    }
}
