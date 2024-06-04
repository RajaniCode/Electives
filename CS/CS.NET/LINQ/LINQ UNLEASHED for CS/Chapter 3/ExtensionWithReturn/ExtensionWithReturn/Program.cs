using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace ExtensionWithReturn
{
  class Program
  {
    static void Main(string[] args)
    {
      var songs = new{
          Artist="Green Day", Song="Wake Me Up When September Ends"};

      Console.WriteLine(songs.Dump());
      Console.ReadLine();
    }
  }



  public static class Dumper
  {
    public static string Dump(this Object o)
    {
      PropertyInfo[] properties = o.GetType().GetProperties();
      StringBuilder builder = new StringBuilder();
      foreach(PropertyInfo p in properties)
      {
        try
        {
          builder.AppendFormat(string.Format("Name: {0}, Value: {1}", p.Name, 
            p.GetValue(o, null)));
        }
        catch
        {
          builder.AppendFormat(string.Format("Name: {0}, Value: {1}", p.Name, 
            "unk."));
        }
        builder.AppendLine();
      }
      return builder.ToString();
    }
  }
}
