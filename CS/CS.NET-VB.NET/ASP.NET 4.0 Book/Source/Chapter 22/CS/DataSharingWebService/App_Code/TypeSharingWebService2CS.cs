using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for TypeSharingWebService2CS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TypeSharingWebService2CS : System.Web.Services.WebService {

    public TypeSharingWebService2CS () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public class EmpDetails
    {
        public string EmpFirstName;
        public string EmpMiddleName;
        public string EmpLastName;
        public string EmpID;
        public string EmpDesignation;
    }
    [WebMethod]
    public EmpDetails UpdateEmpDetail(EmpDetails name, string FID, string FDesignation)
    {
        //EmpDetails name = new EmpDetails();
        name.EmpID = FID;
        name.EmpDesignation = FDesignation;
        return name;
    }

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}


    
}
