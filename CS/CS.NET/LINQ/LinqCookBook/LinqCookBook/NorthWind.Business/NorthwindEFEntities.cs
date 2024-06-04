using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Microsoft.Data.Extensions;
namespace NorthWind.Business.EF
{
    public partial class NorthwindEFEntities
    {
        
        private EntitySet<Product> productSet;
        public EntitySet<Product> ProductSet
        {
            get
            {
                if (this.productSet == null)
                {
                    this.productSet = new EntitySet<Product>(this);
                }
                return this.productSet;
            }
        }

        private EntitySet<Category> categorySet;
        public EntitySet<Category> CategorySet
        {
            get
            {
                if (this.categorySet == null)
                {
                    this.categorySet = new EntitySet<Category>(this);
                }
                return this.categorySet;
            }
        }
    }
}
