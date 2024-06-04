using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AverageFileSizeDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] files = Directory.GetFiles("c:\\temp\\");
      double averageFileSize = (from file in files select (new FileInfo(file)).Length).Average();
      averageFileSize = Math.Round(averageFileSize/1000000, 2 );
      Console.WriteLine("Average file size (in c:\\temp) {0} Mbytes", averageFileSize );
      Console.ReadLine();

    }
  }
}
