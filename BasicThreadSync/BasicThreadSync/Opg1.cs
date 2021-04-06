using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThreadSync
{
    class Opg1
    {

        int counter = 0;
        object _lock = new object();

        public void incrementCounter()
        {
            while (true)
            {
                //Lock counter and make sure noone is using it
                Monitor.Enter(_lock);
                try
                {
                    counter += 2;
                }
                finally
                {
                    Monitor.Exit(_lock);
                    Thread.Sleep(1000);
                }
            }
        }

        public void decrementCounter()
        {
            while (true)
            {
                Monitor.Enter(_lock);
                try
                {
                    counter--;
                    Console.WriteLine(counter);
                }
                finally
                {
                    Monitor.Exit(_lock);
                    Thread.Sleep(1000);
                }
            }
        }


    }
}
