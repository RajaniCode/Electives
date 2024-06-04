using System;
using System.Collections.Generic;
using System.Text;

namespace CommonGenericOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> pList = new List<Person>();
            pList.Add(new Person(1, "John", "", "Shields", 29, 'M'));
            pList.Add(new Person(2, "Mary", "Matthew", "Jacobs", 35, 'F'));
            pList.Add(new Person(3, "Amber", "Carl", "Agar", 25, 'M'));
            pList.Add(new Person(4, "Kathy", "", "Berry", 21, 'F'));
            pList.Add(new Person(5, "Lena", "Ashco", "Bilton", 33, 'F'));
            pList.Add(new Person(6, "Susanne", "", "Buck", 45, 'F'));
            pList.Add(new Person(7, "Jim", "", "Brown", 38, 'M'));
            pList.Add(new Person(8, "Jane", "G", "Hooks", 32, 'F'));
            pList.Add(new Person(9, "Robert", "", "", 31, 'M'));
            pList.Add(new Person(10, "Cindy", "Preston", "Fox", 25, 'F'));
            pList.Add(new Person(11, "Gina", "", "Austin", 27, 'F'));
            pList.Add(new Person(12, "Joel", "David", "Benson", 33, 'M'));
            pList.Add(new Person(13, "George", "R", "Douglas", 55, 'M'));
            pList.Add(new Person(14, "Richard", "", "Banks", 22, 'M'));
            pList.Add(new Person(15, "Mary", "C", "Shaw", 39, 'F'));

            PrintOnConsole(pList, "1. --- Looping through all items in the List<T> ---");

            List<Person> filterOne = pList.FindAll(delegate(Person p) { return p.Age > 35; });
            PrintOnConsole(filterOne, "2. --- Filtering List<T> on single condition (Age > 35) ---");

            List<Person> filterMultiple = pList.FindAll(delegate(Person p) { return p.Age > 35 && p.Sex == 'F'; });
            PrintOnConsole(filterMultiple, "3. --- Filtering List<T> on multiple conditions (Age > 35 and Sex is Female) ---");

            List<Person> sortFName = pList;
            sortFName.Sort(delegate(Person p1, Person p2)
            {
                return p1.FirstName.CompareTo(p2.FirstName);
            });
            PrintOnConsole(sortFName, "4. --- Sort List<T> (Sort on FirstName) ---");


            List<Person> sortLNameDesc = pList;
            sortLNameDesc.Sort(delegate(Person p1, Person p2)
            {
                return p2.LastName.CompareTo(p1.LastName);
            });
            PrintOnConsole(sortLNameDesc, "5. --- Sort List<T> descending (Sort on LastName descending) ---");


            List<Person> newList = new List<Person>();
            newList.Add(new Person(16, "Geoff", "", "Fisher", 29, 'M'));
            newList.Add(new Person(17, "Samantha", "Carl", "Baxer", 32, 'F'));
            pList.AddRange(newList);
            PrintOnConsole(pList, "6. --- Add new List<T> to existing List<> ---");

            List<Person> removeList = pList;
            removeList.RemoveAll(delegate(Person p) { return p.Sex == 'M'; });
            PrintOnConsole(removeList, "7. --- Remove multiple items from List<> based on condition ---");

            Console.WriteLine("8. --- Create Read Only List<> ---");
            IList<Person> personReadOnly = pList;
            Console.WriteLine("Before - Is List Read Only? True or False : " + personReadOnly.IsReadOnly);
            personReadOnly = pList.AsReadOnly();
            Console.WriteLine("After - Is List Read Only? True or False : " + personReadOnly.IsReadOnly);
            Console.ReadLine();
        }

        static void PrintOnConsole(List<Person> pList, string info)
        {
            Console.WriteLine(info);
            Console.WriteLine("\n{0,2}  {1,7}    {2,8}      {3,8}      {4,2}  {5,3}",
                "ID", "FName", "MName", "LName", "Age", "Sex");            
            pList.ForEach(delegate(Person per)
            {
                Console.WriteLine("{0,2}  {1,7}    {2,8}      {3,8}      {4,2}  {5,3}",
                    per.ID, per.FirstName, per.MiddleName, per.LastName, per.Age, per.Sex);
            });

            Console.ReadLine();

        }

        
        
        
        
    }
}
