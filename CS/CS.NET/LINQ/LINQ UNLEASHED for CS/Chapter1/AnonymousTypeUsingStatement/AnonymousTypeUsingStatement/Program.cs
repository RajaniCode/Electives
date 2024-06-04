using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AnonymousUsingStatement
{
  class Program
  {
    static void Main(string[] args)
    {
      string connectionString = 
        "Data Source=BUTLER;Initial Catalog=AdventureWorks2000;" + 
        "Integrated Security=True";
      using( var connection = new SqlConnection(connectionString))
      {
        connection.Open();
        Console.WriteLine(connection.State);
        Console.ReadLine();

      }
    }
  }
}
