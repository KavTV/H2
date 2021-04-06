using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BasicThread
{
    class Working
    {

        int temp = 20;

        public void sayHello()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine("Hello!");
        }
        public void sayEasy()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
            }
        }
        public void sayMore()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde...");
                Thread.Sleep(1000);
            }
        }


        public void RandomTemp()
        {
            Random rnd = new Random();

            while (true)
            {
                temp = rnd.Next(-20, 120);
                Console.WriteLine(temp);
                Thread.Sleep(2000);
            }

        }

        public void TempAlarm()
        {
            int alarmtimes = 0;

            while (alarmtimes < 3)
            {
                if (temp < 0 || temp > 100)
                {
                    alarmtimes++;
                    Console.WriteLine("Der er gået en alarm");
                }
                Thread.Sleep(2000);
            }
        }

    }
}
