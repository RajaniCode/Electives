using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CommonGenericOperationsUsingLINQ
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var Person = TypeCreator.TypeGenerator(new[]{
                new {ID=1, FirstName="John", MiddleName="",  LastName="Shields",  Age=29, Sex='M'},
                new {ID=2, FirstName="Mary", MiddleName="Matthew",  LastName="Shields",  Age=29, Sex='M'},
                new {ID=3, FirstName="Amber", MiddleName="Carl",  LastName="Shields",  Age=29, Sex='M'},
                new {ID=4, FirstName="Kathy", MiddleName="",  LastName="Shields",  Age=29, Sex='M'}
            });
                           
            Person.PrintToConsole();

            var Products = TypeCreator.TypeGenerator(new[]{
                new {PID=1, ProductName="Chai", Quantity=12,  Price=18.10},
                new {PID=2, ProductName="Coffee",Quantity=23 ,  Price=28.20},
                new {PID=3, ProductName="Chains", Quantity=42,   Price=21.60},
                new {PID=4, ProductName="Chips", Quantity=21,  Price=21.20}
            });

            Products.PrintToConsole();        

        }
    }
}
