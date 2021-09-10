using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assessmenttest.Models
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime datetime { get; set; }

        public string venue { get; set; }

        public int numtickets { get; set; }

        public Double amount { get; set; }

        public string currency { get; set; }

    }
}
