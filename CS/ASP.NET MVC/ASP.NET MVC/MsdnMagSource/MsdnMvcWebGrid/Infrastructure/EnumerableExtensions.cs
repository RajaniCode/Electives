using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MsdnMvcWebGrid.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TTarget> SafeCast<TTarget>(this IEnumerable source)
        {
            return source == null ? null : source.Cast<TTarget>();
        }
    }
}