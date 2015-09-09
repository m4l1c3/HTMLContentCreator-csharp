using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface ICMSBlockProcessor
    {
        string currentWorkingDirectory { get; set; }
        IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable { get; set; }

        void processCMSData();
    }
}
