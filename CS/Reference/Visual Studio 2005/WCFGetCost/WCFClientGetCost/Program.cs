using System;
using System.Collections.Generic;
using System.Text;
using WCFSampleGetCost;
namespace WFCClientGetCost
{
    class Program
    {
        static void Main(string[] args)
        {
            productData objproductData = new productData();
            objproductData.costPerProduct = 100;
            objproductData.Qty = 4;
            objproductData.strProductName = "Tooth Paste";
            ServiceGetCostProxy objServiceGetCostProxy = new ServiceGetCostProxy();
            Console.WriteLine(objServiceGetCostProxy.GetTotalCost(objproductData));
            Console.ReadLine();

        }
    }
}
