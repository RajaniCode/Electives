using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public class Customer
    {
        public int Key;
        public string Name;
    }
    public class Order
    {
        public int Key;
        public string OrderNumber;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var customers = new List<Customer>()
		{
			new Customer {Key = 1, Name = "Neha" },
			new Customer {Key = 2, Name = "Amar" },
			new Customer {Key = 3, Name = "Neeraj" },
			new Customer {Key = 4, Name = "Priya" },
			new Customer {Key = 5, Name = "Jyoti" }
		};
        var orders = new List<Order>() 
		{
			new Order {Key = 1, OrderNumber = "Number 1" },
			new Order {Key = 2, OrderNumber = "Number 2" },
			new Order {Key = 3, OrderNumber = "Number 3" },
			new Order {Key = 4, OrderNumber = "Number 4" },
			new Order {Key = 5, OrderNumber = "Number 5" }
		};
        var q = from c in customers
                join o in orders on c.Key equals o.Key
                select new { c.Name, o.OrderNumber };
        foreach (var i in q)
        {
            ListBox1.Items.Add(i.OrderNumber.ToString() + " " + i.Name);
        }

    }
}