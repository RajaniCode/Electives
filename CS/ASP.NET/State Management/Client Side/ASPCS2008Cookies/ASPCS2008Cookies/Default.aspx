<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008Cookies._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>    

    <div>    
        <asp:Button ID="Button1" runat="server" Text="Write Cookie" onclick="Button1_Click" />
        &nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Modify Cookie" />
        &nbsp;      
        <asp:Button ID="Button3" runat="server" Text="Delete Cookie" onclick="Button3_Click" />
        &nbsp;&nbsp;
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Read Cookie" onclick="Button4_Click" />        
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    
    </ContentTemplate>    
    </asp:UpdatePanel>
    </form>
</body>
</html>
