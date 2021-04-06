using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine c = new CoffeeMachine();
            Console.WriteLine(c.MakeCoffee(2,250));

            TeaMachine t = new TeaMachine();
            Console.WriteLine(t.MakeTea(4,200));

            EspressoMachine e = new EspressoMachine();
            Console.WriteLine(e.MakeEspresso(200));
        }
    }
}
