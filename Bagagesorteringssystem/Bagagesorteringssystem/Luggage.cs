using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Luggage
    {
        //public string Destination { get; private set; }
        public Flightplan flightplan { get; private set; }
        public Guid Id { get; private set; }
        public Luggage(Flightplan plan, Guid guid)
        {
            this.flightplan = plan;
            this.Id = guid;
        }
    }
}
