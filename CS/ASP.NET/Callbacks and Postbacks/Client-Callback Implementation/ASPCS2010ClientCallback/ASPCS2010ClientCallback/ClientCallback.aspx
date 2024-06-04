<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientCallback.aspx.cs"
    Inherits="ASPCS2010ClientCallback.ClientCallback" %>

<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" type="text/C#">
    // .NET Framework 4 - ASP.NET
    // Client-Callback Implementation (C#) Example
    // Demonstrates an ASP.NET Web page that implements a client callback.

    protected System.Collections.Specialized.ListDictionary catalog;

    protected string returnValue;

    protected void Page_Load(object sender, EventArgs e)
    {
        string cbReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
        string callbackScript = "function CallServer(arg, context)" + "{ " + cbReference + ";}";

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);

        catalog = new System.Collections.Specialized.ListDictionary();
        catalog.Add("Monitor", 11);
        catalog.Add("Laptop", 22);
        catalog.Add("Keyboard", 33);
        catalog.Add("Printer", 44);
        catalog.Add("Webcam", 55);
        catalog.Add("Scanner", 66);
        catalog.Add("Pendrive", 77);
        catalog.Add("Mike", 88);
        catalog.Add("Speaker", 99);
        catalog.Add("Modem", 100);

        ListBox1.DataSource = catalog;
        ListBox1.DataTextField = "key";
        ListBox1.DataBind();
    }

    public void RaiseCallbackEvent(string eventArgument)
    {
        if (catalog[eventArgument] == null)
        {
            returnValue = "-1";
        }
        else
        {
            returnValue = catalog[eventArgument].ToString();
        }
    }

    public string GetCallbackResult()
    {
        return returnValue;
    }
   
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Callback Example</title>
    <script type="text/javascript">
        function LookUpStock() {
            var lb = document.getElementById("ListBox1");
            if (lb.selectedIndex != -1) {
                var product = lb.options[lb.selectedIndex].text;
                CallServer(product, "");
            }
            else {
                alert("Please select an item from the list box.");
            }
        }

        function ReceiveServerData(rValue) {
            document.getElementById("ResultsSpan").innerHTML = rValue;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="ListBox1" runat="server" Width="10%"></asp:ListBox>
        <br />
        <br />
        <button type="button" onclick="LookUpStock()">
            Look Up Stock</button>
        <br />
        <br />
        Items in stock: <span id="ResultsSpan" runat="server"></span>
        <br />
    </div>
    </form>
</body>
</html>
