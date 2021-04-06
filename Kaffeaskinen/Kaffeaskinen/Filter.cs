using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    interface IFilter
    {
        bool NewFilter { get; set; }

        void ReplaceFilter();
        void FilterUsed();
    }
}
