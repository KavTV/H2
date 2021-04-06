using System;
using System.Collections.Generic;
using System.Text;

namespace VitosPizza
{
    abstract class Pizza
    {
        string name;
        List<string> stuffing;

        public string Name { get => name; set => name = value; }
        public List<string> Stuffing { get => stuffing; set => stuffing = value; }

        protected Pizza()
        {
            
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
