using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class PlaneEventArgs : EventArgs
    {
        public Flightplan Flightplan { get; private set; }

        public PlaneEventArgs(Flightplan plan, int passAmount)
        {
            this.Flightplan = plan;
            //Update the flightplan with amount of passengers
            this.Flightplan.passengerAmount = passAmount;
        }
    }
}
