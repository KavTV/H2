using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Bagagesorteringssystem
{
    public class Simulation
    {
        public event EventHandler PlaneWaiting;
        public event EventHandler PlaneDepartured;
        public event EventHandler LuggageCreated;
        public event EventHandler LuggageSent;

        public List<Counter> counters = new List<Counter>();
        public List<Terminal> terminals = new List<Terminal>();
        public List<Thread> threads = new List<Thread>();
        public Splitter splitter;

        public Simulation()
        {
            splitter = new Splitter(terminals);
            splitter.LuggageSent += Splitter_LuggageSent;
        }



        public void StartSimulation(int counterAmount)
        {
            //Add terminals with their destination
            terminals.Add(new Terminal("Terminal1", "CPH"));
            terminals.Add(new Terminal("Terminal2", "STO"));
            terminals.Add(new Terminal("Terminal3", "LDN"));


            FlightScheduler scheduler = new FlightScheduler(terminals);
            scheduler.CreateSchedules();

            //Add amount of counters requested
            for (int i = 1; i <= counterAmount; i++)
            {
                counters.Add(new Counter("Counter" + i, splitter));
            }

            //Start threads and add them to thread list
            foreach (var item in counters)
            {
                threads.Add(item.Start());
                //Subscribe to event
                item.LuggageCreated += Counter_LuggageCreated;
            }
            //Start terminal threads, and subscribe to event
            foreach (var item in terminals)
            {
                threads.Add(item.Start());
                item.PlaneDepartured += Item_PlaneDepartured;
                item.PlaneWaiting += Item_PlaneWaiting;
            }
        }

        private void Counter_LuggageCreated(object sender, EventArgs e)
        {
            LuggageCreated?.Invoke(sender, e);
        }
        private void Splitter_LuggageSent(object sender, EventArgs e)
        {
            LuggageSent?.Invoke(this, e);
        }
        private void Item_PlaneWaiting(object sender, EventArgs e)
        {
            PlaneWaiting?.Invoke(sender, e);
        }

        private void Item_PlaneDepartured(object sender, EventArgs e)
        {
            Debug.WriteLine($"flyet er lettet fra {((Terminal)sender).name}");
            PlaneDepartured?.Invoke(sender, e);
        }


        public void AddCounter()
        {
            Counter counter = new Counter("Counter" + counters.Count + 1, splitter);
            counters.Add(counter);
        }

        public void StopThread(int threadNumber)
        {
            Console.WriteLine($"{threads[threadNumber].Name} fjernet");
            threads[threadNumber].Abort();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="counterNumber"></param>
        /// <returns>true if counter is resumed, false if counter is suspended</returns>
        public bool StartStopCounter(int counterNumber)
        {
            //Find a thread with the name counter and the number assigned to counter.
            var foundThread = threads.Where(x => x.Name == "Counter" + counterNumber).First();
            //if the thread is suspended, then resume it and if not, then suspend
            if (foundThread.ThreadState == System.Threading.ThreadState.Suspended)
            {
                foundThread.Resume();
                return true;
            }
            else
            {
                foundThread.Suspend();
                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="terminalNumber"></param>
        /// <returns>true if terminal resumed, false if terminal suspended</returns>
        public bool StartStopTerminal(int terminalNumber)
        {
            //Find a thread with the name terminal and the number assigned to counter.
            var foundThread = threads.Where(x => x.Name == "Terminal" + terminalNumber).First();
            //if the thread is suspended, then resume it and if not, then suspend
            if (foundThread.ThreadState == System.Threading.ThreadState.Suspended)
            {
                foundThread.Resume();
                Console.WriteLine($"[{foundThread.Name}] er åbnet");
                return true;
            }
            else
            {
                foundThread.Suspend();
                Console.WriteLine($"[{foundThread.Name}] er lukket");
                return false;
            }
        }

    }
}
