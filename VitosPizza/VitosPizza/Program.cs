using System;

namespace VitosPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new PizzaFactory().CreatePizza("Margarita").ToString());
        }
    }
}
