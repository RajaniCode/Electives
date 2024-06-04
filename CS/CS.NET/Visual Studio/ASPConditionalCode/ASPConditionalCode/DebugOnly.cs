using System;
using System.Diagnostics;
using System.Web;

namespace WebApplication1
{    
    public class DebugOnly
    {
        [Conditional("DEVELOPMENT")]
        public void ShowDebugControls(System.Web.UI.WebControls.Label lbl)
        {
            lbl.Text = "Debug control displayed at: " + DateTime.Now.ToString();         
            lbl.Visible = true;
        }
    }
}
