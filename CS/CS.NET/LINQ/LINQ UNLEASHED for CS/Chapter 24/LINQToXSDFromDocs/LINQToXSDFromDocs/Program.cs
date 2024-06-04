using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using www.example.com.Orders;

namespace LINQToXSDFromDocs
{
  class Program
  {

    static double CalculateTotal(Batch batch) 
    {
      return
        (from purchaseOrder in batch.PurchaseOrder
         from item in purchaseOrder.Item
         select item.Price * item.Quantity
         ).Sum();
    }

    public static void Main(string[] args)
    {
        // Load an element with orders
        var os = Batch.Load("../../XMLFile1.xml");

        // Calculuate and print the total
        var total = CalculateTotal(os);
        Console.WriteLine(total);
        Console.ReadLine();
    }
  }
}
