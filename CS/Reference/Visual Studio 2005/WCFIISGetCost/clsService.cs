using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCFSampleGetCost
{
    public class ServiceGetCost : IServiceGetCost
    {
        public string GetTotalCost(productData objProductData)
        {
            double totalCost = objProductData.Qty * objProductData.costPerProduct;
            return " The Product Name is " + objProductData.strProductName + 
            "and total cost is " + totalCost.ToString();

        }

    }
}

    