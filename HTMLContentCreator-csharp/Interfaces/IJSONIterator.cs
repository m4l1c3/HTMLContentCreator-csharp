using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface IJSONIterator
    {
        IEnumerable<Newtonsoft.Json.Linq.JToken> getEnumerable();
    }
}
