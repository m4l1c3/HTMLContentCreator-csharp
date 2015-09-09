using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class XMLPlugin : ContentFormatPlugin //, IContentFormat
    {
        public XMLPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
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
