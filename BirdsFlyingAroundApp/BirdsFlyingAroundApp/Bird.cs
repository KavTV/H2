using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    abstract class Bird
    {
        public abstract void SetLocation(double longtitude, double latitude);
        public abstract void Draw();
    }
}
