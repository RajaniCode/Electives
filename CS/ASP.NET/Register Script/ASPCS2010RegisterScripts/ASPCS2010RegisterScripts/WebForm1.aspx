<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010RegisterScripts.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    // RegisterStartupScript VS RegisterClientScriptBlock
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScriptManager CSM = Page.ClientScript;

        // Check to see if the startup script is already registered.
        // if (!CSM.IsClientScriptBlockRegistered(this.GetType(), "PopupScript")) // Button loads after alert 
        if (!CSM.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
        {
            StringBuilder ScriptBuilder = new StringBuilder();
            ScriptBuilder.Append("<script type=text/javascript> alert('Hello World!') </");
            ScriptBuilder.Append("script>");

            // CSM.RegisterClientScriptBlock(this.GetType(), "PopupScript", ScriptBuilder.ToString()); // Button loads after alert 
            CSM.RegisterStartupScript(this.GetType(), "PopupScript", ScriptBuilder.ToString());
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScriptManager CSM = Page.ClientScript;

        // if (!CSM.IsStartupScriptRegistered(this.GetType(), "ButtonClickScript")) // Works fine
        if (!CSM.IsClientScriptBlockRegistered(this.GetType(), "ButtonClickScript"))
        {
            StringBuilder FunctionBuilder = new StringBuilder();
            FunctionBuilder.Append("<script type=\"text/javascript\"> function ChangeColor() {");
            FunctionBuilder.Append("var lbl = document.getElementById('Label1');");
            FunctionBuilder.Append("lbl.style.color = '#FF0000';} </");
            FunctionBuilder.Append("script>");

            // CSM.RegisterStartupScript(this.GetType(), "ButtonClickScript", FunctionBuilder.ToString()); // Works fine
            CSM.RegisterClientScriptBlock(this.GetType(), "ButtonClickScript", FunctionBuilder.ToString());
        }

        if (!CSM.IsStartupScriptRegistered("JSScript"))
        {
            string FunctionCall = "<script type=\"text/javascript\">ChangeColor();</" + "script>";

            CSM.RegisterStartupScript(this.GetType(), "JSScript", FunctionCall);
        }

        /* // Works fine
        if (!ClientScript.IsStartupScriptRegistered("JSScript"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "JSScript", FunctionCall);
        }
        */
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegisterStartupScript VS RegisterClientScriptBlock</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </div>
    </form>
</body>
</html>
