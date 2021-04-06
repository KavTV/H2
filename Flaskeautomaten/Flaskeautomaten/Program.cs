using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the containers/conveyer belts
            Container producedDrinks = new Container(15);
            Container beer = new Container(30);
            Container soda = new Container(30);

            Producer producer = new Producer(producedDrinks);
            Splitter splitter = new Splitter(producedDrinks,beer,soda);
            Consumer beerConsumer = new Consumer(beer, "Beer Consumer");
            Consumer sodaConsumer = new Consumer(soda, "Soda Consumer");



            Console.Read();
        }
    }
}
