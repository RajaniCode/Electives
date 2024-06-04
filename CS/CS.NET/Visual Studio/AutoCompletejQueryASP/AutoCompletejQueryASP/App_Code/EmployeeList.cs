using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Script.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class EmployeeList : System.Web.Services.WebService
{
[WebMethod]
public List<Employee> FetchEmailList(string mail)
{
    var emp = new Employee();
    var fetchEmail = emp.GetEmployeeList()
    .Where(m => m.Email.ToLower().StartsWith(mail.ToLower()));
    return fetchEmail.ToList();
}    
}

