using System;
using System.Collections.Generic;
using System.Text;

namespace VitosPizza
{
    class Anchovy : Pizza
    {
        public Anchovy() : base()
        {
            Name = "Anchovy";
            List<string> stuffing = new List<string>();
            stuffing.Add("tomat");
            stuffing.Add("ost");
            stuffing.Add("rødløg");
            stuffing.Add("basilikum");
            stuffing.Add("anjoser");
            Stuffing = stuffing;
        }
    }
}
