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
            string currentWorkingDirectory = Directory.GetCurrentDirectory() + @"\..\..\";
            Config config = new Config(currentWorkingDirectory);
            JSONEnumerableFactory jsonEnumerableFactory = new JSONEnumerableFactory(config.config, "files");
            IEnumerable<Newtonsoft.Json.Linq.JToken> jsonEnumerable = jsonEnumerableFactory.getEnumerable();            
            ICMSBlockProcessor dataProcessor = new CMSBlockProcessor(currentWorkingDirectory, jsonEnumerable);
            //Console.ReadLine();
        }
    }
}