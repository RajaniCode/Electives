<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SomePage.aspx.cs" Inherits="ASPCS2008ViewState.SomePage" 
EnableViewState="true" ViewStateEncryptionMode="Always" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
    <p>
        <span lang="en-us">Wellcome to Some Page! </span>
    </p>
    
    <p>
    <asp:Button ID="Button2" runat="server" Text="Go back" onclick="Button2_Click" />
    </p>
    <div>
    
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
