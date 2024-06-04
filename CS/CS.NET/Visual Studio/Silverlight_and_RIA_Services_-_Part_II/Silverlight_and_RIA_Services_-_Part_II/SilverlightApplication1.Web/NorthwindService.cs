
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
        public IQueryable<Supplier> GetSuppliers()
        {
            return this.Context.Suppliers;
        }

        public void InsertSuppliers(Supplier suppliers)
        {
            this.Context.AddToSuppliers(suppliers);
        }

        public void UpdateSuppliers(Supplier currentSuppliers)
        {
            this.Context.AttachAsModified(currentSuppliers, this.ChangeSet.GetOriginal(currentSuppliers));
        }

        public void DeleteSuppliers(Supplier suppliers)
        {
            if ((suppliers.EntityState == EntityState.Detached))
            {
                this.Context.Attach(suppliers);
            }
            this.Context.DeleteObject(suppliers);
        }
    }
}


