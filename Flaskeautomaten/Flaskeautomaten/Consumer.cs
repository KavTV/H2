using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flaskeautomaten
{
    class Consumer
    {

        public Container container { get; private set; }

        Random rnd = new Random();

        public Consumer(Container container, string name)
        {
            this.container = container;

            Thread thread = new Thread(DrinkDrinks);
            thread.Name = name;
            thread.Start();
        }

        void DrinkDrinks()
        {
            while (true)
            {
                Monitor.Enter(container.Drinks);

                while (container.Drinks.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Thread.CurrentThread.Name} venter på der kommer drinks...");
                    Monitor.Wait(container.Drinks);
                }
                //Console.WriteLine($"{Thread.CurrentThread.Name} har drukket en drink");
                for (int i = 0; i < rnd.Next(container.Drinks.Count); i++)
                {
                    //put the drink in the list to be sortet.
                    Drink selectedDrink = container.Drinks.Dequeue();
                    Console.WriteLine($"{Thread.CurrentThread.Name} har drukket en {selectedDrink.Name} med et id af {selectedDrink.Number}");
                }
                //Make 
                Monitor.Exit(container.Drinks);
                Thread.Sleep(2000);
            }
        }

    }
}
