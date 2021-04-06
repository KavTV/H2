using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    class EspressoMachine : Machine, IFilter
    {
        public bool NewFilter { get; set; }

        public EspressoMachine()
        {
            Content.Name = "coffee beans";
        }
        public void FilterUsed()
        {
            NewFilter = false;
        }

        public void ReplaceFilter()
        {
            NewFilter = true;
        }
        public override void RefillWater(int cups, double cupsize)
        {
            //Uses code from machine but makes only 1 cup no matter what.
            base.RefillWater(1, cupsize);
        }
        public string MakeEspresso(double cupsize)
        {
            RefillWater(1, cupsize);
            ReplaceFilter();
            //Handful of coffee beans
            RefillContent(250);
            TurnOn();
            MakeOutput();
            FilterUsed();
            TurnOff();

            return "Espresso er lavet";
        }
    }
}
