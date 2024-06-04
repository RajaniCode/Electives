<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OutPut Cache Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" Style="z-index: 101; left: 232px; position: absolute; top: 
 		  95px"
		runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" 
 		  Height="15px"
		Width="284px">Output Cache example</asp:Label>
		<asp:Label ID="Label2" Style="z-index: 102; left: 358px; position: absolute; top: 
 		  153px;
		width: 160px;" runat="server">Label</asp:Label>
		<asp:Label ID="Label3" Style="z-index: 103; left: 231px; position: absolute; top: 
 		  263px"
		runat="server" Font-Bold="True" Font-Names="Tahoma" Width="440px">The above 
 		  displayed time was cached for 10 seconds. Keep Refereshing the page to see the 
 		  changes.</asp:Label>

    </div>
    </form>
</body>
</html>
