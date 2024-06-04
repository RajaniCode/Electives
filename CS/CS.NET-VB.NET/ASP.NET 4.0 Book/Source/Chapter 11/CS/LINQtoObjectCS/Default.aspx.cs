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
        List<Customer> customers = GetCustomers();
        var q = from c in customers
                where c.CustAge > 30
                select c;
        foreach (var i in q)
        {
            ListBox1.Items.Add(i.CustName + ":   " + i.CustAge.ToString());
        }

    }
    List<Customer> GetCustomers()
    {
        List<Customer> custs = new List<Customer>();
        custs.Add(new Customer(1001, "Amit", 10));
        custs.Add(new Customer(1002, "Neha", 50));
        custs.Add(new Customer(1003, "Priya", 30));
        custs.Add(new Customer(1004, "Sneha", 40));
        custs.Add(new Customer(1005, "Jiya", 50));
        custs.Add(new Customer(1006, "Jaison", 10));
        custs.Add(new Customer(1007, "Puja", 20));
        custs.Add(new Customer(1008, "Frenscesco", 30));
        custs.Add(new Customer(1009, "Feni", 40));
        custs.Add(new Customer(10010, "Era", 50));
        custs.Add(new Customer(10011, "Raj", 60));
        custs.Add(new Customer(10012, "Vijay", 20));
        custs.Add(new Customer(10013, "Mudita", 30));
        custs.Add(new Customer(10014, "Nancy", 40));
        custs.Add(new Customer(10015, "Kapil", 10));
        return custs;
    }

}