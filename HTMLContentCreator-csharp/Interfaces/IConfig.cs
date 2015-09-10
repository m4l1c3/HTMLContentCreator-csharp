using Newtonsoft.Json.Linq;

namespace HTMLContentCreator_csharp
{
    interface IConfig
    {
        string configFile { get; set; }
        string sampleXlsx { get; set; }
        JObject config { get; set; }
    }
}
