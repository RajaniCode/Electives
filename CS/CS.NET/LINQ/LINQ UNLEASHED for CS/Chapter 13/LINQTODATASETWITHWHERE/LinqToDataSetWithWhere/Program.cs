using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LinqToDataSetWithWhere
{
  class Program
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    static void Main(string[] args)
    {
      string sql = "SELECT * FROM [Order Details] od " + 
        "INNER JOIN Products p on od.ProductID = od.ProductID";


      DataSet data = new DataSet();
      using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = 
          new SqlCommand(sql, connection);
        command.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(data);
      }

      DataTable detailTable = data.Tables[0];

      IEnumerable<DataRow> details = 
        from detail in detailTable.AsEnumerable()
        where detail.Field<float>("Discount") > 0.10f
        orderby detail.Field<int>("ProductID")
        select detail;

      // with skip
      details = details.Take(25);

      Console.WriteLine("Big-discount orders");
      foreach(DataRow row in details)
      {
        Console.WriteLine(row.Field<int>("OrderID"));
        Console.WriteLine(row.Field<string>("ProductName"));
        Console.WriteLine(row.Field<decimal>("UnitPrice"));
        Console.WriteLine(row.Field<float>("Discount"));
        Console.WriteLine();
      }

      Console.ReadLine();
    }
  }
}
