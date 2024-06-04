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
        if ((FileName.Value.ToString() == "") || (File1.Value.ToString() == ""))
        {
            messagearea.InnerHtml = "Error: You must enter a file name.";
            return;
        }

        if (File1.PostedFile.ContentLength > 0)
        {
            try
            {
                File1.PostedFile.SaveAs("C:/" + FileName.Value.ToString());
                messagearea.InnerHtml = "File uploaded successfully";

            }
            catch (Exception ex)
            {
                messagearea.InnerHtml = "Error saving file.";
            }

        }
    }

}
