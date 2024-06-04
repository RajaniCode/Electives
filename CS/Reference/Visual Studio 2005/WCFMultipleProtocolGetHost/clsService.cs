using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace WCFSampleGetCost
{
    [ServiceContract()]
    public interface IServiceGetCost
    {
        [OperationContract]
        string GetTotalCost(productData objProductData);
    }
    [DataContract]
    public struct productData
    {
        [DataMember] public int Qty;
        [DataMember] public string strProductName;
        [DataMember] public double costPerProduct;
    }
    public class serviceGetCost : IServiceGetCost
    {
        public string GetTotalCost(productData objProductData)
        {
            double totalCost = objProductData.Qty * objProductData.costPerProduct;
            return " The Product Name is " + objProductData.strProductName + 
            "and total cost is " + totalCost.ToString();

        }
    }
}

    