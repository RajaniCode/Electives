using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.MobileControls;

using System.ServiceModel.Web;

namespace WCF_DMLService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/CreateEmployee/{empNo}/{empName}/{salary}/{deptNo}",
            Method="POST")]
        int InsertEmployee(string empNo, string empName, string salary, string deptNo);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/DeleteEmployee/{empNo}",
            Method = "POST")]
        int DeleteEmployee(string empNo);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare
            )]
        Employee[] GetAllEmployee(); 
    }

    [DataContract(Name="Employee",Namespace="")]
    public class Employee
    {
        [DataMember]
        public int EmpNo { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public int DeptNo { get; set; }
        [DataMember]
        public int Salary { get; set; }
    }
 }
