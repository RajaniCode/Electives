using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistinctDemo
{
  class Program
  {
    static void Main(string[] args)
    {

      var grades = new int[] 
        { 65, 72, 72, 75, 75, 77, 79, 80, 81, 81, 81, 85, 88, 91, 92, 92, 92, 95, 99, 100 };

      // select distinct grades
      var distinct = grades.Distinct();

      Console.WriteLine("Median grade: {0}", distinct.ToArray<int>()[distinct.Count() / 2]);
      Console.ReadLine();
      
    }
  }
}
