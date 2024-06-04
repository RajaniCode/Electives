using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Collections;
using LinqToActiveDirectory;

namespace QueryActiveDirectory
{
  class Program
  {
    static void Main(string[] args)
    {
      //straight C# code
      //GetUsersCSharp();
      GetUsersLinq();
    }

    
    private static readonly string LDAP =
      "LDAP://sci.softconcepts.com:3268/DC=softconcepts,DC=COM";


    static DirectoryEntry activeDirectory = new DirectoryEntry(LDAP);
      

    private static readonly string user =
      "Administrator";
    private static readonly string password = "Wyoming1";

    
    private static void GetUsersLinq()
    {

      var users = new DirectorySource<User>(activeDirectory, SearchScope.Subtree);
      users.Log = Console.Out;
      var groups = new DirectorySource<Group>(activeDirectory, SearchScope.Subtree);
      groups.Log = Console.Out;


      var results = from user in users
                    where user.Name == "Paul Kimmel" ||
                    user.Name == "Guest"
                    select new { user.Name };

      
      Console.WriteLine("users");
      foreach (var r in results)
        Console.WriteLine(r.Name);
        

      Console.ReadLine();
      #region Group Demo with where and sort
      Console.WriteLine(new string('-', 40));
      Console.WriteLine("groups");

      var groupResults = from group1 in groups
                         where group1.Name == "Users" ||
                         group1.Name == "IIS_WPG"
                         orderby group1.Name descending
                         select new { group1.Name };

      Array.ForEach(groupResults.ToArray(), g =>
        {
          Console.WriteLine("Group: {0}", g.Name);
          //Array.ForEach(g.Members.ToArray(), m => Console.WriteLine(m));
        }
      );
      #endregion

    }

    private static void GetUsersCSharp()
    {
 	    using(DirectoryEntry entry = new 
        DirectoryEntry(LDAP, user, password, AuthenticationTypes.None))
      {
        string filter =
          "(&(objectClass=person))";

        DirectorySearcher searcher = new DirectorySearcher(entry, filter);
        var results = searcher.FindAll();

        foreach (SearchResult result in results)
        {
          Console.WriteLine(result.Properties["Name"][0]);
          Console.WriteLine(Environment.NewLine);
        }
        Console.ReadLine();
      }
    }
  }
}

