using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Business.LS
{
    public partial class Customer
    {
        public static IQueryable<Customer> GetCustomersByContactTitle(string contacttitle, int start, int max)
        {
            var db = new NorthWindDataContext();
            db.Log = new DebuggerWriter();
            var custs = db.Customers.AsQueryable();
            if (contacttitle != null)
            {
                custs = custs.Where(c => c.ContactTitle == contacttitle);
            }
            //linq to sql does not require ordering.
            custs = custs.Skip(start).Take(max);
                        
            var stuff = custs.ToString();
            return custs;
        }

        public static int GetCustomersByContactTitleCount(string contacttitle)
        {
            var db = new NorthWindDataContext();
            var custs = db.Customers.AsQueryable();
            if (contacttitle != null)
            {
                custs = custs.Where(c => c.ContactTitle == contacttitle);
            }
            return custs.Count();
        }
    }
}
