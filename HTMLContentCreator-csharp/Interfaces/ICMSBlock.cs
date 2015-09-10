using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface ICMSBlock
    {
        string Name { get; set; }
        CMSLanguage Language { get; set; }


    }
}
