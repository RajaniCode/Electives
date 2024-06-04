using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using clsDataContracts;


namespace WCF_Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        List<clsEmployee> GetAllEmployee();

        [OperationContract]
        [WebGet]
        List<clsSales> GetSalesDetails();

        [OperationContract]
        [WebGet]
        List<clsSalesData> GetSalesData();

        [OperationContract]
        [WebGet]
        List<clsStatewiseSales> GetStatewiseSales(); 
    }


     
}
