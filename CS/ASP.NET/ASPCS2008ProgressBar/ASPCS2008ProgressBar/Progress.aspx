<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="Progress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server"><base target="_self" />
    <title>Progress</title>
    <style type="text/css">
        #Form1
        {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
            <asp:Label id="lblMessages" runat="server"></asp:Label>
            <asp:Panel id="panelBarSide" runat="server" Width="300px" BorderStyle="Solid" BorderWidth="1px"
                ForeColor="Silver">
                <asp:Panel id="panelProgress" runat="server" Width="100px" BackColor="Green"></asp:Panel>
            </asp:Panel>
            <asp:Label id="lblPercent" runat="server" ForeColor="Blue"></asp:Label>
        </form>

</body>
</html>

