using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Blackbird b = new Blackbird();
            b.Draw();

            Penguin p = new Penguin();
            p.Draw();
        }
    }
}
