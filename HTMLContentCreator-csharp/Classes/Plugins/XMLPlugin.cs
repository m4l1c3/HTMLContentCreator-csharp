using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HTMLContentCreator_csharp
{
    class XMLPlugin : IContentFormat
    {
        public string CurrentPageSection { get; set; }
        public IContentType contentFormat { get; set; }
        public string currentFile { get; set; }
        public FileStream fileInput { get; set; }
        public string currentPageName { get; set; }
        public string currentWorkingDirectory { get; set; }
        public List<CMSLanguage> languages { get; set; }
        public List<CMSBlock> cmsBlocks { get; set; }
        public XmlDocument doc { get; set; }
        public ICMSDataParser cmsBlockFactory { get; set; }

        public XMLPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentType(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            fileInput = new FileStream(Path.Combine(currentWorkingDirectory, this.currentFile), FileMode.Open, FileAccess.Read);
            currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            languages = new List<CMSLanguage>();
            cmsBlocks = new List<CMSBlock>();
            doc = new XmlDocument();
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
