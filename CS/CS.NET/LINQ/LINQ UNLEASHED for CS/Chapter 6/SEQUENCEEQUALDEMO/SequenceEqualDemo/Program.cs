using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SequenceEqualDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      var folder1 = Directory.GetDirectories("C:\\");
      var folder2 = Directory.GetDirectories("C:\\TEMP");

      // are they equal
      Console.WriteLine("Equal: " + folder1.SequenceEqual(folder2));
      Console.ReadLine();

      // what's difference
      var missingFolders = folder1.Except(folder2);

      Console.WriteLine("Missing Folders: {0}", missingFolders.Count());
      Array.ForEach(missingFolders.ToArray(),
        folder=>Console.WriteLine(folder));
      Console.ReadLine();

    }
  }
}
