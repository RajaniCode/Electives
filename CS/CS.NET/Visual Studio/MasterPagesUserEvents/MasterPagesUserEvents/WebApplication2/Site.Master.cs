using System;

namespace WebApplication2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public EventHandler<CustomArgs> ButtonClick;           
        protected void Button1_Click(object sender, EventArgs e)
        {
            lblValue.Text = null;
            if (ButtonClick != null)
            {
                CustomArgs args = new CustomArgs();
                ButtonClick(sender, args);
                if (args.Cancel)
                {
                    lblValue.Text = args.Message;
                }
                else
                {
                    Response.Redirect(args.NavigateTo);
                }
            }            
        }
    }
}
