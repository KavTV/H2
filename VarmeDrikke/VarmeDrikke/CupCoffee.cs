using System;
using System.Collections.Generic;
using System.Text;

namespace VarmeDrikke
{
    class CupCoffee : HotDrink
    {

        public CupCoffee()
        {
            //Makes a cup of coffee when CupCoffe is instantiated
            BoilWater();
            Brew();
            Pour();
            AddMilkAndSugar();
        }

        protected override void Brew()
        {
            Console.WriteLine("Brygger kaffe...");
        }

        protected override void Pour()
        {
            Console.WriteLine("Hælder kaffen i koppen...");
        }
        protected void AddMilkAndSugar()
        {
            Console.WriteLine("Tilføjer mælk og sukker...");
        }
        
    }
}
