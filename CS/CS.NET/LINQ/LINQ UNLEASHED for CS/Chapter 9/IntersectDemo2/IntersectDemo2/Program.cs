using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Permissions;


namespace IntersectDemo2
{
  class Program
  {
    static void Main(string[] args)
    {
      var v2 = Directory.GetFiles(
        @"C:\Windows\Microsoft.NET\Framework\v2.0.50727", "*.*", SearchOption.AllDirectories);
      var v35 = Directory.GetFiles(
        @"C:\Windows\Microsoft.NET\Framework\v3.5", "*.*", SearchOption.AllDirectories);

      var frameworkMatches = v35.Intersect(v2);

      Console.WriteLine("Framework matches between version 2 and 3.5");
      Array.ForEach(frameworkMatches.ToArray(), file => Console.WriteLine(file));

      var frameworkDifferences = v35.Except(v2);
      Console.WriteLine("Framework differences between version 2 and 3.5");
      Array.ForEach(frameworkDifferences.ToArray(), file => Console.WriteLine(new FileInfo(file).Name));
      Console.ReadLine();

    }
  }
}
