using System;
using System.Collections.Generic;
using System.Web.Services;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static List<EmployeeCar> FetchEmployeeCars(int id)
        {
            var emp = new EmployeeCar();
            return emp.FetchEmployeeCars(id);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employees = new Employee();
                ddlEmployee.DataSource = employees.FetchEmployees();
                ddlEmployee.DataTextField = "Surname";
                ddlEmployee.DataValueField = "Id";
                ddlEmployee.DataBind();
            }
        }
    }
}
