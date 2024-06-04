using System;
using System.Collections.Generic;

namespace Paging
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount, string sortExpression)
        {
            this.AddRange(items);
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.SortExpression = sortExpression;
            this.TotalItemCount = totalItemCount;
            this.TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortExpression { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; private set; }

    }
}
