using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace DataContextChildClass
{
  public class Northwind : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    public Northwind() : base(connectionString)
    {}
  }

  class Program
  {
    static void Main(string[] args)
    {
      Northwind context = new Northwind();
      Table<OrderDetail> details = context.GetTable<OrderDetail>();

      Console.WriteLine("SELECT: {0}", context.GetCommand(details).CommandText);
      Console.WriteLine();

      var results = from detail in details 
                where detail.OrderID == 10248
                select detail;


      Array.ForEach(results.ToArray(), d=>Console.WriteLine(d));
      Console.ReadLine();
    }
  }

  [Table(Name="Order Details")]
  public class OrderDetail
  {
    [Column()]
    public int OrderID{get; set;}
    [Column()]
    public int ProductID{get; set;}
    
    [Column()]
    public decimal UnitPrice{get; set;}
    [Column()]
    public Int16 Quantity{get; set;}
    [Column()]
    public float Discount{get; set;}

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      PropertyInfo[] props = this.GetType().GetProperties();

      // using array for each
      Array.ForEach(props.ToArray(), prop =>
        builder.AppendFormat("{0} : {1}", prop.Name,
          prop.GetValue(this, null) == null ? "<empty>\n" :
          prop.GetValue(this, null).ToString() + "\n"));

      return builder.ToString();
    }
  }
}
