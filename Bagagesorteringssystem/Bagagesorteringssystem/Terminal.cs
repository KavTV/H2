using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Bagagesorteringssystem
{
    public class Terminal
    {
        public event EventHandler PlaneWaiting;
        public event EventHandler PlaneDepartured;

        public string Destination { get; private set; }
        public Queue<Luggage> IncomingLuggage { get; private set; }
        public List<Flightplan> flightplan { get; private set; }
        public bool IsFlying { get; private set; }
        public string name { get; private set; }
        Random rnd = new Random();

        public Terminal(string name, string dest)
        {
            this.name = name;
            this.Destination = dest;
            //Set capacity
            IncomingLuggage = new Queue<Luggage>(50);
            //Get the list with schedules for current terminal
            flightplan = FlightScheduler.ReadTerminalSchedules(this).OrderBy(x => x.Departure).ToList();
        }

        public Thread Start()
        {
            //Start a thread and return it
            Thread thread = new Thread(SendLuggage);
            thread.Name = name;
            thread.Start();
            //thread.Join();
            return thread;
        }

        void SendLuggage()
        {
            while (true)
            {
                //Monitor.Enter(IncomingLuggage);

                //while (IncomingLuggage.Count == 0)
                //    Monitor.Wait(IncomingLuggage);

                //get the plan for the current terminal


                foreach (var plan in flightplan)
                {
                    //make sure that the departure have not past the time now
                    if (plan.Departure > DateTime.Now)
                    {
                        Debug.WriteLine($"{Thread.CurrentThread.Name} venter på næste flyafgang [{plan.Departure}]");

                        IsFlying = false;

                        //Wait for the flight to be ready.
                        while (plan.Departure > DateTime.Now)
                        {
                            Thread.Sleep(100);
                        }
                        PlaneWaiting?.Invoke(this, EventArgs.Empty);
                        //Flight is ready, begin taking the luggage with departure closest to now.
                        List<Luggage> luggageList = new List<Luggage>();

                        Monitor.Enter(IncomingLuggage);

                        //Take all luggage from queue into a list we can sort
                        for (int i = IncomingLuggage.Count; 0 < i; i--)
                        {
                            luggageList.Add(IncomingLuggage.Dequeue());
                        }
                        //sort list by earliest departure time
                        luggageList = luggageList.OrderBy(x => x.flightplan.Departure).ToList();

                        int count = 0;
                        foreach (var item in luggageList.ToList())
                        {
                            //Removes the first 30 and sends them on a plane.
                            if (count < 30)
                            {
                                luggageList.Remove(item);
                                Debug.WriteLine($"[{Thread.CurrentThread.Name}] flyet [{plan.Departure}] bagagens tidsplan [{item.flightplan.Departure}] Bagage sendt på flyet til {Destination}");
                                count++;
                            }
                        }

                        //Flyet letter her
                        IsFlying = true;
                        PlaneDepartured?.Invoke(this, new PlaneEventArgs(plan, count));

                        //Add the luggage that did not come with flight back to the queue
                        foreach (var item in luggageList)
                        {
                            IncomingLuggage.Enqueue(item);
                        }
                        Debug.WriteLine("Bagage tilbage: " + IncomingLuggage.Count);
                        Monitor.Exit(IncomingLuggage);
                        Thread.Sleep(1000);
                    }
                }
            }
        }


    }
}
