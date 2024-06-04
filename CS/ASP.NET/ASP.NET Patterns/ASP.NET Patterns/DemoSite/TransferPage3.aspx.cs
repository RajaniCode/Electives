using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TransferPage3 : PageControllerBase
{

  // override virtual method in PageControllerBase class
  protected override void PageLoadEvent(Object sender, System.EventArgs e)
  {
    // use values that were set in base class Page_Load event
    if (displayView != null)
    {
      pageTitleElement.Text = "Displaying view '" + displayViewName + "'";
      pageHeadingElement.InnerHtml = "Displaying view '" + displayViewName + "'";
      PlaceHolder1.Controls.Add(displayView);
    }
    else
    {
      pageHeadingElement.InnerHtml = noViewSelectedText;
    }
    // display actual URL of currently executing page
    lblActualPath.Text = Request.CurrentExecutionFilePath;
    String qs = Request.QueryString.ToString();
    if (qs != null && qs != String.Empty)
    {
      lblActualPath.Text += '?' + qs;
    }
  }
  //---------------------------------------------------
  
  protected void btn_Close_Click(object sender, EventArgs e)
  {
    Response.Redirect("Default.aspx");
  }
  //---------------------------------------------------
}
