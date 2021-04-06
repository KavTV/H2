using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BasicThreadSync
{
    class Opg2
    {

        int signs = 0;
        object _lock = new object();

        public void startPrint()
        {
            while (true)
            {
                //Make sure to lock, since we are using critical variable
                lock (_lock)
                {
                    int length = 60;
                    string toWrite = "";
                    for (int i = 0; i < length; i++)
                    {
                        toWrite += "*";
                    }
                    signs += length;
                    toWrite += " " + signs;

                    Console.WriteLine(toWrite);
                }
                Thread.Sleep(500);
            }
        }

        public void hashPrint()
        {
            while (true)
            {
                //Make sure to lock, since we are using critical variable
                lock (_lock)
                {
                    //The length of the text
                    int length = 60;
                    string toWrite = "";
                    for (int i = 0; i < length; i++)
                    {
                        //Add the same character to string x amount of times
                        toWrite += "#";
                    }
                    //increment signs with length of text
                    signs += length;
                    //Add the amount of characters in string
                    toWrite += " " + signs;

                    Console.WriteLine(toWrite);
                }
                Thread.Sleep(500);
            }
        }

    }
}
