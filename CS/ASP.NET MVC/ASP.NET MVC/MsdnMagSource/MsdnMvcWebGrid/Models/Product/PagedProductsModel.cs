using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsdnMvcWebGrid.Models.Product
{
    public class PagedProductsModel
    {
        public int PageNumber { get; set; }

        public IEnumerable<Domain.Product> Products { get; set; }

        public int TotalRows { get; set; }

        public int PageSize { get; set; }
    }
}