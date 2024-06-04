using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
//using Inheritance;

namespace InheritanceHierarchy
{
  class Program
  {
    static void Main(string[] args)
    {
      Inheritance inherit = new Inheritance();
      Table<Person> people = inherit.GetTable<Person>();

      Array.ForEach(people.Where(
        person => person.GetType() == typeof(Patient)).ToArray(), r => Console.WriteLine(r));
      Console.ReadLine();
    }
  }

  [Database(Name = "Inheritance")]
  public class Inheritance : DataContext
  {
    private static readonly string connectionString =
      "Data Source=.\\SQLEXPRESS;Initial Catalog=Inheritance;" +
      "Integrated Security=True;Pooling=False";

    public Inheritance()
      : base(connectionString)
    {
      this.Log = Console.Out;
    }

    public Table<Patient> GetPatients()
    {
      return this.GetTable<Patient>();
    }

    public Table<VendorContact> GetVendors()
    {
      return this.GetTable<VendorContact>();
    }
  }



  [Table(Name="Person")]
  [InheritanceMapping(Code = "P", Type = typeof(Person), IsDefault = true)]
  [InheritanceMapping(Code = "A", Type = typeof(Patient))]
  [InheritanceMapping(Code = "V", Type = typeof(VendorContact))]
  public class Person
  {
    [Column(IsPrimaryKey = true)]
    public int PersonID { get; set; }

    [Column(IsDiscriminator = true)]
    public char KindKey { get; set; }

    [Column()]
    public string FirstName { get; set; }

    [Column()]
    public string LastName { get; set; }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("Type: {0}\n", this.GetType().Name);

      PropertyInfo[] props = this.GetType().GetProperties();

      // using array for each
      Array.ForEach(props.ToArray(), prop =>
        builder.AppendFormat("{0} : {1}", prop.Name,
          prop.GetValue(this, null) == null ? "<empty>\n" :
          prop.GetValue(this, null).ToString() + "\n"));

      return builder.ToString();
    }
  }

  public class Patient : Person
  {
    [Column()]
    public char Gender { get; set; }

    [Column()]
    public int Age { get; set; }

    [Column(CanBeNull = true)]
    public DateTime? DateOfLastVisit { get; set; }
  }

  public class VendorContact : Person
  {
    [Column()]
    public string Title { get; set; }

    [Column()]
    public int CompanyID { get; set; }
  }
}

