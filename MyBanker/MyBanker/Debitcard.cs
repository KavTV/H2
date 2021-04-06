using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Debitcard : Card
    {
        public Debitcard(string name)
        {
            AutoGenerate(name, "2400");
        }
    }
}
