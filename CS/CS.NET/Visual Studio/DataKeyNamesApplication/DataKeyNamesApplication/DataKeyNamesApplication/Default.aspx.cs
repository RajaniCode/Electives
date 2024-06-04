using System;
using System.Collections.Generic;

namespace DataKeyNamesApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Customer> customers = new List<Customer>();
                customers.Add(new Customer()
                {
                    ID = 123,
                    GivenName = "Steve",
                    Surname = "Jobs",
                    EmailAddress = "steve@apple.com",
                    NickName = "Steve"
                });

                customers.Add(new Customer()
                {
                    ID = 789,
                    GivenName = "Bill",
                    Surname = "Gates",
                    EmailAddress = "bgates@microsoft.com",
                    NickName = "Bill"
                });

                grdCustomer.DataSource = customers;
                grdCustomer.DataBind();
            }
        }

        protected void grdCustomer_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            object dataKeyValue = grdCustomer.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
        }
    }
}
