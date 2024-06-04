using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MinMaxDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] files = Directory.GetFiles("C:\\WINDOWS",
        "*.*", SearchOption.AllDirectories);
      Console.WriteLine(files.Count());

      // gets maximum
      var max = (from fileName in files
                 let info = new FileInfo(fileName)
                 orderby info.Length descending
                 select
                   new { FileName = info.Name, Size = info.Length }).Take(1);

      Console.WriteLine("Using Take: {0}", max.ElementAt(0));



      // with anonymous type we have to indicate what to get the max of
      var max1 = (from fileName in files
                  let info = new FileInfo(fileName)
                  select
                    new { FileName = info.Name, Size = info.Length}).Max(s=>s.Size);

      Console.WriteLine("Using Max with anonymous type: {0}", max1);

      // with named type we lose convenience of anonymous type but get 
      // inheritance, realization, for example we can implement IComparable
      // and get the max of the whole object
      var max2 = (from fileName in files
                  let info = new FileInfo(fileName)
                  select
                    new Temp{ FileName = info.Name, Size = info.Length}).Max();

      Console.WriteLine("Using Max: {0}", max2);
      Console.ReadLine();
    }

    private static Func<T, int> GetCompare<T>(T y) where T : IComparable
    {
      return k => y.CompareTo(k);
    }


    public class Temp : IComparable<Temp>
    {
      public string FileName { get; set; }
      public long Size { get; set; }
      public int CompareTo(Temp o)
      {
        return Size.CompareTo(o.Size);
      }
      public override string ToString()
      {
        return string.Format("FileName: {0}, Size: {1}", FileName, Size);
      }
    }


  }
}
