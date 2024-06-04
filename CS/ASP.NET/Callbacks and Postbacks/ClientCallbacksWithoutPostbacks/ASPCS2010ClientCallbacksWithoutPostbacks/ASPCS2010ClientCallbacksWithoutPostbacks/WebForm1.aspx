<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010ClientCallbacksWithoutPostbacks.WebForm1" %>

<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    public void RaiseCallbackEvent(String eventArgument)
    {

    }

    public string GetCallbackResult()
    {
        return "aStringValue";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager CSM = Page.ClientScript;

        string cbReference = CSM.GetCallbackEventReference(this, "arg", "ReceiveServerData", "");

        string callbackScript = "function CallServer(arg, context) {" + cbReference + "; }";

        CSM.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ReceiveServerData(arg, context) {
            Message.innerText = 'Processed callback.';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="Callback" onclick="CallServer(1, alert('Callback'))" />
        <br />
        <span id="Message"></span>
    </div>
    </form>
</body>
</html>
