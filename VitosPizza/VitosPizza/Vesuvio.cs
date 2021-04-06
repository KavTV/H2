using System;
using System.Collections.Generic;
using System.Text;

namespace VitosPizza
{
    class Vesuvio : Pizza
    {
        public Vesuvio() : base()
        {
            Name = "Vesuvio";
            List<string> stuffing = new List<string>();
            stuffing.Add("tomat");
            stuffing.Add("ost");
            stuffing.Add("æg");
            stuffing.Add("basilikum");
            Stuffing = stuffing;
        }
    }
}
