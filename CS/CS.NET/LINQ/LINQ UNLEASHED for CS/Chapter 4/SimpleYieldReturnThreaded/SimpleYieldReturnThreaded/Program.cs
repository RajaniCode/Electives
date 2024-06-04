using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace SimpleYieldReturn
{
  class Program
  {
    static void Main(string[] args)
    {
      BackgroundWorker worker = new BackgroundWorker();
      worker.DoWork += new DoWorkEventHandler(worker_DoWork);
      worker.RunWorkerAsync();
      
      //for(int i = 0; i<10; i++)
      //{
      //  System.Threading.Thread.Sleep(100);
      //  Console.WriteLine(i);
      //}

      Console.ReadLine();
    }

    static void worker_DoWork(object sender, DoWorkEventArgs e)
    {
      foreach(int i in GetEvents())
      {
        System.Threading.Thread.Sleep(100);
        Console.WriteLine(i);
      }

    }

    public static IEnumerable<int> GetEvents()
    {
      var integers = new[]{1, 2, 3, 4, 5, 6, 7, 8};
      foreach(int i in integers)
        if(i % 2 == 0)
          yield return i;
    }
  }
}
