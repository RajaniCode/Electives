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


// Compare two List<string> and display common elements
lstNew = lstOne.Intersect(lstTwo, StringComparer.OrdinalIgnoreCase);
PrintList(lstNew);

// Compare two List<string> and display items of lstOne not in lstTwo
lstNew = lstOne.Except(lstTwo, StringComparer.OrdinalIgnoreCase);
PrintList(lstNew);

// Unique List<string>
lstNew = lstFour.Distinct(StringComparer.OrdinalIgnoreCase);
PrintList(lstNew);

// Convert elements of List<string> to Upper Case
lstNew = lstOne.ConvertAll(x => x.ToUpper());
PrintList(lstNew);

// Concatenate and Sort two List<string>
lstNew = lstOne.Concat(lstTwo).OrderBy(s => s);
PrintList(lstNew);

// Concatenate Unique Elements of two List<string>
lstNew = lstOne.Concat(lstTwo).Distinct();
PrintList(lstNew);

// Reverse a List<string>
lstOne.Reverse();
PrintList(lstOne);

// Search a List<string> and Remove the Search Item
// from the List<string>
int cnt = lstFour.RemoveAll(x => x.Contains("Feb"));
Console.WriteLine("{0} items removed", cnt);
PrintList(lstFour);



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
