using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IntroAjax;


public partial class DialogAnim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ddlCustomers_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
            UpdateView();
    }

    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateView();
    }

    #region Updating the screen view
    protected void UpdateView()
    {
        // Look up the customer
        Customer c = GetSelectedCustomer();

        // Update the visible panel 
        UpdateView(c);
    }

    protected void UpdateView(Customer c)
    {
        lblCustomerID.Text = c.ID;
        lblCompanyName.Text = c.CompanyName;
        lblContactName.Text = c.ContactName;
        lblCountry.Text = c.Country;
    }
    #endregion


    #region Helpers
    private Customer GetSelectedCustomer()
    {
        string id = ddlCustomers.SelectedValue;
        Customer c = CustomerManager.Load(id);
        return c;
    }
    #endregion
}
