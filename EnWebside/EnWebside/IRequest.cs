using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EnWebside
{
    interface IRequest<T,K>
    {
        T MakeRequest(K website);
    }
}
