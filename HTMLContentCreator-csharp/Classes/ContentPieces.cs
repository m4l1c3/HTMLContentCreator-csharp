using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class ContentPieces : IContentPieces
    {
        public string SectionName { get; set; }
        public string SectionContent { get; set; }

        public ContentPieces(string sectionName, string sectionContent)
        {
            this.SectionName = sectionName;
            this.SectionContent = sectionContent;
        }
    }
}
