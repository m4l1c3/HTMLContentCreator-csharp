using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    public static class IEnumerableExtensions
    {
        public static bool IsLast<T>(this IEnumerable<T> items, T item)
        {
            var last = items.LastOrDefault();
            if (last == null)
                return false;
            return item.Equals(last);
        }

        public static bool IsFirst<T>(this IEnumerable<CellValue> items, T item)
        {
            var first = items.FirstOrDefault();
            if (first == null)
                return false;
            return item.Equals(first);
        }
    }
}
