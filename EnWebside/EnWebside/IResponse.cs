using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EnWebside
{
    public interface IWebResponse<T,K>
    {
        
        T GetResponse(K request);

    }
}
