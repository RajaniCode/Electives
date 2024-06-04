using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data;

namespace LinqCookBook.EFUsingPOCO
{
    [EdmEntityTypeAttribute
        (NamespaceName="LinqCookBook.EFUsingPOCO",Name="Customer")]
    public class Customer : IEntityWithChangeTracker, IEntityWithKey,IEntityWithRelationships
    {
        #region changetracker and entity key
        //IEntity tracker is required to participate in change tracking.
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
            get
            {
                return entitykey;
            }
            set
            {
                entitykey = value;
            }
        }
        #endregion

        #region public properties
        //customerid,contacttitle,companyname
        string customerid;
        [EdmScalarPropertyAttribute
            (EntityKeyProperty = true, IsNullable = false)]
        public string CustomerID
        {
            get { return customerid; }
            set
            {
                ReportPropertyChanging("CustomerID");
                customerid = value;
                ReportPropertyChanged("CustomerID");
            }
        }
        string contacttitle;
        [EdmScalarPropertyAttribute]
        public string ContactTitle
        {
            get
            {
                return contacttitle;
            }
            set
            {
                ReportPropertyChanging("ContactTitle");
                contacttitle = value;
                ReportPropertyChanged("ContactTitle");
            }
        }
        string companyname;
        [EdmScalarPropertyAttribute(IsNullable = false)]
        public string CompanyName
        {
            get { return companyname; }
            set
            {
                companyname = value;
            }
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
        
        [EdmRelationshipNavigationPropertyAttribute
            ("LinqCookBook.EFUsingPOCO","CustomerOrders","Orders")]
        public EntityCollection<Order> Orders
        {
            get
            {
                return RelationshipManager
                    .GetRelatedCollection<Order>("LinqCookBook.EFUsingPOCO.CustomerOrders","Orders");
            }
        }
    }
}
