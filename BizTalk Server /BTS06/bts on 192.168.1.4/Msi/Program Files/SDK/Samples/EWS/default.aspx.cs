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
        // This method makes use of the Web Service exposed by BizTalk Server.
        // Static data is constructed here and is then sent to the Web Service.
        // The Web Service replies echoing back the zip code specified in the
        // code below.            

        localhost.ClientRequest oCR;
        localhost.ClientRequestAddress oCRA;
        localhost.CompanyRequest oCoReq;
        localhost.Microsoft_Samples_BizTalk_ExposeWebService_ProcessClientRequest_SOAPPort oWSMethodCall;

        oCR = new localhost.ClientRequest();
        oCRA = new localhost.ClientRequestAddress();
        oCoReq = new localhost.CompanyRequest();
        oWSMethodCall = new localhost.Microsoft_Samples_BizTalk_ExposeWebService_ProcessClientRequest_SOAPPort();

        oCRA.Street = "One Microsoft Way";
        oCRA.City = "Redmond";
        oCRA.State = "WA";
        oCRA.Zip = "98052";

        oCR.Address = oCRA;
        oCR.AppraisalValue = "123.45";
        oCR.CoverageRequested = "3000.00";
        oCR.Name = "Building 3";

        oCoReq = oWSMethodCall.Operation_1(oCR);
        Response.Write(HttpUtility.HtmlEncode("The area code specified is: " + oCoReq.LocationCode));
    }
}