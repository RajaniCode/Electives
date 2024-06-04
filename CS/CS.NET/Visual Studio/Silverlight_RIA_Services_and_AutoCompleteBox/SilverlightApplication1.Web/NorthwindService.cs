
namespace SilverlightApplication1.Web
{
    using System.Linq;
    using System.Web.DomainServices.LinqToEntities;
    using System.Web.Ria;


    // Implements application logic using the NorthwindEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    [EnableClientAccess()]
    public class NorthwindService : LinqToEntitiesDomainService<NorthwindEntities>
    {

        // TODO: Consider
        // 1. Adding parameters to this method and constraining returned results, and/or
        // 2. Adding query methods taking different parameters.
        public IQueryable<Customers> GetCustomers()
        {
            return this.Context.Customers;
        }
    }
}


