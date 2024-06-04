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
using System.Xml;

public partial class CSRMainForm : System.Web.UI.Page
{
    protected SouthridgeVideo_OrderBroker.Microsoft_Samples_BizTalk_SouthridgeVideo_OrderBroker_OrderBrokerOrch_OrderPort orderPort;

    protected void Page_Load(object sender, EventArgs e)
    {
        orderPort = new SouthridgeVideo_OrderBroker.Microsoft_Samples_BizTalk_SouthridgeVideo_OrderBroker_OrderBrokerOrch_OrderPort();
        orderPort.Credentials = System.Net.CredentialCache.DefaultCredentials;
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        SouthridgeVideo_OrderBroker.CSR_OrderRequest orderRequest = ConstructOrderRequest();
        orderRequest.RequestHeader.OrdStatus = "NEW";
        CSRMessageLabel.Text = "Customer ID " + orderRequest.RequestHeader.CRN + "\nOrder ID " + orderRequest.RequestHeader.ORN + "\nSequence Number " + orderRequest.RequestHeader.ORNSeq;
        orderPort.SubmitOrder(orderRequest);
    }

    protected void TerminateButton_Click(object sender, EventArgs e)
    {
        SouthridgeVideo_OrderBroker.CSR_OrderRequest orderRequest = ConstructOrderRequest();
        orderRequest.RequestHeader.OrdStatus = "TERMINATE";
        orderPort.SubmitOrder(orderRequest);
    }

    private SouthridgeVideo_OrderBroker.CSR_OrderRequest ConstructOrderRequest()
    {
        SouthridgeVideo_OrderBroker.CSR_OrderRequest orderRequest = new SouthridgeVideo_OrderBroker.CSR_OrderRequest();

        orderRequest.Header = new SouthridgeVideo_OrderBroker.CSR_OrderRequestHeader();
        orderRequest.Header.ReqId = Guid.NewGuid().ToString();
        orderRequest.Header.RequestType = "CSR Placed Order";
        orderRequest.Header.SourceSystem = "MSMQ://FORMATNAME:DIRECT=HTTP://localhost/msmq/private$/ToCSRSystemQ"; //"file://c:\\BPMTest\\CSRResponse-DSP\\%MessageID%.xml";
        orderRequest.Header.Timestamp = DateTime.Now;

        orderRequest.RequestHeader = new SouthridgeVideo_OrderBroker.CSR_OrderRequestRequestHeader();
        orderRequest.RequestHeader.CRN = CustomerIDTextBox.Text;
        orderRequest.RequestHeader.ORN = OrderIDTextBox.Text;
        orderRequest.RequestHeader.OrdDate = DateTime.Today;
        orderRequest.RequestHeader.OrdTypeCode = OrderTypeCodeDropDownList.SelectedValue;
        orderRequest.RequestHeader.OrdStatus = "NEW";
        orderRequest.RequestHeader.ORNSeq = Convert.ToInt32(SequenceNumberTextBox.Text);

        orderRequest.RequestInfo = new SouthridgeVideo_OrderBroker.CSR_OrderRequestRequestInfo();
        orderRequest.RequestInfo.Address1 = "1 Interesting Lane";
        orderRequest.RequestInfo.Address2 = "Apt 2";
        orderRequest.RequestInfo.City = "New City";
        orderRequest.RequestInfo.CompletionDate = DateTime.Today.AddDays(2);
        orderRequest.RequestInfo.ContactName = "John Doe";
        orderRequest.RequestInfo.ContactPhone = "555-1234";
        orderRequest.RequestInfo.CS_Notes = "Customer has a dog";
        orderRequest.RequestInfo.CS_Office = "New City Office";
        orderRequest.RequestInfo.CS_RepId = "CSRRep1";
        orderRequest.RequestInfo.StartDate = DateTime.Today;
        orderRequest.RequestInfo.State = "Washington";
        orderRequest.RequestInfo.WorkOrderType = "Service Update";
        orderRequest.RequestInfo.Zip = "98052";

        return orderRequest;
    }
}
