using System;
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
    }}