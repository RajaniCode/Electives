using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }  

    protected void btnHandled_Click(object sender, EventArgs e)
    {
        try
        {
            throw new Exception("Sample Exception");
        }
        catch (Exception ex)
        {
            // Log the error to a text file in the Error folder
            ErrHandler.WriteError(ex.Message);
        }
    }

    protected void btnUnhandled_Click(object sender, EventArgs e)
    {
        int i = 1;
        int j = 0;
        Response.Write(i / j);
    }
}
