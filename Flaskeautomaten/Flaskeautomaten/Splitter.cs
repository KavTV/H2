using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Flaskeautomaten
{
    class Splitter
    {

        public Container ProduceContainer { get; private set; }
        public Container BeerContainer { get; private set; }
        public Container SodaContainer { get; private set; }

        private Queue<Drink> takenDrinks = new Queue<Drink>();
        Random rnd = new Random();

        public Splitter(Container produceContainer, Container beerContainer, Container sodaContainer)
        {
            this.ProduceContainer = produceContainer;
            this.BeerContainer = beerContainer;
            this.SodaContainer = sodaContainer;
            //This takes the drinks from conveyer belt
            Thread thread = new Thread(GetDrinks);
            //This thread is responsable for taking drinks taken from producer and put them in the right container
            Thread thread2 = new Thread(SplitDrinks);

            thread.Name = "TakeProduced";
            thread2.Name = "SplitDrinks";
            thread.Start();
            thread2.Start();
        }

        void GetDrinks()
        {
            //Assigned to a thread that takes drinks from a belt and puts it in a list that gets splitted.
            while (true)
            {
                Monitor.Enter(ProduceContainer.Drinks);

                while (ProduceContainer.Drinks.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Splitter waiting for drinks to refill...");
                    Monitor.Wait(ProduceContainer.Drinks);
                }
                //Takes a random amount of drinks from producer and put them in a list that another thread will sort.
                Monitor.Enter(takenDrinks);
                for (int i = 0; i < rnd.Next(ProduceContainer.Drinks.Count); i++)
                {
                    //put the drink in the list to be sorted.
                    takenDrinks.Enqueue(ProduceContainer.Drinks.Dequeue());
                }
                Console.WriteLine($"{Thread.CurrentThread.Name} har taget {takenDrinks.Count} drinks!");
                Monitor.Exit(takenDrinks);

                Monitor.Exit(ProduceContainer.Drinks);
                Thread.Sleep(2000);
            }
        }
        void SplitDrinks()
        {
            while (true)
            {
                if (takenDrinks.Count != 0)
                {
                    //take a drink from the queue and put it in the right container
                    Drink selectedDrink = takenDrinks.Dequeue();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{selectedDrink.Name} bliver sendt til automat");
                    if (selectedDrink.Name == "Øl")
                    {
                        Monitor.Enter(BeerContainer.Drinks);
                        BeerContainer.Drinks.Enqueue(selectedDrink);
                        Monitor.PulseAll(BeerContainer.Drinks);
                        Monitor.Exit(BeerContainer.Drinks);
                    }
                    else
                    {
                        Monitor.Enter(SodaContainer.Drinks);
                        SodaContainer.Drinks.Enqueue(selectedDrink);
                        Monitor.PulseAll(SodaContainer.Drinks);
                        Monitor.Exit(SodaContainer.Drinks);
                    }
                }
                Thread.Sleep(100);
            }
        }

    }
}
