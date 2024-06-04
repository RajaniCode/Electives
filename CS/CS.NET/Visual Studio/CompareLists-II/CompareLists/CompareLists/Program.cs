using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstOne = new List<string>() { "January", "February", "March"};
            List<string> lstTwo = new List<string>() { "January", "April", "March"};
            List<string> lstThree = new List<string>() { "January", "April", "March", "May" };
            List<string> lstFour = new List<string>() { "Jan", "Feb", "Jan", "April", "Feb" };
            IEnumerable<string> lstNew = null;

            // Order by Length then by words (descending)
            lstNew = lstThree.OrderBy(x => x.Length)
                    .ThenByDescending(x => x);
            PrintList(lstNew);


            // Create a string by combining all words of a List<string>
            // Use StringBuilder if you want performance
            string delim = ",";
            var str = lstOne.Aggregate((x, y) => x + delim + y);
            Console.WriteLine(str);
            Console.WriteLine("-------------");


            // Create a List<string> from a Delimited string
            string s = "January February March";
            char separator = ' ';
            lstNew = s.Split(separator).ToList();
            PrintList(lstNew);

            // Convert a List<int> to List<string>
            List<int> lstNum = new List<int>(new int[] { 3, 6, 7, 9 });
            lstNew = lstNum.ConvertAll<string>(delegate(int i) 
            {
               return i.ToString(); 
            });
            PrintList(lstNew);

            // Count Repeated Words
            var q = lstFour.GroupBy(x => x)
               .Select(g => new { Value = g.Key, Count = g.Count() })
               .OrderByDescending(x => x.Count);

            foreach (var x in q)
            {
               Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);
            }

            Console.ReadLine();          
        }

        static void PrintList(IEnumerable<string> str)
        {
            foreach (var s in str)
                Console.WriteLine(s);
            Console.WriteLine("-------------");
        }
    }
}
