using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: EdmRelationshipAttribute
    ("LinqCookBook.EFUsingPOCO","CustomerOrders", "Customer",
    RelationshipMultiplicity.ZeroOrOne,
    typeof(LinqCookBook.EFUsingPOCO.Customer),
    "Orders",RelationshipMultiplicity.Many, 
    typeof(LinqCookBook.EFUsingPOCO.Order))]
namespace LinqCookBook.EFUsingPOCO
{
    public class NorthwindEntities:ObjectContext
    {
        public NorthwindEntities()
            : base("name=nwefpoco", "NorthwindEntities") { }
        ObjectQuery<Customer> customers;
        public ObjectQuery<Customer> Customers
        {
            get
            {
                if (customers == null)
                {
                    this.customers = base.CreateQuery<Customer>("[Customers]");
                }
                return customers;   
            }
        }

        ObjectQuery<Order> orders;
        public ObjectQuery<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    orders = base.CreateQuery<Order>("[Orders]");
                }
                return orders;
            }
        }
    }
}
