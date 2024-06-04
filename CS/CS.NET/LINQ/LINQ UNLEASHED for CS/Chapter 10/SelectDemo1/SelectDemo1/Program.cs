using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectDemo1
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime start = DateTime.Now;

      const long upper = 1000000;
      var numbers = new long[upper];
      for (long i = 2000; i < 5000; i++)
        numbers[i] = i+1;

      /* prohibitively slow */
      //var primes = from n in numbers
      //  where IsPrime(n)
      //  select n;

      // use Sieve of Eratosthenes; of course now we have primes
      BuildPrimes(upper);
      var primes = from n in numbers
                   where IsPrime2(n)
                   select n;



      DateTime stop = DateTime.Now;
      StringBuilder builder = new StringBuilder();
      Array.ForEach(primes.ToArray(), n=>builder.AppendFormat("{0}\n", n));
      Console.Write(builder.ToString());
      Console.WriteLine("Elapsed: {0}", Elapsed(start, stop));
      Console.ReadLine();

    }

    /// <summary>
    /// Brute force prime tester, very slow.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private static bool IsPrime(long v)
    {
      if (v <= 1) return false;
      for (long i = 1; i < v; i++)
        if (Gcd(i, v) > 1)
          return false;

      return true;
    }


    /// <summary>
    /// Use the Sieve of Eratosthenes: no number is divisible 
    /// by a number greater than its square root
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private static bool IsPrime2(long v)
    {
      for(int i=0; i<Primes.Count; i++)
      {
        if(v % Primes[i] == 0) return false;
        if(Primes[i] >= Math.Sqrt(v)) return true;
      }

      return true;
    }

    private static List<long> Primes = new List<long>();
    private static void BuildPrimes(long max)
    {
      Primes.Add(2);
      if (max < 3) return;

      for (long i = 2; i <= max; i++)
      {
        if (IsPrime2(i))
          Primes.Add(i);
      }
    }


    /// <summary>
    /// Recursive Euclidean algorithm
    /// </summary>
    /// <param name="num"></param>
    /// <param name="den"></param>
    /// <returns></returns>
    private static long Gcd(long num, long den)
    {
      return den % num == 1 ? 1 :
        den % num == 0 ? num : Gcd(den % num, num);
    }

    private static string Elapsed(DateTime start, DateTime stop)
    {
      TimeSpan span = stop - start;
      return string.Format("Days: {0}, Hours: {1}, Minutes: {2}, Seconds: {3}, Mils: {4}", 
        span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds);
   }
      
  }



}
