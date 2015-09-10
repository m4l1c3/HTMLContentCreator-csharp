using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class CMSBlock : ICMSBlock
    {
        public string Name { get; set; }
        
        public CMSLanguage Language { get; set; }

        public CMSBlock(string name, CMSLanguage language)
        {
            this.Name = name;
            this.Language = language;
        }
    }
}
