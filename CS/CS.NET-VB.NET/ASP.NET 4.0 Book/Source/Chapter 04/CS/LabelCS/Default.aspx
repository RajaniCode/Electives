<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Label Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" 
			Text="Example showing some of the properties of the Label Control" 
			Font-Bold="True" Font-Underline="True"></asp:Label>
			<br />
			<br />
			<asp:Label ID="Label3" runat="server"></asp:Label>
			<br />
			<br />
			<asp:Label ID="Label4" runat="server"></asp:Label>
			<br />
    </div>
    </form>
</body>
</html>
