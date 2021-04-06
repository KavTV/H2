using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Flightplan
    {
        public string Dest { get; private set; }
        public DateTime Departure { get; private set; }
        public Terminal Terminal { get; private set; }
        public int passengerAmount { get; set; }

        public Flightplan(string dest, DateTime departure, Terminal terminal)
        {
            this.Dest = dest;
            this.Departure = departure;
            this.Terminal = terminal;
            passengerAmount = 0;
        }


    }
}
