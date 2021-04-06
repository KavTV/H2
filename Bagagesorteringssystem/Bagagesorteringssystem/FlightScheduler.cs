using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Bagagesorteringssystem
{
    public class FlightScheduler
    {
        static List<Terminal> terminals = new List<Terminal>();
        static string fileLocation = "FlightSchedule.txt";
        Random rnd = new Random();

        public FlightScheduler(List<Terminal> terminals)
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation);
            }
            else
            {
                //empty file
                File.WriteAllText(fileLocation, "");
            }

            FlightScheduler.terminals = terminals;
        }

        public void CreateSchedules()
        {
            foreach (var item in terminals)
            {
                //make 30 flights for every terminal
                for (int i = 1; i <= 30; i++)
                {
                    //Make a flight with random times 
                    WriteToSchedules(new Flightplan(item.Destination, DateTime.Now.AddSeconds(rnd.Next(10, 21) * i), item));
                }
            }
        }

        void WriteToSchedules(Flightplan plan)
        {
            //FileStream fs = new FileStream(fileLocation, FileMode.Open);

            StreamWriter sw = File.AppendText(fileLocation);

            //Write to file, and seperate with ;
            sw.WriteLine($"{plan.Terminal.name};{plan.Departure};{plan.Dest}");

            sw.Close();
        }

        public static List<Flightplan> ReadTerminalSchedules(Terminal terminal)
        {
            //Wait for the file to be ready
            while (!Monitor.TryEnter(fileLocation))
            {
                Thread.Sleep(100);
            }

            List<Flightplan> plan = new List<Flightplan>();
            FileStream fs = new FileStream(fileLocation, FileMode.Open);

            var reader = new StreamReader(fs);

            //Read textfile
            while (!reader.EndOfStream)
            {
                //the line is seperated with ;
                string[] read = reader.ReadLine().Split(';');
                //Only add to list if the plan is for the right terminal
                if (read[0] == terminal.name)
                {
                    plan.Add(new Flightplan(read[2], DateTime.Parse(read[1]), terminal));
                }

            }
            reader.Close();
            //tell everyone waiting its available
            Monitor.PulseAll(fileLocation);
            Monitor.Exit(fileLocation);
            //order lidt by departure
            plan.OrderBy(x => x.Departure);
            return plan;
        }

        public static List<Flightplan> ReadSchedules()
        {
            //Wait for the file to be ready
            while (!Monitor.TryEnter(fileLocation))
            {
                Monitor.Wait(fileLocation);
            }

            List<Flightplan> plan = new List<Flightplan>();
            FileStream fs = new FileStream(fileLocation, FileMode.Open);

            var reader = new StreamReader(fs);

            //Read textfile
            while (!reader.EndOfStream)
            {
                //the line is seperated with ;
                string[] read = reader.ReadLine().Split(';');

                plan.Add(new Flightplan(read[2], DateTime.Parse(read[1]),terminals.Where(x => x.name == read[0]).First()));

            }
            reader.Close();
            //tell everyone waiting its available
            Monitor.PulseAll(fileLocation);
            Monitor.Exit(fileLocation);
            return plan;
        }

    }
}
