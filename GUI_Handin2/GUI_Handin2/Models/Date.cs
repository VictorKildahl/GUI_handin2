using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Handin2.Models
{
    public class Date
    {
        public int DateId { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public Guest Guest { get; set; } 
    }
}
