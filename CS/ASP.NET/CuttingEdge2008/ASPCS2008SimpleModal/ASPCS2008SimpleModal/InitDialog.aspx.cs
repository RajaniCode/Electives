using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008SimpleModal
{
    public partial class InitDialog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        protected void ddlCustomers_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UpdateView();
        }

        // This button click triggers the modal dialog box. 
        protected void btnEditText_Click(object sender, EventArgs e)
        {
            // Initialize the controls in the panel used as the UI of the dialog box
            InitializeDialog();

            // The panel markup has been served already to the page. To edit it, 
            // you need to a) wrap the panel's content in an UpdatePanel region and 
            // b) update the panel once you made any changes
            ModalPanel1.Update();

            // Order to inject the script to show the dialog as the page loads up 
            // in the browser.
            ModalPopupExtender1.Show();
        }

        // This button handles a postback from the client dialog (the Apply button)
        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Edit the server controls in the modal panel. Because the 
            // call occurs over a partial rendering call, any updates
            // will be automatically reflected by the client UI.
            if (editTxtCountry.Text == "Germany")
                editTxtCountry.Text = "Cuba";
            else
                editTxtCountry.Text = "USA";
        }

        protected void editBox_OK_Click(object sender, EventArgs e)
        {
            // Save to the database
            // :

            // Refresh the UI
            lblCompanyName.Text = editTxtCompanyName.Text;
            lblContactName.Text = editTxtContactName.Text;
            lblCountry.Text = editTxtCountry.Text;
        }

        #region Initializing the modal dialog
        protected void InitializeDialog()
        {
            // Look up the customer
            Customer c = GetSelectedCustomer();

            // Update the modal dialog before display 
            InitializeDialog(c);
        }

        protected void InitializeDialog(Customer c)
        {
            editCustomerID.Text = c.ID;
            editTxtCompanyName.Text = c.CompanyName;
            editTxtContactName.Text = c.ContactName;
            editTxtCountry.Text = c.Country;

            SetFocus("editTxtCompanyName");
        }
        #endregion


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
}
