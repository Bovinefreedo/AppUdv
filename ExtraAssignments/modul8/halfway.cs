using ExtraAssignments.OlesExtra.Arv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.modul8
{
    public class Halfway
    {
        private List<Item> items = new();
        public Halfway() {
            items.Add(new Item("cup", 20, 50, "blue"));
            items.Add(new Item("earphone", 200, 10, "black"));
            items.Add(new Item("gloves", 100, 5, "red"));
            items.Add(new Item("bag", 600, 12, "orange"));
            items.Add(new Item("jacket", 600, 12, "black"));
            items.Add(new Item("cup", 20, 2, "black"));
            items.Add(new Item("Fararri", 2000000, 0, "red"));
        }

        public List<Item> ItemsInStock()
        {
            List<Item> inStock = new ();
            foreach (Item item in items)
            {
                if (item.Stock > 0)
                    inStock.Add(item);
            }
            return inStock;
        }

        public void printNamePrice() {
            foreach (Item item in items) {
                Console.WriteLine($"{item.Name} costs: {item.Price}");
            }
        }


        public void printAList()
        {
            foreach(Item item in items)
            {
                Console.WriteLine($"{item.Color} {item.Name} costs {item.Price}, there are {item.Stock} in stock");
            }
        }
    }
}
