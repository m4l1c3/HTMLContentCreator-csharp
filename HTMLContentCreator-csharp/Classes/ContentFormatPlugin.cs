using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class ContentFormatPlugin
    {
        public int currentRow = 0;
        public int currentColumn = 0;
        public ContentFormat contentFormat;
        public FileStream fileInput;
        //FileInputStream fileInputStream;
        public string currentFile;
        public string currentWorkingDirectory;
        public string currentPageName;
        public IEnumerable rowEnumerator;
        public List<CMSLanguage> languages = new List<CMSLanguage>();
        public List<CMSBlock> cmsBlocks = new List<CMSBlock>();

        
    }
}
