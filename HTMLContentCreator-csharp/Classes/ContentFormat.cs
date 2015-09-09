using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class ContentFormat
    {
        private string format;
        private string outputType;

        public ContentFormat(string format, string outputType)
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
