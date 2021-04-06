using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    class CoffeeMachine : Machine, IFilter
    {
        public bool NewFilter { get ; set ; }

        public CoffeeMachine()
        {
            Content.Name = "Kaffe";
        }

        public void FilterUsed()
        {
            NewFilter = false;
        }

        public void ReplaceFilter()
        {
            NewFilter = true;
        }

        public string MakeCoffee(int cups, double cupsize)
        {
            RefillWater(cups, cupsize);
            ReplaceFilter();
            //Handful of coffee beans
            RefillContent(250);
            TurnOn();
            MakeOutput();
            FilterUsed();
            TurnOff();

            return "Kaffen er lavet";
        }
    }
}
