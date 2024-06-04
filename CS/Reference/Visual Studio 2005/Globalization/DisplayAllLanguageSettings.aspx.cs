using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Globalization;
using System.Threading;

/// <summary>
///  This program will display all the languages that the browser has
/// </summary>
public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        foreach(string strLang in Request.UserLanguages)
        {
            Response.Write(strLang + "<br>");
        }
        
    }
}
