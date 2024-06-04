using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// base class for TransferPage1 and TransferPage2
// implements common tasks and can call method(s)
// in the concrete page class implementations 
public class PageControllerBase : Page
{
  // values that will be available in page class
  protected UserControl displayView = null;
  protected String displayViewName = String.Empty;
  protected String noViewSelectedText = "No View Selected";
  
  // define method that concrete page classes must implement
  // and will be called by this base class after Page_Load
  virtual protected void PageLoadEvent(Object sender, System.EventArgs e)
  { 
    // overridden in concrete page implementation
  }
  
  protected void Page_Load(Object sender, System.EventArgs e)
  {
    // get name of view (UserControl) to show in the page 
    displayViewName = Context.Request.QueryString["view"];
    if (displayViewName != null && displayViewName != String.Empty)
    {
      try
      {
        // load view from ASCX file
        displayView = (UserControl)Page.LoadControl(displayViewName + ".ascx");
      }
      catch { }
    }
    // call concrete page class method
    PageLoadEvent(sender, e);
  }
}
