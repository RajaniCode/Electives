using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Entity
{
    public class Category:BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
