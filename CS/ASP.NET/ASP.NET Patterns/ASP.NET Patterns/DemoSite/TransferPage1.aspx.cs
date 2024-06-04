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

public partial class TransferPage1 : System.Web.UI.Page
{

  String viewName = String.Empty;

  protected void Page_Load(object sender, EventArgs e)
  {
    if (Page.IsPostBack)
    {
      // get current view name from page viewstate
      viewName = (String)ViewState["ViewName"];
    }
    else
    {
      viewName = "CustomerList";
      LoadAndDisplayView();
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

  protected void btn_Back_Click(object sender, EventArgs e)
  {
    switch (viewName)
    {
      case "CustomerDetails": 
        viewName = "CustomerList";
        break;
      case "CityList": 
        viewName = "CustomerDetails";
        break;
    }
    LoadAndDisplayView();
  }
  //---------------------------------------------------

  protected void btn_Next_Click(object sender, EventArgs e)
  {
    switch (viewName)
    {
      case "CustomerList":
        viewName = "CustomerDetails";
        break;
      case "CustomerDetails":
        viewName = "CityList";
        break;
    }
    LoadAndDisplayView();
  }
  //---------------------------------------------------

  protected void btn_Cancel_Click(object sender, EventArgs e)
  {
    Response.Redirect("Default.aspx");
  }
  //---------------------------------------------------

  private void LoadAndDisplayView()
  {
    // could alternatively use Server.Execute to execute
    // separate ASPX pages, each an MVP pattern implementation
    // that generates the appropriate output. However, User
    // Controls are probably easier to manage and more efficient
    // Each control contains its own initialization code.

    // load and display the appropriate view
    if (viewName != null && viewName != String.Empty)
    {
      try
      {
        UserControl view = (UserControl)LoadControl(viewName + ".ascx");
        viewPlaceHolder.Controls.Add(view);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot load view '" + viewName + "'", ex);
      }
    }
    else
    {
      viewName = "No view specified";
    }
    // set state of buttons to match view
    btn_Back.Enabled = (viewName != "CustomerList");
    btn_Next.Enabled = (viewName != "CityList");
    // display name of current view
    pageHeaderElement.InnerText = "Current View is '" + viewName + "'";
    // save in page viewstate for use in postback
    ViewState["ViewName"] = viewName;
  }
  //---------------------------------------------------
}
