using System.Collections.Generic;

namespace MsdnMvcWebGrid.Domain
{
    public interface IProductService
    {
        Product GetProduct(int productId, bool includeCategory = false);
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProducts(out int totalRecords, int pageSize = -1,
                                         int pageIndex = -1, string sort = "Name",
                                         SortDirection sortOrder = SortDirection.Ascending);

    }
}