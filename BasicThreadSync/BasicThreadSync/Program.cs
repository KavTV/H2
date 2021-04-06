using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BasicThreadSync
{
    class Program
    {
        static void Main(string[] args)
        {

            //opg1
            Opg1 opg1 = new Opg1();
            Thread thread1 = new Thread(opg1.incrementCounter);
            thread1.Start();

            Thread thread2 = new Thread(opg1.decrementCounter);
            thread2.Start();

            //opg2 and 3
            Opg2 opg2 = new Opg2();
            Thread starPrinter = new Thread(opg2.startPrint);
            starPrinter.Start();

            Thread hashPrinter = new Thread(opg2.hashPrint);
            hashPrinter.Start();


            Console.Read();
        }
    }
}
