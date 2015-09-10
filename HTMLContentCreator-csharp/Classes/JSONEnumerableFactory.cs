using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTMLContentCreator_csharp
{
    class JSONEnumerableFactory : IJSONEnumerable
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
