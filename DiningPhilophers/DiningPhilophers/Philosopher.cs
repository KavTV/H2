using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public class Philosopher
    {

        int number;

        Fork leftFork { get; set; }
        Fork rightFork { get; set; }

        public Philosopher(int number, Fork leftFork, Fork rightFork)
        {
            this.number = number;
            this.leftFork = leftFork;
            this.rightFork = rightFork;
            start();
        }

        void start()
        {
            Thread phil = new Thread(StartDining);
            phil.Start();
        }

        void StartDining()
        {
            while (true)
            {
                TakeForks();
            }
        }

        public void TakeForks()
        {
            if (Monitor.TryEnter(leftFork) || Monitor.TryEnter(rightFork))
            {
                try
                {
                    if (Monitor.IsEntered(leftFork))
                        grabFork(rightFork);
                    if (Monitor.IsEntered(rightFork))
                        grabFork(leftFork);
                }
                finally
                {
                    Console.WriteLine($"Philosopher {number} has let go of fork {leftFork.Id} and fork {rightFork.Id}");
                }
            }
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(2000));
        }

        void grabFork(Fork equipFork)
        {
            Random rnd = new Random();
            int tries = rnd.Next(10);
            Console.WriteLine($"philosoph {number} is trying to grab fork{equipFork.Id}, {tries} times");

            int counter = 0;

            while (counter < tries)
            {
                if (Monitor.TryEnter(equipFork))
                {
                    Console.WriteLine($"Philosopher {number} took fork {equipFork.Id}");
                    try
                    {
                        //Eat for a random amount of time
                        Eat();
                        Thread.Sleep(rnd.Next(3000));
                        break;
                    }
                    finally
                    {
                        Console.WriteLine($"Philosopher {number} let go of fork{equipFork.Id}");
                    }
                }
                else
                {
                    Console.WriteLine($"Philosopher {number} could not get fork {equipFork.Id}");
                }

                counter++;
                Thread.Sleep(2000);
            }
        }

        void Eat()
        {
            Console.WriteLine($"Philosopther {number} is eating with left fork{leftFork.Id} and right fork{rightFork.Id}");
        }

    }
}
