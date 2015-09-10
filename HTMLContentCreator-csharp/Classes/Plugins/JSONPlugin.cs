using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HTMLContentCreator_csharp
{
    class JSONPlugin : IContentFormat
    {
        public string CurrentPageSection { get; set; }
        public IContentType contentFormat { get; set; }
        public string currentFile { get; set; }
        public FileStream fileInput { get; set; }
        public string currentPageName { get; set; }
        public string currentWorkingDirectory { get; set; }
        public ICMSDataParser cmsBlockFactory { get; set; }
        private JToken objJSON { get; set; }
        private int position { get; set; }

        public JSONPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentType(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            fileInput = new FileStream(Path.Combine(currentWorkingDirectory, this.currentFile), FileMode.Open, FileAccess.Read);
            currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            objJSON = JObject.Parse(GetFileStreamAsString(fileInput));
            cmsBlockFactory = new CMSBlockFactory(currentPageName);
            processDataRows();
        }

        public string GetFileStreamAsString(FileStream fileStream)
        {
            string fileContents;
            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContents = reader.ReadToEnd();
            }
            return fileContents;
        }

        public void getLanguages(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                foreach (JToken item in enumerable)
                {
                    cmsBlockFactory.languages.Add(new CMSLanguage(item.Path));                   
                }
            }
        }

        public void processDataCells(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                
                try {
                    
                    string placeholder = "";
                    foreach (var item in enumerable)
                    {
                        foreach (var childItem in JObject.Parse(item.ToString()))
                        {
                            placeholder = childItem.Key;
                            CMSLanguage currentLanguage = cmsBlockFactory.languages[position];
                            currentLanguage.ContentPieces.Add(new ContentPieces(placeholder, childItem.Value.ToString()));
                            
                        }
                        
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Index: " + position + " " + exception.ToString());
                }
            }
        }
        
        public void processDataRows()
        {
            try
            {
                foreach (var item in objJSON)
                {
                    getLanguages(item.ToList());
                    processDataCells(item.ToList());
                    position++;
                }
                cmsBlockFactory.getCMSBlocks();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }
    }
}
