using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSqlDatabinding
{
  public partial class _Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Northwind northwind = new Northwind();

      var products = from product in northwind.Products
                     select product;

      GridView1.DataSource = products;
      GridView1.DataBind();

    }

 
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=.\\SQLEXPRESS;AttachDbFilename=c:\\temp\\northwnd.mdf;" +
      "Integrated Security=True;Connect Timeout=30;User Instance=True";

    public Northwind()
      : base(connectionString)
    {
      Log = Console.Out;
    }

    public Table<ProductList> Products
    {
      get { return this.GetTable<ProductList>(); }
    }
  }

  [Table(Name = "Alphabetical list of products")]
  public class ProductList
  {
    [Column()]
    public int ProductID { get; set; }

    [Column()]
    public string ProductName{ get; set; }

    [Column()]
    public int SupplierID { get; set; }

    [Column()]
    public int CategoryID { get; set; }

    [Column()]
    public string QuantityPerUnit { get; set; }

    [Column()]
    public decimal UnitPrice { get; set; }

    [Column()]
    public Int16 UnitsInStock { get; set; }

    [Column()]
    public Int16 UnitsOnOrder { get; set; }

  }
}
