using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    class TeaMachine : Machine, IFilter
    {
        public bool NewFilter { get; set; }

        public TeaMachine()
        {
            Content.Name = "The";
        }

        public void FilterUsed()
        {
            NewFilter = false;
        }


        public void ReplaceFilter()
        {
            NewFilter = true;
        }
        public string MakeTea(int cups, double cupsize)
        {
            RefillWater(cups, cupsize);
            ReplaceFilter();
            RefillContent(250);
            TurnOn();
            MakeOutput();
            FilterUsed();
            TurnOff();
            return $"Der er nu lavet {Output}ml {Content.Name}";
        }

    }
}
