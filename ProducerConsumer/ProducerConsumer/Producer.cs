using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProducerConsumer
{
    class Producer
    {
        Queue<Cookie> cookieHolder = new Queue<Cookie>();
        Random rnd = new Random();

        public Producer()
        {
            //Start thread when producer instantiated
            Thread producerThread = new Thread(Refill);
            Thread consumerThread = new Thread(GetCookie);
            Thread consumerThread2 = new Thread(GetCookie);
            Thread consumerThread3 = new Thread(GetCookie);

            producerThread.Start();
            consumerThread.Start();
            consumerThread.Name = "tråd 1";
            consumerThread.Priority = ThreadPriority.Highest;
            consumerThread2.Start();
            consumerThread2.Name = "tråd 2";
            consumerThread3.Start();
            consumerThread3.Name = "tråd 3";
        }

        void Refill()
        {
            //producer
            while (true)
            {
                Monitor.Enter(cookieHolder);
                //Fill cookies depending on the random number
                for (int i = 0; i < rnd.Next(1, 5); i++)
                {
                    cookieHolder.Enqueue(new Cookie());
                }
                Console.WriteLine($"har produceret {cookieHolder.Count} cookies");
                //Tell all waiting to access cookieholder that it is available
                Monitor.PulseAll(cookieHolder);
                Monitor.Exit(cookieHolder);
                Thread.Sleep(1000);
            }
        }

        void GetCookie()
        {
            //Consumer
            while (true)
            {

                Monitor.Enter(cookieHolder);
                //If there is no cookies available, then wait for more
                while (cookieHolder.Count == 0)
                {
                    Console.WriteLine("Venter på flere cookies");
                    Monitor.Wait(cookieHolder);
                }
                Console.WriteLine($"Du har fået en cookie af {Thread.CurrentThread.Name}, der er {cookieHolder.Count} tilbage");
                cookieHolder.Dequeue();
                Thread.Sleep(1000);
            }
        }

    }
}
