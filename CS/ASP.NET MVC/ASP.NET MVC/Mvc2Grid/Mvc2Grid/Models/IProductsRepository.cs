using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc2Grid.Models
{
    public interface IProductsRepository
    {
        IQueryable<Products> Products { get; set; }
    }
}
