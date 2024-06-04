
namespace SilverlightApplication1.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Ria;
    using System.Web.Ria.Data;
    using System.Web.DomainServices;
    using System.Data;
    using System.Web.DomainServices.LinqToEntities;


    // Implements application logic using the NorthwindEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    [EnableClientAccess()]
    public class NorthwindService : LinqToEntitiesDomainService<NorthwindEntities>
    {

        // TODO: Consider
        // 1. Adding parameters to this method and constraining returned results, and/or
        // 2. Adding query methods taking different parameters.
        public IQueryable<Customer> GetCustomers()
        {
            return this.Context.Customers;
        }
    }
}


