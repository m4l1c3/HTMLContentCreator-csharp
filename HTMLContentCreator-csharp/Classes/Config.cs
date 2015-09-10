using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class Config : IConfig
    {
        public string configFile { get; set; }
        public string sampleXlsx { get; set; }
        public JObject config { get; set; }

        public Config(string currentWorkingDirectory)
        {
            configFile = "ContentconfigJSON.txt";
            sampleXlsx = "Sample.xlsx";

            try
            {
                if (File.Exists(Path.Combine(currentWorkingDirectory, configFile)))
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(currentWorkingDirectory, configFile)))
                    {
                        this.config = JObject.Parse(reader.ReadToEnd());
                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(Path.Combine(currentWorkingDirectory, configFile), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("{");
                            sw.WriteLine("\t\"files\": [");
                            sw.WriteLine("\t\t\"" + currentWorkingDirectory + sampleXlsx + "\"");
                            sw.WriteLine("\t]");
                            sw.WriteLine("}");
                            sw.Flush();
                        }
                        this.config = JObject.Parse(fs.ToString());
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }
    }
}
