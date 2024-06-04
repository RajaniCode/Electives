<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ClientCallbacksWithoutPostbacks._Default" %>

<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--Implementing Client Callbacks Programmatically Without Postbacks in ASP.NET Web Pages--%>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Client Callbacks</title>
    <script runat="server">
        public void RaiseCallbackEvent(String eventArgument)
        {
            // Processes a callback event on the server using the event
            // argument from the client.
        }

        public string GetCallbackResult()
        {
            // Returns the results of a callback event to the client.
            string dateString = DateTime.Now.ToLongDateString();

            return dateString;
        }

        void Page_Load(object sender, EventArgs e)
        {
            ClientScriptManager cm = Page.ClientScript;
            String cbReference = cm.GetCallbackEventReference(this, "arg",
                "ReceiveServerData", "");
            String callbackScript = "function CallServer(arg, context) {" +
                cbReference + "; }";
            cm.RegisterClientScriptBlock(this.GetType(),
                "CallServer", callbackScript, true);

            //if (!IsPostBack)
            //{

            //}
        }
    </script>
    <script type="text/javascript">
        function ReceiveServerData(arg, context) {
            Message.innerText = "Date from server: " + arg;
        }
    </script>
</head>
<body>
    <h2>Client Callbacks Without Postbacks</h2>
    <form id="form1" runat="server">
       <input type="button" value="Callback" 
           onclick="CallServer('1', alert('Callback sent to Server'))" />
       <br />
       <span id="Message"></span>
   </form>
</body>
</html>
