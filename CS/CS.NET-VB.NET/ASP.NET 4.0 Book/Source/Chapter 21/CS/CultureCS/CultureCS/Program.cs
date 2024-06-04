using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace CultureCS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (CultureInfo cultinfo in
              CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                Console.WriteLine(cultinfo);
                Console.ReadLine();
            } 

        }
    }
}
