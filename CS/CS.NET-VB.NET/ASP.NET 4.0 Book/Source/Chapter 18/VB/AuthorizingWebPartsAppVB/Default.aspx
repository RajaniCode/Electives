<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
	Protected Sub wpm_AuthorizeWebPart(ByVal sender As Object, _
	ByVal e As WebPartAuthorizationEventArgs)
    
		If Not String.IsNullOrEmpty(e.AuthorizationFilter) Then
			If e.AuthorizationFilter = "admin" Then
				e.IsAuthorized = True
			Else
				e.IsAuthorized = False
			End If
		End If

	End Sub
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Authorizing Web Parts Example</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div>
		<div id="header">
			<h1>
				ASP.NET 3.5 Black Book
			</h1>
		</div>
		<div id="sidebar">
			<div id="nav">
				&nbsp;
			</div>
		</div>
		<div id="content">
			<div class="itemContent">
			<asp:WebPartManager ID="wpm" runat="server" 
			OnAuthorizeWebPart="wpm_AuthorizeWebPart" />
			<asp:WebPartZone ID="WebPartZone1" runat="server" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
			<ZoneTemplate>
			<asp:HyperLink ID="HyperLink1" runat="server" 
			Title="Allowed control"
			AuthorizationFilter="admin" NavigateUrl="~/Default.aspx">my link</asp:HyperLink>
			<asp:Label ID="Label1" runat="server" Text="My label" Title="Allowed control"
			AuthorizationFilter="admin" />
			<asp:TextBox ID="TextBox1" runat="server" 
			Title="restricted control:"
			AuthorizationFilter="admins" />
			</ZoneTemplate>
			<PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
			<MenuLabelHoverStyle ForeColor="#E2DED6" />
			<EmptyZoneTextStyle Font-Size="0.8em" />
			<MenuLabelStyle ForeColor="White" />
			<MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid"
			BorderWidth="1px" ForeColor="#333333" />
			<HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
			<MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
			<PartStyle Font-Size="0.8em" ForeColor="#333333" />
			<TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
			<MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
			Font-Size="0.6em" />
			<PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
			</asp:WebPartZone>
			</div></div>
            <div id="footer">
				<p class="left">
					All content copyright &copy; Kogent Solutions Inc.</p>
			</div>
		</div>

    </form>
</body>
</html>
