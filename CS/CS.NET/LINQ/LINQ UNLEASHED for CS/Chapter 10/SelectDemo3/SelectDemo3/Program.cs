using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SelectDemo3
{
  class Program
  {
    static void Main(string[] args)
    {
      IEnumerable<Supplier> USSuppliers = DataAccess.ReadSuppliers(s => s.Country == "USA");

      Array.ForEach(USSuppliers.ToArray(), s => Console.WriteLine(s));
      Console.ReadLine();
    }
  }

  public class Supplier 
  {
    public int SupplierID{ get; set; }
    public string CompanyName{ get; set; }
    public string ContactName{ get; set; }
    public string ContactTitle{ get; set; }
    public string Address{ get; set; }
    public string City{ get; set; }
    public string Region{ get; set; }
    public string PostalCode{ get; set; }
    public string Country{ get; set; }
    public string Phone{ get; set; }
    public string Fax{ get; set; }
    public string HomePage { get; set; }

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


  public static class DataAccess
  {
    private static readonly string connectionString = 
      "Data Source=.\\SQLEXPRESS;"+
      "AttachDbFilename=\"C:\\Books\\Addison Wesley\\"+
      "LINQ\\Northwind\\northwnd.mdf\";Integrated Security=True;"+
      "Connect Timeout=30;User Instance=True";

    public static IEnumerable<Supplier> ReadSuppliers(Func<Supplier, bool> predicate)
    {
      IEnumerable<Supplier> suppliers = ReadSuppliers();
      return (from s in suppliers select s).Where(predicate);
    }

    //public static List<Supplier> ReadSupplier(Func)
    public static IEnumerable<Supplier> ReadSuppliers()
    {
        using(SqlConnection connection = new SqlConnection(connectionString))
      {
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT * FROM SUPPLIERS", connection);
        IDataReader reader = command.ExecuteReader();

        List<Supplier> list = new List<Supplier>();
        while(reader.Read())
        {
          list.Add(reader.ReadSupplier());
        }

        return list;
      }
    }
  }

  public static class ExtendsReader
  {
    static Func<string, IDataReader, string, string> SafeRead =
      (fieldName, reader, defaultValue) =>
        reader[fieldName] != null ?
        (string)Convert.ChangeType(reader[fieldName], typeof(string)) :
        defaultValue;
    
    public static Supplier ReadSupplier(this IDataReader reader)
    {
      Supplier supplier = new Supplier();
      supplier.SupplierID = reader.GetInt32(0);
      supplier.CompanyName = SafeRead("CompanyName", reader, "");
      supplier.ContactName = SafeRead("ContactName", reader, "");
      supplier.ContactTitle = SafeRead("ContactTitle", reader, "");
      supplier.Address = SafeRead("Address", reader, "");
      supplier.City = SafeRead("City", reader, "");
      supplier.Region = SafeRead("Region", reader, "");
      supplier.PostalCode = SafeRead("PostalCode", reader, "");
      supplier.Country = SafeRead("Country", reader, "");
      supplier.Phone = SafeRead("Phone", reader, "");
      supplier.Fax = SafeRead("Fax", reader, "");
      supplier.HomePage = SafeRead("HomePage", reader, "");
      return supplier;
    }
  }
}
