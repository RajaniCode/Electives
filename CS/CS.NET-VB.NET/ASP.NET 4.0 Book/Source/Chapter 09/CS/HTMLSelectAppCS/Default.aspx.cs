using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        span1.InnerHtml = "Selected Day: " + Select1.Value.ToString();
        int loopindex;
        span2.InnerHtml = "Selected month: ";

        for (loopindex = 0; loopindex <= Select2.Items.Count - 1; loopindex++)
        {
            if (Select2.Items[loopindex].Selected)
                span2.InnerHtml += Select2.Items[loopindex].Value.ToString() + " ";
        }
    }
}
