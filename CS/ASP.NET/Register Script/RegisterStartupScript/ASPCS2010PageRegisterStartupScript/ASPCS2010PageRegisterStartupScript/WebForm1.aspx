<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010PageRegisterStartupScript.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">  
    // Page.RegisterStartupScript Method
    // Note: This API is now obsolete.
    // Emits a client-side script block in the page response.    
    public void Page_Load(Object sender, EventArgs e)
    {
        if (!IsClientScriptBlockRegistered("PopupScript"))
        {
            string Script = "<script type=\"text/javascript\">" + "alert('Hello World!');</" + "script>";

            //This API is now obsolete.
            RegisterStartupScript("PopupScript", Script);
        }

        if (!IsClientScriptBlockRegistered("ButtonClickScript"))
        {
            StringBuilder ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("<script type=\"text/javascript\"> function DoClick() {");
            ScriptBuilder.Append("form1.Message.value='Text from client script.'} </");
            ScriptBuilder.Append("script>");

            //This API is now obsolete.
            RegisterClientScriptBlock("ButtonClickScript", ScriptBuilder.ToString());
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
        <input type="text" id="Message" />
        <input type="button" value="ClickMe" onclick="DoClick()" />
    </div>
    </form>
</body>
</html>
