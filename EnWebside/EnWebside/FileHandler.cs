using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnWebside
{
    class FileHandler : IRequest<string, string>
    {
        public string MakeRequest(string website)
        {
            return File.ReadAllText(website);
        }
    }
}
