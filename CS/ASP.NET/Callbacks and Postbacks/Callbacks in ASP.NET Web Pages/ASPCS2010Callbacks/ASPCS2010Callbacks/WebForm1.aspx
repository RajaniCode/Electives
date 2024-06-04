<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010Callbacks.WebForm1" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    string returnValue;
    
    public string GetCallbackResult()
    {
        return returnValue;
    }

    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation("ClientCallback1");
        base.Render(writer);
    }
    
    public void RaiseCallbackEvent(String eventArgument)
    {
        try
        {
            Page.ClientScript.ValidateEvent("ClientCallback1");
            // Callback logic goes here.
            returnValue = "callback result";
        }
        catch
        {
            // Failed callback validation logic.
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
