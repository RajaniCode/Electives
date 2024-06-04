using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Reflection;


namespace LinqToSqlConflictResolution
{
  class Program
  {
    static void Main(string[] args)
    {
      BackgroundWorker worker1 = new BackgroundWorker();
      worker1.DoWork += new DoWorkEventHandler(worker1_DoWork);
      BackgroundWorker worker2 = new BackgroundWorker();
      worker2.DoWork += new DoWorkEventHandler(worker1_DoWork);
      worker1.RunWorkerAsync("Speedy Distressed");
      worker2.RunWorkerAsync("Speedy Xpress");

      while(worker1.IsBusy || worker2.IsBusy)
        ;
      Console.ReadLine();
    }

    static void worker1_DoWork(object sender, DoWorkEventArgs e)
    {
      Northwind northwind = new Northwind();
      var one = northwind.Shippers.Single(r => r.ShipperID == 1);
      
      // Speedy Express
      one.CompanyName = (string)e.Argument;
      
      System.Threading.Thread.Sleep(2500);
      try
      {
        northwind.SubmitChanges(ConflictMode.FailOnFirstConflict);
      }
      catch(ChangeConflictException ex)
      {
        Console.WriteLine(ex.Message);
        foreach(ObjectChangeConflict conflict in northwind.ChangeConflicts)
        {
          // entity in conflict
          MetaTable meta = northwind.Mapping.GetTable(conflict.Object.GetType());
          Console.WriteLine("Table: {0}", meta.TableName);
          Console.WriteLine("Object:\n {0}", conflict.Object);

          // member in conflict
          foreach(MemberChangeConflict member in conflict.MemberConflicts)
          {
            var current = member.CurrentValue;
            var original = member.OriginalValue;
            var database = member.DatabaseValue;

            Console.WriteLine("Current:\n{0}", current);
            Console.WriteLine("Original:\n{0}", original);
            Console.WriteLine("Database:\n{0}", database);

            Console.WriteLine("1=Use database values, " + 
              "2=Use object values, 3=Merge values");

              string input = Console.ReadLine();
              int value = Convert.ToInt32(input);
              switch(value)
              {
                case 1:
                  conflict.Resolve(RefreshMode.KeepCurrentValues);
                  break;
                case 2:
                  conflict.Resolve(RefreshMode.OverwriteCurrentValues);
                  break;
                case 3:
                  conflict.Resolve(RefreshMode.KeepChanges);
                  break;
                default:
                  throw;
              }
          }
        }
        
        northwind.SubmitChanges(ConflictMode.FailOnFirstConflict);

      }
    }
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString =
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    public Northwind() : base(connectionString)
    {
      Log = Console.Out;
    }

    public Table<Shipper> Shippers
    {
      get { return this.GetTable<Shipper>(); }
    }
  }

  [Table(Name = "Shippers")]
  public class Shipper
  {
    [Column(IsPrimaryKey=true)]
    public int ShipperID { get; set; }
    
    [Column(UpdateCheck=UpdateCheck.WhenChanged)]
    public string CompanyName { get; set; }
    
    [Column(UpdateCheck=UpdateCheck.Never)]
    public string Phone { get; set; }

    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      PropertyInfo[] info = this.GetType().GetProperties();

      Array.ForEach(info, i=>
      {
        builder.AppendFormat("Name: {0}, Value: {1}\n",
          i.Name,
          i.GetValue(this, null) == null ? "none" : 
          i.GetValue(this, null));
      });

      return builder.ToString();
    }
  }
}
