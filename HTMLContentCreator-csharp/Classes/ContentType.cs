using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class ContentType : IContentType
    {
        public string format { get; set; }
        public string outputType { get; set; }

        public ContentType(string format, string outputType)
        {
            this.format = format;
            this.outputType = outputType;
        }

        public string getOutputType()
        {
            return this.outputType;
        }
    }
}
