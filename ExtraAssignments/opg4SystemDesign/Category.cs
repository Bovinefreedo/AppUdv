using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.opg4SystemDesign
{
    public class Category
    {
        public string name { get; set; }
        public int price { get; set; }

        public Category(string name, int price) { 
            this.name = name;
            this.price = price;
        }
    }
}
