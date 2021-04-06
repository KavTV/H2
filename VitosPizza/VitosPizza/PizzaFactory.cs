using System;
using System.Collections.Generic;
using System.Text;

namespace VitosPizza
{
    class PizzaFactory
    {
        public Pizza CreatePizza(string pizzaName)
        {
            switch (pizzaName)
            {
                case "Vesuvio": return new Vesuvio();

                case "Margarita": return new Margarita();

                case "Anchovy": return new Anchovy();

                default: return null;
                    
            }
        }
    }
}
