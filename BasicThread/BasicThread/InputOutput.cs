using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BasicThread
{
    class InputOutput
    {
        char ch = '*';


        public void printer()
        {
            while (true)
            {
                Console.WriteLine(ch);
                Thread.Sleep(100);
            }
        }

        public void reader()
        {
            while (true)
            {
                ch = Console.ReadKey().KeyChar;
            }
        }

    }
}
