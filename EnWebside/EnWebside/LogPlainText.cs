using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnWebside
{
    class LogPlainText : ILogger
    {
        public void LogText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
