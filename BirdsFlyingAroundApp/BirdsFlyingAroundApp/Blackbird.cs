using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    class Blackbird : Bird, IFly
    {
        public override void Draw()
        {
            //Draw bird
            Console.WriteLine(@"   \\
   (o >
\\_//)
 \_ / _)
  _ | _");
        }

        public void SetAltitude(double altitude)
        {
            //Set altitude
        }

        public override void SetLocation(double longtitude, double latitude)
        {
            //Set location
        }
    }
}
