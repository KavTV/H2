using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Container
    {

        public Queue<Drink> Drinks;

        public Container(int capacity)
        {
            Drinks = new Queue<Drink>(capacity);
        }

    }
}
