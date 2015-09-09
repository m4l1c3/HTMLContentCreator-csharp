using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class CMSBlockFactory : ICMSDataParser
    {
        public string currentPageName { get; set; }
        public List<CMSLanguage> languages { get; set; }
        public List<CMSBlock> cmsBlocks { get; set; }

        public CMSBlockFactory(string currentPageName)
        {
            this.currentPageName = currentPageName;
            this.languages = new List<CMSLanguage>();
            this.cmsBlocks = new List<CMSBlock>();
        }

        public List<CMSBlock> getCMSBlocks()
        {
            if (this.languages.Count() > 0)
            {
                foreach (CMSLanguage currentLanguage in this.languages)
                {
                    CMSBlock cmsBlock = new CMSBlock(this.currentPageName, currentLanguage);
                    this.cmsBlocks.Add(cmsBlock);
                }
            }

            return this.cmsBlocks;
        }
    }
}
