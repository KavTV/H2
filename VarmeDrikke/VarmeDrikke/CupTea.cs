using System;
using System.Collections.Generic;
using System.Text;

namespace VarmeDrikke
{
    class CupTea : HotDrink
    {
        public CupTea()
        {
            //Makes the tea when a cup of tea is instantiated
            BoilWater();
            Brew();
            Pour();
            AddLemon();
            Console.WriteLine("din the er klar");
        }
        protected override void Brew()
        {
            Console.WriteLine("Brygger the");
        }

        protected override void Pour()
        {
            Console.WriteLine("Hælder the i koppen");
        }
        protected void AddLemon()
        {
            Console.WriteLine("Tilføjer et skvæt citron");
        }
    }
}
