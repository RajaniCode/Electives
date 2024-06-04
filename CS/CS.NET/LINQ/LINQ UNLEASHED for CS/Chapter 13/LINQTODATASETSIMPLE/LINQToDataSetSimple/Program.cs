using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LINQToDataSetSimple
{
  class Program
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    static void Main(string[] args)
    {
      DataSet data = new DataSet();
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = 
          new SqlCommand("SELECT * FROM Suppliers", connection);
        command.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(data, "Suppliers");
      }

      DataTable supplierTable = data.Tables["Suppliers"];

      IEnumerable<DataRow> suppliers = 
        from supplier in supplierTable.AsEnumerable()
        select supplier;

      Console.WriteLine("Supplier Information");
      foreach(DataRow row in suppliers)
      {
        Console.WriteLine(row.Field<string>("CompanyName"));
        Console.WriteLine(row.Field<string>("City"));
        Console.WriteLine();
      }

      Console.ReadLine();
    }
  }
}
