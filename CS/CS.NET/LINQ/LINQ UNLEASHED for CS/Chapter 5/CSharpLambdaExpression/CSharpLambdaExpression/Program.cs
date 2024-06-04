using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnonymousDelegate
{
  class Program
  {
    delegate void FunctionPointer(string str);

    static void Main(string[] args)
    {
      FunctionPointer fp = 
        s => Console.WriteLine(s);
      
      fp("Hello World!");
      Console.ReadLine();
    }
  }
}
