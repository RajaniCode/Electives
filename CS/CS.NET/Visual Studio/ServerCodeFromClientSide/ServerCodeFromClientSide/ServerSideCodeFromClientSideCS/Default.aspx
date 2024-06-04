<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server Side From Client Side</title>   
</head>
<body>
<script type="text/javascript" language="javascript" src="script.js"> </script>
    <form id="form1" runat="server">     
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"/>
        <div>
        <asp:Label ID="lblCustId1" runat="server" Text="Customer ID 1"></asp:Label>
        <asp:TextBox ID="txtId1" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtContact1" runat="server" BorderColor="Transparent" BorderStyle="None"
                ReadOnly="True"></asp:TextBox><br />
        <br />
        <asp:Label ID="lblCustId2" runat="server" Text="Customer ID 2"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtId2" runat="server"></asp:TextBox><br />
            <asp:TextBox ID="txtContact2" runat="server" BorderColor="Transparent" BorderStyle="None"
                ReadOnly="True"></asp:TextBox>&nbsp;<br />
            </div>
    </form>
</body>
</html>
