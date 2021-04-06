using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flaskeautomaten
{
    class Producer
    {

        public Container container { get; private set; }
        Random rnd = new Random();

        public Producer(Container container)
        {
            this.container = container;
            Thread thread = new Thread(refillContainer);
            thread.Start();
        }

        void refillContainer()
        {
            int drinkCounter = 1;
            while (true)
            {
                Monitor.Enter(container.Drinks);

                for (int i = 0; i < rnd.Next(1, 10); i++)
                {
                    if (rnd.Next(2) == 1)
                    {
                        container.Drinks.Enqueue(new Drink("Øl", drinkCounter));
                    }
                    else
                    {
                        container.Drinks.Enqueue(new Drink("Soda", drinkCounter));
                    }
                    drinkCounter++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Der er nu {container.Drinks.Count} drinks på båndet");
                //Tell every waiting thread that this is available
                Monitor.PulseAll(container.Drinks);
                Monitor.Exit(container.Drinks);
                Thread.Sleep(rnd.Next(1000,3000));
            }
        }

    }
}
