using System;
using System.Collections;
using System.Web;

public partial class TransferPage4 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // display actual URL of currently executing page
    lblActualPath.Text = Request.CurrentExecutionFilePath;
    String qs = Request.QueryString.ToString();
    if (qs != null && qs != String.Empty)
    {
      lblActualPath.Text += '?' + qs;
    }
  }
  //------------------------------------------------

  protected void btn_Build_Click(object sender, EventArgs e)
  {
    // create instance of subject class will raise the 
    // BuildCarEvent through its helper class BuildCarHelper
    EventProductionLine pLine = new EventProductionLine();

    // create instances of required subscriber classes 
    EventPartsDept parts = new EventPartsDept();
    EventTransportDept transport = new EventTransportDept();
    EventSalesDept sales = new EventSalesDept();

    // subscribe them to the BuildCarEvent of the publisher (the 
    // EventProductionLine class) according to settings in page
    if (chk_Parts.Checked)
    {
      pLine.Helper.BuildCarEvent += parts.BuildCarEventHandler;
    }
    if (chk_Transport.Checked)
    {
      pLine.Helper.BuildCarEvent += transport.BuildCarEventHandler;
    }
    if (chk_Sales.Checked)
    {
      pLine.Helper.BuildCarEvent += sales.BuildCarEventHandler;
    }

    // call the main method of the subject class to do the
    // actual work required, specifying any properties required
    // in this example, just the name of the car to build
    pLine.BuildNewMotorCar(lstCarName.SelectedValue);

    // display counter values from subscribers to show that they
    // were notified by the EventProductionLine main routine
    lblResults.Text += "<b>Cars to deliver</b>: "
                    + ShowAllCarsCount(transport.CountOfCarsToDeliver);
    lblResults.Text += "<b>Cars available to sell</b>: "
                    + ShowAllCarsCount(sales.CountOfCarsBuilt);
    lblResults.Text += "<b>Parts to order</b>: "
                    + ShowAllCarsCount(parts.CountOfPartsUsed);
  }
  //------------------------------------------------

  private String ShowAllCarsCount(Hashtable values)
  {
    // get list of car models and count as a String
    String result = String.Empty;
    foreach (DictionaryEntry item in values)
    {
      result += item.Key.ToString() + ":" + item.Value.ToString() + " ";
    }
    return result + "<br />";
  }
  //------------------------------------------------

  protected void btn_Close_Click(object sender, EventArgs e)
  {
    Response.Redirect("Default.aspx");
  }
  //------------------------------------------------
}
