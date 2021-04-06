using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics;

namespace Bagagesorteringssystem
{
    public class Counter
    {
        public event EventHandler LuggageCreated;

        public string name { get; private set; }
        public int LuggageMade { get; private set; }
        private Queue<Luggage> splitter;
        private List<Flightplan> flightplans = FlightScheduler.ReadSchedules();
        static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        Random rnd = new Random();

        public Counter(string name, Splitter splitter)
        {
            this.name = name;
            this.splitter = splitter.IncomingLuggage;
        }
        public Thread Start()
        {
            //Start a thread and return it
            Thread thread = new Thread(ProduceLuggage);
            thread.Name = name;
            thread.Start();
            return thread;
        }

        void ProduceLuggage()
        {
            
            while (true)
            {
                //lock the splitters incoming luggage
                Monitor.Enter(splitter);

                Luggage newLuggage = GenerateLuggage();
                splitter.Enqueue(newLuggage);
                //Add luggage to the counter of lifetime made.
                LuggageMade++;
                Debug.WriteLine($"[{Thread.CurrentThread.Name}] [{newLuggage.flightplan.Departure}] [{LuggageMade}] Har sendt baggage til splitter");
                //Tell that luggage were made
                LuggageCreated?.Invoke(this, EventArgs.Empty);
                //Tell all waiting threads its available and exit thread
                Monitor.PulseAll(splitter);
                Monitor.Exit(splitter);
                //Make some more randomness to make the timing of all counters random
                int b = 4500;
                byte roll = RollDice((byte)b);
                Thread.Sleep(roll);
                Thread.Sleep(rnd.Next(600,1200));
            }
        }


        Luggage GenerateLuggage()
        {
            foreach (var item in flightplans.ToList())
            {
                //Remove all old departures
                if (item.Departure < DateTime.Now)
                {
                    flightplans.Remove(item);
                }
            }
            //select random flightplan (reservation)
            int planAmount = flightplans.Count - 1;
            byte roll = RollDice((byte)planAmount);
            //Return the luggage with random flightplan and an id for luggage
            return new Luggage(flightplans[roll],Guid.NewGuid());

        }

        public static byte RollDice(byte numberSides)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");

            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[1];
            do
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));
            // Return the random number mod the number
            // of sides.  The possible values are zero-
            // based, so we add one.
            return (byte)((randomNumber[0] % numberSides) + 1);
        }

        private static bool IsFairRoll(byte roll, byte numSides)
        {
            // There are MaxValue / numSides full sets of numbers that can come up
            // in a single byte.  For instance, if we have a 6 sided die, there are
            // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
            int fullSetsOfValues = Byte.MaxValue / numSides;

            // If the roll is within this range of fair values, then we let it continue.
            // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
            // < rather than <= since the = portion allows through an extra 0 value).
            // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
            // to use.
            return roll < numSides * fullSetsOfValues;
        }

    }
}
