using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class CMSBlockProcessor : ICMSBlockProcessor
    {
        public string currentWorkingDirectory { get; set; }
        public IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable { get; set; }

        public CMSBlockProcessor(string currentWorkingDirectory, IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable)
        {
            this.currentWorkingDirectory = currentWorkingDirectory;
            this.jsonEnumerable = jsonEnumerable;
            processCMSData();
        }

        public void processCMSData()
        {
            try
            {
                foreach (var file in jsonEnumerable)
                {
                    string currentFile = file.ToString();
                    ContentFormatPluginFactory contentFormatPluginFactory = new ContentFormatPluginFactory();
                    IContentFormat data = contentFormatPluginFactory.getContentFormat(currentFile.Substring(currentFile.LastIndexOf(".") + 1).ToUpper(),
                        currentFile, currentWorkingDirectory);
                    TemplateWriter writer = new TemplateWriter();
                    writer.writeTemplates(data);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }
    }
}
