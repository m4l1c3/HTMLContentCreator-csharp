using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class JSONEnumerableFactory : IJSONIterator
    {
        JToken jsonObject;
        
        public JSONEnumerableFactory(JObject configFile, string sectionToParse)
        {
            try
            {
                this.jsonObject = configFile.SelectToken(sectionToParse);
            }
            catch (Newtonsoft.Json.JsonReaderException exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }

        public IEnumerable<Newtonsoft.Json.Linq.JToken> getEnumerable()
        {
            return this.jsonObject.ToList();
        }
    }
}
