using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class CMSLanguage : ICMSLanguage
    {
        public string Name { get; set; }
        public List<ContentPieces> ContentPieces { get; set; }

        public CMSLanguage(string name)
        {
            this.Name = name;
            this.ContentPieces = new List<ContentPieces>();
        }
    }
}
