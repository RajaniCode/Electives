using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousMethod
{
  class Program
  {
    static void Main(string[] args)
    {
      // ctrl+c
      Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

      // anonymous cancel delegate
      Console.CancelKeyPress += 
        delegate
        { 
          Console.WriteLine("Anonymous Cancel pressed"); 
        };

      Console.ReadLine();
      
    }

    static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
      Console.WriteLine("Cancel pressed");
    }
  }
}
