using System;
using System.Collections.Generic;
using System.Text;

namespace VitosPizza
{
    class Margarita : Pizza
    {
        public Margarita() : base()
        {
            Name = "Margarita";
            List<string> stuffing = new List<string>();
            stuffing.Add("tomat");
            stuffing.Add("ost");
            stuffing.Add("oregano");
            Stuffing = stuffing;
        }
    }
}
