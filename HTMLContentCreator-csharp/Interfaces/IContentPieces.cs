using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface IContentPieces
    {
        string SectionName { get; set; }
        string SectionContent { get; set; }
    }
}
