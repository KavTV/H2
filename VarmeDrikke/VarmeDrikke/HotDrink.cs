using System;
using System.Collections.Generic;
using System.Text;

namespace VarmeDrikke
{
    abstract class HotDrink
    {

        protected  void BoilWater()
        {
            Console.WriteLine("Koger vand");
        }
        protected abstract void Brew();
        protected abstract void Pour();
    }
}
