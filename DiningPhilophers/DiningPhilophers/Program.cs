using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DiningPhilosophers
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Fork> forkList = new List<Fork>();
            forkList.Add(new Fork(1));
            forkList.Add(new Fork(2));
            forkList.Add(new Fork(3));
            forkList.Add(new Fork(4));
            forkList.Add(new Fork(5));

            Philosopher phil1 = new Philosopher(1,forkList[0], forkList[1]);
            Philosopher phil2 = new Philosopher(2, forkList[1], forkList[2]);
            Philosopher phil3 = new Philosopher(3, forkList[2], forkList[3]);
            Philosopher phil4 = new Philosopher(4, forkList[3], forkList[4]);
            Philosopher phil5 = new Philosopher(5, forkList[4], forkList[0]);

            Console.Read();
        }
    }
}
