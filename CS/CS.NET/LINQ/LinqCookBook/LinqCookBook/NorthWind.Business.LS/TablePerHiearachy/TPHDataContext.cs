using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace NorthWind.Business.LS.TablePerHiearachy
{
    public class TPHDataContext:DataContext
    {
        public TPHDataContext():
            base("Data Source=.;Initial Catalog=Ecommerce;Integrated Security=true;")
        {
        }

        public Table<Book> Books;
    }
}
