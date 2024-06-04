<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Print Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div><div>
        <asp:Panel ID="Panel1" runat="server" Height="161px" Width="714px">
            First Name
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;<br />
            <br />
            Last Name
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Age &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <br />
        </asp:Panel>
    </div>
        <br />
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print" />
    
    </div>
    </form>
</body>
</html>
