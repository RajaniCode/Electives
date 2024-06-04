using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.LS;
using ConsoleLinqToSql.TablePerType;
using ConsoleLinqToSql.TablePerHiearachy;
using System.Data.Linq;



namespace ConsoleLinqToSql
{
    class Program
    {
        static void Main(string[] args)
        {
            // Category.DeleteCategoryExample();
            //how to do in clause in entity framework.

            //table per type
            //TablePerTypeExample.InsertEmployees();

            //table per hiearachy
            TablePerHiearachyExample.BooksExample();
            
            
        }
    }
}
