using System;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ButtonClick = delegate(object s, CustomArgs c)
            {
                c.Cancel = false;
                c.NavigateTo = "~/WebForm1.aspx";
            };
        }
    }
}
