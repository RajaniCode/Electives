<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache CacheProfile="CacheHourly" VaryByParam="name" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CacheProfiles Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
		<br />
		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
		<asp:Label ID="Label3" runat="server" Font-Names="Verdana" Text="Cache Profiles Example"
		Font-Bold="True" Font-Size="Larger"></asp:Label>
		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
		<br />
		<br />
		<br />
		<asp:Label ID="Label1" runat="server" Font-Names="Verdana" Text="Please Enter a 
 		  Name"></asp:Label>
		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
		<asp:TextBox ID="Name" runat="server"></asp:TextBox>
		&nbsp;<br />
		<br />
		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
		&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
		<asp:Button ID="Button1" runat="server" Text="Submit" /><br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Names="Verdana" 
 		  Text="Label2"></asp:Label>


    </div>
    </form>
</body>
</html>
