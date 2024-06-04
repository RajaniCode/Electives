<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm.aspx.cs" Inherits="ObjectSerializationXMLCS.MyWebForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
				ASP.NET 4.0 Black Book
			</h1>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Font-
 		Underline="True" Text="Object Serialization with XML"></asp:Label>
		<br />
		<br />
		<asp:ListBox ID="ListBox1" runat="server" Height="105px" Width="302px">
		</asp:ListBox>
		<br />
		<br />
		<asp:Button ID="Button2" runat="server" Text="Serialize Data" Font-Bold="True" Height="26px" 
 		Width="136px" onclick="Button2_Click1" />
		&nbsp;
		<asp:Button ID="Button1" runat="server" Text="View XML File" Font-Bold="True" 
 		Height="26px" Width="136px" onclick="Button1_Click1" />
		<br />
		<br />
		<br />
		<br />
        <p class="left">
			All content copyright &copy; Kogent Solutions Inc.</p>
    </div>
    </form>
</body>
</html>
