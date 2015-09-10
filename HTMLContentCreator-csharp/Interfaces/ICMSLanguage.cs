using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface ICMSLanguage
    {
        string Name { get; set; }
        List<ContentPieces> ContentPieces { get; set; }
    }
}
