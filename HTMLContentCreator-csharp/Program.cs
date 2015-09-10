using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HTMLContentCreator_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentWorkingDirectory = Directory.GetCurrentDirectory() + @"\..\..\";
            IConfig config = new Config(currentWorkingDirectory);
            IJSONEnumerable jsonEnumerableFactory = new JSONEnumerableFactory(config.config, "files");
            IEnumerable<JToken> jsonEnumerable = jsonEnumerableFactory.getEnumerable();            
            ICMSBlockProcessor dataProcessor = new CMSBlockProcessor(currentWorkingDirectory, jsonEnumerable);
            //Console.ReadKey();
        }
    }
}