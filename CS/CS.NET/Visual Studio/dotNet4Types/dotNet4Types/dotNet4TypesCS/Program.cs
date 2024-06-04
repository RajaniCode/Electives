using System;
using System.Linq;

namespace dotNet4Types
{
    class Program
    {
    static void Main(string[] args)
    {
        var assemb = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from aType in assembly.GetExportedTypes()
                        select aType;

        var filtered = assemb
        .Where(x => x.Assembly.FullName.Contains("Version=4.0.0.0"))
        .GroupBy(a => a.Name.Length)
        .OrderByDescending(x => x.Key);

        // Find the Longest and Shortest Types
        var longestType = filtered.First();
        var shortestType = filtered.Last();

        // Loop and print the Longest Type Names
        foreach (var nm in longestType)
        {
            Console.WriteLine("Longest Type Name: {0} \nFullName: {1} \nTypeLength: {2}", 
                nm.Name, nm.FullName, nm.Name.Length);
            Console.WriteLine("-------------------------------------------");
        }

            
        // Loop and print the Shortest Type Names
        foreach (var nm in shortestType)
        {
            Console.WriteLine("Shortest Type Name: {0} \nFullName: {1} \nTypeLength: {2}",
                nm.Name, nm.FullName, nm.Name.Length);
            Console.WriteLine("-------------------------------------------");
        }

        Console.ReadLine();
    }
    }
}
