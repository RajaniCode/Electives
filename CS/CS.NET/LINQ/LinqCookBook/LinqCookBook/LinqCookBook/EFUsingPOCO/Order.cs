using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data;

namespace LinqCookBook.EFUsingPOCO
{
    [EdmEntityTypeAttribute(NamespaceName = "LinqCookBook.EFUsingPOCO", Name = "Order")]
    public class Order : IEntityWithChangeTracker, IEntityWithKey, IEntityWithRelationships
    {
        #region implementation details for the interface requirements of EF.
        private IEntityChangeTracker changetracker;
        public void SetChangeTracker(IEntityChangeTracker changeTracker)
        {
            this.changetracker = changeTracker;
        }

        protected void ReportPropertyChanging(string propertyname)
        {
            if (changetracker != null)
            {
                changetracker.EntityMemberChanging(propertyname);
            }
        }
        protected void ReportPropertyChanged(string propertyname)
        {
            if (changetracker != null)
            {
                changetracker.EntityMemberChanged(propertyname);
            }
        }
        EntityKey entitykey;
        public System.Data.EntityKey EntityKey
        {
            get { return entitykey; }
            set { entitykey = value; }
        }
        #endregion
        
        RelationshipManager manager;
        public RelationshipManager RelationshipManager
        {
            get
            {
                if (manager == null)
                {
                    manager = RelationshipManager.Create(this);
                }
                return manager;
            }
        }

        int orderid;
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        public int OrderID
        {
            get{return orderid;}
            set
            {
                ReportPropertyChanging("OrderID");
                orderid = value;
                ReportPropertyChanged("OrderID");
            }
        }

        DateTime? orderdate;
        [EdmScalarPropertyAttribute]
        public DateTime? OrderDate
        {
            get{return orderdate;}
            set
            {
                ReportPropertyChanging("OrderDate");
                orderdate = value;
                ReportPropertyChanged("OrderDate");
            }
        }

        string shipcity;
        [EdmScalarPropertyAttribute]
        public string ShipCity
        {
            get{return shipcity;}
            set
            {
                ReportPropertyChanging("ShipCity");
                shipcity = value;
                ReportPropertyChanged("ShipCity");
            }
        }
        //Customer customer;
        [EdmRelationshipNavigationPropertyAttribute
            ("LinqCookBook.EFUsingPOCO", "CustomerOrders", "Customer")]
        public Customer Customer
        {
            get
            {
                var efreference =
                    RelationshipManager
                    .GetRelatedReference<Customer>
                    ("LinqCookBook.EFUsingPOCO.CustomerOrders", "Customer");
                if (!efreference.IsLoaded)
                {
                    efreference.Load();
                }
                return efreference.Value;
            }
        }
    }
}
