using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFunctionPointer
{
  class Program
  {
    delegate void FunctionPointer(String str);

    static void Main(string[] args)
    {
      FunctionPointer fp = HelloWorld;
      fp("Hello World!");
    }

    static void HelloWorld(string str)
    {
      Console.WriteLine(str);
      Console.ReadLine();
    }
  }
}
