using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace LambdaExpressionAction
{
  class Program
  {
    static void Main(string[] args)
    {
      Action<string, TextWriter> print =
        (s, writer) => writer.WriteLine(s);
   
      print("Console", Console.Out);
      StreamWriter stream = File.AppendText("c:\\temp\\text.txt");
      stream.AutoFlush = true;
      print("File", stream);
      Console.ReadLine();
    }
  }
}
