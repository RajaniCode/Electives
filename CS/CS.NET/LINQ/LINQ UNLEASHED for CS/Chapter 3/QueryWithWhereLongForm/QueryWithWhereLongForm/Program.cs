using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueryWithWhereLongForm
{
  class Program
  {
    static void Main(string[] args)
    {
      var numbers = new int[]{1966, 1967, 1968, 1969, 1970};
      Func<int, bool> getEvents = delegate(int num)
      {
        return num % 2 == 0;
      };

      IEnumerable<int> evens = numbers.Where<int>(getEvents);

      IEnumerator<int> enumerator = evens.GetEnumerator();
      while(enumerator.MoveNext())
        Console.WriteLine(enumerator.Current);

      Console.ReadLine();

    }
  }
}
