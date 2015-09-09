using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface ICMSDataParser
    {
        string currentPageName { get; set; }
        List<CMSLanguage> languages { get; set; }
        List<CMSBlock> cmsBlocks { get; set; }
        List<CMSBlock> getCMSBlocks();
    }
}
