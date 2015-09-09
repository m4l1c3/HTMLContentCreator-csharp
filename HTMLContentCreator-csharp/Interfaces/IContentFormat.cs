using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace HTMLContentCreator_csharp
{
    interface IContentFormat
    {
        ContentFormat contentFormat { get; set; }
        FileStream fileInput { get; set; }
        string currentFile { get; set; }
        string currentWorkingDirectory { get; set; }
        string currentPageName { get; set; }
        //List<CMSLanguage> languages { get; set; }
        //List<CMSBlock> cmsBlocks {  get; set; }
        ICMSDataParser cmsBlockFactory { get; set; }

        void getLanguages(IEnumerable enumerable);

        void processDataRows();

        void processDataCells(IEnumerable enumerable);
    }
}
