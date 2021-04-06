using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    class Penguin : Bird
    {
        public override void Draw()
        {
            Console.WriteLine(@"                        __
                     -=(o '.
                        '.-.\
                        /|  \\
                        '|  ||
                         _\_):,_");
        }

        public override void SetLocation(double longtitude, double latitude)
        {
            //Sets location
        }
    }
}
