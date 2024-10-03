using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.OlesExtra.Arv
{
    public class Project
    {
        public int _payment { get; set; }
        public DateOnly _start { get; set; } 
        public DateOnly _end { get; set; }

        public Project(int payment, DateOnly start, DateOnly end) {
            _payment = payment;
            _start = start;
            _end = end;
        }
    }
}
