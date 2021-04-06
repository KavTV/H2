using System;
using System.Threading;

namespace BasicThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Working working = new Working();

            //Thread thread1 = new Thread(working.sayEasy);
            //thread1.Name = "thread1";
            //thread1.Start();

            //Thread thread2 = new Thread(working.sayMore);
            //thread2.Name = "thread2";
            //thread2.Start();

            //opg3
            //Thread randomThread = new Thread(working.RandomTemp);
            //randomThread.Name = "randomThread";
            //randomThread.Start();

            //Thread alarmThread = new Thread(working.TempAlarm);
            //alarmThread.Name = "alarmThread";
            //alarmThread.Start();

            //while (true)
            //{
            //    if (!alarmThread.IsAlive)
            //    {
            //        Console.WriteLine("Alarm tråd termineret!");

            //        Thread.CurrentThread.Abort();
            //    }

            //    Thread.Sleep(10000);
            //}

            InputOutput inputOutput = new InputOutput();
            Thread printer = new Thread(inputOutput.printer);
            printer.Start();
            

            Thread reader = new Thread(inputOutput.reader);
            reader.Start();
            //Makes sure that main thread does not stop before this thread.
            reader.Join();

            
        }


        
    }
}
