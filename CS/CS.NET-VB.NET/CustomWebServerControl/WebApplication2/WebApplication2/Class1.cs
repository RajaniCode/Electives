using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace WebApplication2
{
    public class Class1
    {
        public Object SelectMethod()
        {
            return new ReturnItems(); 
        }
    }
    public class ReturnItems : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}