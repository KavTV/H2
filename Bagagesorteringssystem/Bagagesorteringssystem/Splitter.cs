using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Bagagesorteringssystem
{
    public class Splitter
    {
        public event EventHandler LuggageSent;
        public Queue<Luggage> IncomingLuggage { get; private set; }

        List<Terminal> terminals;
        Random rnd = new Random();

        public Splitter(List<Terminal> terminals)
        {
            IncomingLuggage = new Queue<Luggage>();
            this.terminals = terminals;
            //Start thread with splitter
            Thread thread = new Thread(GetLuggage);
            //Splitter gets highest priority 
            thread.Priority = ThreadPriority.Highest;
            thread.Name = "Splitter";
            thread.Start();
        }

        void GetLuggage()
        {
            while (true)
            {
                Monitor.Enter(IncomingLuggage);
                while (IncomingLuggage.Count == 0)
                {
                    //Wait for luggage to come in, and immediately send it out
                    Monitor.Wait(IncomingLuggage);
                }
                LuggageSent?.Invoke(this, EventArgs.Empty);

                for (int i = 0; i < rnd.Next(0, IncomingLuggage.Count); i++)
                {
                    SplitLuggage(IncomingLuggage.Dequeue());
                }



                Monitor.Exit(IncomingLuggage);

                Thread.Sleep(rnd.Next(100, 300));
            }
        }

        void SplitLuggage(Luggage luggage)
        {
            foreach (var item in terminals)
            {
                //Find the terminal with matching terminal
                if (item == luggage.flightplan.Terminal)
                {
                    Monitor.Enter(item.IncomingLuggage);

                    item.IncomingLuggage.Enqueue(luggage);
                    Debug.WriteLine($"[{Thread.CurrentThread.Name}] Har sendt en bagage afsted til {item.name}");

                    Monitor.PulseAll(item.IncomingLuggage);
                    Monitor.Exit(item.IncomingLuggage);
                }
            }
        }

    }
}
