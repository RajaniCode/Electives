<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload Control Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-
 				  Underline="True" 
				Text="FileUpload Control Example"></asp:Label>
				<br />
				<br />
				<br />
				&nbsp;<asp:Label ID="Label1" runat="server" Text="Please select a 
 				  file to Upload:"></asp:Label>
				<asp:FileUpload ID="FileUpload1" runat="server" />
				<br />
				<br />
				&nbsp;<br />
				<asp:Button ID="Button1" runat="server" Font-Bold="True" Font-
 				  Underline="False" 
				Text="Click to Upload" Height="26px" onclick="Button1_Click" 
				Width="144px" />
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Label ID="Label3" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
