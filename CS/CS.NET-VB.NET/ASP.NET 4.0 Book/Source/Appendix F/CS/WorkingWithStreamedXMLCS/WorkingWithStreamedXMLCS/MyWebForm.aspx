<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWebForm.aspx.cs" Inherits="WorkingWithStreamedXMLCS.MyWebForm" %>

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
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
			Font-Underline="True" Text="Working with Streamed XML"></asp:Label>
  			<br />
			<br />
    		</div>
			<asp:ListBox ID="ListBox1" runat="server" Height="318px" Width="557px">
			</asp:ListBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
 			Text="Show All Elements" 
			Font-Bold="True" />
			&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
 			Text="Show Last Names" 
			Font-Bold="True" />
			&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
 			Text="Show All Attributes" 
			Font-Bold="True" />
			<br />
			<br />
			<br />
			<br />
			<div id="footer">
				<p class="left">
				All content copyright &copy; Kogent Solutions Inc.</p>   
    </div>
    </form>
</body>
</html>
