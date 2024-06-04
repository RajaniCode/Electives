<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010ValidationGroup.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1"   
            ValidationGroup="ValidationGroup1"       
            ControlToValidate="TextBox1"          
            ErrorMessage="Required field 1!" />
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" 
            ValidationGroup="ValidationGroup2"
            ControlToValidate="TextBox2"
            ErrorMessage="Required field 2!"/>
        <br />
        <asp:Button ID="Button1" runat="server"  Text="Button" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" 
            ValidationGroup="ValidationGroup3"
            ControlToValidate="TextBox3"
            ErrorMessage="Required field 3!"/>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"/>
    </div>
    </form>
</body>
</html>
