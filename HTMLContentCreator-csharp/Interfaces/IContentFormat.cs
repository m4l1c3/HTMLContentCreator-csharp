using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    interface IContentFormat
    {
        void getLanguages(IEnumerable enumerable);

        void getCMSBlocks();

        void processDataRows();

        void processDataCells(IEnumerable enumerable);
    }
}
