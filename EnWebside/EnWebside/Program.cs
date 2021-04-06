using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnWebside
{
    class Program
    {

        static void Main(string[] args)
        {
            LogPlainText logger = new LogPlainText();

            WebHandler wh = new WebHandler();
            logger.LogText("Skriv hjemmeside (https://www.google.com)");
            //Get user input
            string website = Console.ReadLine();
            //Write webcontent in console
            logger.LogText(wh.GetWebContent(wh, wh, website));

            FileHandler fh = new FileHandler();
            //Get text from file
            string fileText = fh.MakeRequest(@"C:\jatak.txt");
            logger.LogText(fileText);

        }

        
    }
}
