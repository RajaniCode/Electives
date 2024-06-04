using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace ExtensionWithAdditionalParameters
{
  class Program
  {
    static void Main(string[] args)
    {
      var song = new{
          Artist="Avril Lavigne", Song="My Happy Ending"
        };

      song.Dump(Console.Out);
      Console.ReadLine();
    }
  }



  public static class Dumper
  {
    public static void Dump(this Object o, TextWriter writer)
    {
      PropertyInfo[] properties = o.GetType().GetProperties();
      foreach(PropertyInfo p in properties)
      {
        try
        {
          writer.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            p.GetValue(o, null)));
        }
        catch
        {
          writer.WriteLine(string.Format("Name: {0}, Value: {1}", p.Name, 
            "unk."));
        }
      }
    }
  }
}
