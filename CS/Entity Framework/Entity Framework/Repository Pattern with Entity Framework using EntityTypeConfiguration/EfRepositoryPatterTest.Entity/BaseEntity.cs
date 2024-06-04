using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfRepPatTest.Entity
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
