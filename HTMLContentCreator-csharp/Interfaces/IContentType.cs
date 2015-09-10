using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface IContentType
    {
        string format { get; set; }
        string outputType { get; set; }

        string getOutputType();
    }
}
