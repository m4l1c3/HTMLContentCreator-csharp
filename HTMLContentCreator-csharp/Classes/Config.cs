using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class Config
    {
        public string configFile = "ContentConfigJSON.txt";
        public string sampleXlsx = "Sample.xlsx";
        public JObject config;

        public Config(string currentWorkingDirectory)
        {
            try
            {
                if (File.Exists(Path.Combine(currentWorkingDirectory, @"..\..\", this.configFile)))
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(currentWorkingDirectory, @"..\..\", configFile)))
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
                            sw.WriteLine("\t\t\"" + currentWorkingDirectory + this.sampleXlsx + "\"");
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
