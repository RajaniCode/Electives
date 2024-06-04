using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpressionWithGenericAction
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Action<string> fp = 
        s => Console.WriteLine(s); 
      
      fp("Hello World!");
      Console.ReadLine();
    }
  }
}

