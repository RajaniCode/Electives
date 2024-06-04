using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LinqVisualizer;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SequenceVisualizer
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      /* add query (or queries) here */

      var evens = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 19, 20, 22, 24, 26, 28, 30, 32, 34 };
      var fibos = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34 };

      var intersection = evens.Intersect(fibos);

                 
      /* keep this stuff */
      Form f = new Form();
      var sequences = MakeSequences(f, evens);
      sequences.Add(f, fibos);
      sequences.Add(f, intersection);
           
      sequences.DrawToClipboard();
      bool go = true;

      f.FormClosed += delegate { go = false; };
      f.TopMost = true;
      f.Show();
      
      while (go)
      {
        Application.DoEvents();
      }

    }

    private static List<T> MakeOne<T>(T one)
    {
      List<T> l = new List<T>();
      l.Add(one);
      return l;
    }

    private static VisualSequences<T> MakeSequences<T>(Control parent, IEnumerable<T> items)
    {
      VisualSequences<T> s = new VisualSequences<T>();
      s.Add(parent, items);
      return s;
    }

    static T SafeRead<T>(IDataReader reader, string name, T defaultValue)
    {
      object o = reader[name];
      if (o != System.DBNull.Value && o != null)
        return (T)Convert.ChangeType(o, defaultValue.GetType());

      return defaultValue;
    }


    private static void RawTest()
    {
      Form f = new Form();
      SequenceElement<string> elem = new SequenceElement<string>();
      elem.Bounds = new Rectangle(10, 10, 50, 50);
      elem.Parent = f;
      elem.Data = "hello world";
      
      bool go = true;
      f.Controls.Add(elem);
      f.FormClosed += delegate { go = false; };
      f.TopMost = true;
      f.Show();


      while (go)
      {
        Application.DoEvents();
      }

    }
  }
}
