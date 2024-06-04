using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace OverloadedExtensionDump
{
  class Program
  {
    static void Main(string[] args)
    {
      var songs = new[] 
        {
          new {Artist="Jussi Bjorling", Song="Aida"}, 
          new {Artist="Sheryl Crow", Song="Steve McQueen"}
        };

      songs.Dump();
      Console.ReadLine();
    }
  }



  public static class Dumper
  {
    public static void Dump(this Object o)
    {
      PropertyInfo[] properties = o.GetType().GetProperties();
      foreach(PropertyInfo p in properties)
      {
        try
        {
          Debug.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            p.GetValue(o, null)));
        }
        catch
        {
          Debug.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            "unk."));
        }
      }
    }

    public static void Dump(this IList list)
    {
      foreach(object o in list)
        o.Dump();
    }

  }
}
