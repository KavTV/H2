using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            Mastercard m = new Mastercard("kasper");
            m.Pay(4000);
            m.Pay(2000);
            if (m.Withdraw(4000) && m.Validate(4000))
            {
                Console.WriteLine("Du har hævet pengene");
            }
            if (m.Withdraw(1001) && m.Validate(1001))
            {
                Console.WriteLine("du har hævet flere penge");
            }
            else
            {
                Console.WriteLine("Du har hævet maks for idag eller måneden");
            }

            Debitcard d = new Debitcard("kasp");
            bool j = d.Validate(5000);
        }
    }
}
