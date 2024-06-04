<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form12" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:TextBox ID="txtOne" runat="server"></asp:TextBox><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="text 1 is required" ControlToValidate="txtOne"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="txtTwo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtTwo" Display="Dynamic" 
            ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:TextBox ID="txtThree" runat="server" Enabled="true"></asp:TextBox>
        <br />
    </asp:Panel>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>short</asp:ListItem>
        <asp:ListItem>longer</asp:ListItem>
        <asp:ListItem Value="1">this is some really long text!!!!</asp:ListItem>
        <asp:ListItem Value="2">hopefull this gets seen too!!!</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
