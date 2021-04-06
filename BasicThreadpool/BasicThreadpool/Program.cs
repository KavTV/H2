using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace BasicThreadpool
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("ThreadPool Execution");

            mywatch.Start();

            ProcessWithThreadPoolMethod();

            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());


            Console.Read();
        }

        public static void Process(object callback)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            //Makes it take a little longer
            for (int i = 0; i < 100000; i++)
            {
                //This takes muuuuch longer for the thread, not the thread pool
                for (int j = 0; j < 100000; j++)
                {
                }
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Name = "nonpool";
                obj.Priority = ThreadPriority.Highest;
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        public static void task1(object callback)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }
        public void task2(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }
    }
}
