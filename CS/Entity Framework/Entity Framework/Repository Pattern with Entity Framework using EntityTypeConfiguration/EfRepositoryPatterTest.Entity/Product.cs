using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Entity
{
    public class Product:BaseEntity<long>
    {
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual string Name { get; set; }
        public virtual int MinimumStockLevel { get; set; }

    }
}
