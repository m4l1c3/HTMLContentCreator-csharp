using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentWorkingDirectory = Directory.GetCurrentDirectory();
            Config config = new Config(currentWorkingDirectory);
            JSONEnumerableFactory jsonEnumerableFactory = new JSONEnumerableFactory(config.config, "files");
            IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable = jsonEnumerableFactory.getEnumerable();
            process(currentWorkingDirectory, jsonEnumerable);
        }

        static void process(string currentWorkingDirectory, IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable)
        {
            try
            {
                foreach(var file in jsonEnumerable)
                {
                    string currentFile = file.ToString();
                    ContentFormatPluginFactory contentFormatPluginFactory = new ContentFormatPluginFactory();
                    ContentFormatPlugin data = contentFormatPluginFactory.getContentFormat(currentFile.Substring(currentFile.LastIndexOf(".") + 1).ToUpper(),
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
