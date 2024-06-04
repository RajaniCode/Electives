using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var names = new List<Employee>();
                names.Add(new Employee() { ID = 1, Surname = "sheridan", GivenName = "malcolm", Department = "sales" });
                names.Add(new Employee() { ID = 2, Surname = "sheridan", GivenName = "debby", Department = "it" });
                names.Add(new Employee() { ID = 3, Surname = "sheridan", GivenName = "livvy", Department = "real estate" });
                grdEmployee.DataSource = names;
                grdEmployee.DataBind();
            }
            
            ClientScript.GetPostBackEventReference(new System.Web.UI.PostBackOptions(this));
            if (!string.IsNullOrEmpty(Request.Form["__EVENTTARGET"]))
            {
                if (Request.Form["__EVENTTARGET"] == "javaScriptEvent")
                {
                    ProcessGridSelection(Request.Form["__EVENTARGUMENT"]);
                }
            }
        }

        private void ProcessGridSelection(string p)
        {
            Session["Selection"] = p;   
            Response.Redirect("~/SelectedRow.aspx");
        }
    }
}
