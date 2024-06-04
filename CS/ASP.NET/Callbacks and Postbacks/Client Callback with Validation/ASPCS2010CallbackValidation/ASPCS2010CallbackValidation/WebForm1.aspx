<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010CallbackValidation.WebForm1" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    protected System.Collections.Specialized.ListDictionary catalog;
    protected System.Collections.Specialized.ListDictionary saleitem;
    protected String returnValue;
    protected String validationLookUpStock = "LookUpStock";
    protected String validationLookUpSale = "LookUpSale";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            validationLookUpStock, "function LookUpStock() {  " +
            "var lb = document.forms[0].ListBox1; " +
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " +
            "var product = lb.options[lb.selectedIndex].text;  " +
            @"CallServer(product, ""LookUpStock"");}  ", true);
        if (User.Identity.IsAuthenticated)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            validationLookUpSale, "function LookUpSale() {  " +
            "var lb = document.forms[0].ListBox1; " +
            "if (lb.selectedIndex == -1) { alert ('Please make a selection.'); return; } " +
            "var product = lb.options[lb.selectedIndex].text;  " +
            @"CallServer(product, ""LookUpSale"");} ", true);
        }

        String cbReference = "var param = arg + '|' + context;" +
            Page.ClientScript.GetCallbackEventReference(this,
            "param", "ReceiveServerData", "context");
        String callbackScript;
        callbackScript = "function CallServer(arg, context)" +
            "{ " + cbReference + "} ;";
        Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
            "CallServer", callbackScript, true);

        catalog = new System.Collections.Specialized.ListDictionary();
        saleitem = new System.Collections.Specialized.ListDictionary();
        catalog.Add("monitor", 12);
        catalog.Add("laptop", 10);
        catalog.Add("keyboard", 23);
        catalog.Add("mouse", 17);
        saleitem.Add("monitor", 1);
        saleitem.Add("laptop", 0);
        saleitem.Add("keyboard", 0);
        saleitem.Add("mouse", 1);

        ListBox1.DataSource = catalog;
        ListBox1.DataTextField = "key";
        ListBox1.DataBind();
    }
    public void RaiseCallbackEvent(String eventArgument)
    {
        string[] argParts = eventArgument.Split('|');
        if ((argParts == null) || (argParts.Length != 2))
        {
            returnValue = "A problem occurred trying to retrieve stock count.";
            return;
        }
        string product = argParts[0];
        string validationaction = argParts[1];
        switch (validationaction)
        {
            case "LookUpStock":
                try
                {
                    Page.ClientScript.ValidateEvent("LookUpStockButton", validationaction);
                    if (catalog[product] == null)
                    {
                        returnValue = "Item not found.";
                    }
                    else
                    {
                        returnValue = catalog[product].ToString() + " in stock.";
                    }
                }
                catch
                {
                    returnValue = "Can not retrieve stock count.";
                }
                break;
            case "LookUpSale":
                try
                {
                    Page.ClientScript.ValidateEvent("LookUpSaleButton", validationaction);
                    if (saleitem[product] == null)
                    {
                        returnValue = "Item not found.";
                    }
                    else
                    {
                        if (Convert.ToBoolean(saleitem[product]))
                            returnValue = "Item is on sale.";
                        else
                            returnValue = "Item is not on sale.";
                    }
                }
                catch
                {
                    returnValue = "Can not retrieve sale status.";
                }
                break;
        }

    }
    public String GetCallbackResult()
    {
        return returnValue;
    }
    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation("LookUpStockButton",
            validationLookUpStock);
        if (User.Identity.IsAuthenticated)
        {
            Page.ClientScript.RegisterForEventValidation("LookUpSaleButton",
                validationLookUpSale);
        }
        base.Render(writer);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Callback with Validation Implementation Example</title>
    <script type="text/javascript">
        function ReceiveServerData(rValue) {
            Results.innerText = rValue;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox id="ListBox1" runat="server" Width="10%"></asp:ListBox>
        <br />
        <br />
        <button id="LookUpStockButton" type="button" onclick="LookUpStock()">Look Up Stock</button>
        <asp:LoginView id="LoginView1" runat="server">
        <LoggedInTemplate>
        <button id="LookUpSaleButton" type="button" onclick="LookUpSale()">Look Up Back Order</button>
        </LoggedInTemplate>
        </asp:LoginView>
        <br />
        Item status: <span id="Results"></span>
    </div>
    </form>
</body>
</html>
