<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010CSMRegisterClientScriptBlock.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    // ClientScriptManager.RegisterClientScriptBlock Method (Type, String, String)
    // Registers the client script with the Page object using a type, key, and script literal.
    public void Page_Load(Object sender, EventArgs e)
    {
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager CSM = Page.ClientScript;

        // Check to see if the startup script is already registered.
        if (!CSM.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
        {
            StringBuilder ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("<script type=text/javascript> alert('Hello World!') </");
            ScriptBuilder.Append("script>");

            CSM.RegisterStartupScript(this.GetType(), "PopupScript", ScriptBuilder.ToString());
        }

        // Check to see if the client script is already registered.
        if (!CSM.IsClientScriptBlockRegistered(this.GetType(), "ButtonClickScript"))
        {
            StringBuilder ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("<script type=\"text/javascript\"> function DoClick() {");
            ScriptBuilder.Append("form1.Message.value='Text from client script.'} </");
            ScriptBuilder.Append("script>");

            CSM.RegisterClientScriptBlock(this.GetType(), "ButtonClickScript", ScriptBuilder.ToString());
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
        <input type="text" id="Message" /> <input type="button" value="ClickMe" onclick="DoClick()" />
    </div>
    </form>
</body>
</html>
