using System;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.ButtonClick += new EventHandler<CustomArgs>(MasterButtonClick);
        }

        private void MasterButtonClick(object sender, CustomArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                e.Cancel = false;
                e.NavigateTo = "~/WebForm2.aspx";
            }
            else
            {
                e.Cancel = true;
                e.Message = "There was no text entered...";
            }            
        }
    }
}
