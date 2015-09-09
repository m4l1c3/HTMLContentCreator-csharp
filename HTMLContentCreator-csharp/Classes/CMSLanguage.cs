using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class CMSLanguage
    {
        public string Name;
        public List<ContentPieces> ContentPieces;

        public CMSLanguage(string name)
        {
            this.Name = name;
            this.ContentPieces = new List<ContentPieces>();
        }
    }
}
