using System;
using System.Linq;

namespace Paging
{
    public static class PageLinqExtensions
    {
        public static PagedList<T> ToPagedList<T>
            (
                this IQueryable<T> allItems,
                int? pageIndex,
                int pageSize
            )
        {
            return ToPagedList<T>(allItems, pageIndex, pageSize, String.Empty);

        }

        public static PagedList<T> ToPagedList<T>
            (
                this IQueryable<T> allItems,
                int? pageIndex,
                int pageSize,
                string sort
            )
        {
            var truePageIndex = pageIndex ?? 0;
            var itemIndex = truePageIndex * pageSize;
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            var totalItemCount = allItems.Count();
            return new PagedList<T>(pageOfItems, truePageIndex, pageSize, totalItemCount, sort);

        }
    }
}
