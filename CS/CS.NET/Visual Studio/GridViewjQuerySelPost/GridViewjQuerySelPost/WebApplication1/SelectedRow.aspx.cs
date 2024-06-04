using System;

namespace WebApplication1
{
    public partial class SelectedRow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Selection"] != null)
	        {
                lblSelectedRow.Text = "Selected ID is " + Session["Selection"] as string;
	        }            
        }
    }
}
