using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for TypeSharingWebService1CS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class TypeSharingWebService1CS : System.Web.Services.WebService {

    public TypeSharingWebService1CS () {

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

    //[WebMethod]
    //public string HelloWorld() {
    //    return "Hello World";
    //}
    [WebMethod]
    public EmpDetails ObtainEmpDetail(string FName, string MName, string LName)
    {
        EmpDetails name = new EmpDetails();
        name.EmpFirstName = FName;
        name.EmpMiddleName = MName;
        name.EmpLastName = LName;
        return name;
    }

    
}
