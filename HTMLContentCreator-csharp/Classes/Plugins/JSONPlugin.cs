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
        public ICMSDataParser cmsBlockFactory { get; set; }

        public JSONPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentFormat(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            fileInput = new FileStream(Path.Combine(currentWorkingDirectory, this.currentFile), FileMode.Open, FileAccess.Read);
            currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            cmsBlockFactory = new CMSBlockFactory(currentWorkingDirectory);
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
        
        public void processDataRows()
        {

        }
    }
}
