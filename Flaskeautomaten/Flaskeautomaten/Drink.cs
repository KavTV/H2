using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Drink
    {
        public string Name { get; private set; }
        public int Number { get; private set; }

        public Drink(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

    }
}
