using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace HTMLContentCreator_csharp
{
    interface IJSONEnumerable
    {
        IEnumerable<JToken> getEnumerable();
    }
}
