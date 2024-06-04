using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TasksReturnValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the Tasks
            Task<int> t1 = new Task<int>(GenerateNumbers);
            Task<string> t2 = new Task<string>(PrintCharacters);
            Task<int> t3 = new Task<int>(PrintArray);
            // Start the tasks
            t1.Start();
            t2.Start();
            t3.Start();
            //Print Return Value
            Console.WriteLine("Numbers  generated till {0}", t1.Result);
            Console.WriteLine("Original String {0}", t2.Result);
            Console.WriteLine("Array Count {0}", t3.Result);
            Console.ReadLine();
        }

        static int GenerateNumbers()
        {
            int i;
            for (i = 0; i < 7; i++)
            {
                Console.WriteLine("Method1 - Number: {0}", i);
                Thread.Sleep(1000);
            }
            return i;
        }

        static string PrintCharacters()
        {
            string str = "dotnet";
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine("Method2 - Character: {0}", str[i]);
                Thread.Sleep(1000);
            }
            return str;
        }

        static int PrintArray()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            foreach (int i in arr)
            {
                Console.WriteLine("Method3 - Array: {0}", i);
                Thread.Sleep(1000);
            }
            return arr.Count();
        }

    }
}
