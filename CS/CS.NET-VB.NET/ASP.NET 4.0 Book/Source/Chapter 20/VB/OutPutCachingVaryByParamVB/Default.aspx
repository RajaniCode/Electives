<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ OutputCache Duration="30" VaryByParam="Name" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OutputCachingVaryByParam Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
		<br />
		<asp:Label ID="Label1" Style="z-index: 101; left: 295px; position: absolute; top: 
 		  193px"
		runat="server" Font-Names="Verdana">Please Enter your Name:</asp:Label>
		<asp:Label ID="Label2" Style="z-index: 102; left: 208px; position: absolute; top: 
 		  427px"
		runat="server"></asp:Label>
		<asp:TextBox ID="Name" Style="z-index: 103; left: 538px; position: absolute; top: 
 		  189px"
		runat="server"></asp:TextBox>
		<asp:Label ID="Label3" Style="z-index: 104; left: 224px; position: absolute; top: 
 		  88px"
		runat="server" Font-Names="tahoma" Font-Bold="True">OutPut Cache VaryByParam 
 		  Example</asp:Label>
		<asp:Button ID="Button1" Style="z-index: 105; left: 449px; right: 288px; 
 		  position: absolute;
		top: 288px" runat="server" Text="Submit"></asp:Button>

    </div>
    </form>
</body>
</html>
