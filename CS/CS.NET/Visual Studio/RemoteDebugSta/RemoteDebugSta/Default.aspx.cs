using System;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("This is only debug code " + DateTime.Now.ToString());
        }        
    }
}
