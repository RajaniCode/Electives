using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Diagnostics;

namespace PartialMethodDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      CustomerList customers = new CustomerList
      {
        new Customer{CustomerID=1, Name="Levi, Ray and Shoup"},
        new Customer{CustomerID=2, Name="General Dynamics Land Systems"},
        new Customer{CustomerID=3, Name="Microsoft"}
      };

      customers.Dump();
      Console.ReadLine();
    }
  }

  public partial class CustomerList 
  {
    private string propertyName;
    private SortDirection direction;

    partial void SpecialSort(string propertyName, SortDirection direction)
    {
      this.propertyName = propertyName;
      this.direction = direction;
      Sort(Comparer);
    }

    /// <summary>
    /// Using an integer to change the direction of the sort was a suggestion made by 
    /// Chris Chartran, my good friend from Canada
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private int Comparer(Customer x, Customer y)
    {
      try
      {
        PropertyInfo lhs = x.GetType().GetProperty(propertyName);
        PropertyInfo rhs = y.GetType().GetProperty(propertyName);

        int directionChanger = direction == SortDirection.Ascending ? 1 : -1;

        object o1 = lhs.GetValue(x, null);
        object o2 = rhs.GetValue(y, null);
        
        if(o1 is IComparable && o2 is IComparable)
        {
          return ((IComparable)o1).CompareTo(o2) * directionChanger;
        }

        // no sort
        return 0;
      }
      catch(Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return 0;
      }
    }
  }


  public partial class CustomerList : List<Customer>
  {
    partial void SpecialSort(string propertyName, SortDirection direction);

    public void Dump()
    {
      SpecialSort("CustomerID", SortDirection.Descending);
      
      foreach(var customer in this)
        Console.WriteLine(customer.ToString());
    }
  }
  

  public class Customer
  {
    private int customerID;
    public int CustomerID
    {
    	get
    	{
    		return customerID;
    	}
    	set
    	{
    		customerID = value;
    	}
    }

    private string name;
    public string Name
    {
    	get
    	{
    		return name;
    	}
    	set
    	{
    		name = value;
    	}
    }

    public override string ToString()
    {
      return string.Format("CustomerID={0}, Name={1}", CustomerID, Name);
    }
  }
}
