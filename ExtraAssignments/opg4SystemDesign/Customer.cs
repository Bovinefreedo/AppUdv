using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.opg4SystemDesign
{
    public class Customer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string userName { get; set; }

        public Customer(string name, string email, string userName) {
            this.name = name;
            this.email = email;
            this.userName = userName;
        }
    }
}
