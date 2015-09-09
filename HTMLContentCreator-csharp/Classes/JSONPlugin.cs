using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HTMLContentCreator_csharp
{
    class JSONPlugin : IContentFormat
    {
        public string CurrentPageSection { get; set; }
        public ContentFormat contentFormat { get; set; }
        public string currentFile { get; set; }
        public FileStream fileInput { get; set; }
        public string currentPageName { get; set; }
        public string currentWorkingDirectory { get; set; }
        public List<CMSLanguage> languages { get; set; }
        public List<CMSBlock> cmsBlocks { get; set; }
        public JSONPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentFormat(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            fileInput = new FileStream(Path.Combine(currentWorkingDirectory, @"..\..\", this.currentFile), FileMode.Open, FileAccess.Read);
            currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            languages = new List<CMSLanguage>();
            cmsBlocks = new List<CMSBlock>();
            processDataRows();
        }

        public void getLanguages(IEnumerable enumerable)
        {
            throw new NotImplementedException();
        }

        public void processDataCells(IEnumerable enumerable)
        {
            throw new NotImplementedException();
        }

        public void getCMSBlocks()
        {

        }

        public void processDataRows()
        {

        }
    }
}
