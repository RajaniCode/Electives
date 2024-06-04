using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace NorthWind.Business.EF.AdventureWorksLT
{
    public partial class Product
    {
        public int ModelId
        {
            get
            {
                if (ProductModelReference.EntityKey != null)
                {
                    return 0;
                }
                return (int)ProductModelReference.EntityKey.EntityKeyValues[0].Value;
            }
            set
            {
                this.ProductModelReference.EntityKey = new EntityKey("AdventureWorksLTEntities.ProductModel", "ProductModelID", value);
            }
        }
    }
}
