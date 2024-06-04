using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForEachWithActionLambda
{
  class Program
  {
    static void Main(string[] args)
    {
      Action<double> print = 
          amount => Console.WriteLine("{0:c}", amount);
      
      Action<double> michiganSalesTax =
        amount => print(amount *= 1.06);
      
      var amounts = new double[]{
        10.36, 12.00, 134};

      Array.ForEach<double>(amounts, michiganSalesTax);
      Console.ReadLine();


    }
  }
}
