using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class JSONPlugin : ContentFormatPlugin //, IContentFormat
    {
        public JSONPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {

        }

        public void getLanguages(IEnumerable enumerable)
        {
            throw new NotImplementedException();
        }

        public void processDataCells(IEnumerable enumerable)
        {
            throw new NotImplementedException();
        }

        public void getCMSBlocks()
        {

        }

        public void processDataRows()
        {

        }
    }
}
